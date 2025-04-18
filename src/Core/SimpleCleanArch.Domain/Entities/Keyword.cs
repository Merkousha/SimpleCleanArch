using System.ComponentModel.DataAnnotations;

namespace SimpleCleanArch.Domain.Entities;

public class Keyword : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Word { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Slug { get; set; }
    
    public ICollection<Book> Books { get; set; }
}