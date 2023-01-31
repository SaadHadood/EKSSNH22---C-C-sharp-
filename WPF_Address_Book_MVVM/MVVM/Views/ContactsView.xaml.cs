using DevExpress.Utils.CommonDialogs.Internal;
using System.Windows;
using System.Windows.Controls;
using WPF_Address_Book_MVVM.MVVM.Models;
using WPF_Address_Book_MVVM.Services;

namespace WPF_Address_Book_MVVM.MVVM.Views
{
    /// <summary>
    /// Interaction logic for ContactsView.xaml
    /// </summary>
    ///
    public partial class ContactsView : UserControl
    {
        public ContactsView()
        {
            InitializeComponent();

        }


        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactPersonModel)button.DataContext;

            string message = "Vill du verkligen ta bort " + contact.DisplayName + " " + "Från listan?";
            string title = "Ta bort";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            DialogResult result = (DialogResult)MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                ContactService.Remove(contact);
            }

            else
            {
                MessageBox.Show("Ingen ändring har skett");
            }
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var contact = (ContactPersonModel)button.DataContext;
        }




        //private void ListView_Selected(object sender, RoutedEventArgs e)
        //{
        //    var button = (Button)sender;
        //    var contact = (ContactPersonModel)button.DataContext;

        //    MessageBox.Show(contact.DisplayName + " Email: " + contact.Email + " Mobil: " + contact.Phone + " Address: " + contact.Address);
        //}

        //private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    var border = (Border)sender;
        //    var contact = (ContactPersonModel)border.DataContext;

        //    MessageBox.Show(contact.DisplayName + " Email: " + contact.Email + " Mobil: " + contact.Phone + " Address: " + contact.Address);
        //}
    }
}
