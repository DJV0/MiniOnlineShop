using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.Entities
{
    public class Order : TEntity
    {
        public DateTime DateTime { get; set; }
        public Account Account { get; set; }
        public List<Product> Products { get; set; }
        public OrderStatus Status { get; set; }
    }
}
