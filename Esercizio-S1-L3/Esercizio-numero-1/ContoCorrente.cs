using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_numero_1
{
    internal class ContoCorrente
    {
        private string nome;
        private string cognome;
        private decimal saldo;
        private bool contoAperto = false;
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public decimal Saldo { get; set; }
        private bool ContoAperto {  get; set; }

        public ContoCorrente() { }


        public ContoCorrente(string nome, string cognome, decimal saldoIniziale)
        {
            nome = nome;
            cognome = cognome;
            saldo = saldoIniziale;
            contoAperto = true;
        }
        public void MenuBanca()
        {
            Console.WriteLine("Benvenuto nella banca Tal dei Tali");
            Console.WriteLine("1. Apri un nuovo conto corrente");
            Console.WriteLine("2. Effettua un versamento");
            Console.WriteLine("3. Effettua un prelievo");
            Console.WriteLine("4. Esci");

            int scelta = int.Parse(Console.ReadLine());

            switch(scelta)
            {
                case 1: 
                    AperturaContocorrente();
                    break;
                case 2:
                    Versamento();
                    break;
                case 3:
                    Prelievo();
                    break;
                case 4: Console.WriteLine("Arrivederci!");
                    break;
                default:Console.WriteLine("Non hai scelto correttamente");
                    MenuBanca();
                    break;
            }
        }  
        
        private void AperturaContocorrente()
        {
            Console.WriteLine("Inserisci il tuo nome: ");
            string Nome = Console.ReadLine();

            Console.WriteLine("Inserisci il tuo cognome: ");
            string Cognome = Console.ReadLine();

            Console.WriteLine("Inserisci un saldo iniziale:");
            string Saldo = Console.ReadLine();
            decimal importoVersato = decimal.Parse(Saldo);
            if (importoVersato < 1000 )
            {
                Console.WriteLine("Devi versare una somma maggiore");
            } else
            {
                ContoCorrente contoCorrente = new ContoCorrente(nome, cognome, saldo);
                {
                    nome = Nome;
                    cognome = Cognome;
                    saldo = importoVersato;
                    contoAperto = true;
                    Console.WriteLine("Apertura del Conto corrente avvenuta correttamente!");
                    Console.WriteLine($"Conto Corrente n°389204 intestato a {Nome} {Cognome}");
                    MenuBanca();
                }
            }
            

         

        }

        private void Versamento()
        {
            if (contoAperto == false) 
            {
                Console.WriteLine("Non puoi fare un versamento se non hai aperto un conto corrente");
            } else
            {
                Console.WriteLine("Inserisci l'importo che vuoi versare");
                string importo = Console.ReadLine();
                decimal importoVersato = decimal.Parse(importo);
                saldo += importoVersato;
                Console.WriteLine($"Hai versato correttamente {importoVersato}€!");
                Console.WriteLine($"Attualmente nel tuo Conto Corrente si trovano {saldo}€");
                MenuBanca();
            }
        }
        private void Prelievo()
        {
            if (contoAperto == false)
            {
                Console.WriteLine("Non puoi fare un versamento se non hai aperto un conto corrente");
            }
            else
            {
                Console.WriteLine("Inserisci l'importo che vuoi prelevare");
                string importo = Console.ReadLine();
                decimal importoPrelevato = decimal.Parse(importo);

                if (importoPrelevato > saldo)
                {
                    Console.WriteLine("Non puoi prevale oltre la quantità di saldo prevista sul tuo conto");
                } else
                {
                   saldo -= importoPrelevato;
                    Console.WriteLine("Prelevamento effettuato correttamente");
                    Console.WriteLine($"Hai prelevato {importoPrelevato}€!");
                    Console.WriteLine($"Attualmente nel tuo Conto Corrente si trovano {saldo}€");
                    MenuBanca();
                }
            }
        }
    }
}
