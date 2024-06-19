namespace Esercizio_S1_L2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona("Mario", "Rossi", 25);
            Console.WriteLine("Nome: " +  persona.GetNome());
            Console.WriteLine(persona.GetDettagli());

            Person persona2 = new Person("Luigi", "Verdi", 30);

            Console.WriteLine(persona2.Description());


            TransformNumber translator = new TransformNumber();
            Console.WriteLine(translator.Translate(0));
            Console.WriteLine(translator.Translate(-10));
            for (int i = 1; i < 1000; i++)
            {
                Console.WriteLine(translator.Translate(i));
                // commento random

            }
        }
    }
}
