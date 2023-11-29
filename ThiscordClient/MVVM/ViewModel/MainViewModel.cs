using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ThiscordClient.Core;
using ThiscordClient.MVVM.Model;
using ThiscordShared;


namespace ThiscordClient.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        
        public RelayCommand SendMessage { get; set; }

        public string _message;
        
        ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact;  }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }
        
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(Storage storage, IServer server)
        {
            Messages = new ObservableCollection<MessageModel>();

            SendMessage = new RelayCommand(o =>
            {
                if (SelectedContact == null)
                    return;

                storage.ClientMessageModel.Message = Message;
                storage.ClientMessageModel.Time = DateTime.Now;

                server.SendMessage(storage.ClientMessageModel, SelectedContact.ChatGuid);
                Message = "";
            });
        }

        public void AddMessage(MessageModel message)
        {
            Messages.Add(message);
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
}
