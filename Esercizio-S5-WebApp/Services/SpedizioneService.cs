
using Esercizio_S5_WebApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using System.Data.Common;

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
        public SpedizioneService(IConfiguration config) : base(config)
        {
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
            if (reader.Read()) { 
                ListaSped.Add(CreateReader(reader));
            }
            return ListaSped;
        }

        public IEnumerable<Spedizione> GetSpedizioniOdierne()
        {
            var cmd = GetCommand(SPEDIZIONI_ODIERNE);
            using var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            var ListaSpedOd = new List<Spedizione>();
            if (reader.Read())
            {
                ListaSpedOd.Add(CreateReader(reader));
            }
            return ListaSpedOd;
        }

        public int NumerodelleSpedizioni()
        {
            var cmd = GetCommand(SPEDIZIONI_TOTALI);
            using var conn = GetConnection();
            conn.Open();
            int numerodelleSpedizioni = (int)cmd.ExecuteScalar();
            return numerodelleSpedizioni;
        }

        public Dictionary<string, int> SpedizioniPercitta()
        {
            var SpedizioniPerCitta = new Dictionary<string, int>();
            var cmd = GetCommand(SPEDIZIONI_RAGGRUPPATE_PER_CITTA);
            using var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string CittaDestinaria = reader.GetString(0);  
                int numeroSpedizioni = reader.GetInt32(1);                  
                SpedizioniPerCitta[CittaDestinaria] = numeroSpedizioni;
            }
            return SpedizioniPerCitta;
        }
    }
}
