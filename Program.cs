using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace AddressBook
{
    class Program
    {

        static void Main(string[] args)
        {
            Program p = new Program();
            int ch = 0; string NameofBook, bname_o;
            // To store new address book with name as Key and value as list
            Dictionary<string, List<Contact>> dict = new Dictionary<string, List<Contact>>();

            /// <summary>
            /// Creating Multiple Address Book and saving it with a name
            /// </summary>
            while (ch != 3)
            {
                Console.WriteLine("1. Add a new Address Book");
                Console.WriteLine("2. Add, edit or delete contacts in an exisiting address Book");
                ch = Convert.ToInt32(Console.ReadLine());
                if (ch == 1)//To create new Book
                {
                    Console.WriteLine("Enter the name of the new address book");
                    //Add the name of the new book to be created
                    NameofBook = Console.ReadLine();
                    //Create new List for each new Address Book
                    List<Contact> clist = new List<Contact>();
                    dict.Add(NameofBook, clist);//Add book name as Key and List as value
                }
                if (ch == 2)//To add to existing book
                {
                    Console.WriteLine("Select Book to add, edit or delete contacts");
                    foreach (string Key in dict.Keys)//Display the names of the book
                    {
                        Console.WriteLine(Key);
                    }
                    bname_o = Console.ReadLine();//Enter the name of the book in which you want to add contatct
                    if (dict.ContainsKey(bname_o))
                    {
                        p.addContact(dict[bname_o]);//function call to perform modification in the books

                    }

                }

            }
        }
        /// <summary>
        /// Adding a new contact to the address book and if saved it shows successfully saved
        /// </summary>
        public void addContact(List<Contact> ContList) //To add to exisiting book
        {
            int choice_one = 0;
            while (choice_one != 5)//Iterate till the user exits by inputting choice 5
            {
                Console.WriteLine("Enter your choice");
                Console.WriteLine("1. Enter the contact");
                Console.WriteLine("2. Display contacts");
                Console.WriteLine("3. Edit the contact");
                Console.WriteLine("4. Delete a contact");
                Console.WriteLine("5. Enter the city to display contacts living in it");
                Console.WriteLine("6. Display contacts city wise");
                Console.WriteLine("7. Exit");
                choice_one = Convert.ToInt32(Console.ReadLine());


                switch (choice_one)
                {
                    case 1://TO add new contact
                        string fname, lname, address, city, state, email;
                        long phoneNumber, zip;
                        Console.WriteLine("Enter the contact details");
                        Console.WriteLine("Enter the first name");
                        fname = Console.ReadLine();
                        Console.WriteLine("Enter the last name");
                        lname = Console.ReadLine();
                        int flags = 0;
                        /// <summary>
                        ///Seaarch for first Name if already exist in the address book 
                        ///if present it does not add the contact and returns below message
                        /// </summary>
                        foreach (Contact Name in ContList)
                        {
                            if (Name.getFname().ToLower().Equals(fname.ToLower()) && Name.getLname().ToLower().Equals(lname.ToLower()))
                            {
                                Console.WriteLine("Entry of this name is already present. Please enter a new Name");
                                flags = 1;
                                break;
                            }
                        }
                        if (flags == 0)
                        {
                            Console.WriteLine("Enter the address");
                            address = Console.ReadLine();
                            Console.WriteLine("Enter the city");
                            city = Console.ReadLine();
                            Console.WriteLine("Enter the state");
                            state = Console.ReadLine();
                            Console.WriteLine("Enter the zip code");
                            zip = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Enter the phone number");
                            phoneNumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Enter the EmailId");
                            email = Console.ReadLine();
                            Contact contact = new Contact(fname, lname, address, city, state, zip, phoneNumber, email);
                            Console.WriteLine("Contact Added Successfully");
                            ContList.Add(contact);//Add new contact obj to the list passed in the method
                        }
                        break;
                    /// <summary>
                    /// Displays the entire address Book
                    /// </summary>
                    case 2:
                        foreach (Contact o in ContList)
                        {
                            Console.WriteLine(o.toString());
                        }
                        break;
                    /// <summary>
                    /// To Edit the Contact in the list
                    /// </summary>
                    case 3:
                        Console.WriteLine("Enter the name of the contact to edit");
                        string name = Console.ReadLine();
                        string f_name, l_name, adrs, cty, st, emailId;
                        long phNo, zp;
                        foreach (Contact Object in ContList)
                        {
                            if (Object.getFname().Equals(name))
                            {
                                Console.WriteLine("Enter the new First name");
                                f_name = Console.ReadLine();
                                Object.setFname(f_name);
                                Console.WriteLine("Enter the new Last name");
                                l_name = Console.ReadLine();
                                Object.setLname(l_name);
                                Console.WriteLine("Enter the address");
                                adrs = Console.ReadLine();
                                Object.setAdd(adrs);
                                Console.WriteLine("Enter the new City");
                                cty = Console.ReadLine();
                                Object.setCity(cty);
                                Console.WriteLine("Enter the new State");
                                st = Console.ReadLine();
                                Object.setState(st);
                                Console.WriteLine("Enter the new Zip code");
                                zp = Convert.ToInt64(Console.ReadLine());
                                Object.setZip(zp);
                                Console.WriteLine("Enter the new Phone Number");
                                phNo = Convert.ToInt64(Console.ReadLine());
                                Object.setPhoneNo(phNo);
                                Console.WriteLine("Enter the new EmailId");
                                emailId = Console.ReadLine();
                                Object.setEmailId(emailId);
                            }
                            else
                                Console.WriteLine("Entered First Name is Not Present");
                        }
                        break;
                    /// <summary>
                    ///  Delets the Contact with the given First Name
                    /// </summary>
                    case 4:
                        Console.WriteLine("Enter the name of the contact to be deleted");
                        string delname = Console.ReadLine();
                        bool flag = false;
                        List<Contact> Li = new List<Contact>();
                        foreach (Contact obj in ContList)
                        {
                            if (obj.getFname().Equals(delname))
                            {
                                flag = true;
                                //Adds the contact you want to delete in a list
                                Li.Add(obj);
                            }
                        }
                        //Remove the objects from the list created above from the original list
                        ContList.RemoveAll(i => Li.Contains(i));
                        Console.WriteLine("deleted");
                        if (flag)
                        {
                            Console.WriteLine("Contacts deleted");
                        }
                        break;
                    /// <summary>
                    /// UC8
                    /// Ability to search Person in a City or state across the multiple AddressBook - Search Result can show multiple person
                    /// </summary>
                    case 5:
                        Console.WriteLine("Enter the state and city for displaying contacts");
                        string Sity;
                        string stte;
                        stte = Console.ReadLine();
                        Sity = Console.ReadLine();
                        foreach (Contact c in ContList)
                        {
                            if (c.getCity().ToLower().Equals(Sity.ToLower())|| c.getCity().ToLower().Equals(stte.ToLower()))
                            {
                                Console.WriteLine(c.getFname() + " " + c.getLname());
                            }
                        }
                        break;
                    /// <summary>
                    /// UC10
                    /// Ability to Count Persons by City Maintain Dictionary of City and Person
                    /// </summary>
                    case 6:
                        Console.WriteLine("Displaying the count city wise");
                        Dictionary<string, int> sT = new Dictionary<string, int>();
                        HashSet<string> states = new HashSet<string>();
                        foreach (Contact p in ContList)
                        {
                            states.Add(p.getState());
                        }
                        foreach (string s in states)
                        {
                            List<string> temp = new List<string>();
                            foreach (Contact c in ContList)
                            {
                                if (s.ToLower().Equals(c.getState()))
                                {
                                    temp.Add(c.getFname() + " " + c.getLname());
                                }
                            }
                            int count = temp.Count;
                            sT.Add(s, count);
                        }
                        foreach (KeyValuePair<string, int> kv in sT)
                        {
                            Console.WriteLine("The number of persons in {0} is {1} ", kv.Key, kv.Value);
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
            }
        }
    }
}
