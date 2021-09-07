using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TQ.Entites;

namespace TQ.DAL
{
   public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions options) : base(options)
        {
            // Just call base
        }

        public DbSet<ChatUser> Users { get; set; }
        public DbSet<ChatMessage> Messages { get; set; }
    }
    
}
