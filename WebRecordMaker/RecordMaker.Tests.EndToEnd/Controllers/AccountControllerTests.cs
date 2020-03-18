using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using RecordMaker.Api;
using RecordMaker.Infrastructure.Commands.Users;
using Xunit;

namespace RecordMaker.Tests.EndToEnd.Controllers
{
    public class AccountControllerTests:ControllerTestBase
    {

        [Fact]
        public async Task given_valid_current_and_new_password_should_be_changed()
        {
            var command = new ChangeUserPassword()
            {
                CurrentPassword = "secret",
                NewPassword = "seceret2"
            };
            var payload = GetPayload(command);
            var response = await Client.PutAsync("account/password", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        }
        
    }
}