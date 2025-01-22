
namespace Polymorphism_Inheritance_Encapsulation_Abstraction
{
    // A derived class that represents a square
    internal sealed class Square (double Length) : Shape
    {
        private readonly double Length = Length;

        // Implement shape abstract double property
        protected override double Area 
        { 
            get 
            { 
                return Length * Length;
            }
        }

        // Implement shape abstract void function
        public override void ShowInfo()
        {
            Console.WriteLine($"This square's area is {Area}");
        }

        // Polymorphic implementation from abstract void function
        public override void ShowInfo(bool showLength)
        {
            Console.WriteLine($"This square, length={Length}, area is {Area}");
        }
    };
}