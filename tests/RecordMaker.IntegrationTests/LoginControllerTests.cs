using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using RecordMaker.Api;
using RecordMaker.Infrastructure.Commands.Accounts;
using Xunit;


namespace RecordMaker.IntegrationTests
{
    public class LoginControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public LoginControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(b=>b.UseEnvironment("Development"));
        }


        [Fact]
        public async Task login_should_set_cache()
        {
            var client = _factory.CreateClient();
            var command = new Login{Email = "user1@test.com", Password = "secret"};

            var response = await client.PostAsJsonAsync("login", command);

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}