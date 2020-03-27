using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands.Users;

namespace RecordMaker.Infrastructure.Commands
{
    public interface ICommandHandler<T>where T:ICommand
    {
        Task HandleAsync(T command);
    }
}