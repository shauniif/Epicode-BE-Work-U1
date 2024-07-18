using Esercizio_S5_WebApp.Models;

namespace Esercizio_S5_WebApp.Services
{
    public interface ISpedizioniService : ICrudService<Spedizione>
    {
        Spedizione Creaspedizione(Spedizione spedizione);
        IEnumerable<Spedizione> GetSpedizioniOdierne();

        int NumerodelleSpedizioni();

        Dictionary<string, int> SpedizioniPercitta();

        IEnumerable<AggiornamentoSpedizione> VerificaAggiornamentoSpedizione(string CFOrPIVA, string NumeroSpedizone);

        AggiornamentoSpedizione CreAggiornamentoSpedizione(int id, AggiornamentoSpedizione aggiornamentoSpedizione);
    }
}
