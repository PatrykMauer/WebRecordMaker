﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.DTO;
using RecordMaker.Infrastructure.Exceptions;
using RecordMaker.Infrastructure.Extensions;
using ErrorCodes = RecordMaker.Infrastructure.Exceptions.ErrorCodes;

namespace RecordMaker.Infrastructure.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;


        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
        }

        public async Task<UserDto> GetAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetOrFailAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task RegisterAsync(Guid userId, string email,
            string username, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new ServiceException(ErrorCodes.EmailInUse,$"User with email '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user=new User(userId, email,username,hash,salt,role);
            await _userRepository.AddAsync(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user==null)
            {
                throw new ServiceException(ErrorCodes.InvalidCredentials,"Invalid credentials");
            }
            
            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
            {
                return;
            }
            throw new ServiceException(ErrorCodes.InvalidCredentials,"Invalid credentials");
        }

        public async Task RecoverPasswordAsync(Guid userId, string newPassword)
        {
           var user= await _userRepository.GetAsync(userId);
           var salt = _encrypter.GetSalt(newPassword);
           user.SetSalt(salt);
           user.SetPassword(_encrypter.GetHash(newPassword, salt));

           await _userRepository.UpdateAsync(user);
        }

        public async Task UpdateEmailAsync(Guid userId, string newEmail)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            user.SetEmail(newEmail);
            await _userRepository.UpdateAsync(user);
        }
    }
}