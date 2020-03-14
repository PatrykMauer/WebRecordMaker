using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public UserDto Get(string email)
            => _userService.Get(email);

        [HttpPost("")]
        public void Post([FromBody] CreateUser request)
        {
            _userService.Register(request.Email,request.Username,request.Password,request.Profession);
        }
    }
}