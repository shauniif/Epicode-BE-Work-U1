using Esercizio_S5_WebApp.Models;

namespace Esercizio_S5_WebApp.Services
{
    public interface IClientiPrivatoService : ICrudService<ClientePrivato>
    { 
        IEnumerable<ClientePrivato> GetAll();
    }
}
