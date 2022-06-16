using CoreLayer.DTOs;
using CoreLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB.Services;

namespace WEB.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly InvoiceApiService _ınvoiceApiService;
        private readonly CustomerApiService _customerApiService;
        private readonly ProductApiService _productApiService;

        public InvoicesController(ProductApiService productApiService, CustomerApiService customerApiService,InvoiceApiService ınvoiceApiService)
        {
            _productApiService = productApiService;
            _customerApiService = customerApiService;
            _ınvoiceApiService = ınvoiceApiService;

        }

        public async Task<IActionResult> Index()
        {

            return View(await _ınvoiceApiService.GetInvoiceDetailAsync());
        }

        public async Task<IActionResult> Save()
        {
            var customersDto = await _customerApiService.GetAllAsync();

            var productsDto = await _productApiService.GetAllAsync();

            ViewBag.products = new SelectList(productsDto, "Id", "Name");

            ViewBag.customers = new SelectList(customersDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(InvoiceDto invoiceDto)

        {

            if (ModelState.IsValid)
            {

                await _ınvoiceApiService.SaveAsync(invoiceDto);


                return RedirectToAction(nameof(Index));
            }

            var customersDto = await _customerApiService.GetAllAsync();

            var productsDto = await _productApiService.GetAllAsync();

            ViewBag.products = new SelectList(productsDto, "Id", "Name");

            ViewBag.customers = new SelectList(customersDto, "Id", "Name");

            return View();
        }


        [ServiceFilter(typeof(NotFoundFilter<Invoice>))]
        public async Task<IActionResult> Update(int id)
        {
            var invoice = await _ınvoiceApiService.GetByIdAsync(id);

            var customersDto = await _customerApiService.GetAllAsync();

            var productsDto = await _productApiService.GetAllAsync();

            ViewBag.products = new SelectList(productsDto, "Id", "Name", invoice.ProductId);

            ViewBag.customers = new SelectList(customersDto, "Id", "Name", invoice.CustomerId);

            return View(invoice);

        }
        [HttpPost]
        public async Task<IActionResult> Update(InvoiceDto invoiceDto)
        {
            if (ModelState.IsValid)
            {

                await _ınvoiceApiService.UpdateAsync(invoiceDto);

                return RedirectToAction(nameof(Index));

            }

            var customersDto = await _customerApiService.GetAllAsync();

            var productsDto = await _productApiService.GetAllAsync();


            ViewBag.customers = new SelectList(customersDto, "Id", "Name", invoiceDto.CustomerId);
            ViewBag.products = new SelectList(productsDto, "Id", "Name", invoiceDto.ProductId);

            return View(invoiceDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _ınvoiceApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
