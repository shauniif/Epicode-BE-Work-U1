
using Esercizio_S5_WebApp.Models;
using System.Data.Common;
using System.Data.SqlClient;

namespace Esercizio_S5_WebApp.Services
{
    public class ClienteAziendaService : SqlServerServiceBase, IClienteAziendaService
    {
        private const string CREATE_AZ = "INSERT INTO Clienti " +
           "(Nome, Email, Telefono, TipoCliente, PartitaIVA)" +
           "OUTPUT INSERTED.IdCliente " +
           "VALUES(@nome, @email, @telefono, 'Azienda', @PIVA)";
        private const string SELECT_CP = "SELECT IdCliente, Nome Email, Telefono, TipoCliente, PartitaIVA " +
          "FROM Clienti " +
          "WHERE TipoCliente = 'Azienda';";
        public ClienteAziendaService(IConfiguration config) : base(config)
        {
        }

        public ClienteAzienda ClientePrivatoReader(DbDataReader reader)
        {
            return new ClienteAzienda
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Email = reader.GetString(2),
                Telefono = reader.GetString(3),
                TipoCliente = reader.GetString(4)
            };
        }
        public ClienteAzienda CreateClienteAzienda(ClienteAzienda clientePrivato)
        {
            var cmd = GetCommand(CREATE_AZ);
            using var conn = GetConnection();
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@nome", clientePrivato.Nome));
            cmd.Parameters.Add(new SqlParameter("@email", clientePrivato.Email));
            cmd.Parameters.Add(new SqlParameter("@telefono", clientePrivato.Telefono));
            cmd.Parameters.Add(new SqlParameter("@PIVA", clientePrivato.PartitaIVA));

            clientePrivato.Id = (int)cmd.ExecuteScalar();
            return clientePrivato;
        }

        public IEnumerable<ClienteAzienda> GetClienteAziende()
        {
            List<ClienteAzienda> clientiAziende = new List<ClienteAzienda>();
            var cmd = GetCommand(SELECT_CP);
            using var conn = GetConnection();
            conn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                clientiAziende.Add(ClientePrivatoReader(reader));
            }
            return clientiAziende;
        }
    }
}
