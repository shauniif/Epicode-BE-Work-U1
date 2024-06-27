namespace Esercizio_S2_L4_Riepilogo.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;
        public bool Available { get; set; }
    }
}
