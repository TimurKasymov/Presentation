using System;
using System.Security.Cryptography;
using System.Text;
using Community2._0.Security.Services.Abstract;

namespace Community2._0.Security.Services
{
    /// <summary>
    /// Хэширует пароли
    /// </summary>
    public class PasswordHasherService: IPasswordHashSercice
    {
        public string HashPassword(string password)
        {
            var cripto = new SHA1CryptoServiceProvider();
            byte[] bytes = Encoding.ASCII.GetBytes(password);
            var str = cripto.ComputeHash(bytes);
            return Convert.ToBase64String(str);
        }
    }
}