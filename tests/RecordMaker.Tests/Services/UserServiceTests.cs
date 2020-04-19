﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.DTO;
using RecordMaker.Infrastructure.Exceptions;
using RecordMaker.Infrastructure.Services;
using Xunit;
using ErrorCodes = RecordMaker.Infrastructure.Exceptions.ErrorCodes;

namespace RecordMaker.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IEncrypter> _encrypterMock = new Mock<IEncrypter>();
        private UserService _userService;

        public UserServiceTests()
        {
            _encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>()))
                .Returns("example_hash");
            _encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>()))
                .Returns("example_salt");
            
            _userService=new UserService(_userRepositoryMock.Object,_mapperMock.Object ,_encrypterMock.Object);
        }
          
        [Fact]
        public async Task get_async_when_not_finding_user_should_throw_service_exception_with_code_user_not_found()
        {
            _userService.Invoking(async x =>await x.GetAsync("email@email.com"))
                .Should().Throw<ServiceException>().Which.Code.Should().Be(ErrorCodes.UserNotFound);
            
            _userService.Invoking(async x =>await x.GetAsync(Guid.NewGuid()))
                .Should().Throw<ServiceException>().Which.Code.Should().Be(ErrorCodes.UserNotFound);
            
            await Task.CompletedTask;
        }
        
        [Fact]
        public async Task get_async_should_invoke_get_async_on_repository()
        {
            _userRepositoryMock.Setup(x => x.GetAsync("email@email.com"))
                .ReturnsAsync(new User(Guid.NewGuid(),"obserer@wp.pl",
                    "observ", "secret","salt", "Observer"));
            
            await _userService.GetAsync("email@email.com");
            
            _userRepositoryMock.Verify(x=>x.GetAsync(It.IsAny<string>()),Times.Once());
        }

        [Fact]
        public async Task get_all_async_should_return_user_dtos()
        {
            var enumerable = await _userService.GetAllAsync();
            enumerable.Should().BeOfType<UserDto[]>(because: "database should return DTO");
        }
        
        [Fact]
        public async Task register_async_should_invoke_get_async_on_repository()
        {
            await _userService.RegisterAsync(Guid.NewGuid(),"obserer@wp.pl",
                "observ", "secret", "Observer");
            
            _userRepositoryMock.Verify(x=>x.GetAsync(It.IsAny<string>()),Times.Once);
        }
        
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            await _userService.RegisterAsync(Guid.NewGuid(),"obserer@wp.pl", "observ",
                "secret", "Observer");
            
            _userRepositoryMock.Verify(x=>x.AddAsync(It.IsAny<User>()),Times.Once);
        }
        
        // [Fact]
        // public async Task register_async_should_throw_exception_registering_existing_user()
        // {
        //     await _userService.RegisterAsync(Guid.NewGuid(),"obserer@wp.pl", "observ",
        //         "secret", "Observer");
        //     
        // }
    }
}