using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _01_task
{
    public class UDPClients
    {
        public static string ip = "127.0.0.1";
        public static int port = 8080; 

        public string Talk(string message)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            using (UdpClient client = new UdpClient())
            {
                byte[] data = Encoding.Unicode.GetBytes(message);

                client.Send(data, data.Length, ipPoint);

                data = client.Receive(ref remoteEndPoint);

                string response = Encoding.Unicode.GetString(data);

                return response;
            }
        }
    }
}
