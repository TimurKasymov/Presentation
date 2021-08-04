using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Community2._0.Models.Entities
{
    [Table("Account")]
    public class AccountEntity : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        public string About { get; set; } = "Hi, it is me.";
        public List<PostEntity> Posts { get; set; } = new List<PostEntity>();
        [Required(ErrorMessage = "Role is required")]
        public Role Role { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password  { get; set; }
        [EmailAddress, Required(ErrorMessage = "Email is required")]
        public string Email  { get; set; }
        public string RefreshToken { get; set; } = null;
    }


    public enum Role
    {
        Admin,
        User
    }

    public class AccountEntityTest : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        public string About { get; set; } = "Hi, it is me.";
        [Required(ErrorMessage = "Role is required")]
        public Role Role { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [EmailAddress, Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
    }

    public class Respons
    {
        public string message { get; set; }
    }
    public class AccountChanging
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        public string About { get; set; } = "Hi, it is me.";
        [Required(ErrorMessage = "Role is required")]
        public string Password { get; set; }
        public string PastPassword { get; set; }
        public string Email { get; set; }
    }

    public class RefreshTokenEntity
    {
        public string ExpiredToken { get; set; }
        public string RefreshToken { get; set; }
    }
}