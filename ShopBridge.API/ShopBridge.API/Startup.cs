using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ShopBridge.IOC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ShopBridge.DTOs;
using Microsoft.OpenApi.Models;
using Serilog;

namespace ShopBridge.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureIoCForApi();
            services.ConfigureDatabase(Configuration);


            services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));
            JwtConfigureAuthentication(services);

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Description = "Specify the authorization token.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = JwtBearerDefaults.AuthenticationScheme
                                }
                            },
                            new string[] {}
                        }
                });

            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureSwagger(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging();
            app.UseMiddleware(typeof(GlobalErrorHandler));
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void JwtConfigureAuthentication(IServiceCollection services)
        {
            var key = Encoding.UTF8.GetBytes(Configuration["TokenSettings:Secret"]);

            var tokenValidationParameter = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
            };

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(item =>
            {
                item.RequireHttpsMetadata = false;
                item.SaveToken = false;
                item.TokenValidationParameters = tokenValidationParameter;
            });
        }

        public void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopBridge v1");
            });
        }
    }
}
