using FoodManagement2.DB;
using FoodManagement2.Models;
using FoodManagement2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace FoodManagement2.Controllers
{
    public class OrdersController : Controller
    {
        private readonly DataContext _context;
        public OrdersController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            try
            {
                var data = (from order in _context.Orders
                            join customer in _context.Customers on order.C_ID equals customer.C_ID
                            join food in _context.Foods on order.F_ID equals food.F_ID
                            select new CustomerOrderVM
                            {
                                O_ID = order.O_ID,
                                ORDER_QTY = order.ORDER_QTY,
                                PRICE = order.PRICE,
                                STATUS = order.STATUS,
                                F_ID = food.F_ID,
                                NAME = food.NAME,
                                QTY = food.QTY,
                                IMAGE = food.IMAGE,
                                C_ID = customer.C_ID,
                                C_NAME = customer.C_NAME,
                                MOBILE = customer.MOBILE

                            }).ToList();
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
          
           
        }

        //GET:Food/Create
        public async Task<IActionResult> Create()
        {
            TakeData();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Order order)
        {
            _context.Add(order);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET:Food/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var result = await _context.Orders
                .FirstOrDefaultAsync(m => m.O_ID == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'DataContext.Orders'  is null.");
            }
            var result = await _context.Orders.FindAsync(id);
            if (result != null)
            {
                _context.Orders.Remove(result);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET:Food/Edit
        public  IActionResult Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }
            var data = _context.Orders.Where(x=>x.O_ID == id).FirstOrDefault();


            if (data == null)
            {
                return NotFound();
            }
            TakeData();
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            _context.Update(order);
            _context.SaveChanges();
            return RedirectToAction("Index", "Orders");

        }

        //GET:Food/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }
            var result = await _context.Orders
                .FirstOrDefaultAsync(m => m.O_ID == id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        public void TakeData()
        {
            var customer = _context.Customers.FromSqlRaw("Select * From Customers")
                .Select(x => new Customer
                {
                    C_ID = x.C_ID,
                    C_NAME = x.C_NAME,
                    MOBILE = x.MOBILE
                }).ToList();
            ViewBag.custom = customer;


            var food = _context.Foods.FromSqlRaw("Select * From Foods")
               .Select(x => new Food
               {
                   F_ID = x.F_ID,
                   NAME = x.NAME,
                   QTY = x.QTY,
                   IMAGE = x.IMAGE
               }).ToList();
            ViewBag.fod = food;
        }

      
    }
}
