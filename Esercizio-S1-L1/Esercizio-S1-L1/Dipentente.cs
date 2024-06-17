using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_S1_L1
{
    internal class Dipentente
    {
        string nome;
        string cognome;
        int età;
        string ruolo;

        public string Nome
        {
            get { return nome; }
            set { this.nome = value; }
        }

        public string Cognome
        {
            get { return cognome; }
            set { this.cognome = value; }
        }
        public int Età
        {
            get { return età; }
            set { this.età = value; }
        }

        public string Ruolo
        {
            get { return ruolo; }
            set { ruolo = value; }

        }

        public void DescrizioneDipendente()
        {
            Console.WriteLine("Mi chiamo " + this.nome + " " + this.cognome + ", ho " + this.età + " anni e il mio ruolo è" + this.ruolo);
        }
    }
}
