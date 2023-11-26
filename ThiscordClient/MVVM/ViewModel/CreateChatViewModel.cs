using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ThiscordClient.Core;

namespace ThiscordClient.MVVM.ViewModel;

public class CreateChatViewModel
{
    public string ChatName { get; set; }
    public string UserName { get; set; }
    public ObservableCollection<string> UsernameList { get; } = new();
    
    public TCPSendReceive TcpSendReceive = TCPSendReceive.instance;
    
    
    private void AddUsernameToList()
    {
        
    }

    private void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
        TcpSendReceive._server.CreateChat(ChatName, UsernameList.ToArray());
    }
}