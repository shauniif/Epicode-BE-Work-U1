using Esercizio_S5_WebApp.Models;

namespace Esercizio_S5_WebApp.Services
{
    public interface ISpedizioniService : ICrudService<Spedizione>
    {
        IEnumerable<Spedizione> GetSpedizioniOdierne();

        int NumerodelleSpedizioni();
        // ciao
    }
}
