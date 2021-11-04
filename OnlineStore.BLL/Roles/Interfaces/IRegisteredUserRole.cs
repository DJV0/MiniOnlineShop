using OnlineStore.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Roles.Interfaces
{
    public interface IRegisteredUserRole : IRole
    {
        IEnumerable<ProductDto> GetProducts();
        bool UpdatePersonalInfo(AccountDto accountDto);
        void SignOut(Action<User> setUser);
        void CreateOrder(OrderDto orderDto);
        IEnumerable<OrderDto> GetOrders();
        bool ChangeOrderStatus(Guid orderId, OrderStatus status);
    }
}
