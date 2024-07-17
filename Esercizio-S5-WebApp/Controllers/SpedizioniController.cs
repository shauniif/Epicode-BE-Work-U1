using Esercizio_S5_WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_S5_WebApp.Controllers
{
    public class SpedizioniController : Controller
    {
        private readonly ISpedizioniService _spedizioniService;
        public SpedizioniController(ISpedizioniService spedizioniService)
        {
            _spedizioniService = spedizioniService;
        }
        public IActionResult SpedizioniGiornaliere()
        {
            var spedizioni = _spedizioniService.GetSpedizioniOdierne();
            return View(spedizioni);
        }
        public IActionResult NumeroDiSpedizioni()
        {
            var numerospedizioni = _spedizioniService.NumerodelleSpedizioni();
            ViewBag.NumeroSpedizioni = numerospedizioni;
            return View(numerospedizioni); 
        }
    }
}
