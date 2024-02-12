        public void PrintContacts()
        {
            foreach (contact contact in contacts)
            {
                if (contact != null)
                {
                    Console.WriteLine(contact);
                }
            }
        }


    }



    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook(100);

            addressBook.addContact(new contact("harsha", "BC", "123 Main rd", "banglore", "NY", "12345", "555 - 1234", ".shashankpd@example.com"));
            addressBook.addContact(new contact("shashank", "pd", "55 main road", "banglore", "NY", "12345", "968624", "harshabc@example.com"));
            addressBook.PrintContacts();

            int i = 1;
            while (i == 1)
            {

                Console.WriteLine("Choose one:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display Contacts");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter details for the new contact:");
                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Address: ");
                        string address = Console.ReadLine();
                        Console.Write("City: ");
                        string city = Console.ReadLine();
                        Console.Write("State: ");
                        string state = Console.ReadLine();
                        Console.Write("Zip: ");
                        string zip = Console.ReadLine();
                        Console.Write("Phone Number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        addressBook.addContact(new contact(firstName, lastName, address, city, state, zip, phoneNumber, email));
                        Console.WriteLine("Contact added successfully.");
                        break;

                    case 2:
                        Console.WriteLine("Enter the details of the contact you want to edit:");
                        Console.Write("First Name: ");
                        string editFirstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string editLastName = Console.ReadLine();

                        Console.WriteLine("Enter new details:");
                        Console.Write("Address: ");
                        string newAddress = Console.ReadLine();
                        Console.Write("City: ");
                        string newCity = Console.ReadLine();
                        Console.Write("State: ");
                        string newState = Console.ReadLine();
                        Console.Write("Zip: ");
                        string newZip = Console.ReadLine();
                        Console.Write("Phone Number: ");
                        string newPhoneNumber = Console.ReadLine();
                        Console.Write("Email: ");
                        string newEmail = Console.ReadLine();

                        addressBook.EditContact(editFirstName, editLastName, newAddress, newCity, newState, newZip, newPhoneNumber, newEmail);
                        break;

                    case 3:
                        Console.WriteLine("Enter the details of the contact you want to delete:");
                        Console.Write("First Name: ");
                        string deleteFirstName = Console.ReadLine();
                        Console.Write("Last Name: ");
                        string deleteLastName = Console.ReadLine();

                        addressBook.DeleteContact(deleteFirstName, deleteLastName);
                        break;

                    case 4:
                        Console.WriteLine("All Contacts:");
                        addressBook.PrintContacts();
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.WriteLine("do you want to continue, enter 1");

                i = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
