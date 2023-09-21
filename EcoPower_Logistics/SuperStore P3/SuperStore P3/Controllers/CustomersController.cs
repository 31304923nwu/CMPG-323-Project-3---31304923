using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(SuperStoreContext context, ICustomerRepository customerRepository)
        {
           
            _customerRepository = customerRepository;
        }

        // GET: Customers
        public IActionResult Index()
        {
            var customers = _customerRepository.GetAllCustomers().ToList();
            return View(customers);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id, ICustomerRepository _customerRepository)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetCustomerById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.CreateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers delete implementation
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetCustomerById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // Customers delete implementation
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _customerRepository.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }

        // Edit method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetCustomerById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // Customer edit method 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _customerRepository.UpdateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public bool CustomerExists(int id)
        {   
            return _customerRepository.CustomerExists(id);    
        }
    }
}
