using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ThiscordClient.MVVM.ViewModel;
using ThiscordClient.Core;

namespace ThiscordClient
{
    /// <summary>
    /// Interaction logic for UserAddScreen.xaml
    /// </summary>
    public partial class ChatCreateScreen : Window
    {
        public ChatCreateScreen(CreateChatViewModel createChatViewModel)
        {
            InitializeComponent();
            DataContext = createChatViewModel;
        }
    }
}