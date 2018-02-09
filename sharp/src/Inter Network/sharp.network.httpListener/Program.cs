using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace sharp.network.httpListener
{
    class Program
    {
        private static int stCode = 200;
        private static dynamic body;
        private static int reqcount;
        private const string Received = "Received method: ";
        private const string URL = "http://localhost:8888/";
        private static string[] content_type = new string[] { "application/json", "application/xml" };
        private static string cType = null;
        [STAThread]
        static void Main()
        {
            Console.Title = "AJAX http server";

            Dialog();
            Start:
            var dialogOpen = new OpenFileDialog()
            {
                Multiselect = false,
                Title = "Select json file for returning as response",
                Filter = "json document| *.json; *.txt"
            };
            using (dialogOpen)
            {
                if (dialogOpen.ShowDialog() == DialogResult.OK)
                {
                    var file = File.ReadAllText(dialogOpen.FileName);
                    try
                    {
                        body = JsonConvert.DeserializeObject<object>(file);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        goto Start;
                    }
                    Console.WriteLine();
                }
            }
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(URL);
            listener.Start();
            while (true)
            {
                if (reqcount == 20) Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(reqcount + ": ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                HttpListenerContext context = listener.GetContextAsync().Result;
                Console.Beep(4000, 300);
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
                response.Headers.Add("Content-Type", cType);
                if (body == null)
                {
                    body = new Dictionary<string, string>
                    {
                        {"Empty", "Empty"}
                    };
                }
                byte[] buffer;

                if (cType == content_type.Last())
                {
                    var xsSub = new XmlSerializer(typeof(object));
                    using (var sww = new StringWriter())
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        dynamic obj = JsonConvert.DeserializeObject<object>(body);
                        xsSub.Serialize(writer, obj);
                        buffer = Encoding.UTF8.GetBytes(sww.ToString());
                    }
                }
                else
                    buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body));
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
                Stream body = c.InputStream;
                Encoding enc = c.ContentEncoding;
                StreamReader reader = new StreamReader(body, enc);

                if(c.ContentType != null)
                {
                    Console.WriteLine("Client data content type -> {0}", c.ContentType);
                }

                Console.WriteLine("Start read client data....");
                string s = reader.ReadToEnd();
                Console.WriteLine(s);
                body.Close();
                reader.Close();
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
            while (cType == null)
            {
                Console.WriteLine("Content-Type ? \n 1. - Json \n 2. - XML");
                string ans = Console.ReadLine();
                if (ans.Contains("2"))
                    cType = content_type.Last();
                else if (ans.Contains("1"))

                    cType = content_type.First();
                else
                    Console.WriteLine("Wrong input.. Try again.");
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
            Console.WriteLine($"\nServer ON. Waiting for requests... Content-Type : {cType}");
        }
    }

}
