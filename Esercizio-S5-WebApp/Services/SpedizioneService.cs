
using Esercizio_S5_WebApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using System.Data.Common;
using System.Data.SqlClient;

namespace Esercizio_S5_WebApp.Services
{
    public class SpedizioneService : SqlServerServiceBase, ISpedizioniService
    {
        private const string SELECT_ALL = "SELECT * FROM Spedizioni";
        // Individuare tutte le spedizioni in consegna nella data odierna,
        private const string SPEDIZIONI_ODIERNE = "SELECT * FROM Spedizioni WHERE CONVERT(date, DataConsegna) = CONVERT(date, GETDATE());";
        // Conoscere il numero delle spedizioni totali in attesa di consegna,
        private const string SPEDIZIONI_TOTALI = "SELECT COUNT(*) FROM Spedizioni AS s JOIN AggiornamentoSpedizioni AS a ON s.IdSpedizione = a.IdSpedizione WHERE a.Stato = 'In consegna';";

        // il numero totale delle spedizioni memorizzate raggruppate per città destinataria.
        private const string SPEDIZIONI_RAGGRUPPATE_PER_CITTA = "SELECT CittaDestinaria, COUNT(*) AS NumeroSpedizioni FROM Spedizioni GROUP BY CittaDestinaria";

        private const string VERIFY_SPEDIZIONE = "SELECT asp.IdAggiornamentoSpedizione, asp.Stato, asp.Luogo, asp.Descrizione " +
            "FROM AggiornamentoSpedizioni asp JOIN Spedizioni AS s ON asp.IdSpedizione = s.IdSpedizione " +
            "JOIN Clienti AS c ON s.IdCliente = c.IdCliente " +
            "WHERE (c.CodiceFiscale = @CFOrPIVA OR c.PartitaIVA = @CFOrPIVA) AND s.NumeroSpedizione = @NumeroSpedizione ORDER BY asp.DataAggiornamento DESC";
        private const string CREA_SPEDIZIONE = "INSERT INTO " +
            "Spedizioni(NumeroSpedizione, DataSpedizione, Peso, CittaDestinaria, Indirizzo, NominativoDestinatario, CostoSpedizione, DataConsegna, IdCliente) " +
            "OUTPUT INSERTED.IdSpedizione " +
            "VALUES(@NumeroSpedizione, @DataSpedizione, @Peso, @CittaDestinaria, @Indirizzo, @NominativoDestinatario, @CostoSpedizione, @DataConsegna, @IdCliente)";
        private const string CREA_AGG_SPED = "INSERT INTO " +
            "AggiornamentoSpedizioni(Stato, Luogo, Descrizione, DataAggiornamento, IdSpedizione) " +
            "OUTPUT INSERTED.IdAggiornamentoSpedizione " +
            "VALUES(@Stato, @Luogo, @Descrizione, @DataAggiornamento, @IdSpedizione)"; 

        public SpedizioneService(IConfiguration config) : base(config)
        {
        }

        public AggiornamentoSpedizione CreAggiornamentoSpedizione(int id, AggiornamentoSpedizione aggiornamentoSpedizione)
        {
            var cmd = GetCommand(CREA_AGG_SPED);
            using var conn = GetConnection();
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@Stato", aggiornamentoSpedizione.Stato));
            cmd.Parameters.Add(new SqlParameter("@Luogo", aggiornamentoSpedizione.Luogo));
            cmd.Parameters.Add(new SqlParameter("@Descrizione", aggiornamentoSpedizione.Descrizione));
            cmd.Parameters.Add(new SqlParameter("@DataAggiornamento", aggiornamentoSpedizione.DataAggiornamento));
            cmd.Parameters.Add(new SqlParameter("@IdSpedizione", id));
            aggiornamentoSpedizione.Id = (int)cmd.ExecuteScalar();
            return aggiornamentoSpedizione;
        }

