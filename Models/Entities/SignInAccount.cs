using System.ComponentModel.DataAnnotations;

namespace Community2._0.Models.Entities
{
    public class SignInAccountEntity
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}