
//using Hashset

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
public class contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }

    public contact(string firstname, string lastname, string email, string phoneNumber, string address, string city, string state, string postalcode)
    {
        FirstName = firstname;
        LastName = lastname;
        Email = email;
        Phone = phoneNumber;
        Address = address;
        City = city;
        State = state;
        PostalCode = postalcode;

    }

    public override string ToString()
    {
        return $"{FirstName},{LastName},{Email},{Phone},{Address},{City},{State},{PostalCode}";
    }

    public static bool isnamevalid(string name)
    {
       return  !string.IsNullOrEmpty(name) && Regex.IsMatch(name, ("[A-Z]{1}[a-z]"));
    }

    public static bool isvalidlastName(string lname)
    {
        return!string.IsNullOrEmpty(lname) && Regex.IsMatch(lname, ("[A-Z]{1}[a-z]"));
    }

    public static bool isvalidEmail(string email)
    {
        return !string.IsNullOrEmpty(email) && Regex.IsMatch(email, ("[a-z0-9]+@[gamil.com]"));

    }
    public static bool isvalidNumber(string number)
    {
        return !string.IsNullOrEmpty(number) && Regex.IsMatch(number, ("[0-9]{10}"));

    }

    public static bool isvalidPin(string pin)
    {
        return !string.IsNullOrEmpty(pin) && Regex.IsMatch(pin, ("[0-9]{6}"));

    }
}

public class HsphoneBook
{
   public HashSet<contact> hscontacts;
public HsphoneBook() 
    {
        hscontacts= new HashSet<contact>();
    }

   
    public void AddContact(contact Newcontacts)
    {
        if (hscontacts.Any(c => c.FirstName == Newcontacts.FirstName && c.LastName == Newcontacts.LastName))
        {
            Console.WriteLine("person with the same name exists .try with other name");
            return;
        }

        string path = "E:\\Addressbook.txt";
        try
        {
            using (StreamWriter strm = new StreamWriter(path,true))
            {
                
                    strm.WriteLine(Newcontacts);
                
                Console.WriteLine("sucessfully addes to txt file");
            }
        } 
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        

        hscontacts.Add(Newcontacts);
        Console.WriteLine("contact addes successfully");
    }

