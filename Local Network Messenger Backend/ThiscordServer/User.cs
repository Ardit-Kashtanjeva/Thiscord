using System.Net.Sockets;

namespace LNMServer;

public class User
{
    public required string UserName;

    public required string UserPassword;

    public readonly List<UserClient> ConnectedClients = new();
}