namespace Esercizio_numero_3
{
    internal class Program
    {
        static void ControlloArr(int[] numeriArr)
        {
            int somma = 0;
            for (int i = 0; i < numeriArr.Length; i++)
            {
                somma += numeriArr[i];
            }
            Console.WriteLine($"La somma è: {somma}");
            Console.WriteLine($"La media è: {somma / numeriArr.Length}");
        }
        static void Main(string[] args)
        {
            int[] arrNumb = { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50 };
            ControlloArr(arrNumb);
            

        }
    }
}
