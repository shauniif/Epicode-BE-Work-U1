using Esercizio_WebApp_S2_L2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Esercizio_S2_L2;

namespace Esercizio_WebApp_S2_L2.Controllers
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
            CV cv = new CV()
            {
                InformazioniPersonali = new InformazioniPersonali
                {
                    Nome = "Luigi",
                    Cognome = "Verdi",
                    Telefono = "3837238476",
                    Email = "luigiverdi98@gmail.com",
                },
                StudiEffettuati = new List<Studi>
               {
                   new Studi
                   {
                       Qualifica = "Informatica",
                       Istituto = "Univerisità di Torino",
                       Tipo = "Laurea",
                       Dal = new DateTime(2017, 9, 30),
                       Al = new DateTime(2021, 7, 24),

                   },
                    new Studi
                   {
                       Qualifica = "Perito Aziendale",
                       Istituto = "Istituto 'Griamldi - Pacioli",
                       Tipo = "Diploma Superiore",
                       Dal = new DateTime(2012, 9, 15),
                       Al = new DateTime(2017, 7, 11),
                    }
                   },
                Impiego = new List<Impiego>
                {
                    new Impiego
                    {
                        Esperienza = new Esperienza
                        {
                             Azienda = "Tech Solutions",
                            JobTitle = "Software Developer",
                            Dal = new DateTime(2022, 1, 1),
                            Al = new DateTime(2022, 6, 30),
                            Descrizione = "Sviluppo di applicazioni web",
                            Compiti = "Analisi dei requisiti, sviluppo, test e manutenzione del software."
                        }

                    },
                    new Impiego
                    {
                        Esperienza = new Esperienza
                        {
                            Azienda = "Innovative Apps",
                            JobTitle = "Senior Developer",
                            Dal = new DateTime(2022, 9, 1),
                            Al = new DateTime (2023, 12, 31),
                            Descrizione = "Gestione e sviluppo di progetti innovativi",
                            Compiti = "Progettazione dell'architettura, mentoring dei nuovi sviluppatori, supervisione dei progetti."
                        }
                    }
                }
            };

            return View(cv);
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
