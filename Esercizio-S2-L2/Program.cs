using System;

namespace Esercizio_S2_L2
{
    internal class Program
    {
        static void StampaVC(CV cv)
        {
            Console.WriteLine("++++ INIZIO Informazioni personali: ++++");
            Console.WriteLine($"Nome: {cv.InformazioniPersonali.Nome}");
            Console.WriteLine($"Cognome: {cv.InformazioniPersonali.Cognome}");
            Console.WriteLine($"Telefono: +{cv.InformazioniPersonali.Telefono}");
            Console.WriteLine($"Email: {cv.InformazioniPersonali.Email}");
            Console.WriteLine("++++ FINE Informazioni personali ++++");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("++++ INIZIO Studi e formazione: ++++");
            foreach(var studi in cv.StudiEffettuati)
            {
               Console.WriteLine($"Istituto: {studi.Istituto}");
               Console.WriteLine($"Studio: {studi.Qualifica}");
               Console.WriteLine($"Tipo: {studi.Tipo}");
                Console.Write($"Da: {studi.Dal.ToShortDateString()} ");
                Console.Write($"al: {studi.Al.ToShortDateString()}\n");
                Console.WriteLine(" ");
            }
            Console.WriteLine("++++ FINE Studi e formazione ++++");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("++++ INIZIO Espererienze Personali: ++++");
            foreach(var jobs in cv.Impiego)
            {   

                Console.WriteLine($"Presso: {jobs.Esperienza.Azienda}");
                Console.WriteLine($"Tip di lavoro:: {jobs.Esperienza.JobTitle}");
                Console.WriteLine($"Descrizione: {jobs.Esperienza.Descrizione} ");
                Console.WriteLine($"Compiti: {jobs.Esperienza.Compiti} ");
                Console.Write($"Da: {jobs.Esperienza.Dal.ToShortDateString()} ");
                Console.Write($"al: {jobs.Esperienza.Al.ToShortDateString()} \n");
                Console.WriteLine(" ");
            }
            Console.WriteLine("++++ FINE Espererienze Personali ++++");

        }
        static void Main(string[] args)
        {
            CV cv = new CV()
            {
                InformazioniPersonali = new InformazioniPersonali
                {
                    Nome = "Luigi",
                    Cognome = "Verdi",
                    Telefono = "3837238476",
                    Email = "luigiverdi98@gmail.com",
                },
                StudiEffettuati = new List<Studi>
               {
                   new Studi
                   {
                       Qualifica = "Informatica",
                       Istituto = "Univerisità di Torino",
                       Tipo = "Laurea",
                       Dal = new DateTime(2017, 9, 30),
                       Al = new DateTime(2021, 7, 24),

                   },
                    new Studi
                   {
                       Qualifica = "Perito Aziendale",
                       Istituto = "Istituto 'Griamldi - Pacioli",
                       Tipo = "Diploma Superiore",
                       Dal = new DateTime(2012, 9, 15),
                       Al = new DateTime(2017, 7, 11),
                    }
                   },
                Impiego = new List<Impiego>
                {
                    new Impiego
                    {
                        Esperienza = new Esperienza
                        {
                             Azienda = "Tech Solutions",
                            JobTitle = "Software Developer",
                            Dal = new DateTime(2022, 1, 1),
                            Al = new DateTime(2022, 6, 30),
                            Descrizione = "Sviluppo di applicazioni web",
                            Compiti = "Analisi dei requisiti, sviluppo, test e manutenzione del software."
                        }
                     
                    },
                    new Impiego
                    {
                        Esperienza = new Esperienza
                        {
                            Azienda = "Innovative Apps",
                            JobTitle = "Senior Developer",
                            Dal = new DateTime(2022, 9, 1),
                            Al = new DateTime (2023, 12, 31),
                            Descrizione = "Gestione e sviluppo di progetti innovativi",
                            Compiti = "Progettazione dell'architettura, mentoring dei nuovi sviluppatori, supervisione dei progetti."
                        }
                    }
                }
            };

            StampaVC(cv);
        }
    }
}
