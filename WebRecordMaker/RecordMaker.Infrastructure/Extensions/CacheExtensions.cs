using System;
using System.Threading;
using Microsoft.Extensions.Caching.Memory;
using RecordMaker.Infrastructure.DTO;

namespace RecordMaker.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtDto jwt, TimeSpan expiryTime)
            => cache.Set(GetJwtKey(tokenId), jwt, expiryTime);

        public static JwtDto GetJwt(this IMemoryCache cache, Guid tokenId)
            => cache.Get<JwtDto>(GetJwtKey(tokenId));

        private static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}