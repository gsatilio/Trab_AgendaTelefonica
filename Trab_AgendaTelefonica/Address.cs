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
        string neighborhood;
        int number;

        public Address(string postalCode, string city, string state, string street, string neighborhood, int number)
        {
            this.postalCode = postalCode;
            this.city = city;
            this.state = state;
            this.street = street;
            this.neighborhood = neighborhood;
            this.number = number;
        }
        public override string? ToString()
        {
            return $"Endereço: \nCEP: {postalCode} \nCidade: {city} \nEstado: {state} \nEndereço: {street} \nBairro: {neighborhood} \nNúmero: {number}";
        }
    }
}
