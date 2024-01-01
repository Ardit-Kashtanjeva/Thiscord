using System.Collections.ObjectModel;
using System.Windows;
using ThiscordClient.Core;
using ThiscordShared;

namespace ThiscordClient.MVVM.Model;

public class Storage
{
    
    public MessageModel ClientMessageModel { get; set; }
    public ObservableCollection<ContactModel> Contacts { get; set; } = new();
    
    public void AddContact(ContactModel contact)
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            Contacts.Add(contact);
        });
    }
}