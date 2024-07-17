namespace Esercizio_S5_WebApp.Models
{
    public class ClientePrivato : ClienteBase
    {
        public DateTime DataDiNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public string Cognome { get; set; }
    
    }
}
