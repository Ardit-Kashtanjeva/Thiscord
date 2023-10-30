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

        private TcpClient _tcpClient = new();
        private TCPSendReceive _tcpSendReceive = new();

        public Form1()
        {
            InitializeComponent();
            ComboBox comboBoxChats = ComboBoxChats;
            comboBoxChats.ForeColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _tcpSendReceive.ConnectToServer(_tcpClient, TxtMessageHistory);
        }

        public void SendMessageButton_Click(object sender, EventArgs e)
        {
            string messageToSend = TxtMessageBox.Text + "\n";
            _tcpSendReceive.SendMessage(messageToSend, TxtMessageHistory, TxtMessageBox);
        }

        private void TxtMessageHistory_TextChanged(object sender, EventArgs e)
        {

        }
    }
}