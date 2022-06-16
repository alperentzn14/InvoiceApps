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
            CreateMap<Invoice, InvoiceDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<InvoiceUpdateDto, Invoice>();
            CreateMap<Product, ProductWithCustomerDto>();
            CreateMap<Invoice, InvoiceDetailDto>();
            CreateMap<Customer, CustomerWithProductsDto>();
        }
    }
}
