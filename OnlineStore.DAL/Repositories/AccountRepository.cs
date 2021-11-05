using AutoMapper;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(OnlineStoreDbContext context, IMapper mapper) : base(mapper)
        {
            Entities = context.Accounts;
        }
    }
}
