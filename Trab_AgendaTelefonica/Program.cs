using System.Numerics;
using System.Xml.Linq;
using Trab_AgendaTelefonica;

internal class Program
{
    private static void Main(string[] args)
    {
        ContactList contactList = new ContactList();
        int opt;
        do
        {
            Console.Clear();
            Console.WriteLine("1 - Criar Contato");
            Console.WriteLine("2 - Remover Contato");
            Console.WriteLine("3 - Mostrar todos os Contatos");
            Console.WriteLine("4 - Pesquisar Contato");
            Console.WriteLine("5 - Modificar Dados do Contato");
            Console.WriteLine("6 - Modificar Telefones do Contato");
            Console.WriteLine("0 - Sair");
            opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 0:
                    break;
                case 1:
                    contactList.add(createContact());
                    pressToContinue();
                    break;
                case 2:
                    Console.WriteLine("Informe o nome do contato que deseja remover:");
                    contactList.removeByName(Console.ReadLine());
                    pressToContinue();
                    break;
                case 3:
                    contactList.showAll();
                    pressToContinue();
                    break;
                case 4:
                    Console.WriteLine("Informe o nome do contato que deseja pesquisar:");
                    contactList.showContact(Console.ReadLine());
                    pressToContinue();
                    break;
                case 5:
                    Console.WriteLine("Informe o nome do contato que deseja alterar dados:");
                    contactList.modifyByName(Console.ReadLine());
                    pressToContinue();
                    break;
                case 6:
                    changeContactPhoneList(contactList);
                    pressToContinue();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    pressToContinue();
                    break;
            }
        } while (opt != 0);
    }
    static Contact createContact()
    {
        string name, email, phone;
        string postalCode, city, state, street, neighborhood;
        Address address;
        Contact contact;
        ContactPhoneList contactPhoneList;
        int number;
        Console.WriteLine("Informe o nome da pessoa:");
        name = Console.ReadLine();

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

        address = new Address(postalCode, state, city, street, neighborhood, number);

        contactPhoneList = createContactPhoneList();

        Console.WriteLine("Informe o e-mail da pessoa:");
        email = Console.ReadLine();

        contact = new Contact(name, email, contactPhoneList, address);
        return contact;
    }
    static ContactPhoneList createContactPhoneList()
    {
        ContactPhoneList contactPhoneList = new ContactPhoneList();
        string opt;
        int count = 1;
        do
        {
            Console.WriteLine($"\nInforme o {count}o Telefone ");
            contactPhoneList.Add(new ContactPhone(Console.ReadLine()));
            Console.WriteLine("\nDeseja adicionar mais um telefone?");
            Console.WriteLine("[S - Sim] ou [Outra tecla para Não]");
            opt = Console.ReadLine().ToLower();
            count++;
        } while (opt == "s");

        return contactPhoneList;
    }
    static void pressToContinue()
    {
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
    static void changeContactPhoneList(ContactList contactList)
    {
        ContactPhoneList contactPhoneList = new ContactPhoneList(); // cria nova contactPhoneList
        string name, opt;
        int count = 1;
        Console.WriteLine("Informe o nome da pessoa:");
        name = Console.ReadLine();
        if (contactList.findContactByName(name)) // localiza a pessoa pelo nome
        {
            do
            {
                Console.WriteLine($"\nInforme o {count}o Telefone ");
                contactPhoneList.Add(new ContactPhone(Console.ReadLine()));

                Console.WriteLine("\nDeseja adicionar mais um telefone?");
                Console.WriteLine("[S - Sim] ou [Outra tecla para Não]");
                opt = Console.ReadLine().ToLower();
                count++;
            } while (opt == "s");
            contactList.changeContactPhoneList(contactPhoneList, name); // substitui a contactPhoneList pela nova
        } else
        {
            Console.WriteLine("Nome não existe na lista");
        }
    }
}