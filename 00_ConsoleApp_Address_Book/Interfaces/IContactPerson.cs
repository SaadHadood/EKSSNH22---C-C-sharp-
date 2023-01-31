namespace _00_ConsoleApp_Address_Book.Interfaces;

internal interface IContactPerson
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string Phone { get; set; }
    string Address { get; set; }
}
