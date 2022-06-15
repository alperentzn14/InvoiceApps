using CoreLayer.DTOs;
using CoreLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB.Services;

namespace WEB.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CustomerApiService _customerApiService;
      
      

        public ProductsController(ProductApiService productApiService, CustomerApiService customerApiService)
        {
            _productApiService = productApiService;
            _customerApiService = customerApiService;

        }


        public async Task<IActionResult> Index()
        {

            return View(await _productApiService.GetProductsWithCustomerAsync());
        }

        public async Task<IActionResult> Save()
        {
            var customersDto = await _customerApiService.GetAllAsync();



            ViewBag.customers = new SelectList(customersDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)

        {


            if (ModelState.IsValid)
            {

                await _productApiService.SaveAsync(productDto);


                return RedirectToAction(nameof(Index));
            }

            var customersDto = await _customerApiService.GetAllAsync();



            ViewBag.customers = new SelectList(customersDto, "Id", "Name");
            return View();
        }


        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);


            var customersDto = await _customerApiService.GetAllAsync();



            ViewBag.customers = new SelectList(customersDto, "Id", "Name", product.CustomerId);

            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {

                await _productApiService.UpdateAsync(productDto);

                return RedirectToAction(nameof(Index));

            }

            var customersDto = await _customerApiService.GetAllAsync();



            ViewBag.customers = new SelectList(customersDto, "Id", "Name", productDto.CustomerId);

            return View(productDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            await _productApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
