using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Services.Interfaces
{
    public interface IAccountService : IGenericService<Account>
    {
        bool RegistrateUser(Account account);
    }
}
