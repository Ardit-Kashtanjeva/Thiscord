using ThiscordClient.Core;
using System.Net.Sockets;
using System.Windows;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using ThiscordClient.MVVM.Model;
using ThiscordClient.MVVM.ViewModel;
using ThiscordShared;

namespace ThiscordClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    ///

    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        
        public App()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<ChatCreateViewModel>();
            serviceCollection.AddTransient<ChatCreateScreen>();
            serviceCollection.AddSingleton<MainViewModel>();
            serviceCollection.AddSingleton<LoginViewModel>();
            serviceCollection.AddSingleton<MainWindow>();
            serviceCollection.AddSingleton<LoginScreen>();
            serviceCollection.AddSingleton<TcpSendReceive>();
            serviceCollection.AddSingleton<Client>();
            serviceCollection.AddSingleton<Storage>();
            serviceCollection.AddSingleton<IServer>(s => new ProxyGenerator().CreateInterfaceProxyWithoutTarget<IServer>(s.GetRequiredService<ServerInterceptor>()));
            serviceCollection.AddSingleton<ServerInterceptor>();
            serviceCollection.AddSingleton<TcpClient>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var tcpSendReceive = _serviceProvider.GetService<TcpSendReceive>();
            var mainWindow = _serviceProvider.GetService<LoginScreen>();
            mainWindow.Show();
            tcpSendReceive.ConnectToServer();
        }

    }
}
