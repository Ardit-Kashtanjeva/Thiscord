using LNMShared;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        MainViewModel mainViewModel = MainViewModel.Instance;

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
            /*
                var contactModel = mainViewModel.Contacts.FirstOrDefault(x => x.ChatGuid == chatGuid);
                contactModel.Messages.Add( new MessageModel(
                {
                    Username = 
                });
            */
        }
    }
}
/*
        public string Username { get; set; }
        public string UsernameColor { get; set; }
        public string ImageSource { get; set;}
        public string Message { get; set;}
        public Guid TargetChat { get; set;}
        public DateTime Time { get; set;}
 */
