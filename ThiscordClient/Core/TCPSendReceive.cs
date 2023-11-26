using Castle.DynamicProxy;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;
using ThiscordShared;
using System.Text.Json;

namespace ThiscordClient.Core;

public class TCPSendReceive
{

    private Client _client;
    
    private readonly TcpClient _tcpClient;
    

    public TCPSendReceive(Client client, TcpClient tcpClient)
    {
        _client = client;
        _tcpClient = tcpClient;
    }
    
    public void ConnectToServer()
    {
        string targetIpAddress = "127.0.0.1";

        if (IPAddress.TryParse(targetIpAddress, out IPAddress targetAddress))
        {
            _tcpClient.Connect(targetAddress, 12345);
            Task.Run(() => HandleTargetMessages());
        }
        else
        {
            Console.WriteLine("a");
        }
    }

    public void HandleTargetMessages()
    {
        NetworkStream stream = _tcpClient.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            CallMethod(receivedMessage);
        }
    }

    public void CallMethod(string incomingMessage)
    {
        var message = JsonSerializer.Deserialize<RcpMessage>(incomingMessage);

        if (message == null)
            return;

        var method = _client.GetType().GetMethod(message.MethodName);

        if (method == null)
            return;

        var methodParameters = method.GetParameters();
        var parameters = new object[methodParameters.Length];

        for (var i = 0; i < method.GetParameters().Length; i++)
        {
            var parameterType = methodParameters[i].ParameterType;
            var jsonElement = message.Parameters[i];

            var parameter = jsonElement.Deserialize(parameterType);

            if (parameter is null)
                continue;

            parameters[i] = parameter;
        }

        method.Invoke(_client, parameters);

    }
}