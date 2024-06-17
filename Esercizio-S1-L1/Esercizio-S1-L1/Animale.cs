using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_S1_L1
{
    internal class Animale
    {
        string nome;
        int età;
        string razza;
        string ciboPreferito;
        public string Nome
        {
            get { return nome; }
            set { this.nome = value; }
        }

        public int Età
        {
            get { return età; }
            set { this.età = value; }
        }

        public string Razza
        {
            get { return razza; }
            set { razza = value; }
        }


        public string CiboPreferito
        {
            get { return ciboPreferito; }
            set { ciboPreferito = value; }
        }

        public void DescrizioneAnimale()
        {
            Console.WriteLine("Il mio bellissimo animale " + this.nome +  " è un " + this.razza + "ha " + this.età + ". Il suo cibo preferito è: " + this.ciboPreferito);
        }
    }
}
