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
        Window logInWindow = Application.Current.MainWindow;
        MainWindow mainWindow = new();
        MainViewModel mainViewModel = MainViewModel.Instance;

        public void MinimizeWindow()
        {
            mainWindow.WindowState = WindowState.Minimized;
        }

        public void MaximizeWindow()
        {
            if (mainWindow.WindowState != WindowState.Maximized)
            {
                mainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                mainWindow.WindowState = WindowState.Normal;
            }
        }

        public void AddToChat(string chatName, Guid chatGuid)
        {
            mainViewModel.AddContact(
                (new ContactModel
                {
                    Chatname = chatName,
                    ChatGuid = chatGuid,
                    Messages = new ObservableCollection<MessageModel>()
                }));
        }

        public void GetSignedIn(string username)
        {
            MainViewModel mainViewModel = MainViewModel.Instance;
            mainViewModel.ClientMessageModel = ( new MessageModel
            {
                Username = username,
                UsernameColor = "#3bff6f",
                Message = "",
                ImageSource = $"https://gravatar.com/avatar/{username}?s=400&d=robohash&r=x",
                Time = DateTime.Now
            });

            Application.Current.Dispatcher.Invoke(() =>
            {
                mainWindow.Show();
                logInWindow.Close();
            });
        }

        public void ReceiveMessage(MessageModel message, Guid chatGuid)
        {
                var contactModel = mainViewModel.Contacts.FirstOrDefault(x => x.ChatGuid == chatGuid);

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