﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_S1_L2
{
    internal class TransformNumber
    {
        public string Translate(int number)
        {
            // possiamo pensare a tre diversi casi iniziali:
            // 1. il numero è = 0
            if (number == 0)
            {
                // 1.1. allora restituisco direttamente "zero"
                return "zero";
            }
            // 2. il numero è negativo
            else if (number < 0)
            {
                // 2.1. allora restituisco la stringa "meno "
                //      alla quale aggiungo la traduzione del numero cambiato di segno
                return "meno " + //qualcosaltro
                                 TranslateNumber(-number);
            }
            // 3. il numero è positivo
            else
            {
                // 3.1. allora devo procedere alla traduzione effettiva...
                return TranslateNumber(number); //qualcosaltro;
            }
        }

        string TranslateNumber(int number)
        {
            if (number == 0) return "";

            if (number < 20)
            {
                return GetUnita(number);
            }

            else if (number < 100)
            {
              return GetDecina(number);
            } else if (number < 1000)
            {
                return GetCentinaia(number);
            }
            // 0. se non posso più tradurre
            // restituisco "overflow"
            return "overflow";
        }
        string GetUnita(int number)
        {
            string[] n = {"uno", "due","tre","quattro","cinque","sei","sette","otto",
                    "nove","dieci","undici","dodici","tredici","quattordici","quindici","sedici",
                    "diciassette","diciotto","diciannove" };
            return n[number - 1];
        }

        string GetDecina(int number) {
            // 2.1. prendo le decine
            int dec = number / 10;
            // 2.2. prendo le unità
            int un = number % 10;
            // 2.3. la traduzione delle decine avviene attraverso la corrispondenza
            //      del nome della decina con il valore passato
            string[] d = {"venti","trenta","quaranta","cinquanta","sessanta","settanta",
                    "ottanta","novanta" };
            string decina = d[dec - 2];
            // 2.4. la traduzione delle unità viene effettuata come nel caso del numero < 20
            string unita = TranslateNumber(un);
            return decina + unita;
        }

        string GetCentinaia(int number) {

            int cen = number / 100;
            int resto = number % 100;
            string[] c = { "cento", "duecento", "trecento", "quattrocento", "cinquecento", "seicento", "settecento", "ottocento", "novecento" };
            string centinaia = c[cen - 1];
            string decina = TranslateNumber(resto);
            return centinaia + decina;
        }
    }
}
