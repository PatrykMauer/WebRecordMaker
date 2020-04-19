using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Accounts;
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Accounts
{
    public class RecoverPasswordHandler : ICommandHandler<RecoverPassword>
    {
        private readonly IHandler _handler;
        private readonly IUserService _userService;

        public RecoverPasswordHandler(IHandler handler, IUserService userService)
        {
            _handler = handler;
            _userService = userService;
        }

        public async Task HandleAsync(RecoverPassword command)
            => await _handler
                .Run(async () => await _userService.RecoverPasswordAsync(command.UserId, command.NewPassword))
                .Next()
                .ExecuteAllAsync();
    }
}