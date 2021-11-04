using OnlineStore.BLL.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Roles.Interfaces
{
    public interface IAdminRole : IRole
    {
        IEnumerable<ProductDto> GetProducts();
        void AddProduct(ProductDto product);
        bool UpdateProduct(ProductDto product);
        IEnumerable<AccountDto> GetAccounts();
        bool UpdateAccount(AccountDto account);
    }
}
