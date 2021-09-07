using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TQ.Entites;

namespace TQ.BAL
{
    public interface IUsersRepository
    {
        Task<GetUsersResponse> Get(GetUsersRequest request);
        public int Create(string userName);
    }
}
