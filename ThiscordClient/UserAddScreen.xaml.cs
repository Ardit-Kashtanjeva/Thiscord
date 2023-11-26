using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ThiscordClient.Core;
using ThiscordShared;

namespace ThiscordClient
{
    /// <summary>
    /// Interaction logic for UserAddScreen.xaml
    /// </summary>
    public partial class UserAddScreen : Window
    {
        private readonly IServer _server;
        public string chatName { get; set; }
        public Guid ChatGuid { get; set; }
        
        public ObservableCollection<string>UsernameList = new();

        public UserAddScreen(IServer server)
        {
            _server = server;
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
                _server.AddChatMember(username, chatName, ChatGuid);
            }
        }
    }
}