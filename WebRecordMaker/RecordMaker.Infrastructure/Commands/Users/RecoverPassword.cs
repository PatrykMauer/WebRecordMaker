using System;

namespace RecordMaker.Infrastructure.Commands.Users
{
    public class RecoverPassword : AuthenticatedCommandBase
    {
        public string NewPassword { get; set; }
    }
}