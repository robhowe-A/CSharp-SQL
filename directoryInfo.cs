using System.IO;
using System;

class createDirectory {
	static void Main()
	{
		string dPath = @"C:\dev\C#\DirectoryInfo-Testing\Test";
		//Initialisation of the Object by passing the path
		DirectoryInfo directory = new DirectoryInfo(dPath);
		// Let us first check if the directory already exist or not
		if (directory.Exists)
		{
			Console.WriteLine("The directory which you are trying to create is already there");
		}
		//If the directory which we are trying to create is not there
		else
		{
		// below code will create the directory with name we have provided
		directory.Create();
		Console.WriteLine("Congratulation we have created directory");
		}
	Console.ReadLine();
	}
}




// function test() {
	
// 	var path = new DirectoryInfo ("\\");
// 	var myFile = path.GetFiles()
// 		.OrderByDescentind(f => f.LastWriteTime)
// 		.First();

// 	if ( filePaths.Length > 0 )
// 	{
//    		for (int i = 0; i < filePaths.Length; ++i)
//    		{
//       		string path = filePaths[i];
//       		Console.WriteLine("File: " + System.IO.Path.GetFileName(path));
//       		Console.WriteLine();
//    		}
//  	}
//  	else{
//    		Console.WriteLine();
//    		Console.WriteLine(" Directory is Empty!");
//    		Console.WriteLine();
//    		Console.ReadLine();
//  	}
// }