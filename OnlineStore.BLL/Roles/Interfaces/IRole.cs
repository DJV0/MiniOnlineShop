using OnlineStore.BLL.Dto;
using System.Collections.Generic;

namespace OnlineStore.BLL.Roles.Interfaces
{
    public interface IRole
    {
        ProductDto GetProduct(string name);
    }
}
