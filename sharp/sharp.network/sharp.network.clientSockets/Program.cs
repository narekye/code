using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace sharp.network.clientSockets
{
    class Program
    {
        private static int port = 8005;
        // ip address
        static IPAddress address = IPAddress.Parse("127.0.0.1");

        static void Main()
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(address, port);  
                // create socket
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                Console.WriteLine("Enter message....");
                string message = Console.ReadLine();
                byte[] arr = Encoding.Unicode.GetBytes(message);
                socket.Send(arr);
                // receiving the response
                arr = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = socket.Receive(arr, arr.Length, 0);
                    sb.Append(Encoding.Unicode.GetString(arr, 0, bytes));
                } while (socket.Available > 0);
                Console.WriteLine("Server response... : " + sb);
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("End of program");
            Console.Read();
        }
    }
}
