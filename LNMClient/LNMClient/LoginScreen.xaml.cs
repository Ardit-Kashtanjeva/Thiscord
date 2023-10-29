using LNMClient.Core;
using LNMShared;
using System.Net.Sockets;
using System.Windows;

namespace LNMClient
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public TcpClient _tcpClient = new();
        public TCPSendReceive _tcpSendReceive;

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _tcpSendReceive._server.SignIn(txtUsername.Text, txtPassword.Password);
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            _tcpSendReceive._server.SignUp(txtUsername.Text, txtPassword.Password);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _tcpSendReceive = new();
            _tcpSendReceive.ConnectToServer(_tcpClient);
        }
    }
}
