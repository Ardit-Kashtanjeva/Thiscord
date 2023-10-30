using LNMClient.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using LNMClient.Core;
using System.Windows;


namespace LNMClient.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        private static MainViewModel instance;
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        public RelayCommand SendCommand { get; set; }


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
