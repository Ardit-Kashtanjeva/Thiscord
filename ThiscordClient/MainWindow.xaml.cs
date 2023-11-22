﻿using System;
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
            TCPSendReceive tcpSendReceive = TCPSendReceive.instance;
            tcpSendReceive._client.MinimizeWindow();
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {

            TCPSendReceive tcpSendReceive = TCPSendReceive.instance;
            tcpSendReceive._client.MaximizeWindow();
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
    }
}