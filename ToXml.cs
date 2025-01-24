/*
 * Description: This program converts a square to Xml.
 * Date: 1-24-2025
 * Author: Robert Howell
 */
using System.Xml.Serialization;

public class testXML
{
    public class Square
    {
        // A square has a side dimension
        public uint Side
        {
            get
            {
                return _side;
            }
            set
            {
                _side = value;
            }
        }

        private uint _side;
        private uint _perimeter;

        // A square has a perimeter
        public uint Perimeter 
        { 
            get 
            { 
                return _perimeter; 
            } 
            set 
            { 
                _perimeter = value; 
            } 
        }

        // Remain perimeter based on the side's lengh
        private uint CalculatePerimeter()
        {
            return Side * 4;
        }

        // Default constructor
        public Square()
        {
            _perimeter = CalculatePerimeter();
        }

        // One-parameter constructor
        public Square(uint Side)
        {
            _side = Side;
            _perimeter = CalculatePerimeter();
        }
    };

    // Function to transform an object to an Xml string
    public string WriteXml(Object obj)
    {
        // Create serializer
        var serializer = new XmlSerializer(obj.GetType());

        // Create string writer, then serialize
        using TextWriter writer = new StringWriter();
        serializer.Serialize(writer, obj);

        // Return writer object string
        return writer.ToString();
    }

    // Entry point
    static int Main()
    {
        // Create a new square
        Square squareOne = new Square(10);

        // Call WriteXml() in console write to output
        Console.Write(new testXML().WriteXml(squareOne));

        return -1;
    }
};