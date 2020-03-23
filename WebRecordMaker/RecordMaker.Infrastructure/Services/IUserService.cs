using System;
using System.Threading.Tasks;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(string email);
        Task RegisterAsync(Guid userId, string email,string username, string password, string role);
        Task LoginAsync(string email, string password);
        Task UpdateEmail(string currentEmail, string newEmail);
        Task<string> GetRole(string email);
    }
}