namespace RecordMaker.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : AuthenticatedCommandBase
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}