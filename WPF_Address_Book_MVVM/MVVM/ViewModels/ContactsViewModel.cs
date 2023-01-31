using _02_WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Utils.CommonDialogs.Internal;
using Microsoft.Azure.KeyVault.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using WPF_Address_Book_MVVM.MVVM.Models;
using WPF_Address_Book_MVVM.Services;

namespace WPF_Address_Book_MVVM.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ContactPersonModel> contacts = ContactService.Contacts();
        private static FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json");


        //private readonly FileService file = new();

        [ObservableProperty]
        private ContactPersonModel selectedContact = null!;

        [RelayCommand]
        public void Remove()
        {

            string message = $"Vill du verkligen ta bort {selectedContact.DisplayName} Från listan?";
            string title = "Ta bort";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result = (DialogResult)MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                ContactService.Contacts().Remove(SelectedContact);
                fileService.Save(JsonConvert.SerializeObject(contacts));

            }

            else
            {
                MessageBox.Show("Ingen ändring har skett");
            }
        }


        public ContactsViewModel()
        {
            //file.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

            //PopulateEmployeesList();
        }

        //private void PopulateEmployeesList()
        //{
        //    try
        //    {
        //        var items = JsonConvert.DeserializeObject<ObservableCollection<ContactPersonModel>>(file.Read());
        //        if (items != null)
        //            Contacts = items;
        //    }
        //    catch { }

        //}
    }
}
