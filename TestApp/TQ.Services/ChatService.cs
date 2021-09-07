using System;
using System.Collections.Generic;
using System.Text;
using TQ.Entites;

namespace TQ.Services
{
   public class ChatService
    {
        private static List<ChatMessage> _chatMessage = new List<ChatMessage>();
        private static ChatService _chatService = new ChatService();

        public ChatService()
        {

        }

        public static ChatService Instance => _chatService;

        public List<ChatMessage> Messages => _chatMessage;
    }
}
