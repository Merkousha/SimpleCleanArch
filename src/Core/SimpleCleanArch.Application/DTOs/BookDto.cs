using System;
using System.Collections.Generic;

namespace SimpleCleanArch.Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
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
        public CategoryDto Category { get; set; }
        public ICollection<AuthorDto> Authors { get; set; }
        public ICollection<KeywordDto> Keywords { get; set; }
        public ICollection<BookDto> RelatedBooks { get; set; }
    }
} 