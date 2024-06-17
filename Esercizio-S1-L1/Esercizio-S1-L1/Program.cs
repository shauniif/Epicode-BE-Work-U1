// See https://aka.ms/new-console-template for more information

using Esercizio_S1_L1;

class Program
{
    public static void Main(string[] args)
    {
        Atleta atleta1 = new Atleta();
        atleta1.Nome = "Mario";
        atleta1.Cognome = "Rossi";
        atleta1.Età = 25;
        atleta1.Sport = "Wrestling";

        atleta1.DescrizioneAtleta();

        Dipentente dipentente1 = new Dipentente();
        dipentente1.Nome = "Alessia";
        dipentente1.Cognome = "Verdi";
        dipentente1.Età = 22;
        dipentente1.Ruolo = "Segretaria";

        dipentente1.DescrizioneDipendente();

        Animale animale1 = new Animale();
        animale1.Nome = "Bau";
        animale1.Età = 3;
        animale1.Razza = "gatto siamese";
        animale1.CiboPreferito = "latte";
        animale1.DescrizioneAnimale();


        Automobile automobile1 = new Automobile();
        automobile1.Modello = "Fiat Punto";
        automobile1.CasaAutomobilista = "Fiat";
        automobile1.AnnoDiImmatricolazione = 2022;
        automobile1.Colore = "Rosso";

        automobile1.DescrizioneAuto();
        // metto un commento a caso
    }
}
