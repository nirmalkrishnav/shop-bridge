using System;
using Microsoft.Extensions.DependencyInjection;
using ShopBridge.Services;
using ShopBridge.Interfaces.Service;
using ShopBridge.Interfaces.Repository;
using EY.EOS.Infrastructure.DataAccess;

namespace ShopBridge.IOC
{
    public static class ContainerConfig
    {

        public static IServiceCollection ConfigureIoCForApi(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IInventoryService, InventoryService>();
            return services;

        }
    }
}
