using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler:ICommandHandler<ChangeUserPassword>
        {
            private readonly IHandler _handler;
            private readonly IUserService _userService;

            public ChangeUserPasswordHandler(IHandler handler, IUserService userService)
            {
                _handler = handler;
                _userService = userService;
            }

            public async Task HandleAsync(ChangeUserPassword command)
                =>await  _handler
                    .Run(async () => await Task.CompletedTask)
                    .Next()
                    .ExecuteAllAsync();

        }
}