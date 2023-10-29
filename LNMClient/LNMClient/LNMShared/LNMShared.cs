using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace LNMShared
{

    public interface IServer
    {
        public void SendMessage(string message, Guid chatGuidId);

        public void CreateChat(string chatName, string[] userNames);

        public void AddChatMember(string userName, string chatName, Guid chatGuid);

        public void SignUp(string userName, string userPassword);


        public void SignIn(string userName, string userPassword);

    }

    public interface IClient
    {
        public void ReceiveMessage(string message, Guid chatGuid);

        public void AddToChat(string chatName, Guid chatGuid);

        public void GetSignedIn();
    }

    public class TCPMessage
    {
        public string MethodName { get; set; }
        public object[] Parameters { get; set; }

    }
    
}
