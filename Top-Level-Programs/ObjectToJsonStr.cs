/*
 * Description: This program creates a json string and then deserializes it.
 * Features: Object initializers, JsonSerializer
 * Date: 1-27-2025
 * Update: 3-3-2025
 * Author: Robert Howell
 */
using System.Text.Json;

// Create some retail stores data
RetailStore retailStore = new() 
{
    Name = "Shoe Testers",
    Number = 01,
    Locations = new List<string> { "Houston", "Lubbock" }
};

RetailStore retailStoreTwo = new()
{
    Name = "Clothes Makers",
    Number = 02,
    Locations = new List<string> { "Abilene", "Houston" }
};

// Add the stores as a list
List<RetailStore> AllRetailStores = new(8) { retailStore, retailStoreTwo };

// Create a json string form the list data
string retailStoresJsonStr = JsonSerializer.Serialize
    (
        AllRetailStores, 
        typeof(List<RetailStore>), 
        new JsonSerializerOptions 
        { 
            WriteIndented=false,
            PropertyNameCaseInsensitive=true,
        }
    );

// Write the json string, to confirm
Console.WriteLine(retailStoresJsonStr);

// Restore the json string data to objects, an array this time
RetailStore[] retailStoresObjs = JsonSerializer.Deserialize<RetailStore[]>(retailStoresJsonStr) ?? throw new NullReferenceException();

// Print the results of the conversion and all (current) data
foreach (RetailStore store in AllRetailStores)
{
    Console.Write("Object: {0}, {1}", store.Name, store.Number);
    
    foreach (string location in store.Locations)
        Console.Write(" {0}", location);
    
    Console.WriteLine();
}

// Retail stores class
internal struct RetailStore
{
    public string Name {get; set;}
    public int Number { get; set; }
    public List<string> Locations { get; set; }
};