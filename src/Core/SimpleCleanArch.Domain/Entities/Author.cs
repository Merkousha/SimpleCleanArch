using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCleanArch.Domain.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; }
        
        [MaxLength(500)]
        public string Biography { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; }
        
        public ICollection<Book> Books { get; set; }
    }
} 