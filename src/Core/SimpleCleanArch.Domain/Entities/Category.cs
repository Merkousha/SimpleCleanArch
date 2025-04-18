namespace SimpleCleanArch.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }
}