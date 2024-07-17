
using Esercizio_S5_WebApp.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Data.Common;
using System.Data.SqlClient;

namespace Esercizio_S5_WebApp.Services
{
    public class ClientePrivatoService : SqlServerServiceBase, IClientePrivatoService
    {
        private const string CREATE_CP = "INSERT INTO Clienti " +
            "(Nome, Cognome, DataDiNascita, Email, Telefono, TipoCliente, CodiceFiscale)" +
            "OUTPUT INSERTED.IdCliente " +
            "VALUES(@nome, @cognome, @DDN, @email, @telefono, 'Privato', @CF)";
        private const string SELECT_CP = "SELECT IdCliente, Nome, Cognome, DataDiNascita, Email, Telefono, TipoCliente, CodiceFiscale " +
            "FROM Clienti " +
            "WHERE TipoCliente = 'Privato';";
        public ClientePrivatoService(IConfiguration config) : base(config)
        {
        }

        public ClientePrivato ClientePrivatoReader(DbDataReader reader)
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
        public ClientePrivato CreateClientePrivato(ClientePrivato clientePrivato)
        {
            var cmd = GetCommand(CREATE_CP);
            using var conn = GetConnection();
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@nome", clientePrivato.Nome));
            cmd.Parameters.Add(new SqlParameter("@cognome", clientePrivato.Cognome));
            cmd.Parameters.Add(new SqlParameter("@DDN", clientePrivato.DataDiNascita));
            cmd.Parameters.Add(new SqlParameter("@email", clientePrivato.Email));
            cmd.Parameters.Add(new SqlParameter("@telefono", clientePrivato.Telefono));
            cmd.Parameters.Add(new SqlParameter("@CF", clientePrivato.CodiceFiscale));

            clientePrivato.Id = (int)cmd.ExecuteScalar();
            return clientePrivato;
        }

        public IEnumerable<ClientePrivato> GetClientePrivati()
        {
            List<ClientePrivato> clientiPrivati = new List<ClientePrivato>();
            var cmd = GetCommand(SELECT_CP);
            using var conn = GetConnection();
            conn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                clientiPrivati.Add(ClientePrivatoReader(reader));
            }
            return clientiPrivati;
        }
    }
}
