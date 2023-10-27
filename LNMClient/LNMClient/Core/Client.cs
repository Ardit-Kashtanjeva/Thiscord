using LNMShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LNMClient.Core
{
    public class Client : IClient
    {
        Window logInWindow = Application.Current.MainWindow;
        MainWindow mainWindow = new();

        void IClient.AddToChat(string chatName, Guid chatGuid)
        {
            throw new NotImplementedException();
        }

        void IClient.GetSignedIn()
        {
            if (logInWindow != null)
            {
                mainWindow.Show();
                logInWindow.Close();
            }
        }

        void IClient.ReceiveMessage(string message, Guid chatGuid)
        {
            throw new NotImplementedException();
        }
    }
}
