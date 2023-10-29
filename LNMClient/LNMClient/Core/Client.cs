using LNMShared;
using System;
using System.Windows;

namespace LNMClient.Core
{
    public class Client : IClient
    {
        Window logInWindow = Application.Current.MainWindow;
        MainWindow mainWindow = new();

        public void AddToChat(string chatName, Guid chatGuid)
        {
            throw new NotImplementedException();
        }

        public void GetSignedIn()
        {
            if (logInWindow != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    mainWindow.Show();
                    logInWindow.Close();
                });
            }
        }

        public void ReceiveMessage(string message, Guid chatGuid)
        {
            throw new NotImplementedException();
        }
    }
}
