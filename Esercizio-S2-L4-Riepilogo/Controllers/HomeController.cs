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
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IWebHostEnvironment env)
        {
            _logger = logger;
            _productService = productService;
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Dictionary <int,string> productImages = new Dictionary<int, string>();
            var products = _productService.GetAllProducts();
            foreach(var product in products)
            {
                string uploads = Path.Combine(_env.WebRootPath, "images");
                string image = Path.ChangeExtension(Path.Combine(uploads, product.Name.ToString()), "jpg");
                if (System.IO.File.Exists(image))
                    productImages[product.Id] = $"/images/{product.Name}.jpg";

            }
            ViewBag.ProductImages = productImages;
            return View(products);
        }
        public IActionResult CreateProduct()
        {  
            return View(new Product());
        }
        public IActionResult Detail(int id) {
            var product = _productService.GetById(id);
            string uploads = Path.Combine(_env.WebRootPath, "images");
            string image = Path.ChangeExtension(Path.Combine(uploads, product.Name.ToString()), "jpg");
            if (System.IO.File.Exists(image))
                ViewBag.Image = $"/images/{product.Name}.jpg";
            return View(product);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _productService.Create(product);
            string uploads = Path.Combine(_env.WebRootPath, "images");
            if (product.ImageProduct.Length > 0)
            {
                string filePath = Path.ChangeExtension(Path.Combine(uploads, product.Name.ToString()), "jpg");
                using Stream fileStream = new FileStream(filePath, FileMode.Create);
                product.ImageProduct.CopyTo(fileStream);
            }
            
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
