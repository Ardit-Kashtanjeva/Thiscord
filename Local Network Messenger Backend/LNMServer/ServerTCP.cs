﻿using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Castle.DynamicProxy;
using LNMShared;
using Newtonsoft.Json;

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
            var message = JsonConvert.DeserializeObject<TCPMessage>(receivedMessage);
            
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
                }
                
                _server.GetType().GetMethod(message.MethodName).Invoke(_server, message.Parameters);

                CurrentClient = null!;
            }
        }
    }
}