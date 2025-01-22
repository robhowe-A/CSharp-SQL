
namespace RequestOnTimerConsole;

public class ConsoleRequestTimed 
{
    public static int Main()
    {
        //EXAMPLE: https://api.dictionaryapi.dev/api/v2/entries/en/socket
        System.Uri? uriEntry = null;
        int intervalEntry = -1;

        // Collect user input from console for url string
        bool isValidUri = false;
        do
        {
            string requestedUri = string.Empty;

            Console.WriteLine("Enter a request url (full url)");
            requestedUri = Console.ReadLine();
            try
            {
                uriEntry = new Uri(requestedUri);
                if(uriEntry != null)
                    isValidUri = true;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        } while (!isValidUri);
        
        // Collect user input from console for timer intervalEntry
        do
        {
            Console.WriteLine("Enter a timer interval (uint (ms))");
            try
            {
                intervalEntry = int.Parse(Console.ReadLine());
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        } while (intervalEntry <= 0);
        
        // Create a timed event object and initialize
        TimedEvent TimedEvent = new
            (
                new System.Timers.Timer(intervalEntry),
                new HttpClient(),
                uriEntry!
            );
        TimedEvent.Timer.Elapsed += TimedEvent.GetAsync;
        TimedEvent.Timer.AutoReset = false;
        TimedEvent.Timer.Enabled = true;

        // Timer is enabled. Do not end the program or the function may not be called.
        Console.WriteLine("Program hold until key entry...");
        Console.ReadLine();

        // Timer funcitons presumed complete; now terminate.
        TimedEvent.Timer.Stop();
        TimedEvent.Timer.Dispose();

        Console.WriteLine("Program complete.");
        return -1;
    }
};