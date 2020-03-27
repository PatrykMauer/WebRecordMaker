using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RecordMaker.Infrastructure.DTO;
using RecordMaker.Infrastructure.Extensions;
using RecordMaker.Infrastructure.Settings;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace RecordMaker.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _settings;

        public JwtHandler(JwtSettings settings)
        {
            _settings = settings;
        }
        
        public JwtDto CreateLoginToken(Guid userId, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role,role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(), 
                    ClaimValueTypes.Integer64) 
            };

            var expires = now.AddMinutes(_settings.ExpiryMinutes);
            
            var signingCredentials =new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key))
                , SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: null,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );
            
            var token =new JwtSecurityTokenHandler().WriteToken(jwt);
            
            return new JwtDto()
            {
                Token = token,
                Expiry = expires.ToTimeStamp()
            };
        }

        public JwtDto CreateRecoveryToken(Guid userId)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(),
                    ClaimValueTypes.Integer64)
            };

            var expires = now.AddMinutes(_settings.ExpiryMinutes);

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key))
                , SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: null,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtDto()
            {
                Token = token,
                Expiry = expires.ToTimeStamp()
            };
        }
    }
}