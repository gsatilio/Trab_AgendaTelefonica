using System.Xml.Linq;
using Trab_AgendaTelefonica;

internal class Program
{
    private static void Main(string[] args)
    {
        ContactList contactList = new ContactList();
        ContactPhoneList contactPhoneList = new ContactPhoneList();
        int opt;
        string name;
        do
        {
            Console.Clear();
            Console.WriteLine("1 - Criar Contato");
            Console.WriteLine("2 - Remover Contato");
            Console.WriteLine("3 - Mostrar todos os Contatos");
            Console.WriteLine("4 - Pesquisar Contato");
            Console.WriteLine("5 - Modificar Dados do Contato");
            Console.WriteLine("0 - Sair");
            opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Informe o nome da pessoa:");
                    name = Console.ReadLine();
                    contactList.Add(createContact(name));
                    contactPhoneList.Add(createContactPhone(name, true));
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Informe o nome do contato que deseja remover:");
                    contactList.RemoveByName(Console.ReadLine());
                    Console.ReadKey();
                    break;
                case 3:
                    contactList.ShowAll();
                    contactPhoneList.ShowAll();
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("Informe o nome do contato que deseja pesquisar:");
                    contactList.ShowContact(Console.ReadLine());
                    Console.ReadKey();
                    break;
                case 5:
                    Console.WriteLine("Informe o nome do contato que deseja alterar dados:");
                    contactList.ModifyByName(Console.ReadLine());
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    break;
            }
        } while (opt != 0);
    }
    static Contact createContact(string name)
    {
        string email, phone;
        string postalCode, city, state, street;
        Address address;
        Contact contact;
        ContactPhoneList contactPhoneList;
        int number;

        Console.WriteLine("Informe o CEP:");
        postalCode = Console.ReadLine();
        Console.WriteLine("Informe a UF:");
        state = Console.ReadLine();
        Console.WriteLine("Informe a Cidade:");
        city = Console.ReadLine();
        Console.WriteLine("Informe o Endereço:");
        street = Console.ReadLine();
        Console.WriteLine("Informe o Número:");
        number = int.Parse(Console.ReadLine());

        address = new Address(postalCode, state, city, street, number);

        Console.WriteLine("Informe o e-mail da pessoa:");
        email = Console.ReadLine();

        contact = new Contact(name, email);
        return contact;
    }
    static ContactPhone createContactPhone(string name, bool newContact)
    {
        string phone;
        ContactPhoneList contactPhoneList = new ContactPhoneList();
        ContactPhone contactPhone = null;
        if (!newContact && !contactPhoneList.ExistsContact(name))
        {
            Console.WriteLine("Pessoa não cadastrada.");
        }
        else
        {
            Console.WriteLine("Informe o telefone da pessoa:");
            phone = Console.ReadLine();
            contactPhone = new ContactPhone(name, phone);
        }
        return contactPhone;
    }
}