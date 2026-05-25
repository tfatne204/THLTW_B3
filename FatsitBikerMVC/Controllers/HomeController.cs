using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FatsitBikerMVC.Models;

namespace FatsitBikerMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index(string sortOrder)
    {
        ViewBag.CurrentSort = sortOrder;
        var products = _context.Products.Include(p => p.Category).AsEnumerable();

        switch (sortOrder)
        {
            case "price_asc":
                products = products.OrderBy(p => GetPriceValue(p.Price));
                break;
            case "price_desc":
                products = products.OrderByDescending(p => GetPriceValue(p.Price));
                break;
            default:
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

    public IActionResult Stores()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
