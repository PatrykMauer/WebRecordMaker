using System;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto CreateLoginToken(Guid userId, string role);
        JwtDto CreateRecoveryToken(Guid userId);
    }
}