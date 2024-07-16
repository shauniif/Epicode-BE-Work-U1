using Esercizio_S5_WebApp.Models;
using Esercizio_S5_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Esercizio_S5_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientiPrivatoService _clientiPrivatoService;

        public HomeController(ILogger<HomeController> logger, IClientiPrivatoService clientiPrivatoService)
        {
            _logger = logger;
            _clientiPrivatoService = clientiPrivatoService;
        }

        public IActionResult Index()
        {
            var clienti = _clientiPrivatoService.GetAll();
            return View(clienti);
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
