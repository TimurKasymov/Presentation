using Community2._0.Models.Entities;

namespace Community2._0.Security.Services.Abstract
{
    public interface IJwtService
    {
        public string CreateJwtToken(AccountEntity account);
    }
}