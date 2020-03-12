using System;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto Get(string email)
        {
            var user = _userRepository.Get(email);
            return new UserDto()
            {
                Id=user.Id, 
                Email=user.Email,
                Profession = user.Profession,
                Username = user.Username, 
                FullName=user.FullName
            };
        }

        public void Register(string email,string username, string password,string profession)
        {
            var user = _userRepository.Get(email);
            if (user == null)
            {
                throw new Exception($"User with email '{email}' already exists.");
            }
            var salt=Guid.NewGuid().ToString("N");
            user=new User(email,username,password,salt,profession);
            _userRepository.Add(user);
        }
    }
}