using AutoMapper;
using CoreLayer.DTOs;
using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;

namespace ServiceLayer.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomResponseDto<CustomerWithProductsDto>> GetSingleCustomerByIdWithProductsAsync(int customerId)
        {
            var customer = await _customerRepository.GetSingleCustomerByIdWithProductsAsync(customerId);

            var customerDto = _mapper.Map<CustomerWithProductsDto>(customer);

            return CustomResponseDto<CustomerWithProductsDto>.Success(200, customerDto);
        }
    }
}
