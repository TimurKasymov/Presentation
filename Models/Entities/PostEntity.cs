using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Community2._0.Models.Entities
{
    [Table("Post")]
    public class PostEntity : BaseEntity
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [MaxLength(300, ErrorMessage = "Exceeded text length")]
        public string Text { get; set; } = "This is my text.";
        public int Likes { get; set; } = 0;
        public byte[] Picture { get; set; }
    }
}