using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.Services;
using Xunit;

namespace RecordMaker.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IEncrypter> _encrypterMock = new Mock<IEncrypter>();

          
        [Fact]
        public async Task register_async_should_invoke_add_async__on_repository()
        {
            var userService=new UserService(_userRepositoryMock.Object,_mapperMock.Object, _encrypterMock.Object);
            await userService.RegisterAsync(Guid.NewGuid(),"obserer@wp.pl", "observ", "seceret", "Observer");
            
            _userRepositoryMock.Verify(x=>x.AddAsync(It.IsAny<User>()),Times.Once);
        }
        [Fact]
        public async Task register_async_should_invoke_get_async_on_repository()
        {
            var userService=new UserService(_userRepositoryMock.Object,_mapperMock.Object, _encrypterMock.Object);
            await userService.RegisterAsync(Guid.NewGuid(),"obserer@wp.pl", "observ", "seceret", "Observer");
            
            _userRepositoryMock.Verify(x=>x.GetAsync(It.IsAny<string>()),Times.Once);
        }

        [Fact]
        public async Task get_async_should_invoke_get_async_on_repository()
        {
            var userService=new UserService(_userRepositoryMock.Object,_mapperMock.Object ,_encrypterMock.Object);
            await userService.GetAsync("email@email.com");
            
            _userRepositoryMock.Verify(x=>x.GetAsync(It.IsAny<string>()),Times.Once());
        }
    }
}