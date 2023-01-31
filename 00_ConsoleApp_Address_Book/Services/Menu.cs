using _00_ConsoleApp_Address_Book.Interfaces;
using _00_ConsoleApp_Address_Book.Models;
using Newtonsoft.Json;

namespace _00_ConsoleApp_Address_Book.Services;


public class Menu
{
    public List<ContactPerson> contacts = new List<ContactPerson>();             //Skapa lista
    private FileService file = new FileService();                                   //Spara data

    public string FilePath { get; set; } = null!;
    public void WelcomeMenu()
    {
        try
        {
            contacts = JsonConvert.DeserializeObject<List<ContactPerson>>(file.Read(FilePath))!;
        }
        catch { }

        Console.WriteLine("Välkommen till Adressboken");
        Console.WriteLine("1. Skapa en kontakt");
        Console.WriteLine("2. Visa alla kontakter");
        Console.WriteLine("3. Visa en specifik kontakt");
        Console.WriteLine("4. Ta bort en specifik kontakt");
        Console.Write("Välj ett av alternativen ovan: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1": OptionOne(); break;
            case "2": OptionTwo(); break;
            case "3": OptionThree(); break;
            case "4": OptionFour(); break;
        }
    }

    private void OptionOne()
    {
        Console.Clear();
        Console.WriteLine("Lägg till en ny kontakt");

        ContactPerson contact = new ContactPerson();
        Console.Write("Ange Förnamn: ");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Ange Efternamn: ");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Ange E-postadress: ");
        contact.Email = Console.ReadLine() ?? "";
        Console.Write("Ange Telefonnummer: ");
        contact.Phone = Console.ReadLine() ?? "";
        Console.Write("Ange Adress: ");
        contact.Address = Console.ReadLine() ?? "";

        contacts.Add(contact);
        file.Save(FilePath, JsonConvert.SerializeObject(contacts));

        Console.WriteLine(" ");
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("Kontakten har lagts till");
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn");
        Console.ReadKey();
    }


    private void OptionTwo()
    {
        Console.Clear();
        Console.WriteLine("Alla kontakter i listan: ");
        Console.WriteLine("");

        contacts!.ForEach(contact => Console.WriteLine("Namn: " + contact.FirstName + " " + contact.LastName + ", " + "Email: " + contact.Email));

        Console.WriteLine("");
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
        Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn");
        Console.ReadKey();
    }

    private void OptionThree()
    {
        Console.Clear();
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}>");
        }
        Console.Write("\nAnge förnamn på personen du söker efter: ");
        var contactName = Console.ReadLine();
        Console.WriteLine("");

        if (contactName !=null && contactName != "") 
        {
            string capitalChar = capitalFirstLetter(contactName);
            var foundName = contacts.Find(contact => contact.FirstName.ToLower() == contactName.ToLower());

            if (foundName != null)
            {
                Console.WriteLine("Förnamn: " + foundName!.FirstName);
                Console.WriteLine("Efternamn: " + foundName!.LastName);
                Console.WriteLine("E-postadress: " + foundName!.Email);
                Console.WriteLine("Telefonnummer: " + foundName!.Phone);
                Console.WriteLine("Adress: " + foundName!.Address);

                Console.WriteLine("______________________________________________________________________");
                Console.WriteLine("Tryck på valfri tangent för att komma tillbaka till huvudmenyn");
            }
            else
            {
                Console.WriteLine($"\nKunde inte hitta kontakt med namnet {capitalChar} i listan");
            }
        } 
        
        Console.ReadKey();
    }

    private void OptionFour()
    {
        Console.Clear();

        foreach(var contact in contacts)
        {
            Console.WriteLine($"{ contact.FirstName } {contact.LastName} <{contact.Email}>");
        }

        Console.Write("\nAnge E-postadress på personen du vill ta bort: ");
        var result = Console.ReadLine();
        Console.Write("Vill du verkligen ta bort personen med E-postadress: " + result + " " + "Från listan? (y/n): ");
        var answer = Console.ReadLine();

        if (answer == "y")
        {
            if (result != null && result !="")
            {
                string capitalChar = capitalFirstLetter(result);
                var foundEmail = contacts.Find(contact => contact.Email.ToLower() == result.ToLower());

                if (foundEmail != null)
                {
                    contacts.Remove(foundEmail);
                    Console.WriteLine("");
                    Console.WriteLine("Personen har tagist bort från listan.");
                    Console.WriteLine("______________________________________________________________________");
                    file.Save(FilePath, JsonConvert.SerializeObject(contacts));
                }
                else
                {
                    Console.WriteLine($"\nKunde inte hitta kontakt med E-postadress {capitalChar} i listan");
                }
            }
        }

        else if (answer == "n") 
        {
            Console.WriteLine("");
            Console.WriteLine("Ingen ändring har skett");
            Console.WriteLine("______________________________________________________________________");
        }

        Console.WriteLine("\nTryck på valfri tangent för att komma tillbaka till huvudmenyn");
        Console.ReadKey();
    }




    private string capitalFirstLetter (string v)
    {
        string firstLetter = char.ToUpper(v.First()) + v.Substring(1).ToLower();
        return firstLetter;
    }

}
