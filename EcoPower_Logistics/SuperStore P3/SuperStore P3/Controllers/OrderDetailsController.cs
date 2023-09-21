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
    public class OrderDetailsController : Controller
    {
        
        private readonly IOrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsController(SuperStoreContext context, IOrderDetailsRepository orderDetailsRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
        }

        // GET: OrderDetails
        public IActionResult Index()
        {
            var orderDetails = _orderDetailsRepository.GetAllOrderDetails().ToList();
            return View(orderDetails);
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = _orderDetailsRepository.GetOrderDetailsById(id.Value);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderDetails/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailsId,OtherProperties")] OrderDetail orderDetails)
        {
            if (ModelState.IsValid)
            {
                _orderDetailsRepository.CreateOrderDetail(orderDetails);
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetails);
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = _orderDetailsRepository.GetOrderDetailsById(id.Value);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // POST: OrderDetails/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailsId,ProductId,Quantity,Discount")] OrderDetail orderDetails)
        {
            if (id != orderDetails.OrderDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _orderDetailsRepository.UpdateOrderDetails(orderDetails);
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetails);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = _orderDetailsRepository.GetOrderDetailsById(id.Value);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _orderDetailsRepository.DeleteOrderDetails(id);
            return RedirectToAction(nameof(Index));
        }

        public bool OrderDetailsExists(int id)
        {
            return _orderDetailsRepository.OrderDetailsExists(id);
        }

    }
}
