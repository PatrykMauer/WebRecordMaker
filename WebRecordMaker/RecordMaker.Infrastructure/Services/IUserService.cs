using System.Threading.Tasks;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(string email);
        Task RegisterAsync(string email,string username, string password, string profession);
        Task UpdateEmail(string currentEmail, string newEmail);
    }
}