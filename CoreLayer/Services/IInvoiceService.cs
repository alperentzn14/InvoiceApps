using CoreLayer.DTOs;
using CoreLayer.Models;

namespace CoreLayer.Services
{
    public interface IInvoiceService : IService<Invoice>
    {
        Task<CustomResponseDto<List<InvoiceDetailDto>>> GetInvoiceDetail();
    }
}
