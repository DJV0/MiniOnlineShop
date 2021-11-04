using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL
{
    public class OnlineStoreDbContext
    {
        public List<Product> Products { get; }
        public List<Account> Accounts { get; }
        public List<Order> Orders { get; }
        public OnlineStoreDbContext()
        {
            Products = new List<Product>()
            {
                new Product(){Name="Product1",Category=ProductCategory.Category1, Description="desc1", Cost=10},
                new Product(){Name="Product2",Category=ProductCategory.Category2, Description="desc2", Cost=20},
                new Product(){Name="Product3",Category=ProductCategory.Category3, Description="desc3", Cost=30}
            };
            Accounts = new List<Account>()
            {
                new Account(){Name="name1", LastName="lastName1", Login="login1", Password="password1", Role = Role.Client},
                new Account(){Name="name2", LastName="lastName2", Login="admin", Password="admin", Role = Role.Admin}
            };

            Orders = new List<Order>();
        }
    }
}
