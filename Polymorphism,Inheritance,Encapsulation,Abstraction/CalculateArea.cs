
namespace Polymorphism_Inheritance_Encapsulation_Abstraction
{
    // A static class contining a static method
    internal sealed class CalculateAreaStart
    {
        // A static method that takes a string parameter and prints a greeting message
        internal static void ShowInfo(string[] names)
        {
            // Output to console the provided names as a readable list
            Console.WriteLine($"Define shapes' area using class(s): { string.Join(", ", names) }");
        }
    };
}