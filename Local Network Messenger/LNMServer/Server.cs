using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LNMServer;

public class Server
{
    private readonly TcpListener _tcpListener = new(IPAddress.Any, 12345);
    private readonly List<Client> _clients = new();
    
    public async Task ListenForClientsAsync()
    {
        _tcpListener.Start();
        while (true)
        {
            var tcpClient = await _tcpListener.AcceptTcpClientAsync();
            
            if (tcpClient.Client.RemoteEndPoint is IPEndPoint ipEndPoint)
            {
                var client = new Client
                {
                    TcpClient = tcpClient,
                    IpAddress = ipEndPoint.Address
                };
                
                _clients.Add(client);
                Task.Run(() => HandleTargetMessages(client));
            }
            
        }
    }

    private void HandleTargetMessages(Client client)
    {
        NetworkStream stream = client.TcpClient.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            foreach (var targetClient in _clients)
            {
                targetClient.SendMessage(receivedMessage);
            }
        }
    }
}