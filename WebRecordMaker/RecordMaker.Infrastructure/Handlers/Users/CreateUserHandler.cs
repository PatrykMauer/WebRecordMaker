using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers
{
    public class CreateUserHandler: ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
        
        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email,command.Username,command.Password,command.Profession);
        }
    }
}