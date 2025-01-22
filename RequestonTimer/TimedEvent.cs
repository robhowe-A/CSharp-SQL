
namespace RequestOnTimerConsole
{
    internal class TimedEvent(System.Timers.Timer Timer, HttpClient Client, Uri RequestUri)
    {
        private readonly HttpClient _client = Client;
        private readonly Uri RequestUri = RequestUri;
        public readonly System.Timers.Timer Timer = Timer;

        public async void GetAsync(Object source, System.Timers.ElapsedEventArgs e)
        {
            HttpResponseMessage response = await _client.GetAsync(RequestUri);
            
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"Request failed with status code: {response.StatusCode}");
            }
        }
    };
}