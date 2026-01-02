/*
 * Description: This program creates a complex XML file in a new directory
 * Features: Directory, directory info, file stream options, stream writer,
 *  xml serializer
 * Date: 1-28-2025
 * Author: Robert Howell
 */

using System.Xml.Serialization;

// Create 2-3 objects
CompIO compIO = new CompIO();
compIO.Type = "PC";
compIO.Name = "Desktop station";
compIO.Devices = new List<string>() { "keyboard", "mouse", "motherboard" };
compIO.Devices.Add("CPU");
compIO.Devices.Add("RAM");
compIO.Devices.Add("GPU");
compIO.Devices.Add("disk");
compIO.Devices.Add("antenna");
compIO.hasAntenna = false;
compIO.CaseSize = CaseSize.Mini;

// Requirements dictate the new document be added to a new directory called XmlFiles
// Create a new directory
string xmlFilesDirPath = @"C:\Temp\Test\XmlFiles";

if(!Directory.Exists(xmlFilesDirPath))
{ 
    DirectoryInfo xmlFilesDirInfo = Directory.CreateDirectory(xmlFilesDirPath);
}

// Specify a file path
string XmlFilePath = string.Concat( [xmlFilesDirPath, @"\newxml.xml"]);

// Configure the file options on stream write
FileStreamOptions fileStreamOptions = new FileStreamOptions();
fileStreamOptions.Share = FileShare.None;
fileStreamOptions.Access = FileAccess.Write;
fileStreamOptions.Mode = FileMode.CreateNew;
fileStreamOptions.Options = FileOptions.None;
fileStreamOptions.PreallocationSize = 8 * 16;
if (Environment.GetEnvironmentVariable("OS") != null
    & !Environment.GetEnvironmentVariable("OS").Contains("Windows"))
{
    fileStreamOptions.UnixCreateMode = UnixFileMode.UserWrite;
}

// Create the file stream writer using the path and options
try
{
    using System.IO.StreamWriter sw = new(XmlFilePath, fileStreamOptions);

    // Serialize XML to document
    XmlSerializer xmlSerializer = new(typeof(CompIO));
    xmlSerializer.Serialize(sw, compIO);

    // Close stream writer and dispose
    sw.Close();
    sw.Dispose();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

public enum CaseSize
{
    Small = 0,
    Mini,
    Mid,
    Full,
    Super
}

public class CompIO
{
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<string> Devices { get; set; } = [];
    public CaseSize CaseSize { get; set; }
    public bool hasAntenna;
    public Antenna? Antenna;
}

public class Antenna
{
    public string Type { get; set; } = string.Empty;
    public int Version { get; set; }
}