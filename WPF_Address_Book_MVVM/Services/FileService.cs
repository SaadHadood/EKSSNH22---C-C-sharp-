using System.IO;


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
