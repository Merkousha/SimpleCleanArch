using System;

namespace SimpleCleanArch.Application.DTOs
{
    public class AuthorUpdateDto
    {
        public string Name { get; set; }
        public string Biography { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
    }
} 