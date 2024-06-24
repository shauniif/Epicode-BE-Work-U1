using Esercizio_Web_App_S2_L1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Esercizio_Web_App_S2_L1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> menuProduct = new List<Product>()
        {
            new Product { NameProduct = "Coca Cola 150 ml", Price = 2.50m},
            new Product { NameProduct = "Insalata di pollo", Price = 5.20m},
            new Product { NameProduct = "Pizza Margherita", Price = 10.00m},
            new Product { NameProduct = "Pizza 4 formaggi", Price = 12.50m},
            new Product { NameProduct = "Pizza Patatine Fritte", Price = 3.50m },
            new Product { NameProduct = "Insalata di riso", Price = 8.00m},
            new Product { NameProduct = "Frutta di stagione", Price = 5.00m},
            new Product { NameProduct = "Pizza Fritta", Price = 5.00m},
            new Product { NameProduct = "Piadina vegetariana" , Price = 6.00m},
            new Product { NameProduct = "Panino Hamburger", Price = 7.90m}
        };
            return View(menuProduct);
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
