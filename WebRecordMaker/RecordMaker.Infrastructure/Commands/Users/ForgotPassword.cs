using System;
using System.Net.NetworkInformation;

namespace RecordMaker.Infrastructure.Commands.Users
{
    public class ForgotPassword : ICommand
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
    }
}