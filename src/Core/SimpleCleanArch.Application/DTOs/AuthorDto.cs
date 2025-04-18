using System.Collections.Generic;

namespace SimpleCleanArch.Application.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Slug { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<BookDto> Books { get; set; }
    }
} 