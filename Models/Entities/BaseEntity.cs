using System;

namespace Community2._0.Models.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public System.DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}