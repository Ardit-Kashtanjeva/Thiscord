using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using ThiscordClient.Core;
using ThiscordClient.MVVM.Model;
using ThiscordShared;


namespace ThiscordClient.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        private static MainViewModel instance;
        public MessageModel ClientMessageModel { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }
        public RelayCommand SendMessage { get; set; }


        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact;  }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }
        

        public string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public static MainViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainViewModel();
                }
                return instance;
            }
        }

        private MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendMessage = new RelayCommand(o =>
            {
                if (SelectedContact == null)
                    return;

                var selectedContact = Instance.SelectedContact;
                TCPSendReceive _tcpSendReceive = TCPSendReceive.instance;
                MainViewModel mainViewModel = Instance;

                mainViewModel.ClientMessageModel.Message = Message;
                mainViewModel.ClientMessageModel.Time = DateTime.Now;

                _tcpSendReceive._server.SendMessage(mainViewModel.ClientMessageModel, selectedContact.ChatGuid);
                Message = "";
            });
        }

        public void AddMessage(MessageModel message)
        {
            Messages.Add(message);
        }

        public void AddContact(ContactModel contact)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Contacts.Add(contact);
            });
        }

    }
}
