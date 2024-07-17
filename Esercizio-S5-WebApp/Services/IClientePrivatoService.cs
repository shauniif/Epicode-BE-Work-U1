using Esercizio_S5_WebApp.Models;

namespace Esercizio_S5_WebApp.Services
{
    public interface IClientePrivatoService
    {
        ClientePrivato CreateClientePrivato(ClientePrivato clientePrivato);

        IEnumerable<ClientePrivato> GetClientePrivati();
    }
}
