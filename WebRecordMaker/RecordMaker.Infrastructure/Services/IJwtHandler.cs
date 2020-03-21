using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(string email, string role);
    }
}