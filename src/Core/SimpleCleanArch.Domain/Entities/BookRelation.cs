using System.ComponentModel.DataAnnotations;

namespace SimpleCleanArch.Domain.Entities;

public class BookRelation : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    
    public int RelatedBookId { get; set; }
    public Book RelatedBook { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string RelationType { get; set; }
} 