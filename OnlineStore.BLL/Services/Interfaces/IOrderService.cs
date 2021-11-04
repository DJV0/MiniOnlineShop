using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IOrderService : IGenericService<Order>
    {
        IEnumerable<Order> GetUserOrders(Guid accountId);
        bool ChangeOrderStatus(Guid orderId, OrderStatus status);
    }
}
