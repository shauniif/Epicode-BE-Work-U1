using Esercizio_S5_WebApp.Models;

namespace Esercizio_S5_WebApp.Services
{
    public interface IClienteAziendaService
    {
        ClienteAzienda CreateClienteAzienda(ClienteAzienda clienteAzienda);

        IEnumerable<ClienteAzienda> GetClienteAziende();
    }
}
