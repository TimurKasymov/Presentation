using Community2._0.Models.Entities;

namespace Community2._0.Security.Services.Abstract
{
    public interface ILoginService
    {
        public AccountEntity LoginService(SignInAccountEntity signAccount);
    }
}