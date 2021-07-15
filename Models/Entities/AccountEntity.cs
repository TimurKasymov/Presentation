using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public List<PostEntity> Posts { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public Role Role { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password  { get; set; }
        [EmailAddress, Required(ErrorMessage = "Email is required")]
        public string Email  { get; set; }
    }

    public enum Role
    {
        Admin,
        User
    }
}