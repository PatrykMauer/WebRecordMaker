using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.Services;

namespace RecordMaker.Infrastructure.Handlers.Users
{
    public class ChangeUserEmailHandler:ICommandHandler<ChangeUserEmail>
    {
        private readonly IUserService _userService;
        
        public ChangeUserEmailHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandleAsync(ChangeUserEmail command)
        {
            await Task.CompletedTask;

            // await _userService.UpdateEmail(command.CurrentEmail,command.NewEmail);
        }
    }
}