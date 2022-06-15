using AutoMapper;
using CoreLayer.DTOs;
using CoreLayer.Models;

namespace ServiceLayer.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Product, ProductWithCustomerDto>();
            CreateMap<Customer, CustomerWithProductsDto>();
        }
    }
}
