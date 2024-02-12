using System;
using System.Security.Cryptography.X509Certificates;


namespace usecase_1
{
    public class contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public contact(string FirstName, string LastName, string address, string city, string state, string zip, string phone_number, string email)
        {

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phone_number = phone_number;
            this.email = email;

        }

        public override string ToString()
        {
            return $"{FirstName}{LastName},{city},{state},{zip},{phone_number},{email}";
        }


    }
