using CoreLayer.Models;


namespace CoreLayer.Repositories
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {

        Task<Customer> GetSingleCustomerByIdWithProductsAsync(int customerId);
    }
}
