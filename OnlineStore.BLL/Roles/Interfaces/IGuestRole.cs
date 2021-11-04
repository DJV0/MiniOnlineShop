using OnlineStore.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Roles.Interfaces
{
    public interface IGuestRole : IRole
    {
        bool RegistrateUser(AccountDto accountDto);
        bool SignIn(string login, string password, Action<User> setUser);
        
    }
}
