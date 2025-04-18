using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCleanArch.Domain.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; }
        
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
        public ICollection<Keyword> Keywords { get; set; }
        
        public ICollection<BookRelation> RelatedBooks { get; set; }
        public ICollection<BookRelation> RelatedToBooks { get; set; }
        
        public int PageCount { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string FilePath { get; set; }
        public string CoverImagePath { get; set; }
        public bool IsPublished { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }
    }
}