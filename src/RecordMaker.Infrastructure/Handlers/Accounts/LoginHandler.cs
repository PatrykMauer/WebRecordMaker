using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Accounts;
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Accounts
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IHandler _handler;
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;


        public LoginHandler(IHandler handler, IUserService userService,
            IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _handler = handler;
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(Login command)
            => await _handler
                .Run(async () => await _userService.LoginAsync(command.Email, command.Password))
                .OnCustomError((e) => throw e)
                .Next()
                .Run((async () =>
                {
                    var user = await _userService.GetAsync(command.Email);
                    var jwt = _jwtHandler.CreateLoginToken(user.Id, user.Role);
                    _cache.SetJwt(command.TokenId, jwt, TimeSpan.FromSeconds(5));
                }))
                .Next()
                .ExecuteAllAsync();
        
    }
}
