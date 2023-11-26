using System.Net.Sockets;
using System.Windows;
using ThiscordClient.Core;
using ThiscordClient.MVVM.ViewModel;

namespace ThiscordClient
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen(LoginViewModel loginViewModel)
        {
            DataContext = loginViewModel;
            InitializeComponent();
        }
    }
}
