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
        
        [Fact]
        public async Task given_current_and_new_email_should_be_changed()
        {
            var command = new ChangeUserEmail()
            {
                CurrentEmail = "referee1@wp.pl",
                NewEmail = "newEmail@wp.pl"
            };
            var payload = GetPayload(command);
            var response = await Client.PutAsync("account/email", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        }
        
        [Fact]
        public async Task creating_a_user_should_create_a_user()
        {
            var command = new CreateUser()
            {
                Email = "testEmail@wp.pl",
                Password = "secret",
                Username = "TestUserName",
                Profession = "Observer"
            };
            var payload = GetPayload(command);
            var response = await Client.PutAsync("users", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
        }
    }
}