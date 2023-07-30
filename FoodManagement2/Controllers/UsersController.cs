using FoodManagement2.DB;
using FoodManagement2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodManagement2.Controllers
{
    public class UsersController : Controller
    {

        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            string userName = HttpContext.Session.GetString("UserName");
            if (userName is not null)
            {
                var reslt = _context.Users.ToList();
                return View(reslt);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        //GET:Food/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(User user)
        {
            _context.Add(user);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET:Food/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var result = await _context.Users
                .FirstOrDefaultAsync(m => m.U_ID == id);
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
            if (_context.Users == null)
            {
                return Problem("Entity set 'DataContext.Users'  is null.");
            }
            var result = await _context.Users.FindAsync(id);
            if (result != null)
            {
                _context.Users.Remove(result);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET:Food/Login
        public async Task<ActionResult> Login(User usr)
        {
            var exist = await _context.Users
                .Where(x => x.U_NAME == usr.U_NAME && x.U_PASSWORD == usr.U_PASSWORD)
                .FirstOrDefaultAsync();

            if (exist != null)
            {
                HttpContext.Session.SetString("UserName", exist.U_NAME);
                return RedirectToAction("Index");
            }
            ViewBag.error = "User Not Found In Database";
            return View();
        }

        //GET:Food/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }
            var data = await _context.Users.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "Users");

        }

        //GET:Food/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }
            var result = await _context.Users
                .FirstOrDefaultAsync(m => m.U_ID == id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
