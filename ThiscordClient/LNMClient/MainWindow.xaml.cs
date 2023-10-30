using System;
using System.Windows;
using System.Windows.Input;
using System.Net.Sockets;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;
using LNMClient.Core;
using LNMClient.MVVM.ViewModel;

namespace LNMClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

            MainViewModel sharedViewModel = MainViewModel.Instance;

            DataContext = sharedViewModel;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
                Application.Current.Shutdown();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ChatCreateScreen chatCreateScreen = new();
            chatCreateScreen.Show();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (MainViewModel.Instance.SelectedContact != null)
            {
                if (e.Key == Key.Enter)
                {
                    var selectedContact = MainViewModel.Instance.SelectedContact;
                    TextBox textBox = (TextBox)sender;
                    TCPSendReceive _tcpSendReceive = TCPSendReceive.instance;


                    _tcpSendReceive._server.SendMessage(textBox.Text, selectedContact.ChatGuid);
                    textBox.Text = "";
                }
            }
        }
    }
}
