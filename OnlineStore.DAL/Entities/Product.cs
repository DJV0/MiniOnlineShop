using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.Entities
{
    public class Product : TEntity
    {
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
    }
}
