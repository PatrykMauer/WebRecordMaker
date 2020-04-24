using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.DTO;
using RecordMaker.Infrastructure.Services;

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
        
        
        [Authorize(Policy ="admin")]
        [HttpGet("{email}")]
        public async  Task<UserDto> Get(string email)
            => await _userService.GetAsync(email);

       // [Authorize(Policy ="admin")]
        [HttpGet("all")]
        public async  Task<IEnumerable<UserDto>> Get()
            => await _userService.GetAllAsync();
        
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await DispatchAsync(command);

            return Created($"users/{command.Email}", null);
        }
    }
}