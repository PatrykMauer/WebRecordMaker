using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;
        public AccountController(ICommandDispatcher commandDispatcher,
            IJwtHandler jwtHandler) : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpGet]
        [Route("token")]
        public IActionResult Get()
        {
            var token = _jwtHandler.CreateToken("referee1@wp.pl", "observer");

            return Ok(token);
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