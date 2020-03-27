using System;

namespace RecordMaker.Infrastructure.Commands.Accounts
{
    public class RecoverPassword : AuthenticatedCommandBase
    {
        public string NewPassword { get; set; }
    }
}