namespace Esercizio_numero_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // ContoCorrente c = new ContoCorrente();
          //  c.MenuBanca();

            ContoCorrente2 d = new ContoCorrente2("Mario", "Rossi", 1200);
            d.Versamento(500);
            d.Prelievo(200);
            try
            {
                ContoCorrente2 a2 = new ContoCorrente2("Luigi","Verdi", 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
