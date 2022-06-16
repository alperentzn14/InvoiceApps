using AutoMapper;
using CoreLayer.DTOs;
using CoreLayer.Models;
using CoreLayer.Repositories;
using CoreLayer.Services;
using CoreLayer.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class InvoiceService: Service<Invoice>, IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IGenericRepository<Invoice> repository, IUnitOfWork unitOfWork, IMapper mapper, IInvoiceRepository invoiceRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<CustomResponseDto<List<InvoiceDetailDto>>> GetInvoiceDetail()
        {
            var invoices = await _invoiceRepository.GetInvoiceDetail();

            var invoicesDto = _mapper.Map<List<InvoiceDetailDto>>(invoices);
            return CustomResponseDto<List<InvoiceDetailDto>>.Success(200, invoicesDto);

        }
    }
}

