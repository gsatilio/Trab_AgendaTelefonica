using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trab_AgendaTelefonica
{
    internal class ContactPhoneList
    {
        ContactPhone head;
        ContactPhone tail;

        public ContactPhoneList()
        {
            this.head = null;
            this.tail = null;
        }
        public void Add(ContactPhone contactPhone)
        {
            int compare;
            if (isEmpty())
            {
                this.head = this.tail = contactPhone;
            }
            else
            {
                compare = String.Compare(contactPhone.getPhone(), head.getPhone(), comparisonType: StringComparison.OrdinalIgnoreCase); // método comparador de tamanho de string sem case sensitive
                if (compare <= 0)
                {
                    ContactPhone aux = head;
                    aux = head;
                    head = contactPhone;
                    head.setNext(aux);
                }
                else
                {
                    ContactPhone aux = head;
                    ContactPhone prev = head;
                    do
                    {
                        compare = String.Compare(contactPhone.getPhone(), aux.getPhone(), comparisonType: StringComparison.OrdinalIgnoreCase); // método comparador de tamanho de string sem case sensitive
                        if (compare > 0)
                        {
                            prev = aux;
                            aux = aux.getNext();
                        }
                    } while (compare > 0 && aux != null);
                    prev.setNext(contactPhone);
                    contactPhone.setNext(aux);
                    if (aux == null)
                    {
                        tail = contactPhone;
                    }
                }
            }
        }
        public void RemoveByPhone(string phone)
        {
            if (!isEmpty())
            {
                if (phone == this.head.getPhone())
                {
                    if (head == tail)
                    {
                        head = tail = null;
                    }
                    else
                    {
                        head = head.getNext();
                    }
                }
                else
                {
                    ContactPhone aux = head;
                    ContactPhone prev = head;
                    bool compare;
                    do
                    {
                        compare = phone.Equals(aux.getPhone());
                        if (!compare)
                        {
                            prev = aux;
                            aux = aux.getNext();
                        }
                        else
                        {
                            prev.setNext(aux.getNext());
                            if (prev.getNext() == null)
                            {
                                tail = prev;
                            }
                        }
                    } while (!compare && aux != null);
                    if (aux == null)
                    {
                        Console.WriteLine("Numero não existe na lista");
                    }
                }
            }
        }
        bool isEmpty()
        {
            if (this.head == null && this.tail == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ExistsContact(string name)
        {
            bool exists = false;
            ContactPhone aux = head;
            if (!isEmpty())
            {
                do
                {
                    if (aux.getName() == name)
                    {
                        exists = true;
                        Console.WriteLine(aux.ToString());
                    }
                    aux = aux.getNext();
                } while (aux != null);
            }
            if (!exists)
            {
                return false;
            } else
            {
                return true;
            }
        }
        public ContactPhone getHead()
        {
            return head;
        }
    }
}