using FluentAssertions;
using System.Collections.ObjectModel;
using WPF_Address_Book_MVVM.MVVM.Models;
using WPF_Address_Book_MVVM.MVVM.ViewModels;
using WPF_Address_Book_MVVM.MVVM.Views;

namespace WpfApp.Tests
{
    public class WPF_Address_Book_Tests
    {
        private readonly ContactsViewModel viewModel;
        public WPF_Address_Book_Tests()
        {
            viewModel= new ContactsViewModel();
        }


        [Fact]
        public void Should_Add_Contact_To_ContactList()
        {
            // act
            var contact = new ContactPersonModel { FirstName = "Saad", LastName = "Fatih" };
            viewModel.Contacts.Remove(contact);

            // assert
            viewModel.Contacts.Should().BeOfType<ObservableCollection<ContactPersonModel>>();
            viewModel.Contacts.Should().NotContain(contact);
        }
    }
}