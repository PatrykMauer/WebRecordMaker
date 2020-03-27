using System;
using System.Threading.Tasks;
using RecordMaker.Core.Domain;

namespace RecordMaker.Infrastructure.Services
{
    public interface IHandlerTask
    {
        IHandlerTask Always(Func<Task> always);
        IHandlerTask OnCustomError(Func<RecordMakerException, Task> onCustomError,
            bool propagateException=false, bool executeOnError = false);
        IHandlerTask OnError(Func<Exception, Task> onError,
            bool propagateException=false, bool executeOnError = false);

        IHandlerTask OnSuccess(Func<Task> onSuccess);
        IHandlerTask PropagateException();
        IHandlerTask DoNotPropagateException();
        IHandler Next();
        Task ExecuteAsync();

    }
}