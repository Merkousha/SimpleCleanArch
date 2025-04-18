using System.ComponentModel.DataAnnotations;

namespace SimpleCleanArch.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }
}