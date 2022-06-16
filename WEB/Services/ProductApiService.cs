﻿using CoreLayer.DTOs;

namespace WEB.Services
{

    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductWithCustomerDto>> GetProductsWithCustomerAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCustomerDto>>>("products/GetProductsWithCustomer");

            return response.Data;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductDto>>>("products");
            return response.Data;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");
            return response.Data;


        }

        public async Task<ProductDto> SaveAsync(ProductDto newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("products", newProduct);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(ProductDto newProduct)
        {
            var response = await _httpClient.PutAsJsonAsync("products", newProduct);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");

            return response.IsSuccessStatusCode;
        }





    }
}
