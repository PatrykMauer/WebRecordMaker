using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using RecordMaker.Api.Controllers;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Accounts;
using RecordMaker.Infrastructure.DTO;
using RecordMaker.Infrastructure.Extensions;
using Xunit;

namespace RecordMaker.Tests.Controllers
{
    public class LoginControllerTests
    {
        private readonly Mock<ICommandDispatcher> _dispatcherMock=new Mock<ICommandDispatcher>();
        private readonly Mock<IMemoryCache> _cacheMock = new Mock<IMemoryCache>();
        private readonly LoginController _controller;
        delegate bool CacheReturns(object key ,out JwtDto obj); 
        
        public LoginControllerTests()
        {
            _controller=new LoginController(_dispatcherMock.Object, _cacheMock.Object);
        }
       

        [Fact]
        public async Task controller_should_not_be_decorated_with_authorize_attribute()
        {
            typeof(LoginController).Should().NotBeDecoratedWith<AuthorizeAttribute>();
            await Task.CompletedTask;
        }
        
        [Fact]
        public async Task post_should_return_ok_with_jwt_token()
        {
            var command = new Login();
            
            var response = await _controller.Post(command);

            response.Should().BeOfType<OkObjectResult>();
        }
    }  
}