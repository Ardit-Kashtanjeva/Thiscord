using System.Net.Sockets;
using ThiscordShared;

namespace ThiscordServer;

public class Server : IServer
{
    public List<User> Users = new();
    public List<Chat> Chats = new();
    
    public void SendMessage(MessageModel message, Guid chatGuidId)
    {
        var targetChat = Chats.FirstOrDefault(x => x.Guid == chatGuidId);
        if (targetChat == null)
        {
            return;
        }
        foreach (var user in targetChat.ChatUsers)
        {
            foreach (var connectedClient in user.ConnectedClients)
            {
                connectedClient.Client.ReceiveMessage(message, chatGuidId);
            }
        }
    }
    
    public void CreateChat(string chatName, string[] userNames)
    {
        Guid tempGuid = new Guid();
        Chats.Add( new Chat
        {
            ChatName = chatName,
            Guid = tempGuid,
            ChatUsers = userNames.Select(x => Users.FirstOrDefault(y => y.UserName == x)).Where(x => x != null).ToList()!
        });
        foreach (var user in Chats.Find(x => x.ChatName == chatName).ChatUsers)
        {
            foreach (var client in user.ConnectedClients)
            {
                client.Client.AddToChat(chatName,tempGuid);
            }
            
        }
    }

    public void AddChatMember(string userName,string chatName , Guid chatGuid)
    {
        var chat = Chats.FirstOrDefault(x => x.Guid == chatGuid);
        var user = Users.FirstOrDefault(x => x.UserName == userName);
        if (chat == null || user == null)
        {
            return;
        }
        chat.ChatUsers.Add(user);
        foreach (var userClient in user.ConnectedClients)
        {
            userClient.Client.AddToChat(chatName,chatGuid);
        }
        
    }

    public void SignUp(string userName, string userPassword)
    {
        Users.Add(new User
        {
            UserName = userName,
            UserPassword = userPassword
        }); 
        
    }

    public void SignIn(string userName, string userPassword)
    {
        var user = Users.FirstOrDefault(x => x.UserName == userName);
        if (user == null)
        {
            return;
        }
        if (user.UserPassword == userPassword)
        {
            user.ConnectedClients.Add(ServerTcp.CurrentClient);
            ServerTcp.CurrentClient.Client.GetSignedIn(userName);
        }
    }   
}