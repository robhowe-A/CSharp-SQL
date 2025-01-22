
namespace Polymorphism_Inheritance_Encapsulation_Abstraction
{
    // A derived class that represents a circle
    internal sealed class Circle (double Radius) : Shape
    {
        private readonly double Radius = Radius;

        // Implement shape abstract double property
        protected override double Area
        { 
            get 
            { 
                return Math.PI * Radius * Radius;
            }
        }

        // Implement shape abstract void function
        public override void ShowInfo()
        {
            Console.WriteLine($"This circle's area is {Area}");
        }

        // Polymorphic implementation from abstract void function
        public override void ShowInfo(bool showRadius)
        {
            Console.WriteLine($"This circle, radius={Radius}, area is {Area}");
        }
    };
}