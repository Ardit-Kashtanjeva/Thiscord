using System;
using System.Windows.Input;
using ThiscordClient.Core;
using ThiscordShared;

namespace ThiscordClient.MVVM.ViewModel;

public class LoginViewModel
{
    private readonly IServer _server;
    public string Username { get; set; }
    public string Password { get; set; }

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
    
    
}