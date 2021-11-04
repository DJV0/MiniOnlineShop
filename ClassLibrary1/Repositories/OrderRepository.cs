using AutoMapper;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(OnlineStoreDbContext context, IMapper mapper) : base(mapper)
        {
            Entities = context.Orders;
        }

        public IEnumerable<Order> GetAccountOrders(Guid accountId)
        {
            return Entities.Where(o => o.Account.Id == accountId);
        }
    }
}
