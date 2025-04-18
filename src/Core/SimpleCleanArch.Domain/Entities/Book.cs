using System.Collections.Generic;

namespace SimpleCleanArch.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string FilePath { get; set; }
        public string CoverImagePath { get; set; }
        public bool IsPublished { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookKeyword> BookKeywords { get; set; }
        public virtual ICollection<BookRelation> RelatedToBooks { get; set; }
        public virtual ICollection<BookRelation> RelatedFromBooks { get; set; }
    }
}