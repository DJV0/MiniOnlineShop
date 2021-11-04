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
    public class Guest : User, IGuestRole
    {
        private readonly IAccountService _accountService;
        private readonly IOrderService _orderService;
        public Guest(IProductService productService, IAccountService accountService,
            IOrderService orderService, IMapper mapper) : 
            base(productService, mapper)
        {
            _accountService = accountService;
            _orderService = orderService;
        }

        public bool RegistrateUser(AccountDto accountDto)
        {
            var accont = _mapper.Map<Account>(accountDto);
            return _accountService.RegistrateUser(accont);
            
        }

        public bool SignIn(string login, string password, Action<User> setUser)
        {
            var account = _accountService.Get(a => a.Login == login);
            if (account == null || account.Password != password) return false;
            RegisteredUser registeredUser;
            if (account.Role == Role.Admin) registeredUser = new Admin(_productService, _accountService, _orderService, _mapper);
            else registeredUser = new RegisteredUser(_productService, _accountService, _orderService, _mapper);
            setUser(_mapper.Map(account, registeredUser));
            return true;
        }
    }
}
