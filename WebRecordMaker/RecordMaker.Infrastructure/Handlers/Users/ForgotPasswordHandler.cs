using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Users
{
    public class ForgotPasswordHandler : ICommandHandler<ForgotPassword>
    {
        private readonly IMemoryCache _cache;
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IEmailSender _sender;

        public ForgotPasswordHandler(IMemoryCache cache,
            IUserService userService,
            IJwtHandler jwtHandler,
            IEmailSender sender)
        {
            _cache = cache;
            _userService = userService;
            _jwtHandler = jwtHandler;
            _sender = sender;
        }
        public async Task HandleAsync(ForgotPassword command)
        {
           var user= await _userService.GetAsync(command.Email);
           var jwt = _jwtHandler.CreateRecoveryToken(user.Id);
           await _sender.SendEmail(jwt.Token);
        }
    }
}