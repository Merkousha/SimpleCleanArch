namespace SimpleCleanArch.Domain.Entities
{
    public class Keyword : BaseEntity
    {
        public string Word { get; set; }

        // Navigation property
        public ICollection<BookKeyword> BookKeywords { get; set; }
    }
}