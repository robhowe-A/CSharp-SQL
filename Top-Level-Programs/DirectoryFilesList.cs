/*
 * Description: This program reads a directory file list and sorts the files by name
 * Date: 1-23-2025
 * Author: Robert Howell
 */

//get newest APOD file
var path2 = new DirectoryInfo("C:\\Dev\\HTMLCSS\\SpaceFlight_Console_Web\\SpaceFlight_Console_Web\\wwwroot\\js\\APOD");
string searchterm = "*.json";
if (path2.GetFiles().Length > 0)
{
    // Read directory files to get the newest json file
    var myAPODFile = path2.GetFiles(searchterm).OrderByDescending(f => f.Name).First();

    // Output to console this file anme
    Console.WriteLine("Newest file: {0}", myAPODFile.Name.ToString());

    // Read directory files matching json extension type
    var APODFiles = path2.GetFiles(searchterm).OrderByDescending(f => f.Name);

    // Output to console file names list
    int count = 0;
    foreach (var file in APODFiles)
    {
        Console.WriteLine("File {0}: {1}", count++, file.Name.ToString());
    }
}