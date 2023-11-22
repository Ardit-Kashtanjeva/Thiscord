using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Castle.DynamicProxy;
using ThiscordShared;

namespace ThiscordServer;

public class Clientinterceptor : IInterceptor
{
    private readonly TcpClient _tcpClient;
    
    public Clientinterceptor(TcpClient tcpClient)
    { 
        _tcpClient = tcpClient;
    }
    
    public void Intercept(IInvocation invocation)
    {
        if (_tcpClient.Connected)
        {
            var str = JsonSerializer.Serialize(new TCPMessage
            {
                MethodName = invocation.Method.Name,
                Parameters = invocation.Arguments
            });
            byte[] data = Encoding.UTF8.GetBytes(str);
            NetworkStream stream = _tcpClient.GetStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }
    }
    
    
}