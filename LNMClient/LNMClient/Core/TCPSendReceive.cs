using Castle.DynamicProxy;
using LNMClient.Core;
using static LNMShared.LNMLibrary;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System;

namespace LNMClient.Core;

public class TCPSendReceive
{
    private IServer? _server;

    public void ConnectToServer(TcpClient _tcpClient)
    {
        string targetIpAddress = "98.71.24.184";

        if (IPAddress.TryParse(targetIpAddress, out IPAddress targetAddress))
        {
            _tcpClient.Connect(targetAddress, 12345);
            Task.Run(() => HandleTargetMessages(_tcpClient));
            _server = new ProxyGenerator().CreateInterfaceProxyWithoutTarget<IServer>(new ServerInterceptor(_tcpClient));

        }
        else
        {
            MessageBox.Show("Server is not Available");
        }
    }

    public void HandleTargetMessages(TcpClient _tcpClient)
    {
        NetworkStream stream = _tcpClient.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            //Add Message function
        }
    }

    public void SendMessage(string messageToSend)
    {
        if (_server != null)
        {
            _server.SendMessage(messageToSend,());
            //Add function to add message to current chat and send it to the other chat users
        }
    }
}