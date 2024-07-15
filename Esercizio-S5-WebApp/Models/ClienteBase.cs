namespace Esercizio_S5_WebApp.Models
{
    public class ClienteBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public DateTime DataDiNascita { get; set; }

        public string Telefono { get; set; }

        public string TipoCliente { get; set; }



    }
}
