using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ThiscordClient.Core;
using ThiscordShared;

namespace ThiscordClient.MVVM.ViewModel;

public class LoginViewModel : INotifyPropertyChanged
{
    private readonly IServer _server;
    private string _username;
    private string _password;

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (value == _password) return;
            _password = value;
            OnPropertyChanged();
        }
    }

    public ICommand SignUpCommand { get; set; }
    public ICommand SignInCommand { get; set; }
    
    public LoginViewModel(IServer server)
    {
        _server = server;

        SignUpCommand = new RelayCommand(o =>
        {
            _server.SignUp(Username, Password);
            Username = string.Empty;
            Password = string.Empty;
        });

        SignInCommand = new RelayCommand(o =>
        {
            _server.SignIn(Username, Password);
            Username = string.Empty;
            Password = string.Empty;
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