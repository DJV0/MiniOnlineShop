using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.BLL.Services;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Infrastructure
{
    public static class BusinessLogicLayerDIConfigurator
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            DataAccessLayerDIConfigurator.ConfigureServices(services);

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IOrderService, OrderService>();

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new DataAccessLayerMapperConfigurator(config));
                config.AddProfile(new BusinessLogicLayerMapperConfigurator(config));
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());
        }
    }
}
