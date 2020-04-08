using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Users
{
    public class ChangeUserEmailHandler : ICommandHandler<ChangeUserEmail>
    {
        private readonly IHandler _handler;
        private readonly IUserService _userService;

        public ChangeUserEmailHandler(IHandler handler, IUserService userService)
        {
            _handler = handler;
            _userService = userService;
        }

        public async Task HandleAsync(ChangeUserEmail command)
            => await _handler
                .Run(async () => await _userService.UpdateEmail(command.UserId, command.NewEmail))
                .Next()
                .ExecuteAllAsync();
        
    }
}