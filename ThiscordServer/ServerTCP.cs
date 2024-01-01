using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Castle.DynamicProxy;
using ThiscordShared;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ThiscordServer;

public class ServerTcp
{
    private readonly TcpListener _tcpListener = new(IPAddress.Any, 12345);
    private readonly List<UserClient> _clients = new();
    private readonly Server _server = new();
    public static UserClient CurrentClient;


    public async Task ListenForClientsAsync()
    {
        _tcpListener.Start();
        while (true)
        {
            var tcpClient = await _tcpListener.AcceptTcpClientAsync();

            if (tcpClient.Client.RemoteEndPoint is IPEndPoint ipEndPoint)
            {
                var client = new UserClient
                {
                    TcpClient = tcpClient,
                    IpAddress = ipEndPoint.Address,
                    Client = new ProxyGenerator().CreateInterfaceProxyWithoutTarget<IClient>(new Clientinterceptor(tcpClient))

                };

                _clients.Add(client);
                Task.Run(() => HandleTargetMessages(client));
            }
        }
    }

    private void HandleTargetMessages(UserClient userClient)
    {
        NetworkStream stream = userClient.TcpClient.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        try
        {
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            
                CurrentClient = userClient;

                lock (CurrentClient)
                {
                    CallMethod(receivedMessage);
                    CurrentClient = null!;
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception();
        }
    }

    public void CallMethod(string incomingMessage)
    {
        var message = JsonSerializer.Deserialize<RcpMessage>(incomingMessage);

        if (message == null)
            return;

        var method = _server.GetType().GetMethod(message.MethodName);
        
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

        method.Invoke(_server, parameters);
    }
}