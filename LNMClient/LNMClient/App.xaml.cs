using LNMClient.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;

namespace LNMClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    ///

    public partial class App : Application
    {
        public TcpClient _tcpClient = new();
        public TCPSendReceive _tcpSendReceive = new();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _tcpSendReceive.ConnectToServer(_tcpClient);
        }

    }
}
