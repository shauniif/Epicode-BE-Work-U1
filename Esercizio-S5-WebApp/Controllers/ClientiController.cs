using Esercizio_S5_WebApp.Models;
using Esercizio_S5_WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_S5_WebApp.Controllers
{
    public class ClientiController : Controller
    {
        public readonly IClientePrivato _clientePrivato;
        public readonly IClienteAzienda _clienteAzienda;
        public ClientiController(IClientePrivato clientePrivato, IClienteAzienda clienteAzienda) 
        {
            _clientePrivato = clientePrivato;
            _clienteAzienda = clienteAzienda;
        }
        public IActionResult CreatePrivato()
        {
            return View(new ClientePrivato());
        }
        [HttpPost]
        public IActionResult CreatePrivato(ClientePrivato clientePrivato) 
        {
            _clientePrivato.CreateClientePrivato(clientePrivato);
            return RedirectToAction("Privacy", "Home");
        }

        public IActionResult CreateAzienda()
        {
            return View(new ClienteAzienda());
        }
        [HttpPost]
        public IActionResult CreateAzienda(ClienteAzienda clienteAzienda)
        {
            _clienteAzienda.CreateClienteAzienda(clienteAzienda);
            return RedirectToAction("Privacy", "Home");
        }
    }
}
