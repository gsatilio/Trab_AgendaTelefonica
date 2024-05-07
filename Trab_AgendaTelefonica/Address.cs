using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trab_AgendaTelefonica
{
    internal class Address
    {
        string postalCode;
        string city;
        string state;
        string street;
        int number;

        public Address(string postalCode, string city, string state, string street, int number)
        {
            this.postalCode = postalCode;
            this.city = city;
            this.state = state;
            this.street = street;
            this.number = number;
        }
        public override string? ToString()
        {
            return $"\nCEP: {postalCode} \nCidade: {city} \nEstado: {state} \nEndereço: {street} \nNúmero: {number}";
        }
    }
}
