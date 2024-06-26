namespace Esercizio_S2_L3.Models
{
    public class Sala
    {
        public string Nome { get; set; }
        public int CapienzaMassima { get; set; } = 120;
        public int BigliettiVendutiInteri { get; set; } = 0;
        public int BigliettiVendutiRidotti { get; set; } = 0;
    }
}
