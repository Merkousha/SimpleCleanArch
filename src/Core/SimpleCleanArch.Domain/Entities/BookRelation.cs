namespace SimpleCleanArch.Domain.Entities
{
    public class BookRelation
    {
        public int BookId { get; set; }
        public int RelatedBookId { get; set; }

        // Navigation properties
        public Book Book { get; set; }
        public Book RelatedBook { get; set; }
    }
} 