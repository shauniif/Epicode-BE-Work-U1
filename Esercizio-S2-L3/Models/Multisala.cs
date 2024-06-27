namespace Esercizio_S2_L3.Models
{
    public class Multisala
    {
        public static List<Ticket> Tickets = new List<Ticket>();
        public static List<Sala> Sale = new List<Sala>
    {
        new Sala { Nome = "SALA NORD"},
        new Sala { Nome = "SALA EST" },
        new Sala { Nome = "SALA SUD" }
    };
    }
}
