using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_S1_L1
{
    internal class Automobile
    {
        string modello;
        string casaAutomobilista;
        int annoDiImmatricolazione;
        string colore;

        public string Modello
        {
            get { return modello; }
            set { this.modello = value; }
        }

        public string CasaAutomobilista
        {
            get { return casaAutomobilista; }
            set { casaAutomobilista = value; }
        }
        public int AnnoDiImmatricolazione
        {
            get { return annoDiImmatricolazione; }
            set { this.annoDiImmatricolazione = value; }
        }



        public string Colore
        {
            get { return colore; }
            set { colore = value; }
        }

        public void DescrizioneAuto()
        {
            Console.WriteLine("La mia auto è una " + this.modello + " è della " + this.casaAutomobilista + " è stata immatricolata nel" + this.AnnoDiImmatricolazione + ". È di colore: " + this.colore);
        }
    }
}
