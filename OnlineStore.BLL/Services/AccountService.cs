using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Services
{
    public class AccountService : GenericService<Account>, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork) : base(unitOfWork.AccountRepository) { }

        public bool RegistrateUser(Account account)
        {
            if (repository.Find(a => a.Login == account.Login) != null) return false;
            base.Add(account);
            return true;
        }
    }
}
