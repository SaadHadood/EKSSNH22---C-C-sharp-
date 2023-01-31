using _00_ConsoleApp_Address_Book.Interfaces;
using _00_ConsoleApp_Address_Book.Models;
using Newtonsoft.Json;

namespace _00_ConsoleApp_Address_Book.Services;

internal class FileService
{
    public void Save(string filePath, string content)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(content);
    }

    public string Read(string filePath)
    {
        try
        {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }
        catch
        {
            return null!;
        }
    }
}
