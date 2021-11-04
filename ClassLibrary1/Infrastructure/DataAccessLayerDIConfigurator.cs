using Microsoft.Extensions.DependencyInjection;
using OnlineStore.DAL.Interfaces;
using OnlineStore.DAL.Repositories;
using OnlineStore.DAL.UoW;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.Infrastructure
{
    public class DataAccessLayerDIConfigurator 
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<OnlineStoreDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperConfigurator(config));
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());
        }
    }
}
