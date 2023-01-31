using _02_WPF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using WPF_Address_Book_MVVM.MVVM.Models;

namespace WPF_Address_Book_MVVM.Services
{
    public static class ContactService
    {
        private static ObservableCollection<ContactPersonModel> contacts;
        private static FileService fileService = new FileService($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json");

        static ContactService()
        {
            try
            {
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactPersonModel>>(fileService.Read())!;
            }
            catch { contacts = new ObservableCollection<ContactPersonModel>(); }
        }



        public static void Remove(ContactPersonModel model)
        {
            contacts.Remove(model);
            fileService.Save(JsonConvert.SerializeObject(contacts));
        }

        public static void Add(ContactPersonModel model)
        {
            contacts.Add(model);
            fileService.Save(JsonConvert.SerializeObject(contacts));
        }

        public static void Save(ContactPersonModel model)
        {
            contacts.Contains(model);
            fileService.Save(JsonConvert.SerializeObject(contacts));
        }

        public static ObservableCollection<ContactPersonModel> Contacts()
        {
            return contacts;
        }


    }
}
