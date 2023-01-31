using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Address_Book_MVVM.MVVM.Models;
using WPF_Address_Book_MVVM.Services;

namespace WPF_Address_Book_MVVM.MVVM.ViewModels
{
    public partial class EditContactModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ContactPersonModel> contacts = ContactService.Contacts();

        [ObservableProperty]
        private ContactPersonModel selectedContact = null!;

        public EditContactModel()
        {

        }

    }
}
