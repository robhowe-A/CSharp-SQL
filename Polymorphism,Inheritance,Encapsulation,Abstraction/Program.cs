
namespace Polymorphism_Inheritance_Encapsulation_Abstraction;

internal class AreaApplication
{
    // Main class begins the program
    private static int Main()
    {
        // Call static method ShowInfo()
        CalculateAreaStart.ShowInfo(["Circle", "Square"]);

        // Instantiate and initialize new circle
        Circle Circle3 = new (3.00);
        Circle3.ShowInfo(true);

        // Instantiate and initialize new circle
        Square Square5 = new (5.00);
        Square5.ShowInfo(true);

        return -1;
    }
};