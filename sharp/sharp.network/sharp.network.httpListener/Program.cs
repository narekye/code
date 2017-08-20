using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace sharp.network.httpListener
{
    class Program
    {
        private static int stCode = 200;
        private static int reqcount;
        private const string Received = "Received method: ";
        private const string URL = "http://localhost:8888/";
        static void Main()
        {
            Console.Title = "AJAX http server";

            Dialog();
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(URL);
            listener.Start();
            while (true)
            {
                if(reqcount == 20) Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(reqcount + ": ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                HttpListenerContext context = listener.GetContextAsync().Result;
                Console.Beep(5000, 300);
                HttpListenerRequest request = context.Request;
                switch (request.HttpMethod)
                {
                    case "GET":
                        Printf(request, ConsoleColor.Yellow, request.HttpMethod);
                        break;
                    case "POST":
                        Printf(request, ConsoleColor.Magenta, request.HttpMethod);
                        break;
                    case "PUT":
                        Printf(request, ConsoleColor.DarkCyan, request.HttpMethod);
                        break;
                }

                HttpListenerResponse response = context.Response;
                response.StatusCode = stCode;
                response.Headers.Add("Content-Type", "application/json");
                Dictionary<string, string> keyvalue = new Dictionary<string, string>()
                {
                    { "key1","value1" },
                    { "key2","value2" }

                };
                byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(keyvalue));
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
                reqcount++;
            }
        }


        public static void Printf(HttpListenerRequest c, ConsoleColor color, string method)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Auth: " + c.IsAuthenticated);
            Console.WriteLine("IsWebSocket: " + c.IsWebSocketRequest);
            Console.WriteLine("Agent: " + c.UserAgent);
            Console.WriteLine("HostName: " + c.UserHostName);
            Console.Write(Received);
            Console.ForegroundColor = color;
            Console.Write(method + Environment.NewLine);
            if (c.HasEntityBody)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Request has body.");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Dialog()
        {
            Here:
            Console.WriteLine("Response status code is: 200. Change y/n ?");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "y":
                    Wrong:
                    Console.WriteLine("Input sample status code: ");
                    string res = Console.ReadLine();
                    int letter;
                    int.TryParse(res, out letter);
                    if (letter < 0 || letter > 500)
                    {
                        Console.WriteLine("Wrong status code.");
                        goto Wrong;
                    }
                    stCode = letter;
                    break;
                case "n":
                    break;
                default:
                    goto Here;
            }

            Console.Clear();
            Console.Write("Current sending status code: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(stCode);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Developed by Narek Yegoryan.");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPerform your AJAX requests to address: " + URL);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nServer ON. Waiting for requests...");
        }
    }

}
