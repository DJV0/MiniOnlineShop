using AutoMapper;
using OnlineStore.DAL.Interfaces;
using OnlineStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineStoreDbContext _context;
        private readonly IMapper _mapper;
        private IProductRepository _productRepository;
        private IAccountRepository _accountRepository;
        private IOrderRepository _orderRepository;

        public UnitOfWork(OnlineStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null) _productRepository = new ProductRepository(_context, _mapper);
                return _productRepository;
            }
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null) _accountRepository = new AccountRepository(_context, _mapper);
                return _accountRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null) _orderRepository = new OrderRepository(_context, _mapper);
                return _orderRepository;
            }
        }
    }
}
