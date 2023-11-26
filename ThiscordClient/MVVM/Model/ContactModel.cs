using System;
using System.Collections.ObjectModel;
using System.Linq;
using ThiscordShared;

namespace ThiscordClient.MVVM.Model
{
    public class ContactModel
    {
        public string Chatname { get; set; }
        public Guid ChatGuid { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; }
    }
}
