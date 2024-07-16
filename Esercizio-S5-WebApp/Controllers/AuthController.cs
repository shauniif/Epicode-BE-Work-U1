using Esercizio_S5_WebApp.Models;
using Esercizio_S5_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Esercizio_S5_WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authenticationService;
        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser user)
        {
            try
            {
                var u = _authenticationService.Login(user.Username, user.Password);
                if (u == null) return RedirectToAction("Privacy", "Home");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, u.Username)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
