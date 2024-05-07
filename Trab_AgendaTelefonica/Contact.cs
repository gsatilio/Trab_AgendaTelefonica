using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Trab_AgendaTelefonica
{
    internal class Contact
    {
        string name;
        Address address;
        string email;
        ContactPhoneList contactPhoneList;
        Contact next;
        public Contact(string name, string email)
        {
            this.name = name;
            this.email = email;
            //this.address = addres;
            //this.contactPhoneList = contactPhoneList;
            next = null;
        }
        public string getName()
        {
            return this.name;
        }
        public void setNext(Contact next)
        {
            this.next = next;
        }
        public Contact getNext()
        {
            return this.next;
        }
        public Address getAddress()
        {
            return address;
        }
        public override string ToString()
        {
            return "\nNome: " + this.name + "\nEndereço: " + "\nEmail: " + this.email;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getEmail()
        {
            return email;
        }
        public void setAddress(Address address)
        {
            this.address = address;
        }
        public void setContactPhoneList(ContactPhoneList contactPhoneList)
        {
            this.contactPhoneList = contactPhoneList;
        }
        public ContactPhoneList GetContactPhoneList()
        {
            return this.contactPhoneList;
        }
    }
}
