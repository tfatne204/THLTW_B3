using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using FatsitBikerMVC.Models;

namespace FatsitBikerMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryManagerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryManagerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.Include(c => c.Products).ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Category model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var category = _context.Categories.FirstOrDefault(c => c.Id == id);
                if (category == null)
                {
                    return NotFound();
                }

                category.Name = model.Name;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                if (category.Products != null && category.Products.Any())
                {
                    TempData["ErrorMessage"] = "Không thể xóa danh mục này vì vẫn còn sản phẩm thuộc danh mục.";
                    return RedirectToAction(nameof(Delete), new { id = id });
                }

                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
