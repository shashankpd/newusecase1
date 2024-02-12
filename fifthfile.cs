public void DeleteContact(string firstName, string lastName)
{
    for (int i = 0; i < count; i++)
    {
        if (contacts[i].FirstName == firstName && contacts[i].LastName == lastName)
        {
            
            for (int j = i; j < count - 1; j++)
            {
                contacts[j] = contacts[j + 1];
            }
           
            contacts[count - 1] = null;
            count--;
            Console.WriteLine("Contact deleted successfully.");
            return;
        }
    }
    Console.WriteLine("Contact not found.");
}