    public void EditContacts(contact otherinfo)
    {


        foreach (var item in hscontacts)
        {
            if (item.FirstName == otherinfo.FirstName && item.LastName == otherinfo.LastName)
            {
                item.FirstName = otherinfo.FirstName;
                item.LastName = otherinfo.LastName;
                item.Email = otherinfo.Email;
                item.Phone = otherinfo.Phone;
                item.Address = otherinfo.Address;
                item.City = otherinfo.City;
                item.State = otherinfo.State;
                item.PostalCode = otherinfo.PostalCode;
                Console.WriteLine("updated successfully");
            }

            string pathcsv= "E:\\editedAddressbook.csv";

            try
            {
                using (StreamWriter csvwrt = new StreamWriter(pathcsv, true))
                {
                    csvwrt.WriteLine("Name,LastName,Email,phone,Address,city,state,zip");
                    csvwrt.WriteLine(otherinfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public void Deletecontacts(string Dfname,string Dlname)
    {

        contact contodlt = null;
        foreach (var item in hscontacts)
        {
            if (item.FirstName == Dfname && item.LastName == Dlname)
            { 
             contodlt= item;
                break;
            }
        }
        if (contodlt != null)
        {
            hscontacts.Remove(contodlt);
            Console.WriteLine("deleted successfully");
        }
        else
        { 
        Console.WriteLine("No data to delete");
        }
    }

    public void Display()
    {

        foreach (var item in hscontacts)
        {
            Console.WriteLine(item);
        }
    }

    public void citystateview(string city,string state)
    {

        var view = hscontacts.Where(a => a.City==city && a.State==state);
        foreach (var val in view) 
        {
            Console.WriteLine($"name: {val.FirstName}");
        }
        /*foreach (var item in hscontacts)
        {
            if (item.City == city && item.State == state)
            {
                Console.WriteLine(item.FirstName);
            }
            else
            {
                Console.WriteLine("no contacts found in such city and state names");
            }
        }*/
    }

    public void countcity(string city)
    {
        var countpeople=hscontacts.Where(a => a.City==city);

        foreach (var val in countpeople)
        {
            Console.WriteLine(val.FirstName);
        }
       /* int count = 0;
        foreach (var item in hscontacts)
        {
            if (item.City == city)
            {
                count++;
            }
        }
        Console.WriteLine($"the nimber of people in {city} is :{count}");
    }*/
}

    public class program
    {
        public static void Main(string[] args)
        {
            HsphoneBook hsphoneBook = new HsphoneBook();

            int repeat = 1;

            while (repeat == 1)
            {


                Console.WriteLine("select 1 for ADDing");
                Console.WriteLine("select 2 for editing");
                Console.WriteLine("select 3 for deleting");
                Console.WriteLine("select 4 for display");
                Console.WriteLine("select 5 to view cantact by city and state");
                Console.WriteLine("select 6 to display count of  given city");

                int ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Console.WriteLine("enter first name");
                        string fname = Console.ReadLine();
                        if (!contact.isnamevalid(fname))
                        {
                            Console.WriteLine("invalid Name");
                            break;
                        }

                        Console.WriteLine("enter last name name");
                        string lname = Console.ReadLine();
                        if (!contact.isvalidlastName(lname))
                        {
                            Console.WriteLine("Invalid Last Name");
                            break;
                        }



                        Console.WriteLine("enter email");
                        string email = Console.ReadLine();
                        if (!contact.isvalidEmail(email))
                        {
                            Console.WriteLine("invalid email");
                            break;
                        }


                        Console.WriteLine("enter number");
                        string number = Console.ReadLine();
                        if (!contact.isvalidNumber(number))
                        {
                            Console.WriteLine("Invalid number");
                            break;
                        }


                        Console.WriteLine("enter the address");
                        string addres = Console.ReadLine();

                        Console.WriteLine("enter the city");
                        string city = Console.ReadLine();

                        Console.WriteLine("enter the state");
                        string state = Console.ReadLine();

                        Console.WriteLine("enter the pin");
                        string pin = Console.ReadLine();
                        if (!contact.isvalidPin(pin))
                        {
                            Console.WriteLine("invalid pin");
                            break;
                        }

                        contact newcontact = new contact(fname, lname, email, number, addres, city, state, pin);
                        hsphoneBook.AddContact(newcontact);

                        break;

                    case 2:

                        Console.WriteLine("enter the name");
                        string checkname = Console.ReadLine();

                        Console.WriteLine("enter the new info");

                        Console.WriteLine("enter the name");
                        string fnameEdit = Console.ReadLine();

                        Console.WriteLine("enter the lastname");
                        string lnameEdit = Console.ReadLine();


                        Console.WriteLine("enter the email");
                        string emailEdit = Console.ReadLine();

                        Console.WriteLine("enter the ph number");
                        string numberEdit = Console.ReadLine();

                        Console.WriteLine("enter the address");
                        string addresEdit = Console.ReadLine();

                        Console.WriteLine("enter the city");
                        string cityEdit = Console.ReadLine();

                        Console.WriteLine("enter the state");
                        string stateEdit = Console.ReadLine();

                        Console.WriteLine("enter the pin");
                        string pinEdit = Console.ReadLine();



                        contact editinfo = new contact(fnameEdit, lnameEdit, emailEdit, numberEdit, addresEdit, cityEdit, stateEdit, pinEdit);
                        hsphoneBook.EditContacts(editinfo);
                        break;

                    case 3:

                        Console.WriteLine("enter the name to delete");
                        string fnameTodelete = Console.ReadLine();

                        Console.WriteLine("enter the name to delete");
                        string lnameTodelete = Console.ReadLine();


                        hsphoneBook.Deletecontacts(fnameTodelete, lnameTodelete);

                        break;

                    case 4:
                        Console.WriteLine("all contacts");
                        hsphoneBook.Display();

                        break;

                    case 5:

                        Console.WriteLine("Enter city name");
                        string citys = Console.ReadLine();

                        Console.WriteLine("Enter state name");
                        string states = Console.ReadLine();
                        hsphoneBook.citystateview(citys, states);


                        break;

                    case 6:

                        Console.WriteLine("enter city name");
                        string citycount = Console.ReadLine();
                        hsphoneBook.countcity(citycount);
                        break;

                }
                Console.WriteLine("enter 1 for continue");
                repeat = int.Parse(Console.ReadLine());

                
            }

        }
    }
}