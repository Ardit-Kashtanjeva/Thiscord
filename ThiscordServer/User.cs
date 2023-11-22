using System.Net.Sockets;

namespace ThiscordServer;

public class User
{
    public required string UserName;

    public required string UserPassword;

    public readonly List<UserClient> ConnectedClients = new();
}