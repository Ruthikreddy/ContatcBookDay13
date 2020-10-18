using System;
using System.Collections.Generic;

class AddressPrompt
{
    public static Dictionary<string, AddressBook> addressBooks;
    AddressBook book;

    public AddressPrompt()
    {
        book = new AddressBook();
    }

    static void Main(string[] args)
    {
        addressBooks = new Dictionary<string, AddressBook>();

        Console.WriteLine("Welcome to Address Book System!");

        var quit = false;

        while (!quit)
        {
            Console.Write("Choose an option\n1.Create New Address Book\n2.Quit\nEnter Your Option :");
            var input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Write("Enter a name for your address book :");
                    var name = Console.ReadLine();
                    addressBooks.Add(name, new AddressBook());
                    quit = true;
                    break;
                case 2:
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }

        string selection = "";
        AddressPrompt prompt = new AddressPrompt();

        prompt.displayMenu();
        while (!selection.ToUpper().Equals("Q"))
        {
            Console.WriteLine("Selection: ");
            selection = Console.ReadLine();
            prompt.performAction(selection);
        }
    }

    void displayMenu()
    {
        Console.WriteLine("Main Menu");
        Console.WriteLine("=========");
        Console.WriteLine("A - Add an Address");
        Console.WriteLine("D - Delete an Address");
        Console.WriteLine("E - Edit an Address");
        Console.WriteLine("L - List All Addresses");
        Console.WriteLine("Q - Quit");
    }

    void performAction(string selection)
    {
        string Firstname = "";
        string lastName = "";
        string address = "";
        string city = "";
        string state = "";
        int zip = 0;
        double phoneNo = 0;
        string eMail = "";
        switch (selection.ToUpper())
        {
            case "A":
                Console.WriteLine("Enter FirstName: ");
                Firstname = Console.ReadLine();
                Console.WriteLine("Enter LastName: ");
                lastName = Console.ReadLine();
                Console.WriteLine("Enter Address: ");
                address = Console.ReadLine();
                Console.WriteLine("Enter City: ");
                city = Console.ReadLine();
                Console.WriteLine("Enter State: ");
                state = Console.ReadLine();
                Console.WriteLine("Enter Zip: ");
                zip = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter PhoneNo: ");
                phoneNo = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Email: ");
                eMail = Console.ReadLine();


                if (book.add(Firstname, lastName, address, city, state, zip, phoneNo, eMail))
                {
                    Console.WriteLine("Address successfully added!");
                }
                else
                {
                    Console.WriteLine("An address is already on file for {0}.", Firstname);
                }
                break;
            case "D":
                Console.WriteLine("Enter Name to Delete: ");
                Firstname = Console.ReadLine();
                if (book.remove(Firstname))
                {
                    Console.WriteLine("Address successfully removed");
                }
                else
                {
                    Console.WriteLine("Address for {0} could not be found.", Firstname);
                }
                break;
            case "L":
                if (book.isEmpty())
                {
                    Console.WriteLine("There are no entries.");
                }
                else
                {
                    Console.WriteLine("Addresses:");
                    book.list((a) => Console.WriteLine("{0} - {1}-{2}--{3}--{4}-{5}--{6}--{7}--{8}", a.Firstname, a.Lastname,a.address,a.city,a.email,a.state,a.zip,a.phoneNo,a.email));
                }
                break;
            case "E":
                Console.WriteLine("Enter Name to Edit: ");
                Firstname = Console.ReadLine();
                Address  addr = book.find(Firstname);
                if (addr == null)
                {
                    Console.WriteLine("Address for {0} count not be found.", Firstname);
                }
                else
                {
                    Console.WriteLine("Enter new Address: ");
                    addr.Lastname = Console.ReadLine();
                    Console.WriteLine("Address updated for {0}", Firstname);
                }
                break;
        }
    }
}