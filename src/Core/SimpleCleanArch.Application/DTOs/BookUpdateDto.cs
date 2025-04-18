using System;
using System.Collections.Generic;

namespace SimpleCleanArch.Application.DTOs
{
    public class BookUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Isbn { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> RelatedBookIds { get; set; }
    }
} 