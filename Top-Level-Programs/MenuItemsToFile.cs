/*
 * Description: This example program writes menu items to a file.
 * Features: Object initializers, JsonSerializer
 * Date: 3-19-2025
 * Author: Robert Howell
 */

string Folder = @"C:\Temp\TEST\";
string FileName = @"Menu.txt";
string sep = "\t";

// StoreMenu for file storage
StoreMenu menuFile = new(
    Folder,
    FileName,
    "\r\n"
);

// Menu data
MenuItem burger = new()
{
    Item = "Burger",
    Price = 10.00m,
    Calories = 500,
    Description = "One quarter pound patty with butter topping."
};
MenuItem steak = new()
{
    Item = "Steak",
    Price = 20.00m,
    Calories = 500,
    Description = "16oz ribeye, a chef special."
};

menuFile.CreateIfNotExistsMenuFile();
menuFile.WriteFileHeading(sep);
burger.WriteMenuItemToFile(sep, menuFile.FullPath);
steak.WriteMenuItemToFile(sep, menuFile.FullPath);


/// <summary>
/// This holds a menu item's data.
/// 
/// </summary>
public record MenuItem
{
    public string Item { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public short Calories { get; set; }
    public string Description { get; set; } = string.Empty;
    
    public void WriteMenuItemToFile(string sep, string filePath)
    {
        // Write item data to file
        File.AppendAllText(filePath, $"{Item}{sep}${Price}{sep}{Calories}{sep}{Description}{StoreMenu.EOL}");
        Console.WriteLine($"Menu item {{{Item}}} written to file.");
    }
}

/// <summary>
/// This object is used to create + initilize a text file.
/// </summary>
public class StoreMenu
{
    public string Folder { get { return _folder; } set { _folder = value; } }
    public string FileName { get { return _fileName; } set { _fileName = value; } }
    public string FullPath { get { return _fullPath; } }
    public static string EOL { get; set; } = "\n";

    private string _folder;
    private string _fileName;
    private string _fullPath;

    public StoreMenu(string folder, string fileName, string EOL)
    {
        _folder = folder;
        _fileName = fileName;
        _fullPath = $@"{folder}{fileName}";
        StoreMenu.EOL = EOL;
    }

    public void CreateIfNotExistsMenuFile()
    {
        if (!File.Exists(_fullPath))
        {
            // Create a file
            File.Create(FullPath).Close();
            Console.WriteLine($"File created at {FullPath}");
        }
    }
    public void WriteFileHeading(string sep)
    {
        // Write file heading
        File.WriteAllText(_fullPath, $"{nameof(MenuItem.Item)}{sep}{nameof(MenuItem.Price)}{sep}{nameof(MenuItem.Calories)}{sep}{nameof(MenuItem.Description)}{StoreMenu.EOL}");
        Console.WriteLine($"File heading written.");
    }
};
