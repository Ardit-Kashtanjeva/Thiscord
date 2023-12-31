﻿using System.Net;
using System.Net.Sockets;
using System.Text;
using ThiscordShared;

namespace ThiscordServer;

public class UserClient
{
    public required IClient Client { get; init; }
    public required TcpClient TcpClient { get; init; }
    public required IPAddress IpAddress { get; set; }

    public User? User;
    
}

