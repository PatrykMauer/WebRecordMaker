using System;
using System.Threading.Tasks;
using AutoMapper;
using RecordMaker.Core.Domain;
using RecordMaker.Core.Repositories;
using RecordMaker.Infrastructure.DTO;

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

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string email,string username, string password, string profession)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with email '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user=new User(email,username,hash,salt,profession);
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateEmail(string currentEmail, string newEmail)
        {
            var user = await _userRepository.GetAsync(currentEmail);
            if (user == null)
            {
                throw new Exception($"User with email '{currentEmail}' doesn't exists.");
            }
            user.ChangeEmail(newEmail);
            await _userRepository.UpdateAsync(user);
        }
    }
}