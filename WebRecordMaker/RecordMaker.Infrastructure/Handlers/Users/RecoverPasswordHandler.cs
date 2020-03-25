using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Users
{
    public class RecoverPasswordHandler : ICommandHandler<RecoverPassword>
    {
        private readonly IUserService _userService;

        public RecoverPasswordHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(RecoverPassword command) //Niech robote z dodaniem tokena do autoryzacji przejmie front?
        {
            await _userService.RecoverPassword(command.UserId, command.NewPassword);
        }
    }
}