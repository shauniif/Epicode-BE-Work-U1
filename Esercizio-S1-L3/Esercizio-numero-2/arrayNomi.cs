using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_numero_2
{
    internal class arrayNomi
    {
        string[] arrNomi = { "Mario", "Luigi", "Wario","Waluigi", "Toad" };
        string nome;

        public void ControlloNomi()
        {
            Console.WriteLine("Inseririsci Il nome");
            nome = Console.ReadLine();
            for (int i = 0; i < arrNomi.Length; i++)
            {
                if (arrNomi[i] == nome)
                {
                    Console.WriteLine("Il nome è presente nella lista");
                } else
                {
                    Console.WriteLine("Il nome non è presente nella lista");
                }
                Console.ReadLine();
            }
        }
    }
}
