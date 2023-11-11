using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNMClient.MVVM.Model
{
    public class MessageModel
    {
        public string Username { get; set; }
        public string UsernameColor { get; set; }
        public string ImageSource { get; set;}
        public string Message { get; set;}
        public DateTime Time { get; set;}
    }
}
