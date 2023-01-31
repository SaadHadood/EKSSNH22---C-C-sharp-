using _02_WPF.Services;
using DevExpress.Utils.CommonDialogs.Internal;
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
    /// Interaction logic for EditContactView.xaml
    /// </summary>
    public partial class EditContactView : UserControl
    {
        public ObservableCollection<ContactPersonModel> contacts = new ObservableCollection<ContactPersonModel>();

        private static FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json");

        public EditContactView()
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

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            string message = "Vill du uppdatera kontakten?";
            string title = "Ändra";

            var selectedContact = lv_Contacts_Edit.SelectedItem as ContactPersonModel;
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result = (DialogResult)MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                if (selectedContact != null)
                {
                    selectedContact.FirstName = tb_FirstName.Text;
                    selectedContact.LastName = tb_LastName.Text;
                    selectedContact.Email = tb_Email.Text;
                    selectedContact.Phone = tb_Phone.Text;
                    selectedContact.Address = tb_Address.Text;

                    ContactService.Save(selectedContact);

                    MessageBox.Show("Kontakten har uppdateras");
                }

                tb_FirstName.Text = string.Empty;
                tb_LastName.Text = string.Empty;
                tb_Email.Text = string.Empty;
                tb_Phone.Text = string.Empty;
                tb_Address.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Ingen ändring har skett");
                tb_FirstName.Text = string.Empty;
                tb_LastName.Text = string.Empty;
                tb_Email.Text = string.Empty;
                tb_Phone.Text = string.Empty;
                tb_Address.Text = string.Empty;
            }
        }


    }
}
