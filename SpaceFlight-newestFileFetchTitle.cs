//dotnet new console
//dotnet run

namespace NewNamespace{

    class Program{
        public static void Main(){
            
            //get newest APOD file
            var path2 = new DirectoryInfo("C:\\Dev\\HTMLCSS\\SpaceFlight_Console_Web\\SpaceFlight_Console_Web\\wwwroot\\js\\APOD");
            string searchterm = "*.json";
            if (path2.GetFiles().Length > 0)
            {
                var myAPODFile = path2.GetFiles(searchterm).OrderByDescending(f => f.Name).First();
                var currentAPODFilePathName = myAPODFile.Name;
                string currentAPODFilePath = currentAPODFilePathName.ToString();
                string APODDate;
                APODDate = currentAPODFilePath;
                Console.WriteLine(APODDate);
            }
        }
    }
}