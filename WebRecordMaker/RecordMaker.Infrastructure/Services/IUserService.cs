using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface IUserService
    {
        UserDto Get(string email);
        void Register(string email,string username, string password, string profession);
    }
}