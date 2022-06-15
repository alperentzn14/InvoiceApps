using CoreLayer.DTOs;
using CoreLayer.Models;

namespace CoreLayer.Services
{
    public interface ICustomerService:IService<Customer>
    {
        public Task<CustomResponseDto<CustomerWithProductsDto>> GetSingleCustomerByIdWithProductsAsync(int customerId);
    }
}
