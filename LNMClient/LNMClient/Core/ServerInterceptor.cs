using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Castle.DynamicProxy;
using LNMShared;

namespace LNMClient.Core;

public class ServerInterceptor : IInterceptor
{
    private readonly TcpClient _tcpClient;

    public ServerInterceptor(TcpClient tcpClient)
    {
        _tcpClient = tcpClient;
    }

    public void Intercept(IInvocation invocation)
    {
        SendOverTcp(invocation.Method.Name, invocation.Arguments);
    }

    private void SendOverTcp(string methodName, params object[] parameters)
    {
        var str = JsonSerializer.Serialize(new TCPMessage
        {
            MethodName = methodName,
            Parameters = parameters
        });
        byte[] data = Encoding.UTF8.GetBytes(str);
        NetworkStream stream = _tcpClient.GetStream();
        stream.Write(data, 0, data.Length);
        stream.Flush();
    }
}
