using System.Numerics;
using System.Xml.Linq;
using Trab_AgendaTelefonica;

internal class Program
{
    private static void Main(string[] args)
    {
        ContactList contactList = new ContactList();
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
            Console.WriteLine("6 - Modificar Telefones do Contato");
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
                    pressToContinue();
                    break;
                case 2:
                    Console.WriteLine("Informe o nome do contato que deseja remover:");
                    contactList.RemoveByName(Console.ReadLine());
                    pressToContinue();
                    break;
                case 3:
                    contactList.ShowAll();
                    pressToContinue();
                    break;
                case 4:
                    Console.WriteLine("Informe o nome do contato que deseja pesquisar:");
                    contactList.ShowContact(Console.ReadLine());
                    pressToContinue();
                    break;
                case 5:
                    Console.WriteLine("Informe o nome do contato que deseja alterar dados:");
                    contactList.ModifyByName(Console.ReadLine());
                    pressToContinue();
                    break;
                case 6:
                    Console.WriteLine("Informe o nome do contato que deseja pesquisar:");
                    //editPhoneContact();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    pressToContinue();
                    break;
            }
        } while (opt != 0);
    }
    static Contact createContact(string name)
    {
        string email, phone;
        string postalCode, city, state, street, neighborhood;
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
        Console.WriteLine("Informe o Bairro:");
        neighborhood = Console.ReadLine();
        Console.WriteLine("Informe o Número:");
        number = int.Parse(Console.ReadLine());

        address = new Address(postalCode, state, city, street, neighborhood, number);

        contactPhoneList = CreateContactPhoneList();

        Console.WriteLine("Informe o e-mail da pessoa:");
        email = Console.ReadLine();

        contact = new Contact(name, email, contactPhoneList, address);
        return contact;
    }
    static ContactPhoneList CreateContactPhoneList()
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
}