using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LNMServer;

public class Client
{
    public required TcpClient TcpClient { get; init; }
    public required IPAddress IpAddress { get; set; }
    
    public void SendMessage(string message)
    {
        if (TcpClient.Connected)
        {
            byte[] data = Encoding.UTF8.GetBytes($"Chatter: {message}");
            NetworkStream stream = TcpClient.GetStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }
    }
}

