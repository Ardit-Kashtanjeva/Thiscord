using System.Net;
using System.Net.Sockets;
using System.Text;
using Castle.DynamicProxy;
using LNMShared;

namespace Local_Network_Messenger;

public class TCPSendReceive
{
    private IServer? _server;
    
    public void ConnectToServer(TcpClient _tcpClient, TextBox TxtMessageHistory)
    {
        string targetIpAddress = "98.71.24.184";

        if (IPAddress.TryParse(targetIpAddress, out IPAddress targetAddress))
        {
            _tcpClient.Connect(targetAddress, 12345);
            Task.Run(() => HandleTargetMessages( _tcpClient,  TxtMessageHistory));
            _server = new ProxyGenerator().CreateInterfaceProxyWithoutTarget<IServer>(new ServerInterceptor(_tcpClient));
            
        }
        else
        {
            MessageBox.Show("Server is not Available");
        }
    }
    
    public void HandleTargetMessages(TcpClient _tcpClient, TextBox TxtMessageHistory)
    {
        NetworkStream stream = _tcpClient.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;
    
        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            TxtMessageHistory.AppendText($"\r\n{receivedMessage}");
        }
    }
    
    public void SendMessage(string messageToSend, TextBox TxtMessageHistory, TextBox TxtMessageBox)
    {
        if (_server != null)
        {
            _server.SendMessage(messageToSend, new Guid());
            TxtMessageHistory.AppendText($"\r\n[You]: {messageToSend}");
            TxtMessageBox.Text = "";
        }
    }
}