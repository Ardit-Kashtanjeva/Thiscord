using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Local_Network_Messenger
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;
        private TcpClient tcpClient;

        public Form1()
        {
            InitializeComponent();
            string hostName = Dns.GetHostName();
            IPHostEntry localHost = Dns.GetHostEntry(hostName);
            foreach (IPAddress address in localHost.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    TxtUserIp.Text = address.ToString();
                    break;
                }
            }

            tcpListener = new TcpListener(IPAddress.Any, 12345);
            tcpListener.Start();
            ListenForClients();
        }

        private async void ListenForClients()
        {
            while (true)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                tcpClient = client;
                Task.Run(() => HandleTargetMessages());
            }
        }

        private void HandleTargetMessages()
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                DisplayReceivedMessage(receivedMessage);
            }
        }

        private void DisplayReceivedMessage(string message)
        {
            TxtMessageHistory.AppendText($"[Target]: {message}\n");
        }

        private void ConnectToTargetButton_Click(object sender, EventArgs e)
        {
            string targetIpAddress = textBox1.Text;
            IPAddress targetAddress;

            if (IPAddress.TryParse(targetIpAddress, out targetAddress))
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(targetAddress, 12345);
                Task.Run(() => HandleTargetMessages());
            }
            else
            {
                MessageBox.Show("Invalid target IP address.");
            }
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            if (tcpClient != null && tcpClient.Connected)
            {
                string messageToSend = TxtMessageBox.Text + "\n";
                byte[] data = Encoding.UTF8.GetBytes(messageToSend);
                NetworkStream stream = tcpClient.GetStream();
                stream.Write(data, 0, data.Length);
                stream.Flush();
                DisplaySentMessage(messageToSend);
            }
        }

        private void DisplaySentMessage(string message)
        {
            TxtMessageHistory.AppendText($"[You]: {message}\n");
        }


    }
}