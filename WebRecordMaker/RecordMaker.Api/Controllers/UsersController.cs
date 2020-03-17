using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.DTO;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{email}")]
        public async  Task<UserDto> Get(string email)
            => await _userService.GetAsync(email);

        [HttpPost("")]
        public async Task Post([FromBody] CreateUser command)
        {
            await _commandDispatcher.DispatchAsync(command);
        }
    }
}