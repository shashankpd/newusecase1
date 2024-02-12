public void EditContact(string firstName, string lastName, string newAddress, string newCity, string newState, string newZip, string newPhoneNumber, string newEmail)
{
    for (int i = 0; i < count; i++)
    {
        if (contacts[i].FirstName == firstName && contacts[i].LastName == lastName)
        {
            contacts[i].address = newAddress;
            contacts[i].city = newCity;
            contacts[i].state = newState;
            contacts[i].zip = newZip;
            contacts[i].phone_number = newPhoneNumber;
            contacts[i].email = newEmail;
            Console.WriteLine("Contact updated successfully.");
            return;
        }
    }
    Console.WriteLine("Contact not found.");
}
