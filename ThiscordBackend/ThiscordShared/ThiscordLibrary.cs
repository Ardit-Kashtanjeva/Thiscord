using System.Net.Sockets;
using System.Text.Json;

namespace LNMShared;


public interface IServer
{
    public void SendMessage(MessageModel message, Guid chatGuidId);
    
    public void CreateChat(string chatName, string[] userNames);

    public void AddChatMember(string userName,string chatName , Guid chatGuid);

    public void SignUp(string userName, string userPassword);

    
    public void SignIn(string userName, string userPassword, TcpClient tcpClient);

}

public interface IClient
{
    public void ReceiveMessage(MessageModel message, Guid chatGuid);

    public void AddToChat(string chatName, Guid chatGuid);

    public void GetSignedIn(string username);
}

public class MessageModel
{
    public string Username { get; set; }
    public string UsernameColor { get; set; }
    public string ImageSource { get; set; }
    public string Message { get; set; }
    public Guid TargetChat { get; set; }
}


public class TCPMessage
{
    public string MethodName { get; set; }
    public Object[] Parameters { get; set; }
    
}

public class RcpMessage
{
    public string MethodName { get; set; }
    public JsonElement[] Parameters { get; set; }
}
