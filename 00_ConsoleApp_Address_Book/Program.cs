using _00_ConsoleApp_Address_Book.Services;


var menu = new Menu();
menu.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json";


while (true)
{
    Console.Clear();
    menu.WelcomeMenu();
}
