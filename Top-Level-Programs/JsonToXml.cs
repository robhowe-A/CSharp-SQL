/*
 * Description: This program writes an XML file output from JSON.
 * Date: 3-24-2025
 * Author: Robert Howell
 */


using System.Text.Json;
using System.Xml.Serialization;

string metalShopDataStart = @"{
    ""Name"": ""Strong Beam"",
    ""Location"": {
        ""City"": ""Dallas"",
        ""State"": ""Texas"",
        ""Zip"": ""12345""
        },
    ""Products"": [
        {
            ""SerialNum"": 1,
            ""Type"": ""Expanded steel""
        },
        {
            ""SerialNum"": 2,
            ""Type"": ""Angle iron""
        }
    ]
}";

// Transform json string to object model
MetalShopStrongBeam metalShop = JsonSerializer.Deserialize<MetalShopStrongBeam>(metalShopDataStart,new JsonSerializerOptions { WriteIndented=false });

// Use xml serializer to create an xml file output
XmlSerializer xmlSerializer = new(typeof(MetalShopStrongBeam));

// Specify the xml file location with writer
StreamWriter streamW = new StreamWriter("C:\\Temp\\Test\\metalShopXML.txt");

// Perform the serialization
xmlSerializer.Serialize(streamW, metalShop);

// Close the stream
streamW.Dispose();

Console.WriteLine("Metal shop name is: {0}", metalShop.Name);

public class MetalShopStrongBeam
{
    public string Name { get; set; }
    public Location Location { get; set; }
    public List<Products> Products { get; set; }
}
public class Location
{
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
}
public class Products
{
        public int SerialNum { get; set; }
        public string Type { get; set; }
}