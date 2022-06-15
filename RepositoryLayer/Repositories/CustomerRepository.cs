using CoreLayer.Models;
using CoreLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer.Repositories
{
    public class CustomerRepository : GenericRepository<Customer> , ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetSingleCustomerByIdWithProductsAsync(int customerId)
        {
            return await _context.Customers.Include(x => x.Products).Where(x => x.Id == customerId).SingleOrDefaultAsync();
        }
    }
}
