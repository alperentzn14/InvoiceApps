using CoreLayer.DTOs;

namespace WEB.Services
{
    public class InvoiceApiService
    {
        private readonly HttpClient _httpClient;

        public InvoiceApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<InvoiceDetailDto>> GetInvoiceDetailAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<InvoiceDetailDto>>>("invoices/GetInvoiceDetail");

            return response.Data;
        }

        public async Task<InvoiceDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<InvoiceDto>>($"invoices/{id}");
            return response.Data;


        }

        public async Task<InvoiceDto> SaveAsync(InvoiceDto newInvoice)
        {
            var response = await _httpClient.PostAsJsonAsync("invoices", newInvoice);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<InvoiceDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(InvoiceDto newInvoice)
        {
            var response = await _httpClient.PutAsJsonAsync("invoices", newInvoice);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"invoices/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
