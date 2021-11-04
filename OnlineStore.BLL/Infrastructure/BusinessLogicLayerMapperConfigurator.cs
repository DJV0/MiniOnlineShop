using AutoMapper;
using OnlineStore.BLL.Dto;
using OnlineStore.BLL.Roles;
using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Infrastructure
{
    public class BusinessLogicLayerMapperConfigurator : Profile
    {
        public BusinessLogicLayerMapperConfigurator(IMapperConfigurationExpression configExpression)
        {
            configExpression.CreateMap<Product, ProductDto>().ReverseMap();
            configExpression.CreateMap<Account, AccountDto>().ReverseMap();
            configExpression.CreateMap<Account, RegisteredUser>()
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            configExpression.CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
