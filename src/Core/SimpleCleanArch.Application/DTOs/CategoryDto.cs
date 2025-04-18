using System.Collections.Generic;

namespace SimpleCleanArch.Application.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public ICollection<BookDto> Books { get; set; }
    }
} 