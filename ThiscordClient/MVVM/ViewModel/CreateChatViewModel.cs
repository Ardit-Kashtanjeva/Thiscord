using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ThiscordClient.Core;
using ThiscordShared;

namespace ThiscordClient.MVVM.ViewModel;

public class CreateChatViewModel : INotifyPropertyChanged
{
    private readonly TCPSendReceive _tcpSendReceive;

    private string _chatName;
    
    private string _username;
    
    private ObservableCollection<string> _usernameList;
    public RelayCommand AddUsernameToListCommand { get; set; }
    public RelayCommand CreateChatCommand { get; set; }
    
    public string ChatName
    {
        get => _chatName;
        set
        {
            if (value == _chatName) return;
            _chatName = value;
            OnPropertyChanged();
        }
    }
    
    public string Username
    {
        get => _username;
        set
        {
            if (value == _username) return;
            _username = value;
            OnPropertyChanged();
        }
    }
    
    public ObservableCollection<string> UsernameList
    {
        get => _usernameList;
        set
        {
            if (Equals(value, _usernameList)) return;
            _usernameList = value;
            OnPropertyChanged();
        }
    }

    public CreateChatViewModel(TCPSendReceive tcpSendReceive, IServer server)
    {
        _tcpSendReceive = tcpSendReceive;
        AddUsernameToListCommand = new RelayCommand(o =>
        {
            UsernameList.Add(Username);
            Username = "";
        });
        
        CreateChatCommand = new RelayCommand(o =>
        {
            server.CreateChat(ChatName, UsernameList.ToArray());
        });
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}