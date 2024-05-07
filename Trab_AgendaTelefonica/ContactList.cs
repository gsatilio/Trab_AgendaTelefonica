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

        public void add(Contact contact)
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
        public void removeByName(string name)
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
        public void modifyByName(string name)
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

        public void showAll()
        {
            Contact aux = head;
            ContactPhoneList contactPhoneList;
            ContactPhone contactPhone;
            Address auxaddress;
            int count;
            if (!isEmpty())
            {
                do
                {
                    count = 0;
                    auxaddress = aux.getAddress(); // pega o objeto endereço do Contato
                    contactPhoneList = aux.getContactPhoneList(); // pega o objeto ContactPhoneList do Contato
                    contactPhone = contactPhoneList.getHead(); // pega o head, primeiro item do ContactPhoneList
                    Console.WriteLine(aux.ToString()); // imprime dados do Contato
                    Console.WriteLine(auxaddress.ToString()); // imprime dados do Endereço do Contato
                    Console.WriteLine("Telefone(s):");
                    do
                    {
                        count++;
                        Console.WriteLine(count + "o " + contactPhone.ToString()); // imprime telefones do ContactPhone
                        contactPhone = contactPhone.getNext();
                    } while (contactPhone != null);
                    aux = aux.getNext();
                    Console.WriteLine("------------------------");
                } while (aux != null);
            }
            else
            {
                Console.WriteLine("Agenda vazia.");
            }
        }
        public void showContact(string name)
        {
            bool exists = false;
            Contact aux = head;
            ContactPhoneList contactPhoneList;
            ContactPhone contactPhone;
            Address auxaddress;
            int count;
            if (!isEmpty())
            {
                do
                {
                    count = 0;
                    auxaddress = aux.getAddress();
                    if (aux.getName() == name)
                    {
                        contactPhoneList = aux.getContactPhoneList();
                        contactPhone = contactPhoneList.getHead();
                        Console.WriteLine(aux.ToString());
                        Console.WriteLine(auxaddress.ToString());
                        Console.WriteLine("Telefone(s):");
                        do
                        {
                            count++;
                            Console.WriteLine(count + "o " + contactPhone.ToString());
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
        public bool findContactByName(string name)
        {
            bool exists = false;
            Contact aux = head;
            if (!isEmpty())
            {
                do
                {
                    if (aux.getName() == name)
                    {
                        exists = true;
                    }
                    aux = aux.getNext();
                } while (aux != null);
            }
            return exists;
        }
        public void changeContactPhoneList(ContactPhoneList contactPhoneList, string name)
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
                        aux.setContactPhoneList(contactPhoneList);
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
    }
}
