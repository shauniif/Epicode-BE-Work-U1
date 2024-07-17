using Esercizio_S5_WebApp.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin, Workers")]
        public IActionResult SpedizioniGiornaliere()
        {
            var spedizioni = _spedizioniService.GetSpedizioniOdierne();
            return View(spedizioni);
        }
        [Authorize(Roles = "Admin, Workers")]
        public IActionResult NumeroDiSpedizioni()
        {
            var numerospedizioni = _spedizioniService.NumerodelleSpedizioni();
            ViewBag.NumeroSpedizioni = numerospedizioni;
            return View(numerospedizioni); 
        }
        [Authorize(Roles = "Admin, Workers")]
        public IActionResult SpedizionePerCitta() 
        {
            var spedizioniPerCitta = _spedizioniService.SpedizioniPercitta();
            return View(spedizioniPerCitta);
        }

        [HttpGet]
        public IActionResult VerificaLaTuaSpedizione()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerificaLaTuaSpedizione(string CFOrPIVA, string NumeroSpedizione) 
        {
            var ListaAggiornamenti = _spedizioniService.VerificaAggiornamentoSpedizione(CFOrPIVA, NumeroSpedizione);
            return View("DettagliSpedizione", ListaAggiornamenti); 
        }
    }
}
