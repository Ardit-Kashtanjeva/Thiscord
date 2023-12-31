﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using ThiscordClient.Core;
using ThiscordShared;

namespace ThiscordClient.MVVM.ViewModel;

public class ChatCreateViewModel : INotifyPropertyChanged
{
    private string _chatname;
    
    private string _username;
    
    private ObservableCollection<string> _usernameList;
    public RelayCommand AddUsernameToListCommand { get; set; }
    public RelayCommand CreateChatCommand { get; set; }
    
    public string Chatname
    {
        get => _chatname;
        set
        {
            if (value == _chatname) return;
            _chatname = value;
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
            _usernameList = value;
            OnPropertyChanged();
        }
    }

    public ChatCreateViewModel(IServer server)
    {
        _usernameList = new();
        
        AddUsernameToListCommand = new RelayCommand(o =>
        {
            UsernameList.Add(Username);
            Username = String.Empty;
        });
        
        CreateChatCommand = new RelayCommand(o =>
        {
            server.CreateChat(Chatname, UsernameList.ToArray());
            UsernameList.Clear();
            Username = String.Empty;
            Chatname = String.Empty;
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