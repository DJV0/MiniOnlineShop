using AutoMapper;
using OnlineStore.BLL.Dto;
using OnlineStore.BLL.Roles.Interfaces;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Roles
{
    public class Admin : RegisteredUser, IAdminRole
    {
        public Admin(IProductService productService, IAccountService accountService,
            IOrderService orderService, IMapper mapper) :
            base(productService, accountService, orderService, mapper)
        { }

        public void AddProduct(ProductDto product)
        {
            var newProduct = _mapper.Map<Product>(product);
            _productService.Add(newProduct);
        }

        public IEnumerable<AccountDto> GetAccounts()
        {
            return _mapper.Map<IEnumerable<AccountDto>>(_accountService.GetAll());
        }

        public bool UpdateAccount(AccountDto account)
        {
            var editedAccount = _mapper.Map<Account>(account);
            return _accountService.Update(editedAccount);
        }

        public bool UpdateProduct(ProductDto product)
        {
            var editedProduct = _mapper.Map<Product>(product);
            return _productService.Update(editedProduct);
        }
        public override bool ChangeOrderStatus(Guid orderId, Dto.OrderStatus status)
        {
            return _orderService.ChangeOrderStatus(orderId, 
                (DAL.Entities.OrderStatus)Enum.Parse(typeof(Dto.OrderStatus), status.ToString()));
        }
    }
}
