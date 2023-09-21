using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly SuperStoreContext _context;
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(_ordersRepository.GetAllOrders().ToList());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _ordersRepository.GetOrderById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (ModelState.IsValid)
            {
                _ordersRepository.CreateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _ordersRepository.GetOrderById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DeliveryAddress")] Order order)
        {
            if (id != order.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _ordersRepository.UpdateOrder(order);
                return RedirectToAction(nameof(Index));
            }

            ViewData["CustomerId"] = new SelectList(_ordersRepository.GetAllOrders(), "CustomerId", "CustomerId", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _ordersRepository.GetOrderById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_ordersRepository.GetAllOrders() == null)
            {
                return Problem("Entity set 'SuperStoreContext.Orders'  is null.");
            }
            _ordersRepository.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }

        public bool OrderExists(int id)
        {
            return _ordersRepository.OrderExists(id);
        }
    }
}
