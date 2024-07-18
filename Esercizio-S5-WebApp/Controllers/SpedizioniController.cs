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
        public IActionResult SpedizioniQuery()
        {
            var spedizioni = _spedizioniService.GetSpedizioniOdierne();
            var numeroSpedizioni = _spedizioniService.NumerodelleSpedizioni();
            var spedizioniPerCitta = _spedizioniService.SpedizioniPercitta();

            var AllQuery = new QueryView()
            {
                SpedizioniOdierne = spedizioni,
                SpedizioniTotali = numeroSpedizioni,
                SpedizioniPercitta = spedizioniPerCitta
            };
        
            return View(AllQuery);
        }
        

        public IActionResult TutteLeSpedizioni() {
            var tutteLeSpedizoni = _spedizioniService.GetAll();
            return View(tutteLeSpedizoni); 
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
        public IActionResult CreaAggiornamentoSped()
        {
            return View(new AggiornamentoSpedizione());
        }
        [HttpPost]
        public IActionResult CreaAggiornamentoSped(int id, AggiornamentoSpedizione aggiornamentoSspedizione)
        {
            var s = _spedizioniService.CreAggiornamentoSpedizione(id, aggiornamentoSspedizione);
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
