using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FatsitBikerMVC.Models;

namespace FatsitBikerMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductManagerController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _context;

        public ProductManagerController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        public IActionResult Index(string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.PriceSortParam = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            var products = _context.Products.Include(p => p.Category).Include(p => p.ProductImages).AsEnumerable();

            switch (sortOrder)
            {
                case "price_asc":
                    products = products.OrderBy(p => GetPriceValue(p.Price));
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => GetPriceValue(p.Price));
                    break;
                default:
                    products = products.OrderByDescending(p => p.Id);
                    break;
            }

            return View(products.ToList());
        }

        private decimal GetPriceValue(string priceString)
        {
            if (string.IsNullOrEmpty(priceString)) return 0;
            string cleanPrice = new string(priceString.Where(char.IsDigit).ToArray());
            return decimal.TryParse(cleanPrice, out decimal result) ? result : 0;
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View(new ProductViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                List<string> uniqueFileNames = ProcessUploadedFiles(model);

                if (!ModelState.IsValid)
                {
                    ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
                    return View(model);
                }

                Product newProduct = new Product
                {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    Price = model.Price,
                    Desc = model.Desc,
                    Engine = model.Engine,
                    Power = model.Power,
                    Weight = model.Weight,
                    ProductImages = uniqueFileNames.Count > 0 
                                ? uniqueFileNames.Select(name => new ProductImage { ImageUrl = "/images/products/" + name }).ToList() 
                                : new List<ProductImage> { new ProductImage { ImageUrl = "https://images.unsplash.com/photo-1558981403-c5f9899a28bc" } }
                };

                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var product = _context.Products.Include(p => p.ProductImages).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Desc = product.Desc,
                Engine = product.Engine,
                Power = product.Power,
                Weight = product.Weight,
                ExistingImages = product.ProductImages.ToList()
            };

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, ProductViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var product = _context.Products.Include(p => p.ProductImages).FirstOrDefault(p => p.Id == model.Id);
                if (product == null)
                {
                    return NotFound();
                }

                product.Name = model.Name;
                product.CategoryId = model.CategoryId;
                product.Price = model.Price;
                product.Desc = model.Desc;
                product.Engine = model.Engine;
                product.Power = model.Power;
                product.Weight = model.Weight;

                if (model.ImagesToDelete != null && model.ImagesToDelete.Count > 0)
                {
                    var imagesToRemove = product.ProductImages.Where(img => model.ImagesToDelete.Contains(img.Id)).ToList();
                    _context.ProductImages.RemoveRange(imagesToRemove);
                }

                if (model.ImageUploads != null && model.ImageUploads.Count > 0)
                {
                    List<string> uniqueFileNames = ProcessUploadedFiles(model);
                    if (!ModelState.IsValid)
                    {
                        ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
                        return View(model);
                    }
                    
                    foreach (var name in uniqueFileNames)
                    {
                        product.ProductImages.Add(new ProductImage { ImageUrl = "/images/products/" + name });
                    }
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.Include(p => p.Category).Include(p => p.ProductImages).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private List<string> ProcessUploadedFiles(ProductViewModel model)
        {
            List<string> fileNames = new List<string>();

            if (model.ImageUploads != null && model.ImageUploads.Count > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");
                if (!Directory.Exists(uploadsFolder)) {
                    Directory.CreateDirectory(uploadsFolder);
                }

                foreach (var file in model.ImageUploads)
                {
                    if (!file.ContentType.StartsWith("image/"))
                    {
                        ModelState.AddModelError("ImageUploads", "Tệp tải lên phải là hình ảnh (.jpg, .png, .jpeg...).");
                        return new List<string>();
                    }

                    if (file.Length > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError("ImageUploads", "Kích thước hình ảnh không được vượt quá 2MB.");
                        return new List<string>();
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    
                    fileNames.Add(uniqueFileName);
                }
            }

            return fileNames;
        }
    }
}
