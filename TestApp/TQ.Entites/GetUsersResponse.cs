using System;
using System.Collections.Generic;
using System.Text;

namespace TQ.Entites
{
   public class GetUsersResponse
    {
        public IEnumerable<GetUsersResponseItem> Users { get; set; }
    }
}
