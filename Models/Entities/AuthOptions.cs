using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Community2._0.Models.Entities
{
    public class AuthOptions
    {
        public string Audience {get; set;}
        public string  Issuer {get; set;}
        public string Secret {get; set;} 
        public int  TokenLifeTime {get; set;}
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}