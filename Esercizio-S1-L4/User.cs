using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_S1_L4
{
    internal static class User
    {
        private static string Username { get; set; }
        public static string Password { get; set; }
        public static string ConfermaPassoword { get; set; }
        public static DateTime LoginEffettuata { get; set; }
        private static DateTime[] LoginHistory = new DateTime[10];
        private static int loginIndex = 0;

        public static void Menu()
        {
            Console.WriteLine("Benvenuto nella banca Tal dei Tali");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Logout");
            Console.WriteLine("3. Verifica ora e data di Login");
            Console.WriteLine("4. Ultimi 10 accessi");
            Console.WriteLine("5. Esci");

            char scelta = Choice();

            switch (scelta)
            {
                case '1':
                    Login();
                    break;
                case '2':
                    logOut();
                    break;
                case '3':
                    stampaOrario();
                    break;
                case '4':
                    lastLoginHistory();
                    break;
                case '5':
                    Console.WriteLine("Arrivederci");
                    break;
                default:
                    Console.WriteLine("Non hai scelto correttamente");
                    Menu();
                    break;
            }
        }
        private static void Login()
        {
            Console.WriteLine("inserisci username:");
            string username = Console.ReadLine();
            Console.WriteLine("SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
            Console.WriteLine("inserisci password:");
            string password = Console.ReadLine();

            Console.WriteLine("Conferma password:");
            string confermaPassowrd = Console.ReadLine();

            if (password != confermaPassowrd)
            {
                throw new Exception("Le password non coincidono");
            }
            Username = username;
            Password = password;
            ConfermaPassoword = confermaPassowrd;
            LoginEffettuata = DateTime.Now;
            UpdateLoginHistory(LoginEffettuata);
            Console.WriteLine($"{Username} ha loggato {LoginEffettuata}");
            Menu();
        }

        private static void logOut()
        {
            if(Username == "")
            {
                throw new Exception("Nessun utente loggato");
            }

            Username = "";
            Password = "";
            ConfermaPassoword = "";
            Console.WriteLine("Arrivederci!");
            Menu();
        }

        private static void stampaOrario()
        {
            if (Username == "")
            {
                throw new Exception("Nessun utente loggato");
            }

            Console.WriteLine($"{Username} ha loggato {LoginEffettuata}");
            Menu();

        }
        private static void lastLoginHistory()
        {
            Console.WriteLine("Ultimi 10 accessi:");
            for (int i = 0; i < 10; i++)
            {
                if (LoginHistory[i] != DateTime.MinValue)
                {
                    Console.WriteLine($"{i + 1}: {LoginHistory[i]}");
                    Console.WriteLine("Ciao");
                }
            }
            Menu();
        }

        private static void UpdateLoginHistory(DateTime LoginEffettuata)
        {
            LoginHistory[loginIndex] = LoginEffettuata;
            loginIndex = (loginIndex + 1) % 10;

        }
        static char Choice()
        {
            
            char answer;
            do 
            {
               
                int c = Console.Read();
                
                answer = (char)c;
                
            } while (answer < '1' || answer > '5');
            
            return answer;
        }

    }
}
