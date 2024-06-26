using Esercizio_S2_L3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Esercizio_S2_L3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
        {
            Multisala.Tickets.Add(ticket);
            var sala = Multisala.Sale.FirstOrDefault(s => s.Nome == ticket.Sala);
            if (sala != null)
            {
                if (ticket.TipoBiglietto == "Intero")
                {
                    sala.BigliettiVendutiInteri++;
                        
                    }
                else if (ticket.TipoBiglietto == "Ridotto")
                {
                    sala.BigliettiVendutiRidotti++;
                }
            }
            if (sala.Nome == "SALA NORD")
                {
                    sala.CapienzaMassima--;
                } else if(sala.Nome == "SALA EST")
                {
                    sala.CapienzaMassima--;
                } else if (sala.Nome == "SALA SUD")
                {
                    sala.CapienzaMassima--;
                }
            
            return RedirectToAction("Index");
        }
        return View(ticket);
        }
       


        public IActionResult Index()
        {
            var sale = Multisala.Sale ?? new List<Sala>();
       
            return View(sale);
        }
        public IActionResult Ticket()
        {
            var ticket = Multisala.Tickets ?? new List<Ticket>();
            return View(ticket);
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
