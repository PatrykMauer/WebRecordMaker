using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Accounts;
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Accounts
{
    public class ForgotPasswordHandler : ICommandHandler<ForgotPassword>
    {
        private readonly IHandler _handler;
        private readonly IMemoryCache _cache;
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IEmailSender _sender;

        public ForgotPasswordHandler(IHandler handler, IMemoryCache cache,
            IUserService userService,
            IJwtHandler jwtHandler,
            IEmailSender sender)
        {
            _handler = handler;
            _cache = cache;
            _userService = userService;
            _jwtHandler = jwtHandler;
            _sender = sender;
        }

        public async Task HandleAsync(ForgotPassword command)
            => await _handler
                .Run(async () =>
                {
                    var user = await _userService.GetAsync(command.Email);
                    var jwt = _jwtHandler.CreateRecoveryToken(user.Id);
                    await _sender.SendEmail(jwt.Token);
                })
                .ExecuteAsync();

    }
}