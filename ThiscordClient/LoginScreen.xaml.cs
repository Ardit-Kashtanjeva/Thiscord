using ThiscordShared;
using System.Net.Sockets;
using System.Windows;
using ThiscordClient.MVVM.ViewModel;
using ThiscordClient.Core;

namespace ThiscordClient
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public TCPSendReceive TcpSendReceive;

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            TcpSendReceive._server.SignIn(txtUsername.Text, txtPassword.Password);
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            TcpSendReceive._server.SignUp(txtUsername.Text, txtPassword.Password);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TcpSendReceive = TCPSendReceive.Instance(new TcpClient());
           
            TcpSendReceive.ConnectToServer();
            
        }
    }
}
