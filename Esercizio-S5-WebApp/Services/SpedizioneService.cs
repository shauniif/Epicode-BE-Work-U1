
using Esercizio_S5_WebApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;

namespace Esercizio_S5_WebApp.Services
{
    public class SpedizioneService : SqlServerServiceBase, ISpedizioniService
    {

        // Individuare tutte le spedizioni in consegna nella data odierna,
        private const string SPEDIZIONI_ODIERNE = "SELECT * FROM Spedizioni WHERE CONVERT(date, DataConsegna) = CONVERT(date, GETDATE());";
        // Conoscere il numero delle spedizioni totali in attesa di consegna,

        // il numero totale delle spedizioni memorizzate raggruppate per città destinataria.
        public SpedizioneService(IConfiguration config) : base(config)
        {
        }

        public IEnumerable<Spedizione> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
