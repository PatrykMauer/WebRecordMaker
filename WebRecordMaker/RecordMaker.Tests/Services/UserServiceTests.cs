﻿using System;
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
        [Fact]
        public async Task register_async_should_invoke_add_async_get_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            
            var userService=new UserService(userRepositoryMock.Object,mapperMock.Object);
            await userService.RegisterAsync("obserer@wp.pl", "observ", "seceret", "Observer");
            
            userRepositoryMock.Verify(x=>x.AddAsync(It.IsAny<User>()),Times.Once);
        }
        [Fact]
        public async Task register_async_should_invoke_get_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            
            var userService=new UserService(userRepositoryMock.Object,mapperMock.Object);
            await userService.RegisterAsync("obserer@wp.pl", "observ", "seceret", "Observer");
            
            userRepositoryMock.Verify(x=>x.GetAsync(It.IsAny<string>()),Times.Once);
        }

        [Fact]
        public async Task get_async_should_invoke_get_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            
            var userService=new UserService(userRepositoryMock.Object,mapperMock.Object);
            await userService.GetAsync("email@email.com");
            
            userRepositoryMock.Verify(x=>x.GetAsync(It.IsAny<string>()),Times.Once());
        }
    }
}