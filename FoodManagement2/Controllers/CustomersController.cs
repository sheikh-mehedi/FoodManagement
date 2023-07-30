using FoodManagement2.DB;
using FoodManagement2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodManagement2.Controllers
{
    public class CustomersController : Controller
    {
        private readonly DataContext _context;
        public CustomersController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var reslt = _context.Customers.ToList();
            return View(reslt);
        }

        //GET:Food/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET:Food/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var result = await _context.Customers
                .FirstOrDefaultAsync(m => m.C_ID == id);
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
            if (_context.Customers == null)
            {
                return Problem("Entity set 'DataContext.Customers'  is null.");
            }
            var result = await _context.Customers.FindAsync(id);
            if (result != null)
            {
                _context.Customers.Remove(result);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET:Food/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }
            var data = await _context.Customers.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");

        }

        //GET:Food/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }
            var result = await _context.Customers
                .FirstOrDefaultAsync(m => m.C_ID == id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    }
}
