using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trab_AgendaTelefonica
{
    internal class ContactList
    {
        Contact head;
        Contact tail;

        //ContactPhone phonehead;
        //ContactPhone phonetail;

        public ContactList()
        {
            this.head = null;
            this.tail = null;
        }

        public void Add(Contact contact)
        {
            int compare;
            if (isEmpty())
            {
                this.head = this.tail = contact;
            }
            else
            {
                compare = String.Compare(contact.getName(), head.getName(), comparisonType: StringComparison.OrdinalIgnoreCase); // método comparador de tamanho de string sem case sensitive
                if (compare <= 0)
                {
                    Contact aux = head;
                    aux = head;
                    head = contact;
                    head.setNext(aux);
                }
                else
                {
                    Contact aux = head;
                    Contact prev = head;
                    do
                    {
                        compare = String.Compare(contact.getName(), aux.getName(), comparisonType: StringComparison.OrdinalIgnoreCase); // método comparador de tamanho de string sem case sensitive
                        if (compare > 0)
                        {
                            prev = aux;
                            aux = aux.getNext();
                        }
                    } while (compare > 0 && aux != null);
                    prev.setNext(contact);
                    contact.setNext(aux);
                    if (aux == null)
                    {
                        tail = contact;
                    }
                }
            }
        }
        public void RemoveByName(string name)
        {
            if (!isEmpty())
            {
                if (name == this.head.getName())
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
                    Contact aux = head;
                    Contact prev = head;
                    bool compare;
                    do
                    {
                        compare = name.Equals(aux.getName());
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
                        Console.WriteLine("Nome não existe na lista");
                    }
                }
            }
            else
            {
                Console.WriteLine("A agenda está vazia.");
            }
        }
        public void ModifyByName(string name)
        {
            if (!isEmpty())
            {
                Contact aux = head;
                Contact prev = head;
                bool compare;
                do
                {
                    compare = name.Equals(aux.getName());
                    if (!compare)
                    {
                        prev = aux;
                        aux = aux.getNext();
                    }
                    else
                    {
                        string opt;
                        do
                        {
                            Console.WriteLine(aux.ToString());
                            Console.WriteLine("Deseja alterar o Nome dessa pessoa? (s/n)");
                            opt = Console.ReadLine().ToLower();
                        } while (opt != "s" && opt != "n");
                        if (opt == "s")
                        {
                            Console.WriteLine("Informe o novo Nome para o contato:");
                            aux.setName(Console.ReadLine());
                        }
                        do
                        {
                            Console.WriteLine(aux.ToString());
                            Console.WriteLine("Deseja alterar o Email dessa pessoa? (s/n)");
                            opt = Console.ReadLine().ToLower();
                        } while (opt != "s" && opt != "n");
                        if (opt == "s")
                        {
                            Console.WriteLine("Informe o novo Email para o contato:");
                            aux.setEmail(Console.ReadLine());
                        }
                        do
                        {
                            Console.WriteLine(aux.ToString());
                            Console.WriteLine("Deseja alterar o Endereço dessa pessoa? (s/n)");
                            opt = Console.ReadLine().ToLower();
                        } while (opt != "s" && opt != "n");
                        if (opt == "s")
                        {
                            Console.WriteLine("Informe o novo Endereço para o contato:");
                            aux.setAddress(changeAddress());
                        }

                    }
                } while (!compare && aux != null);
                if (aux == null)
                {
                    Console.WriteLine("Nome não existe na lista");
                }
            }
            else
            {
                Console.WriteLine("A agenda está vazia.");
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

        public void ShowAll()
        {
            Contact aux = head;
            ContactPhoneList contactPhoneList;
            ContactPhone contactPhone;
            Address auxaddress;
            if (!isEmpty())
            {
                do
                {
                    auxaddress = aux.getAddress();
                    contactPhoneList = aux.getContactPhoneList();
                    contactPhone = contactPhoneList.getHead();
                    Console.WriteLine(aux.ToString());
                    Console.WriteLine(auxaddress.ToString());
                    do
                    {
                        Console.WriteLine(contactPhone.getPhone());
                        contactPhone = contactPhone.getNext();
                    } while (contactPhone != null);
                    aux = aux.getNext();
                } while (aux != null);
            }
            else
            {
                Console.WriteLine("Agenda vazia.");
            }
        }
        public void ShowContact(string name)
        {
            bool exists = false;
            Contact aux = head;
            ContactPhoneList contactPhoneList;
            ContactPhone contactPhone;
            Address auxaddress;
            if (!isEmpty())
            {
                do
                {
                    auxaddress = aux.getAddress();
                    if (aux.getName() == name)
                    {
                        contactPhoneList = aux.getContactPhoneList();
                        contactPhone = contactPhoneList.getHead();
                        Console.WriteLine(aux.ToString());
                        Console.WriteLine(auxaddress.ToString());
                        do
                        {
                            Console.WriteLine(contactPhone.getPhone());
                            contactPhone = contactPhone.getNext();
                        } while (contactPhone != null);
                        exists = true;
                    }
                    aux = aux.getNext();
                } while (aux != null);
            }
            if (!exists)
            {
                Console.WriteLine("Contato não localizado.");
            }
        }
        static Address changeAddress()
        {
            string postalCode, city, state, street, neighborhood;
            int number;

            Console.WriteLine("Informe o CEP:");
            postalCode = Console.ReadLine();
            Console.WriteLine("Informe a UF:");
            state = Console.ReadLine();
            Console.WriteLine("Informe a Cidade:");
            city = Console.ReadLine();
            Console.WriteLine("Informe o Endereço:");
            street = Console.ReadLine();
            Console.WriteLine("Informe o Bairro:");
            neighborhood = Console.ReadLine();
            Console.WriteLine("Informe o Número:");
            number = int.Parse(Console.ReadLine());

            Address address = new Address(postalCode, state, city, street, neighborhood, number);
            return address;
        }
    }
}
