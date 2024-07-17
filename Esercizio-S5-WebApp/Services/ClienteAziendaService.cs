
using Esercizio_S5_WebApp.Models;
using System.Data.SqlClient;

namespace Esercizio_S5_WebApp.Services
{
    public class ClienteAziendaService : SqlServerServiceBase, IClienteAzienda
    {
        private const string CREATE_AZ = "INSERT INTO Clienti " +
           "(Nome, Cognome, DataDiNascita, Email, Telefono, TipoCliente, CodiceFiscale)" +
           "OUTPUT INSERTED.IdCliente " +
           "VALUES(@nome, @cognome, @DDN, @email, @telefono, 'Azienda', @CF)";

        public ClienteAziendaService(IConfiguration config) : base(config)
        {
        }

        public ClienteAzienda CreateClienteAzienda(ClienteAzienda clientePrivato)
        {
            var cmd = GetCommand(CREATE_AZ);
            using var conn = GetConnection();
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@nome", clientePrivato.Nome));
            cmd.Parameters.Add(new SqlParameter("@cognome", clientePrivato.Cognome));
            cmd.Parameters.Add(new SqlParameter("@DDN", clientePrivato.DataDiNascita));
            cmd.Parameters.Add(new SqlParameter("@email", clientePrivato.Email));
            cmd.Parameters.Add(new SqlParameter("@telefono", clientePrivato.Telefono));
            cmd.Parameters.Add(new SqlParameter("@CF", clientePrivato.PartitaIVA));

            clientePrivato.Id = (int)cmd.ExecuteScalar();
            return clientePrivato;
        }
    }
}
