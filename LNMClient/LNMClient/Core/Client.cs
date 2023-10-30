using LNMShared;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using LNMClient.MVVM.ViewModel;
using LNMClient.MVVM.Model;

namespace LNMClient.Core
{
    public class Client : IClient
    {
        Window logInWindow = Application.Current.MainWindow;
        MainWindow mainWindow = new();

        public void AddToChat(string chatName, Guid chatGuid)
        {
            MainViewModel.AddContact(
                (new ContactModel
                {
                    Chatname = chatName,
                    ChatGuid = chatGuid,
                    Messages = new ObservableCollection<MessageModel>()
                }));
        }

        public void GetSignedIn()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                mainWindow.Show();
                logInWindow.Close();
            });
        }

        public void ReceiveMessage(string message, Guid chatGuid)
        {
            throw new NotImplementedException();
        }
    }
}
