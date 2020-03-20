namespace RecordMaker.Infrastructure.Commands.Users
{
    public class ChangeUserEmail:ICommand
    {
        public string CurrentEmail { get; set; }
        public string NewEmail { get; set; }
    }
}