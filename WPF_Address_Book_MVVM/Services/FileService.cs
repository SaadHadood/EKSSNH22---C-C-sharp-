using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using WPF_Address_Book_MVVM.MVVM.Models;

namespace _02_WPF.Services
{
    public class FileService
    {
        public string _filePath;

        public FileService(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(string content)
        {
            using var sw = new StreamWriter(_filePath);
            sw.WriteLine(content);
        }

        public string Read()
        {
            try
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }
            catch { return null!; }
        }
    }
}
