using ThiscordShared;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using ThiscordClient.MVVM.Model;
using ThiscordClient.MVVM.ViewModel;

namespace ThiscordClient.Core
{
    public class Client : IClient
    {
        private Window _logInWindow;
        private MainWindow _mainWindow;
        private readonly Storage _storage;
        private MainViewModel _mainViewModel;

        public Client(MainWindow mainWindow, Storage storage, LoginScreen loginScreen)
        {
            _mainWindow = mainWindow;
            _storage = storage;
            _logInWindow = loginScreen;
        }

        public void AddToChat(string chatName, Guid chatGuid)
        {
            _storage.AddContact(
                new ContactModel
                {
                    Chatname = chatName,
                    ChatGuid = chatGuid,
                    Messages = new ObservableCollection<MessageModel>()
                });
        }

        public void GetSignedIn(string username)
        {
            _storage.ClientMessageModel = new MessageModel
            {
                Username = username,
                UsernameColor = "#3bff6f",
                Message = String.Empty,
                ImageSource = $"https://gravatar.com/avatar/{username}?s=400&d=robohash&r=x",
                Time = DateTime.Now
            };

            Application.Current.Dispatcher.Invoke(() =>
            {
                _mainWindow.Show();
                _logInWindow.Close();
            });
        }

        public void ReceiveMessage(MessageModel message, Guid chatGuid)
        {
                var contactModel = _storage.Contacts.FirstOrDefault(x => x.ChatGuid == chatGuid);

                if (contactModel == null)
                {
                    return;
                }

                Application.Current.Dispatcher.Invoke(() =>
                {
                    contactModel.Messages.Add(message);
                });
        }
    }
}