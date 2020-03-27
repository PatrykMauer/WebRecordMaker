using System;
using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Users
{
    public class CreateUserHandler: ICommandHandler<CreateUser>
    {
        private readonly IHandler _handler;
        private readonly IUserService _userService;
        
        public CreateUserHandler(IHandler handler, IUserService userService)
        {
            _handler = handler;
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
            => await _handler
                .Run(async () => await _userService.RegisterAsync(Guid.NewGuid(), command.Email,
                    command.Username, command.Password, command.Role))
                .ExecuteAsync();

    }
}