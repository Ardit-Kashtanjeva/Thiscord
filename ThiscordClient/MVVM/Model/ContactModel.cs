﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using LNMShared;

namespace LNMClient.MVVM.Model
{
    internal class ContactModel
    {
        public string Chatname { get; set; }
        public Guid ChatGuid { get; set; }
        public ObservableCollection<MessageModel> Messages { get; set; }
    }
}