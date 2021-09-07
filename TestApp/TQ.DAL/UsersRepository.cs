using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TQ.BAL;
using TQ.Entites;

namespace TQ.DAL
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ChatDbContext _dbContext;

        public UsersRepository(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetUsersResponse> Get(GetUsersRequest request)
        {
            var response = new GetUsersResponse
            {
                Users = _dbContext.Users
                       .GroupBy(user => user.UserName)
                       .Select(grouping => new GetUsersResponseItem { Name = grouping.Key, Count = grouping.Count() })
                       .ToArray()
                       .Where(user => user.Name.Contains(request.MatchingName))
                       .OrderBy(user => user.Count)
            };

            return response;
        }

        public int Create(string userName)
        {
            var newUser = new ChatUser
            {
                UserName = userName,
            };

            _dbContext.Users.Add(newUser);

            _dbContext.SaveChanges();

            return newUser.Id;
        }
    }
}
