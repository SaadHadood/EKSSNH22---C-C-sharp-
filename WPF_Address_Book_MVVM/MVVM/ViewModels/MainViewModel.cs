using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Address_Book_MVVM.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel = new ContactsViewModel();

        [RelayCommand] // Istället för clik på knappen. 
        private void GoToAddContacts() => CurrentViewModel = new AddContactModel();


        [RelayCommand]
        private void GoToContacts() => CurrentViewModel = new ContactsViewModel();


        [RelayCommand]
        private void GoToEditContacts() => CurrentViewModel = new EditContactModel();

        public MainViewModel()
        {
            CurrentViewModel = new ContactsViewModel();
        }
    }
}
