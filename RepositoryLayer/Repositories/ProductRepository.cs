using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Repositories
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCustomer()
        {

            return await _context.Products.Include(x => x.Customer).ToListAsync();
        }
    }
}
