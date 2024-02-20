using CustomerApp.Interfaces;
using CustomerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;



namespace CustomerApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IApiService _apiService;

        public CustomerController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            List<CustomerViewModel> customerList = new List<CustomerViewModel>();

            try
            {
                customerList = (List<CustomerViewModel>)await _apiService.GetCustomersAsync();
            }
            catch (HttpRequestException)
            {

                ModelState.AddModelError(string.Empty, "Error retrieving customer");
            }
            return View(customerList);
        }

        public IActionResult Create()
        {
            return View(new CustomerViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                await _apiService.CreateCustomerAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _apiService.GetCustomerAsync(id);
            return View(customer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _apiService.GetCustomerAsync(id);
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomerViewModel customer)
        {
            if (ModelState.IsValid) 
            { 
                await _apiService.UpdateCustomerAsync(id, customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _apiService.DeleteCustomerAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetPremiumCustomers(int id)
        {
            var customer = await _apiService.GetPremiumCustomersAsync(id);
            return View(customer);
        }




    }



}