        public Spedizione Creaspedizione(Spedizione spedizione)
        {
            var cmd = GetCommand(CREA_SPEDIZIONE);
            using var conn = GetConnection();
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@NumeroSpedizione", spedizione.NumeroSpedizione));
            cmd.Parameters.Add(new SqlParameter("@DataSpedizione", spedizione.DataSpedizione));
            cmd.Parameters.Add(new SqlParameter("@Peso", spedizione.Peso));
            cmd.Parameters.Add(new SqlParameter("@CittaDestinaria", spedizione.CittaDestinataria));
            cmd.Parameters.Add(new SqlParameter("@Indirizzo", spedizione.IndirizzoDestinatario));
            cmd.Parameters.Add(new SqlParameter("@NominativoDestinatario", spedizione.NominativoDestinatario));
            cmd.Parameters.Add(new SqlParameter("@DataConsegna", spedizione.DataConsegna));
            cmd.Parameters.Add(new SqlParameter("@CostoSpedizione", spedizione.CostoSpedizione));
            cmd.Parameters.Add(new SqlParameter("@IdCliente", spedizione.IdCliente));

            spedizione.Id = (int)cmd.ExecuteScalar();
            return spedizione;
        }

        public Spedizione CreateReader(DbDataReader reader)
        {
            return new Spedizione
            {
                Id = reader.GetInt32(0),
                NumeroSpedizione = reader.GetString(1),
                DataSpedizione = reader.GetDateTime(2),
                Peso = reader.GetDecimal(3),
                CittaDestinataria = reader.GetString(4),
                IndirizzoDestinatario = reader.GetString(5),
                NominativoDestinatario = reader.GetString(6),
                CostoSpedizione = reader.GetDecimal(7),
                DataConsegna = reader.GetDateTime(8),
                IdCliente = reader.GetInt32(9)
            };
        }
        public IEnumerable<Spedizione> GetAll()
        {

            var cmd = GetCommand(SELECT_ALL);
            using var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            var ListaSped = new List<Spedizione>();
            while (reader.Read()) { 
                ListaSped.Add(CreateReader(reader));
            }
            return ListaSped;
        }

        public IEnumerable<Spedizione> GetSpedizioniOdierne()
        {
            var cmd = GetCommand(SPEDIZIONI_ODIERNE);
            var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            var ListaSpedOd = new List<Spedizione>();
            if (reader.Read())
            {
                ListaSpedOd.Add(CreateReader(reader));
            }
            conn.Close();
            return ListaSpedOd;
        }

        public int NumerodelleSpedizioni()
        {
            var cmd = GetCommand(SPEDIZIONI_TOTALI);
            var conn = GetConnection();
            conn.Open();
            int numerodelleSpedizioni = (int)cmd.ExecuteScalar();
            conn.Close();
            return numerodelleSpedizioni;
        }

        public Dictionary<string, int> SpedizioniPercitta()
        {
            var SpedizioniPerCitta = new Dictionary<string, int>();
            var cmd = GetCommand(SPEDIZIONI_RAGGRUPPATE_PER_CITTA);
            var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string CittaDestinaria = reader.GetString(0);  
                int numeroSpedizioni = reader.GetInt32(1);                  
                SpedizioniPerCitta[CittaDestinaria] = numeroSpedizioni;
            }
            conn.Close();
            return SpedizioniPerCitta;
        }

        public IEnumerable<AggiornamentoSpedizione> VerificaAggiornamentoSpedizione(string CFOrPIVA, string NumeroSpedizone)
        {
            var AggiornamentoSpedizione = new List<AggiornamentoSpedizione>();
            var cmd = GetCommand(VERIFY_SPEDIZIONE);
            cmd.Parameters.Add(new SqlParameter("@CFOrPIVA", CFOrPIVA));
            cmd.Parameters.Add(new SqlParameter("@NumeroSpedizione", NumeroSpedizone));
            using var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                AggiornamentoSpedizione.Add(
                new AggiornamentoSpedizione
                {
                    Id = reader.GetInt32(0),
                    Stato = reader.GetString(1),
                    Luogo = reader.GetString(2),
                    Descrizione = reader.GetString(3)
                });
            }

            return AggiornamentoSpedizione;

        }
    }
}
