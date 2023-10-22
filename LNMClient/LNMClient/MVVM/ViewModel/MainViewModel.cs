using LNMClient.MVVM.Model;
using System;
using System.Collections.ObjectModel;
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

            SendCommand = new RelayCommand(o=>
            {
                Messages.Add(new MessageModel
                {
                    Message = Message,
                    FirstMessage = false
                });

                Message = "";
            });

            Messages.Add(new MessageModel
            {
                Username = "Aromat",
                UsernameColor = "#409aff",
                ImageSource = "https://image.migros.ch/mo-boxed/v-w-1000-h-1000/10d73ebff5ec5b53787f83f3d16af5981a872401/knorr-aromat.jpg",
                Message = "Test",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 3; i++)
            {

                Messages.Add(new MessageModel
                {
                    Username = "Ardit",
                    UsernameColor = "#409aff",
                    ImageSource = "https://image.migros.ch/mo-boxed/v-w-1000-h-1000/10d73ebff5ec5b53787f83f3d16af5981a872401/knorr-aromat.jpg",
                    Message = "abc",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            for (int i = 0; i < 3; i++)
            {
               

                Messages.Add(new MessageModel
                {
                    Username = "Jones",
                    UsernameColor = "#409aff",
                    ImageSource = "https://image.migros.ch/mo-boxed/v-w-1000-h-1000/10d73ebff5ec5b53787f83f3d16af5981a872401/knorr-aromat.jpg",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false
                });
            }

            Messages.Add(new MessageModel
            {
                Username = "Aromat",
                UsernameColor = "#409aff",
                ImageSource = "https://image.migros.ch/mo-boxed/v-w-1000-h-1000/10d73ebff5ec5b53787f83f3d16af5981a872401/knorr-aromat.jpg",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Aromat {i}",
                    ImageSource = "https://image.migros.ch/mo-boxed/v-w-1000-h-1000/10d73ebff5ec5b53787f83f3d16af5981a872401/knorr-aromat.jpg",
                    Messages = Messages

                });
            }


        }
    }
}
