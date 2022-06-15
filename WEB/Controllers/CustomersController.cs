using CoreLayer.DTOs;
using CoreLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WEB.Services;

namespace WEB.Controllers
{
    public class CustomersController : Controller
    {
        //private readonly ProductApiService _productApiService;
        private readonly CustomerApiService _customerApiService;

        public CustomersController(CustomerApiService customerApiService)
        {
            //_productApiService = productApiService;
            _customerApiService = customerApiService;

        }

        public async Task<IActionResult> Index()
        {

            return View(await _customerApiService.GetAllAsync());
        }

        public async Task<IActionResult> Save()
        {
            //var customersDto = await _customerApiService.GetAllAsync();

            //ViewBag.customers = new SelectList(customersDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customerDto)

        {

            if (ModelState.IsValid)
            {

                await _customerApiService.SaveAsync(customerDto);


                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        public async Task<IActionResult> Update(int id)
        {
            var customer = await _customerApiService.GetByIdAsync(id);


            //var customersDto = await _customerApiService.GetAllAsync();

            //ViewBag.customers = new SelectList(customersDto, "Id", "Name", product.CustomerId);

            return View(customer);

        }
        [HttpPost]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            if (ModelState.IsValid)
            {

                await _customerApiService.UpdateAsync(customerDto);

                return RedirectToAction(nameof(Index));

            }

            var customersDto = await _customerApiService.GetAllAsync();

            //ViewBag.customers = new SelectList(customersDto, "Id", "Name", productDto.CustomerId);

            return View(customerDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            await _customerApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
