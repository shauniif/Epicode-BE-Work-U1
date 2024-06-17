using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_S1_L1
{
    internal class Atleta
    {
        string nome;
        string cognome;
        int età;
        string sport;

        public string Nome
        {
            get { return nome; }
            set { this.nome = value; }
        }

        public string Cognome {
            get { return cognome; }
            set { this.cognome = value; }
        }
        public int Età
        {
            get { return età; }
            set { this.età = value; }
        }

        public string Sport
        {
            get { return sport; }
            set { this.sport = value; }
        }

        public void DescrizioneAtleta()
        {
            Console.WriteLine("Mi chiamo " + this.nome + " " + this.cognome + ", ho " + this.età + " anni e pratico " + this.sport);
        }

    }
}
