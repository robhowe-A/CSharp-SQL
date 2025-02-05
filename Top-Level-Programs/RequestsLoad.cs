/*
 * Description: This program creates a loop for HTTP requests.
 * Features: Async, multi-threaded, client programming
 * Date: 2-4-2025
 * Author: Robert Howell
 */
int expected = 500; //Num requests to send to url
int sent = 0; //Num requests sent

Console.WriteLine("Program started...");

// Use a stack or queue data structure to process urls
System.Collections.Generic.Stack<string> urls = new();

// Process a url
urls.Push( @"https://www.randomwebbits.com" );

// A new thread for long-running task
Thread thread = new Thread(
    new ThreadStart(async () =>
        await RequestsLoad(urls.Pop(), expected)
    ));
thread.Name = "ProcessRequests";
thread.Start();

// Process a second url
urls.Push( @"https://www.randomwebbits.com/pages" );
await RequestsLoad((string)urls.Pop() ?? "cancel", expected);
thread.Join();

Thread.Sleep(5000);

async Task<bool> RequestsLoad(string uri, int count=1000)
{
    if (uri == "cancel") return false;
    // Declare http client for web requests
    using HttpClient client = new();

    for (var i= count; i>0; i--)
    {
        // Send the GET request to the uri provided as parameter
        Console.WriteLine($"GetAsync(\"{uri}\")...");
        HttpResponseMessage response = await client.GetAsync(uri);

        // Program will terminate on a failed call with EnsureSuccessStatusCode() method
        response.EnsureSuccessStatusCode();

        // Increment counter
        sent++;

        // Output to console response+loop details
        Console.WriteLine(
            string.Format
            (
                "{2,8}: {0}-{1}, HTTP/{3}", 
                response.ReasonPhrase, response.Content.Headers.ContentLength, 
                sent,
                response.Version
            )
        );
    }

    // Request loop complete
    client.Dispose();
    return true;
}
