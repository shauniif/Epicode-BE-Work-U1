using Esercizio_S2_L4_Riepilogo.Entities;
using Esercizio_S2_L4_Riepilogo.Models;
using Esercizio_S2_L4_Riepilogo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Esercizio_S2_L4_Riepilogo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {   
            var products = _productService.GetAllProducts();
            return View(products);
        }
        public IActionResult CreateProduct()
        {  
            return View(new Product());
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        { 
            _productService.Create(product);
            return RedirectToAction("Index");
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
