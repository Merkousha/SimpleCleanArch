using System;

namespace SimpleCleanArch.Application.DTOs
{
    public class BookCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
    }
} 