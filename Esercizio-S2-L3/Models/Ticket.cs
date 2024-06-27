using System.ComponentModel.DataAnnotations;

namespace Esercizio_S2_L3.Models
{
    public class Ticket
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage ="Nome Obbligatorio")]
        public string Nome { get; set; }
        [Display(Name = "Cognome")]
        [Required(ErrorMessage = "Cognome Obbligatorio")]
        public string Cognome { get; set; }
        [Display(Name = "Tipo Biglietto")]
        [Required(ErrorMessage = "Tipo Biglietto Obbligatorio")]
        public string TipoBiglietto { get; set; }
        [Required(ErrorMessage = "Scelta Sala Obbligatoria")]
        [Display(Name = "Sale disponibili")]
        public string Sala { get; set; }
    }
}
