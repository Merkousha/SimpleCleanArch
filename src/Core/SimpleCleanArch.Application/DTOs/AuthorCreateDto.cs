using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCleanArch.Application.DTOs
{
    public class AuthorCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Biography { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }
    }
} 