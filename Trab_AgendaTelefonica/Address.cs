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
            return $"\nEndereço: \nCEP: {postalCode} \nCidade: {city} \nEstado: {state} \nEndereço: {street} \nBairro: {neighborhood} \nNúmero: {number}";
        }
        public string getPostalCode()
        {
            return this.postalCode;
        }
        public string getCity()
        {
            return this.city;
        }
        public string getState()
        {
            return this.state;
        }
        public string getStreet()
        {
            return this.street;
        }
        public string getNeighborhood()
        {
            return this.neighborhood;
        }
        public int getNumber()
        {
            return this.number;
        }
    }
}
