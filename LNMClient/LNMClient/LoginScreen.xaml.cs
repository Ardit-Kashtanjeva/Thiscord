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
        TcpClient _tcpClient = ((App)Application.Current)._tcpClient;
        TCPSendReceive _tcpSendReceive = ((App)Application.Current)._tcpSendReceive;

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _tcpSendReceive._server.SignIn(txtUsername.Text, txtPassword.Password, _tcpClient);
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            _tcpSendReceive._server.SignUp(txtUsername.Text, txtPassword.Password);
        }
    }
}
