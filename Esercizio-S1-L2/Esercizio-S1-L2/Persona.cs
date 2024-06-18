using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_S1_L2
{
    internal class Persona
    {
        private string _nome;
        private string _cognome;
        private int _eta;

        public Persona(string nome, string cognome, int eta)
        {
            this._nome = nome;
            this._cognome = cognome;
            this._eta = eta;
        }
        public string GetNome()
        {
            return _nome; 
        }
        public string GetCognome()
        {
            return _cognome;
        }

        public int GetEta() 
        {
            return _eta;
        }
        public string GetDettagli()
        {
            return $"Nome: {GetNome()}, Cognome: {GetCognome()}, Età: {GetEta()}" ;
        }
    
    }
}
