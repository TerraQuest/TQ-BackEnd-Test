﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TQ.Entites
{
  public  class ChatUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<ChatMessage> ChatMessage { get; set; }
    }
}
