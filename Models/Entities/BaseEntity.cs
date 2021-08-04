using System;
using System.ComponentModel.DataAnnotations;

namespace Community2._0.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public System.DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}