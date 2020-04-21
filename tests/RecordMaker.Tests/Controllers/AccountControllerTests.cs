using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordMaker.Api.Controllers;
using RecordMaker.Infrastructure.Commands;
using RecordMaker.Infrastructure.Commands.Users;
using RecordMaker.Infrastructure.Services;
using Xunit;

namespace RecordMaker.Tests.Controllers
{
    public class AccountControllerTests
    {
       private readonly Mock<ICommandDispatcher> _dispatcherMock=new Mock<ICommandDispatcher>();
       private readonly AccountController _controller;
       public AccountControllerTests()
        {
            _controller=new AccountController(_dispatcherMock.Object);
        }

       [Fact]
       public async Task controller_should_be_decorated_with_authorize_attribute()
       {
           typeof(AccountController).Should().BeDecoratedWith<AuthorizeAttribute>();
           await Task.CompletedTask;
       }
       
       [Fact]
       public async Task put_password_should_return_no_content()
       {
           _dispatcherMock.Setup((x =>
               x.DispatchAsync(It.IsAny<ChangeUserPassword>())));

           var response = await _controller.Put(It.IsAny<ChangeUserPassword>());

           response.Should().BeOfType<NoContentResult>();
       }
       
       [Fact]
       public async Task put_password_should_invoke_dispatch_async()
       {
           await _controller.Put(It.IsAny<ChangeUserPassword>());
           
           _dispatcherMock.Verify(x=>
               x.DispatchAsync(It.IsAny<ChangeUserPassword>()),Times.Once);
       }
       
       [Fact]
       public async Task put_email_should_return_no_content()
       {
           _dispatcherMock.Setup((x =>
               x.DispatchAsync(It.IsAny<ChangeUserPassword>())));

           var response = await _controller.Put(It.IsAny<ChangeUserPassword>());

           response.Should().BeOfType<NoContentResult>();
       }
       
       [Fact]
       public async Task put_email_should_invoke_dispatch_async()
       {
           await _controller.Put(It.IsAny<ChangeUserPassword>());
           
           _dispatcherMock.Verify(x=>
               x.DispatchAsync(It.IsAny<ChangeUserPassword>()),Times.Once);
       }
    }
}