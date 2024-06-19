using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_numero_3
{
    internal class ArrNumb
    {
        public void arrNumb()
        {
        int x = 0;
            int somma = 0;
        Console. WriteLine("Inserisci un numero che dare la dimensione all'array");
            x = int.Parse(Console.ReadLine());
            int[] arrNumbers = new int[x];

            for (int i = 0; i < arrNumbers.Length; i++)
            {
                Console.WriteLine("inserisci un numero");
                arrNumbers[i]= int.Parse(Console.ReadLine());
            };

            for (int i = 0; i < arrNumbers.Length; i++) {
               somma += arrNumbers[i];
            }
            Console.WriteLine($"La somma è: {somma}");
            Console.WriteLine($"La media è: {somma/x}");

        }
    }
}
