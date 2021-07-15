using Community2._0.BLL.Abstract;
using Community2._0.Models.Entities;
using Community2._0.Security.Services.Abstract;

namespace Community2._0.Security.Services
{
    /// <summary>
    /// Возвращает AccountEntity на основе SignInAccount
    /// нужно добавить в DI!
    /// </summary>
    public class Login: ILoginService
    {
        private IService<AccountEntity> _context;
        public Login(IService<AccountEntity> context)
        {
            _context = context;
        }
        public AccountEntity LoginService(SignInAccountEntity signAccount)
        {
            var account = _context.Get(signAccount.Email, signAccount.Password);
            return account;
        }
    }
}