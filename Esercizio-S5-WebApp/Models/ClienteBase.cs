namespace Esercizio_S5_WebApp.Models
{
    public class ClienteBase : BaseEntity
    {     
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public DateTime DataDiNascita { get; set; }
        public string Email { get; set; }

        public string Telefono { get; set; }

        public string TipoCliente { get; set; }



    }
}
