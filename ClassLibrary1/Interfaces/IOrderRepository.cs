using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetAccountOrders(Guid accountId);
    }
}
