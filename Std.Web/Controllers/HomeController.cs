using System.Diagnostics;
using Std.Application;
using Microsoft.AspNetCore.Mvc;
using Std.Web.Models;
using Std.Application.Product;

namespace Std.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult DominosCaseHome()
        {
            return View(_productService.GetAll());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
}
