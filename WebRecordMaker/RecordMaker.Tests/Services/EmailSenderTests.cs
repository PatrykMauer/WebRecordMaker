using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using RecordMaker.Infrastructure.Services;
using Xunit;

namespace RecordMaker.Tests.Services
{
    public class EmailSenderTests
    {
        [Fact]
        public void email_should_be_sent()
        {
            var sender = new EmailSender();
            var body = "test";
            var response = sender.SendEmail(body);
           
                response.Status.Should().Be(TaskStatus.WaitingForActivation);
        }
    }
}