using System;
using System.Threading.Tasks;

namespace RecordMaker.Infrastructure.Services
{
    public interface IHandlerTaskRunner
    {
        IHandlerTask Run(Func<Task> run);
    }
}