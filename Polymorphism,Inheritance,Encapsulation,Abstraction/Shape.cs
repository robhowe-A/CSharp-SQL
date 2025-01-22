
namespace Polymorphism_Inheritance_Encapsulation_Abstraction
{
    // An abstract class to represent a Shape
    internal abstract class Shape
    {
        // An abstract property returning a shape's area
        protected abstract double Area { get; }

        // An abstract function for inherited class to implement
        public abstract void ShowInfo();
        // An abstract polymorphic function for inherited class to implement
        public abstract void ShowInfo(bool showLength);
    };
}