using Esercizio_S5_WebApp.Models;

namespace Esercizio_S5_WebApp.Services
{
    public interface IClienteAziendaService : ICrudService<ClienteAzienda>
    {
        IEnumerable<ClienteAzienda> GetAll();
    }
}
