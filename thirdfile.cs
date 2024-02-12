 public class AddressBook
 {
     private contact[] contacts;
     private int count;

     public AddressBook(int size)
     {
         contacts = new contact[size];
         count = 0;
     }
     public void addContact(contact contact)
     {
         if (count < contacts.Length)
         {
             contacts[count++] = contact;
             return;

         }
         else
         {
             Console.WriteLine("Address book is full");
         }
     }
