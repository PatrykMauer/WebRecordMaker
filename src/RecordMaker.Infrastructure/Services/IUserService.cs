using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(Guid userId);
        Task<UserDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> GetAllAsync();

        Task RegisterAsync(Guid userId, string email,string username, string password, string role);
        Task LoginAsync(string email, string password);
        Task RecoverPasswordAsync(Guid userId, string newPassword);
        Task UpdateEmailAsync(Guid userId, string newEmail);
    }
}