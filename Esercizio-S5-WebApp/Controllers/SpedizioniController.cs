using Esercizio_S5_WebApp.Models;
using Esercizio_S5_WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_S5_WebApp.Controllers
{
    public class SpedizioniController : Controller
    {
        private readonly ISpedizioniService _spedizioniService;
        private readonly IClientePrivatoService _clientePrivatoService;
        private readonly IClienteAziendaService _clienteAziendaService;
        public SpedizioniController(ISpedizioniService spedizioniService, IClientePrivatoService clientePrivatoService, IClienteAziendaService clienteAziendaService)
        {
            _spedizioniService = spedizioniService;
            _clientePrivatoService = clientePrivatoService;
            _clienteAziendaService = clienteAziendaService;
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

        public IActionResult RegistraSpedizione()
        {
            ViewBag.clientiPrivati = _clientePrivatoService.GetClientePrivati();
            ViewBag.clientiAziende = _clienteAziendaService.GetClienteAziende();
            return View(new Spedizione());
        }

        [HttpPost]
        public IActionResult RegistraSpedizione(Spedizione spedizione)
        {
            var s = _spedizioniService.Creaspedizione(spedizione);
            return RedirectToAction("Index", "Home");
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
