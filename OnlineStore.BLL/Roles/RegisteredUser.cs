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
    public class RegisteredUser : User, IRegisteredUserRole
    {
        protected readonly IAccountService _accountService;
        protected readonly IOrderService _orderService;
        private enum OrderStatusForUser
        {
            Received,
            Canceled_by_user
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Guid AccountId { get; set; }
        public string Login { get; set; }
        public RegisteredUser(IProductService productService, IAccountService accountService, 
            IOrderService orderService, IMapper mapper) : 
            base(productService, mapper)
        {
            _accountService = accountService;
            _orderService = orderService;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(_productService.GetAll());
        }

        public void SignOut(Action<User> setUser)
        {
            setUser(new Guest(_productService, _accountService, _orderService, _mapper));
        }

        public virtual bool UpdatePersonalInfo(AccountDto accountDto)
        {
            var editedAccount = _mapper.Map<Account>(accountDto);
            editedAccount.Id = this.AccountId;
            return _accountService.Update(editedAccount);
        }

        public void CreateOrder(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.DateTime = DateTime.Now;
            order.Account = _accountService.Get(a => a.Id == orderDto.User.AccountId);
            _orderService.Add(order);
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            return _mapper.Map<IEnumerable<OrderDto>>(_orderService.GetUserOrders(this.AccountId));
        }

        public virtual bool ChangeOrderStatus(Guid orderId, Dto.OrderStatus status)
        {
            if(Enum.IsDefined(typeof(OrderStatusForUser), status)) 
                return _orderService.ChangeOrderStatus(orderId, 
                    (DAL.Entities.OrderStatus)Enum.Parse(typeof(Dto.OrderStatus), status.ToString()));
            return false;
        }
    }
}
