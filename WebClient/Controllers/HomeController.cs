using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {
        
        private CustomerRepository _customer;
        public HomeController()
        {
            _customer = new CustomerRepository();
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            string token = User.FindFirst("AccessToken").Value;
            return View(_customer.GetAllCustomer(token));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //Send Request To API
        public IActionResult Create(CustomerRepository.Customer customer)
        {  
            _customer.AddCustomer(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = _customer.GetCustomerById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(CustomerRepository.Customer customer)
        {
            _customer.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _customer.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
