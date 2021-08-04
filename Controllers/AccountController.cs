using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Community2._0.BLL.Abstract;
using Community2._0.Models.Entities;

using Community2._0.Security.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Community2._0.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController: ControllerBase
    {
        //private ILoginService _login;
        private IJwtService _jwtService;
        //private IWebHostEnvironment _appEnvironment;
        private IPasswordHashSercice _passwordHashSercice;
        private IService<AccountEntity> _accountService;
        public AccountController(IJwtService jwtService, IService<AccountEntity> accountService, IPasswordHashSercice passwordHashSercice)
        {
            _passwordHashSercice = passwordHashSercice;
            _accountService = accountService;
            _jwtService = jwtService;
        }
        ///// <summary>
        ///// Принимает эмайл и пароль, возвращает JwtToken пользователя 
        ///// </summary>
        ///// <param name="signInAccount"></param>
        ///// <returns></returns>
        [HttpPost("editing")]
        public async Task<IActionResult> AccountEditing([FromBody] AccountChanging accountC)
        {
            var pastPassword = _passwordHashSercice.HashPassword(accountC.PastPassword);
            var newPassword = _passwordHashSercice.HashPassword(accountC.Password);
            var foundAccount = _accountService.Get(accountC.Email, pastPassword, false);
            if (foundAccount == null) { return new JsonResult(new { message = "Аккаунт не найден" }); }
            else if (foundAccount.Password == pastPassword)
            {
                foundAccount.Name = accountC.Name;
                foundAccount.Password = newPassword;
                foundAccount.Surname = accountC.Surname;
                await _accountService.Update(foundAccount);
                return new JsonResult(new { account = foundAccount });
            }
            else { return new JsonResult(new { message = "Неверный пароль" }); }
        }
        ///// <summary>
        ///// Создает Account
        ///// </summary>
        ///// <param name="account"></param>
        ///// <returns></returns>
        ///// <exception cref="Exception"></exception>
        [HttpPost("login")]
        public IActionResult Login([FromBody] SignInAccountEntity signINaccount)
        {
            var passwordHashed = _passwordHashSercice.HashPassword(signINaccount.Password);
            signINaccount.Password = passwordHashed;
            var account = _accountService.Get(signINaccount.Email, signINaccount.Password, false);
            if ( account == null)
            {
                var res1 = new {newToken = "non", refreshToken = "non"};
                return new JsonResult(res1);
            }
            var refreshToken = account.RefreshToken;
            var token = _jwtService.CreateJwtToken(account);
            var res = new {newToken = token, refreshToken = refreshToken, _account = account};
            return new JsonResult(res);
        }
        //[HttpPost("passImage")]
        //public async Task<IActionResult> PassImage(IFormFile file)
        //{
        //    string path = "/images/" + file.FileName;
        //    FileStream fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create);
        //    await file.CopyToAsync(fileStream);
        //    return Ok("Все ок");
        //}

        [HttpPost("getAccount")]
        public IActionResult GetAccount(RefreshTokenEntity refreshToken)
        {
            var principal = _jwtService.GetPrincipalFromExpiredToken(refreshToken.ExpiredToken);
            var id = principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var account = _accountService.Get(Int32.Parse(id));
            Console.WriteLine(account.Name);
            return new JsonResult(new {account = account});
        }
        [HttpPost("newToken")]
        public IActionResult GetNewToken(RefreshTokenEntity refreshToken)
        {
            var principal = _jwtService.GetPrincipalFromExpiredToken(refreshToken.ExpiredToken);
            var id = principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var account = _accountService.Get(Int32.Parse(id));
            if (account == null || account.RefreshToken != refreshToken.RefreshToken) return BadRequest();
            var newJwtToken = _jwtService.CreateJwtToken(account);
            var newRefreshToken = _jwtService.GenerateRefreshToken();
            account.RefreshToken = newRefreshToken;
            return new JsonResult(new { newToken = newJwtToken, refreshToken = newRefreshToken, _account = account});
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AccountEntity accountEntity)
        {
            var headers = HttpContext.Request.Headers;
            var password = _passwordHashSercice.HashPassword(accountEntity.Password);
            accountEntity.Password = password;
            if (_accountService.Get(accountEntity.Email, password, true) == null)
            {
                var refreshToken = _jwtService.GenerateRefreshToken();
                accountEntity.RefreshToken = refreshToken;
                await _accountService.Create(accountEntity);
                var account = _accountService.Get(accountEntity.Email, accountEntity.Password, true);
                var token = _jwtService.CreateJwtToken(account);
                var res = new {message = "Аккаунт создан", 
                    token = token, refreshToken = refreshToken};
                return new JsonResult(res);
            }
            else
            {
                var res = new {message = "Аккаунт с таким эмайлом уже существует", 
                    token = "non",
                    refreshToken = "non"
                };
                return new JsonResult(res);
            }
        }
    }
}