using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace sharp.network.webSockets
{
    /// <summary>
    /// server program
    /// </summary>
    class Program
    {
        private static int port = 8005;

        static void Main()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            // create socket.
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // open the socket
                socket.Bind(ipPoint);
                socket.Listen(10);
                Console.WriteLine("Server is on.. Press any key to continue..");
                // Console.ReadLine();

                // operations

                while (true)
                {
                    // receiving the message...
                    Socket handler = socket.Accept();
                    StringBuilder sb = new StringBuilder();
                    int bytescount = 0;
                    byte[] arr = new byte[256];

                    do
                    {
                        bytescount = handler.Receive(arr);
                        sb.Append(Encoding.Unicode.GetString(arr, 0, bytescount));
                    } while (handler.Available > 0);

                    Console.WriteLine(DateTime.Now.ToShortDateString() + " : " + sb);

                    string message = "Your message has been sent..";
                    arr = Encoding.Unicode.GetBytes(message);
                    handler.Send(arr);
                    // close socket...
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
