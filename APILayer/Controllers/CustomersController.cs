using APILayer.Filters;
using AutoMapper;
using CoreLayer.DTOs;
using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    public class CustomersController : CustomBaseController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customers = await _customerService.GetAllAsync();
            var customersDtos = _mapper.Map<List<CustomerDto>>(customers.ToList());
            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customersDtos));
        }


        [HttpGet("[action]/{customerId}")]
        public async Task<IActionResult> GetSingleCustomerByIdWithProducts(int customerId)
        {

            return CreateActionResult(await _customerService.GetSingleCustomerByIdWithProductsAsync(customerId));

        }
        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        // GET /api/customer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var customer = await _customerService.GetByIdAsync(id);
            var customersDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customersDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            var customer = await _customerService.AddAsync(_mapper.Map<Customer>(customerDto));
            var customersDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, customersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerUpdateDto customerDto)
        {
            await _customerService.UpdateAsync(_mapper.Map<Customer>(customerDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            await _customerService.RemoveAsync(customer);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
