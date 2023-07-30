using FoodManagement2.DB;
using FoodManagement2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace FoodManagement2.Controllers
{
    public class FoodsController : Controller
    {
        private readonly DataContext _context;

        private readonly IWebHostEnvironment _hostEnvironment;
        public FoodsController(DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            string userName = HttpContext.Session.GetString("UserName");
            if (userName is not null)
            {
                var reslt = _context.Foods.ToList();
                return View(reslt);
            }
            else
            {
                return RedirectToAction("Login", "Users");
            }
        }

        //GET:Food/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Food food)
        {

            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(food.ImageFile.FileName);
            string extension = Path.GetExtension(food.ImageFile.FileName);
            food.IMAGE = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await food.ImageFile.CopyToAsync(fileStream);
            }

            _context.Add(food);
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        //GET:Food/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Foods == null)
            {
                return NotFound();
            }

            var result = await _context.Foods
                .FirstOrDefaultAsync(m => m.F_ID == id);
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
            if (_context.Foods == null)
            {
                return Problem("Entity set 'DataContext.Foods'  is null.");
            }
            var result = await _context.Foods.FindAsync(id);
            if (result != null)
            {
                _context.Foods.Remove(result);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //GET:Food/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Foods == null)
            {
                return NotFound();
            }
            var data = await _context.Foods.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Food food)
        {
            _context.Update(food);
            _context.SaveChanges();
            return RedirectToAction("Index", "Foods");

        }

        //GET:Food/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Foods == null)
            {
                return NotFound();
            }
            var result = await _context.Foods
                .FirstOrDefaultAsync(m => m.F_ID == id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        public IActionResult Card()
        { 
         var data = _context.Foods.ToList();

          return View(data);
        }

        [HttpPost]
        public JsonResult GetClassByFood(string result)
        {
            return Json(result);
        }

    }
}
