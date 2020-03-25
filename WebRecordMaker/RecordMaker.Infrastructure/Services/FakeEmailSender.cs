using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace RecordMaker.Infrastructure.Services
{
    public class FakeEmailSender : IEmailSender
    {
        private readonly ILogger<FakeEmailSender> _logger;

        public FakeEmailSender(ILogger<FakeEmailSender> logger)
        {
            _logger = logger;
        }
        public async Task SendEmail(string body)
        {
            Console.WriteLine(body);
            await Task.CompletedTask;
        }
    }
}