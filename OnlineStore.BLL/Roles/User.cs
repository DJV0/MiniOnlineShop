using AutoMapper;
using OnlineStore.BLL.Dto;
using OnlineStore.BLL.Roles.Interfaces;
using OnlineStore.BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Roles
{
    public abstract class User : IRole
    {
        protected readonly IProductService _productService;
        protected readonly IMapper _mapper;

        protected User(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public ProductDto GetProduct(string name)
        {
            var product = _productService.Get(product => product.Name == name);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
