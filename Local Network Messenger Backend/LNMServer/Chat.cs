using System.Net.Sockets;

namespace LNMServer;

public class Chat
{

    public string ChatName;

    public Guid Guid = new();

    public List<User> ChatUsers;
    
}