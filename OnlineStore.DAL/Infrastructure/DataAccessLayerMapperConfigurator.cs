using AutoMapper;
using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.Infrastructure
{
    public class DataAccessLayerMapperConfigurator : Profile
    {
        public DataAccessLayerMapperConfigurator(IMapperConfigurationExpression configExpression)
        {
            configExpression.CreateMap<Product, Product>();
            configExpression.CreateMap<Account, Account>();
            configExpression.CreateMap<Order, Order>();
        }
    }
}
