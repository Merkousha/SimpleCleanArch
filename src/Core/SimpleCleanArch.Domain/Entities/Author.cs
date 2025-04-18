using System.Collections.Generic;

namespace SimpleCleanArch.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public string Slug { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
} 