using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put(ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
        
        [HttpPut]
        [Route("email")]
        public async Task<IActionResult> Put(ChangeUserEmail command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}