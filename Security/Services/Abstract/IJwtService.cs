using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Community2._0.Models.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Community2._0.Security.Services.Abstract
{
    public interface IJwtService
    {
        public string CreateJwtToken(AccountEntity account);

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        public string GenerateRefreshToken();
    }
}