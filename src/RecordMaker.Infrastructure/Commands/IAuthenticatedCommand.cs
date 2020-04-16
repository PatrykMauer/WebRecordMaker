using System;

namespace RecordMaker.Infrastructure.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        public Guid UserId { get; set; }
    }
}