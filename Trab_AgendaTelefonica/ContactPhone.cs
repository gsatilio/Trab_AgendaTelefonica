using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trab_AgendaTelefonica
{
    internal class ContactPhone
    {
        string phone;
        ContactPhone next;

        public ContactPhone(string phone)
        {
            this.phone = phone;
        }
        public override string ToString()
        {
            return "\nTelefone: " + this.phone;
        }
        public string getPhone()
        {
            return "Telefone: " + this.phone;
        }
        public void setPhone(string phone)
        {
            this.phone = phone;
        }
        public string getName()
        {
            return this.phone;
        }
        public void setNext(ContactPhone next)
        {
            this.next = next;
        }
        public ContactPhone getNext()
        {
            return this.next;
        }
    }
}
