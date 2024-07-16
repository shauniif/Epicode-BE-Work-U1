

using Esercizio_S5_WebApp.Models;
using System.Data.Common;

namespace Esercizio_S5_WebApp.Services
{
    public class ClientiPrivatoService : SqlServerServiceBase, IClientiPrivatoService
    {
        public ClientiPrivatoService(IConfiguration config) : base(config)
        {
        }

        public ClientePrivato CreateReader(DbDataReader reader)
        {
            return new ClientePrivato
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Cognome = reader.GetString(2),
                DataDiNascita = reader.GetDateTime(3),
                Email = reader.GetString(4),
                Telefono = reader.GetString(5),
                TipoCliente = reader.GetString(6),
                CodiceFiscale = reader.GetString(7),
            };
        }
        public void Create(ClientePrivato entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientePrivato> GetAll()
        {
            var query = "SELECT IdCliente, Nome, Cognome, DataDiNascita, Email, Telefono, TipoCliente, CodiceFiscale FROM Clienti WHERE TipoCliente = 'Privato'";
            var cmd = GetCommand(query);
            using var conn = GetConnection();
            conn.Open();
            var reader = cmd.ExecuteReader();
            var ClientiPrivati = new List<ClientePrivato>();
            while (reader.Read())
            {
                ClientiPrivati.Add(CreateReader(reader));
            }
            return ClientiPrivati;

        }

        public ClientePrivato GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ClientePrivato entity)
        {
            throw new NotImplementedException();
        }
    }
}
