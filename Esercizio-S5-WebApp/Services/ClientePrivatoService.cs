
using Esercizio_S5_WebApp.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Data.SqlClient;

namespace Esercizio_S5_WebApp.Services
{
    public class ClientePrivatoService : SqlServerServiceBase, IClientePrivato
    {
        private const string CREATE_CP = "INSERT INTO Clienti " +
            "(Nome, Cognome, DataDiNascita, Email, Telefono, TipoCliente, CodiceFiscale)" +
            "OUTPUT INSERTED.IdCliente " +
            "VALUES(@nome, @cognome, @DDN, @email, @telefono, 'Privato', @CF)";

        public ClientePrivatoService(IConfiguration config) : base(config)
        {
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
    }
}
