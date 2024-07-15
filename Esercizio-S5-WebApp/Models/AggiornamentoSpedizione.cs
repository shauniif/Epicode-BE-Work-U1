namespace Esercizio_S5_WebApp.Models
{
    public class AggiornamentoSpedizione
    {
        public int IdAggiornamentoSpedizione { get; set; }

        public string Stato { get; set; }

        public string Luogo { get; set; }

        public string Descrizione { get; set; }

        public DateTime DataAggiornamento { get; set; }
        public int IdSpedizione { get; set; }
    }
}
