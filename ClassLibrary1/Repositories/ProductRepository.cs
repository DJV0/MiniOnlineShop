using AutoMapper;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Interfaces;

namespace OnlineStore.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(OnlineStoreDbContext context,IMapper mapper) : base(mapper)
        {
            Entities = context.Products;
        }
    }
}
