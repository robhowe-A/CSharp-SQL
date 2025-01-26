/*
 * Description: This program creates a directory at the specified path. It lists 
 * files within the directory if it is previously created.
 * Date: 1-26-2025
 * Author: Robert Howell
 */

string dPath = @"C:\dev\Test\DirectoryInfo_Testing";

// Initialize a directory path
DirectoryInfo directory = new DirectoryInfo(dPath);

// First, check if parent directory exists
if (directory.Parent == null || !directory.Parent.Exists)
{
    // Directory path at this point does not have a "Test" folder
    // Inform the user and exit the program
    Console.WriteLine($"Parent directory incorrect or does not exist.");
    Console.WriteLine($"Exiting program.");
    return;
}

if (directory.Exists)
{
    // The directory already exists
    // List the directory files
    Console.WriteLine($"A directory preexists at {directory.FullName}");
    ListDirectoryFiles(directory);
}
else
{
    // Create directory
    directory.Create();
    Console.WriteLine($"Directory created at {directory.FullName}");
}


void ListDirectoryFiles(DirectoryInfo directoryInfo)
{
    var path = directory;
    var myFile = path.GetFiles()
        .OrderByDescending(f => f.LastWriteTime)
        .ToArray();

    if (myFile.Length > 0)
    {
        for (int i = 0; i < myFile.Length; ++i)
        {
            var filePath = myFile[i];
            Console.WriteLine("{0}: " + System.IO.Path.GetFileName(filePath.Name), i + 1);
        }
    }
    else
    {
        Console.WriteLine("\n Directory is Empty!\n");
    }
}