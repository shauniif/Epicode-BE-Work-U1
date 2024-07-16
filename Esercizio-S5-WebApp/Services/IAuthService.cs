using Esercizio_S5_WebApp.Models;

namespace Esercizio_S5_WebApp.Services
{
    public interface IAuthService
    {
        ApplicationUser Login(string username, string password);
    }
}
