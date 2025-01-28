using System.Text.Json;

// Create some retail stores data
RetailStore retailStore = new();
retailStore.Name = "Shoe Testers";
retailStore.Number = 01;
retailStore.Locations = new List<string> { "Houston", "Lubbock" };

RetailStore retailStoreTwo = new();
retailStoreTwo.Name = "Clothes Makers";
retailStoreTwo.Number = 02;
retailStoreTwo.Locations = new List<string> { "Abilene", "Houston" };

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
internal class RetailStore
{
    public string Name {get; set;}
    public int Number { get; set; }
    public List<string> Locations { get; set; }
};