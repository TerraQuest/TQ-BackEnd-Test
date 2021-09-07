using System;
using System.Collections.Generic;
using System.Text;

namespace TQ.Entites
{
   public class ChatMessage
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public int UserIdentifier { get; set; }

        public string Message { get; set; }
    }
}
