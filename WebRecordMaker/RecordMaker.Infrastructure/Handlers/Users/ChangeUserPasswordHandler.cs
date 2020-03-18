using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;

namespace RecordMaker.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler:ICommandHandler<ChangeUserPassword>
        {
            public async Task HandleAsync(ChangeUserPassword command)
            {
                await Task.CompletedTask;
            }
        }
}