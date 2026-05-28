using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FatsitBikerMVC.Models;

namespace FatsitBikerMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Product/List
        public IActionResult List(int categoryId = 0, int page = 1, string sortOrder = "", string searchQuery = "")
        {
            int pageSize = 9;
            var query = _context.Products.Include(p => p.Category).Include(p => p.ProductImages).AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(p => p.Name.Contains(searchQuery));
                ViewBag.CurrentCategory = "Kết quả tìm kiếm: " + searchQuery;
            }
            else if (categoryId > 0)
            {
                query = query.Where(p => p.CategoryId == categoryId);
                ViewBag.CurrentCategory = _context.Categories.FirstOrDefault(c => c.Id == categoryId)?.Name;
            }
            else
            {
                ViewBag.CurrentCategory = "Tất cả xe";
            }

            switch (sortOrder)
            {
                case "price_asc":
                    query = query.OrderBy(p => Convert.ToInt64(p.Price));
                    break;
                case "price_desc":
                    query = query.OrderByDescending(p => Convert.ToInt64(p.Price));
                    break;
                default:
                    query = query.OrderByDescending(p => p.Id);
                    break;
            }

            int totalItems = query.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var products = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.CategoryId = categoryId;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SearchQuery = searchQuery;
            ViewBag.Categories = _context.Categories.ToList();

            return View(products);
        }



        // GET: /Product/Detail/{id}
        public IActionResult Detail(int id)
        {
            var product = _context.Products.Include(p => p.Category).Include(p => p.ProductImages).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
