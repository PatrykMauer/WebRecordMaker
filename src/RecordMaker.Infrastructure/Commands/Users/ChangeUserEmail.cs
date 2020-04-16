namespace RecordMaker.Infrastructure.Commands.Users
{
    public class ChangeUserEmail : AuthenticatedCommandBase
    {
        public string CurrentEmail { get; set; }
        public string NewEmail { get; set; }
    }
}