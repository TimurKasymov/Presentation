using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Community2._0.Models.Entities;
using Community2._0.Security.Services.Abstract;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Community2._0.Security.Services
{
    public class JwtService: IJwtService
    {
        private IOptions<AuthOptions> _options;
        public JwtService(IOptions<AuthOptions> options)
        {
            _options = options;
        }

        /// <summary>
        /// Создает JWT токен
        /// </summary>
        /// <param name="???"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public string CreateJwtToken(AccountEntity account)
        {
            var options = _options.Value;
            var tokenHendler = new JwtSecurityTokenHandler();
            var signCredentials = new SigningCredentials(options.GetSymmetricSecurityKey(),
                SecurityAlgorithms.Sha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, account.Email),
                new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
                new Claim("role", account.Role.ToString())
            };
            var token = new JwtSecurityToken(options.Issuer, options.Audience, claims,
                signingCredentials: signCredentials, expires: DateTime.Now.AddSeconds(options.TokenLifeTime));
            return tokenHendler.WriteToken(token);
        }
        //public GetPrincipalFromExpiredToken(string token){}
        //public GenerateRefreshToken(){}
    }
}