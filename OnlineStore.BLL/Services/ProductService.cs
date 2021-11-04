using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Services
{
    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork.ProductRepository) { }
        public override bool Update(Product entity)
        {
            var product = repository.Find(p => p.Name == entity.Name);
            if (product == null) return false;
            entity.Id = product.Id;
            return base.Update(entity);
        }
    }
}
