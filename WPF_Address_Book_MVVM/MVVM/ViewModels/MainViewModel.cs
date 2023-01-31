using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
