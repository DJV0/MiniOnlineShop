using OnlineStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.UoW
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IAccountRepository AccountRepository { get; }
        IOrderRepository OrderRepository { get; }
    }
}
