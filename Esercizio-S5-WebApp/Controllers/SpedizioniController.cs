using Esercizio_S5_WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_S5_WebApp.Controllers
{
    public class SpedizioniController : Controller
    {
        private readonly ISpedizioniService ;
        public SpedizioniController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}
