using System;
using System.Net;
using System.Threading.Tasks;

namespace sharp.network.requestSending
{
    class Program
    { 
        static Uri uri = new Uri("www.somesite.com/cars.pdf");
        static void Main()
        {
            WebClient client = new WebClient();
            client.DownloadFile(uri,"cars_downloaded.pdf");
            DownloadFileAsync().GetAwaiter();
        }
        // it can be async
        static async Task DownloadFileAsync()
        {
            WebClient client = new WebClient();
            await client.DownloadFileTaskAsync(uri, "example.pdf");
            Console.WriteLine("File downloaded");
        }
    }
}
