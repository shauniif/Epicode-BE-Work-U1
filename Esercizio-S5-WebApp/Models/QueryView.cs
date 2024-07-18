namespace Esercizio_S5_WebApp.Models
{
    public class QueryView
    {
        public IEnumerable<Spedizione> SpedizioniOdierne { get; set; }

        public int SpedizioniTotali { get; set; }

        public Dictionary<string, int> SpedizioniPercitta { get; set; }
    }
}
