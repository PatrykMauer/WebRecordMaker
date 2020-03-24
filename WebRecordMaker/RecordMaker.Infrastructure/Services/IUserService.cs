using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> GetAllAsync();

        Task RegisterAsync(Guid userId, string email,string username, string password, string role);
        Task LoginAsync(string email, string password);
        Task UpdateEmail(Guid userId, string newEmail);
    }
}