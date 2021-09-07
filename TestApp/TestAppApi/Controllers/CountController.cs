using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using TQ.Entites;
using TQ.BAL;
using TQ.Services;

namespace TestAppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
       
        private readonly IUsersRepository _users;
        private readonly ILogger _logger;
        public ChatController(IUsersRepository users,ILogger logger)
        {
            _users = users;
            _logger = logger;
        }

        [HttpGet("/messages")]
        public ActionResult<ChatMessage[]> Get()
        {
            return ChatService.Instance.Messages.ToArray();
        }

        [HttpGet("/counter/{iterations?}")]
        public async Task<ActionResult<int>> Get(int? iterations, CancellationToken token=default)
        {
            var task = await WorkerTallyCounter.TallyCounterAsync(iterations??0, () => true);

            return task;
        }

        [HttpGet("/users")]
        public async Task<ActionResult<GetUsersResponse>> Get([FromBody] GetUsersRequest request)
        {
            GetUsersResponse getUsersResponse=new GetUsersResponse(); 
            try
            {
                getUsersResponse= await _users.Get(request);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting response : {ex.Message}");
            }

            return getUsersResponse;
        }

        [HttpPost("/users")]
        public ActionResult<int> Create(string userName)
        {
            int result = 0;
            try
            {
                result= _users.Create(userName);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error while creating user : {ex.Message}");
            }
            return result;
          
        }
    }
}
