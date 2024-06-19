using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Esercizio_numero_1
{
    internal class ContoCorrente2
    {
        private static int ultimoAccount = 0;
        public string Nome {  get; set; }
        public string Cognome { get; set; }
        public int Id { get; set; }
        public DateTime operazionEffettuata { get; set; }
           
        public decimal Saldo {  get; set; }

        public ContoCorrente2(string nome, string cognome, int saldo)
        {
            if (saldo < 1000) {
                throw new ArgumentException("Per aprire il conto serve versare almeno 1000");
            }
            operazionEffettuata = DateTime.Now;
            Saldo += saldo;
            Nome = nome;
            Cognome = cognome;
            Id = ++ultimoAccount;
            Saldo = saldo;
            Console.WriteLine(DescrizioneConto());
        }
        public void Versamento(decimal saldo)
        {
            operazionEffettuata = DateTime.Now;
            Saldo += saldo;
            Console.WriteLine($"Hai versato correttamente {saldo} euro!");
            Console.WriteLine(DescrizioneConto());
        }

        public void Prelievo(decimal saldo)
        {

            if (saldo > Saldo)
                throw new ArgumentException("Non puoi prevale oltre la quantità di saldo prevista sul tuo conto");

            
                Saldo -= saldo;
                Console.WriteLine("Prelevamento effettuato correttamente");
                Console.WriteLine($"Hai prelevato {saldo}€!");
                Console.WriteLine($"Attualmente nel tuo Conto Corrente si trovano {saldo}€");
                Console.WriteLine(DescrizioneConto());

            
            
        }
        public string DescrizioneConto()
        {
            return $"Conto corrente n. {Id} intestato a {Nome} {Cognome}\n\tUltima operazione effettuata il {operazionEffettuata}\n\tSaldo: {Saldo} euro";
        }

    }
}
