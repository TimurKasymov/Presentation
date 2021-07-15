using System;
using Community2._0.Models.Entities;
using Community2._0.Security.Services;
using Community2._0.Security.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Community2._0.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController: ControllerBase
    {
        private ILoginService _login;
        private IJwtService _jwtService;

        public AccountController(ILoginService login, IJwtService jwtService)
        {
            _login = login;
            _jwtService = jwtService;
        }
        /// <summary>
        /// Принимает эмайл и пароль, возвращает JwtToken пользователя 
        /// </summary>
        /// <param name="signInAccount"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] SignInAccountEntity signInAccount)
        {
            AccountEntity account = _login.LoginService(signInAccount);
            if (account != null)
            {
                string jwtToken = _jwtService.CreateJwtToken(account);
                return Ok(new { access_token = jwtToken });
            }
            return new UnauthorizedResult();
        }
        /// <summary>
        /// Создает Account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] SignInAccountEntity account)
        {
            throw new Exception();
        }
    }
}