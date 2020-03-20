using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.DTO;
using RecordMaker.Infrastructure.Services;
using RecordMaker.Infrastructure.Settings;

namespace RecordMaker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService,
            ICommandDispatcher commandDispatcher):base(commandDispatcher)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async  Task<UserDto> Get(string email)
            => await _userService.GetAsync(email);

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Ok();
        }
    }
}