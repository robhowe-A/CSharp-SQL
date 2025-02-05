/*
 * Description: This program creates object (Meal) data for json text serialization.
 * Date: 2-5-2025
 * Author: Robert Howell
 */
using System.Text.Json;

// Make a meal
Meal meal = new Meal();
meal.Name = "Ham sandwich";
meal.Recipe.Enqueue("Gather/layout the ingredients");
meal.Recipe.Enqueue("Add condiments to bread");
meal.Recipe.Enqueue("Add the meat");
meal.Recipe.Enqueue("Add the toppings");
meal.Recipe.Enqueue("Cut in half");
meal.Recipe.Enqueue("Enjoy!");
meal.Portions = 1;

// Make a second meal
Meal meal2 = new Meal();
meal2.Name = "Order takeout";
meal2.Recipe.Enqueue("No recipe instructions");
meal2.Portions = 2;

// Create a meal list
List<Meal> MealsList = new(2);
MealsList.Add(meal);
MealsList.Add(meal2);

// Set object string serializer options
JsonSerializerOptions jsonStrOptions = new JsonSerializerOptions();
jsonStrOptions.AllowOutOfOrderMetadataProperties = false;
jsonStrOptions.AllowTrailingCommas = true;
jsonStrOptions.IncludeFields = true;
jsonStrOptions.PropertyNameCaseInsensitive = false;
jsonStrOptions.WriteIndented = true;
jsonStrOptions.DictionaryKeyPolicy = JsonNamingPolicy.KebabCaseUpper;
jsonStrOptions.PropertyNamingPolicy = JsonNamingPolicy.KebabCaseUpper;
jsonStrOptions.IndentCharacter = '\t';
jsonStrOptions.NewLine = "\n";
jsonStrOptions.IndentSize = 1;
jsonStrOptions.Encoder = null;

// Transform list data into json text
string mealsJson = JsonSerializer.Serialize(
    MealsList, 
    typeof(List<Meal>),
    jsonStrOptions);

// Show the result in the output window
Console.WriteLine(mealsJson);

internal class Meal
{
    public string Name { get; set; } = string.Empty;
    public Queue<string> Recipe = new Queue<string>();
    public int Portions { get; set; } = 0;

    public Meal()
    {
        // constructor logic (not implemented)
    }
}