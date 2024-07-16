namespace Esercizio_S5_WebApp.Models
{
    public class Spedizione : BaseEntity
    {
        public string NumeroSpedizione { get; set; }
        
        public decimal Peso { get; set; }

        public DateTime DataSpedizione { get; set; }

        public string CittaDestinataria { get; set; }
        public string Indirizzo { get; set; }

        public decimal CostoSpedizione { get; set; }

        public DateTime DataConsegna { get; set; }

        public int IdCliente { get; set; }


    }
}
