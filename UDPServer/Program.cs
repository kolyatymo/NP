using System.Net.Sockets;
using System.Net;
using System.Text;

internal class Program
{
    static string ip = "127.0.0.1";
    public static readonly int port = 8080;
    private static void Main(string[] args)
    {
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port);

        IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

        using UdpClient listener = new UdpClient(port);
        while (true)
        {
            byte[] data = listener.Receive(ref remoteEndPoint);

            string message = Encoding.Unicode.GetString(data);

            string response = ResponseS(message);

            byte[] responseData = Encoding.Unicode.GetBytes(response);

            listener.Send(responseData, responseData.Length, remoteEndPoint);
        }
    }
    public static string ResponseS(string message)
    {
        List<string> messagernd = new List<string>
        {
            "Okay", "my name robot", "Its good", "How do u fell?","Im fine"
        };
       
        Random rnd = new Random();

        string text = message.ToLower();

        if (text.Contains("hello") || text.Contains("hi"))
        {
            return "Hello How are you?";
        }

        if (text.Contains("how are you?"))
        {
            return "Im good. how are u?";
        }

        if (text.Contains("what is your name?"))
        {
            return "My name bot";
        }

        if (text.Contains("how do you feel?"))
        {
            return "I can't feel";
        }

        if (text.Contains("thank you"))
        {
            return "You're welcome";
        }

        if (text.Contains("goodbye") || text.Contains("bye"))
        {
            return "Goodbye";
        }

        return messagernd[rnd.Next(messagernd.Count)];
    }
}