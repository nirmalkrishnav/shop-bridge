using System;
using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Services;
using ShopBridge.Interfaces.Service;
using ShopBridge.Interfaces.Repository;
using EY.EOS.Infrastructure.DataAccess;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopBridge.Entities;
using ShopBridge.Service;

namespace ShopBridge.IOC
{
    public static class ContainerConfig
    {

        public static IServiceCollection ConfigureIoCForApi(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthService, AuthService>();

            return services;

        }

        private const string assemblyName = "ShopBridge.Infrastructure.DataAccess";
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connStrKey = configuration.GetConnectionString("DbConnection");
            
            services.AddIdentity<AppUser, AppRole>(o =>
            {
                o.Password.RequiredLength = 8;
                o.Password.RequireUppercase = true;
                o.Password.RequireLowercase = true;
                o.Password.RequireNonAlphanumeric = true;
                o.Password.RequireDigit = true;
                o.Password.RequiredUniqueChars = 1;// ?

                o.Lockout.AllowedForNewUsers = true;
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                o.Lockout.MaxFailedAccessAttempts = 5;
            })
            .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connStrKey, x =>
                {
                    x.MigrationsAssembly(assemblyName);
                });
            });

            return services;
        }
    }
}
