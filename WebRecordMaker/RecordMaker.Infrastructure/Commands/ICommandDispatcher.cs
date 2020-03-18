using System.Threading.Tasks;
using RecordMaker.Infrastructure.Commands.Users;

namespace RecordMaker.Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}