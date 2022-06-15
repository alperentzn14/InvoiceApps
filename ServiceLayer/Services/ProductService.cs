using AutoMapper;
using CoreLayer.DTOs;
using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;

namespace ServiceLayer.Services
{
    public class ProductService:Service<Product>,IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCustomerDto>>> GetProductsWithCustomer()
        {
            var products = await _productRepository.GetProductsWithCustomer();

            var productsDto = _mapper.Map<List<ProductWithCustomerDto>>(products);
            return CustomResponseDto<List<ProductWithCustomerDto>>.Success(200, productsDto);

        }
    }
}
