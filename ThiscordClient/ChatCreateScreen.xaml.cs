using System.Windows;
using ThiscordClient.MVVM.ViewModel;

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