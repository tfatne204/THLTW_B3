using Microsoft.AspNetCore.Mvc;

namespace FatsitBikerMVC.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult NanoCoating()
        {
            return View();
        }

        public IActionResult LoanSupport()
        {
            return View();
        }

        public IActionResult Maintenance()
        {
            return View();
        }
    }
}
