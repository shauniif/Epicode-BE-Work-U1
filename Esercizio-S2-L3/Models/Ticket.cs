using System.ComponentModel.DataAnnotations;

namespace Esercizio_S2_L3.Models
{
    public class Ticket
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Cognome")]
        public string Cognome { get; set; }
        [Display(Name = "Tipo Biglietto")]
        public string TipoBiglietto { get; set; }
        [Display(Name = "Sale disponibili")]
        public string Sala { get; set; }
    }
}
