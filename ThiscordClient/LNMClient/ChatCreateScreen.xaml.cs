using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using LNMClient.Core;
using LNMClient.MVVM.ViewModel;

namespace LNMClient
{
    /// <summary>
    /// Interaction logic for UserAddScreen.xaml
    /// </summary>
    public partial class ChatCreateScreen : Window
    {
        public string ChatName { get; set; }
        public Guid ChatGuid { get; set; }
        public TCPSendReceive TcpSendReceive = TCPSendReceive.instance;
        public ObservableCollection<string> UsernameList { get; } = new();

        public ChatCreateScreen()
        {
            InitializeComponent();
            DataContext = this;
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
            Close();
            TcpSendReceive._server.CreateChat(txtChatName.Text, UsernameList.ToArray());
        }
    }
}