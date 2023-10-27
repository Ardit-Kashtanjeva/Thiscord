using LNMClient.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LNMClient.Core;


namespace LNMClient.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
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

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();


            Messages.Add(new MessageModel 
            { 
                Message = "LOOOL",
                FirstMessage = false,
                IsNativeOrigin = false,
                Time = DateTime.Now,
                Username = "ARDIJEEET",
                UsernameColor = "#FFFFFF",
                TargetChat = new Guid(),
                ImageSource = "https://image.migros.ch/mo-boxed/v-w-1000-h-1000/10d73ebff5ec5b53787f83f3d16af5981a872401/knorr-aromat.jpg"
            });

            Contacts.Add(new ContactModel
            {
                Chatname = "ASDSADSADAD",
                Messages = Messages,
                ImageSource = "https://image.migros.ch/mo-boxed/v-w-1000-h-1000/10d73ebff5ec5b53787f83f3d16af5981a872401/knorr-aromat.jpg"
            });


        }
    }
}
