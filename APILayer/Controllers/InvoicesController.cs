using APILayer.Filters;
using AutoMapper;
using CoreLayer.DTOs;
using CoreLayer.Models;
using CoreLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    public class InvoicesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(IMapper mapper, IInvoiceService invoiceService)
        {

            _mapper = mapper;
            _invoiceService = invoiceService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetInvoiceDetail()
        {
            
            return CreateActionResult(await _invoiceService.GetInvoiceDetail());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var invoices = await _invoiceService.GetAllAsync();
            var invoicesDtos = _mapper.Map<List<InvoiceDto>>(invoices.ToList());
            return CreateActionResult(CustomResponseDto<List<InvoiceDto>>.Success(200, invoicesDtos));
        }


        [ServiceFilter(typeof(NotFoundFilter<Invoice>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {


            var invoice = await _invoiceService.GetByIdAsync(id);
            var invoicesDto = _mapper.Map<InvoiceDto>(invoice);
            return CreateActionResult(CustomResponseDto<InvoiceDto>.Success(200, invoicesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(InvoiceDto invoiceDto)
        {
            var invoice = await _invoiceService.AddAsync(_mapper.Map<Invoice>(invoiceDto));
            var invoicesDto = _mapper.Map<InvoiceDto>(invoice);
            return CreateActionResult(CustomResponseDto<InvoiceDto>.Success(201, invoicesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(InvoiceUpdateDto invoiceDto)
        {
            await _invoiceService.UpdateAsync(_mapper.Map<Invoice>(invoiceDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var ınvoice = await _invoiceService.GetByIdAsync(id);

            await _invoiceService.RemoveAsync(ınvoice);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
