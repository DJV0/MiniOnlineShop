using OnlineStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        public override string ToString()
        {
            return $"Название: {Name}, Категория: {Category}, Описание: {Description}, Цена: {Cost}";
        }
    }
}
