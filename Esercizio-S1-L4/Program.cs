namespace Esercizio_S1_L4
{
    internal class Program
    {
            static void Main(string[] args)
        {
         try
            {
                User.Menu();
            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }              


        }
    }
}
