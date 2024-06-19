using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_numero_2
{
    internal class arrayNomi
    {

        public void ControlloNomi(string name)
        {
        string[] arrNomi = { "Mario", "Luigi", "Wario","Waluigi", "Toad" };

            if (arrNomi.Contains(name))
            {
                Console.WriteLine("Il nome è presente nella lista");
            }
            else
            {
                Console.WriteLine("Il nome non è presente nella lista");
            }
        }
    }
}
