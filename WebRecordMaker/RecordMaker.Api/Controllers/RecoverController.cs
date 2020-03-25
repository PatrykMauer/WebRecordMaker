using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;

namespace RecordMaker.Api.Controllers
{
    public class RecoverController : ApiControllerBase
    {
        public RecoverController(ICommandDispatcher commandDispatcher)
            :base(commandDispatcher)
        {
        }
        
        [HttpPost("forgot")]
        public async Task<IActionResult> Post([FromBody] ForgotPassword command)
        { 
            command.TokenId = Guid.NewGuid();
            await DispatchAsync(command);
        
            return Ok();
        }
        
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] RecoverPassword command)
        { 
            await DispatchAsync(command);
        
            return Ok();
        }
    }
}