using _00_ConsoleApp_Address_Book.Models;
using _00_ConsoleApp_Address_Book.Services;

namespace ConsoleApp.Tests__xUnit
{
    public class AddressBook_Tests
    {
        private Menu addressBook;
        ContactPerson contact;

        public AddressBook_Tests()
        {
            // arrange
            addressBook = new Menu();
            contact = new ContactPerson();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            // act
            addressBook.contacts.Add(contact);
            addressBook.contacts.Add(contact);

            // assert
            Assert.Equal(2, addressBook.contacts.Count);
        }

        [Fact]
        public void Should_Remove_Contact_From_List()
        {
            // arrange
            addressBook.contacts.Add(contact);
            addressBook.contacts.Add(contact);

            // act
            addressBook.contacts.Remove(contact);

            // assert
            Assert.Single(addressBook.contacts);
        }
    }
}