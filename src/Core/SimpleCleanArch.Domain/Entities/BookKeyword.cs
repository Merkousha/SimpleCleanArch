namespace SimpleCleanArch.Domain.Entities
{
    public class BookKeyword
    {
        public int BookId { get; set; }
        public int KeywordId { get; set; }

        // Navigation properties
        public Book Book { get; set; }
        public Keyword Keyword { get; set; }
    }
} 