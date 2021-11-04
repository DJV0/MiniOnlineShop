using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineStore.BLL.Services
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork) : base(unitOfWork.OrderRepository)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ChangeOrderStatus(Guid orderId, OrderStatus status)
        {
            var order = repository.Find(o => o.Id == orderId);
            if (order == null) return false;
            order.Status = status;
            return true;
        }

        public IEnumerable<Order> GetUserOrders(Guid accountId)
        {
            return _unitOfWork.OrderRepository.GetAccountOrders(accountId);
        }
    }
}
