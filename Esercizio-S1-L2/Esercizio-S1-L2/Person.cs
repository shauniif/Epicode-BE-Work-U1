using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_S1_L2
{
    internal class Person
    {
        private string FirstName {  get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
        public Person() { }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Person (string firstName, string lastName, int age) 
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string Description()
        {
            return $"Mi chiamo {FullName} ed ho {Age} anni";
        }
    }
}
