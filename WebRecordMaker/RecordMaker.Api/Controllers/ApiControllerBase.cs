using Microsoft.AspNetCore.Mvc;
using RecordMaker.Infrastructure.Commands;

namespace RecordMaker.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase:ControllerBase
    {
        protected readonly ICommandDispatcher CommandDispatcher;

        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }
    }
}