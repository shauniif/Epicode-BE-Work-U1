namespace Esercizio_S5_WebApp.Models
{
    public class SpedizioniOdierne
    {
        public string NumeroSpedizione { get; set; }

        public decimal Peso { get; set; }

        public DateTime DataSpedizione { get; set; }
        public string CittaDestinataria { get; set; }
        public DateTime DataConsegna { get; set; }

        public string Stato { get; set; }

        public string Descrizione { get; set; }


    }
}
