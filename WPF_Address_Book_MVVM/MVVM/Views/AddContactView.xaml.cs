using _02_WPF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WPF_Address_Book_MVVM.MVVM.Models;
using WPF_Address_Book_MVVM.Services;

namespace WPF_Address_Book_MVVM.MVVM.Views
{
    /// <summary>
    /// Interaction logic for AddContactView.xaml
    /// </summary>
    public partial class AddContactView : UserControl
    {
        public ObservableCollection<ContactPersonModel> contacts = new ObservableCollection<ContactPersonModel>();   //ObservableCollection ist för lista. För den ska kunna upptaderas.

        private static FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json");

        public AddContactView()
        {
            InitializeComponent();
            PopulateContactList();
        }

        private void PopulateContactList()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<ObservableCollection<ContactPersonModel>>(fileService.Read());
                if (items != null)
                    contacts = items;
            }
            catch { }
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)        //knapp metod. lägga till.
        {
            ContactService.Add(new ContactPersonModel
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                Phone = tb_Phone.Text,
                Address = tb_Address.Text
            });

            Clearform();
        }

        private void Clearform()            //Tömma formulär
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_Phone.Text = "";
            tb_Address.Text = "";
        }

    }
}
