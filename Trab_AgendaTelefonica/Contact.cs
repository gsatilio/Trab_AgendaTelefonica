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
        ContactPhoneList contactPhoneList;
        Address address;
        string email;
        Contact next;
        public Contact(string name, string email, ContactPhoneList contactPhoneList, Address address)
        {
            this.name = name;
            this.email = email;
            this.contactPhoneList = contactPhoneList;
            this.address = address;
            next = null;
        }
        public Contact(ContactPhoneList contactPhoneList)
        {
            this.contactPhoneList = contactPhoneList;
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
        public void setName(string name)
        {
            this.name = name;
        }
        public void setEmail(string email)
        {
            this.email = email;
        }
        public void setAddress(Address address)
        {
            this.address = address;
        }
        public void setContactPhoneList(ContactPhoneList contactPhoneList)
        {
            this.contactPhoneList = contactPhoneList;
        }
        public ContactPhoneList getContactPhoneList()
        {
            return this.contactPhoneList;
        }
        public override string ToString()
        {
            return "\nNome: " + this.name + "\nEmail: " + this.email;
        }
    }
}
