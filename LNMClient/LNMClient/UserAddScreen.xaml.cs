using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using LNMClient.Core;

namespace LNMClient
{
    /// <summary>
    /// Interaction logic for UserAddScreen.xaml
    /// </summary>
    public partial class UserAddScreen : Window
    {
        public string chatName { get; set; }
        public Guid ChatGuid { get; set; }
        public TCPSendReceive TcpSendReceive { get; set; }
        public ObservableCollection<string>UsernameList = new();

        public UserAddScreen()
        {
            InitializeComponent();
        }

        private void TxtUsername_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UsernameList.Add(txtUsername.Text);
            }
        }

        private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var username in UsernameList)
            {
                TcpSendReceive._server.AddChatMember(username, chatName, ChatGuid);
            }
        }
    }
}