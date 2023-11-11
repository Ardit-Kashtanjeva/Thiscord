using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Castle.DynamicProxy;
using LNMShared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace LNMServer;

public class ServerTcp
{
    private readonly TcpListener _tcpListener = new(IPAddress.Any, 12345);
    private readonly List<UserClient> _clients = new();
    private readonly Server _server = new();

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

    public static UserClient CurrentClient;

    private void HandleTargetMessages(UserClient userClient)
    {
        NetworkStream stream = userClient.TcpClient.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;  

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                var message = new TCPMessage();
                
                try
                {
                    message = JsonConvert.DeserializeObject<TCPMessage>(receivedMessage);
                }
                catch
                {
                    
                } 
            
                CurrentClient = userClient;

                lock (CurrentClient)
                {
                    
                    
                    if (message.MethodName == "SignIn")
                    {
                        var newParameters = new object[message.Parameters.Length + 1];
                    
                        for (int i = 0; i < message.Parameters.Length; i++)
                        {
                            newParameters[i] = message.Parameters[i];
                        }
                    
                        newParameters[message.Parameters.Length] = CurrentClient.TcpClient;
                    
                        message.Parameters = newParameters;
                        
                        _server.GetType().GetMethod(message.MethodName).Invoke(_server, message.Parameters);

                    }
                    else
                    {
                        CallMethod(receivedMessage);
                    }
                    
                    //
                    // if (message.MethodName == "CreateChat")
                    // {
                    //     object obj = message.Parameters[1];
                    //
                    //     JArray jsonArray = obj as JArray;
                    //
                    //     if (jsonArray != null)
                    //     {
                    //         string[] stringArray = jsonArray.Select(jv => (string)jv).ToArray();
                    //         message.Parameters[1] = stringArray;
                    //     }
                    // }
                    //
                    // if (message.MethodName == "AddChatMember")
                    // {
                    //     message.Parameters[2] = Guid.Parse(message.Parameters[2].ToString());
                    // }
                    //
                    CurrentClient = null!;
                }
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