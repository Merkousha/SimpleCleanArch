using AutoMapper;
using SimpleCleanArch.Application.DTOs;
using SimpleCleanArch.Domain.Entities;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCleanArch.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom((src, dest, _, context) => 
                    src.Author != null ? new List<AuthorDto> { context.Mapper.Map<AuthorDto>(src.Author) } : new List<AuthorDto>()))
                .ForMember(dest => dest.Category, opt => opt.MapFrom((src, dest, _, context) => 
                    src.Category != null ? context.Mapper.Map<CategoryDto>(src.Category) : null))
                .ForMember(dest => dest.Keywords, opt => opt.MapFrom((src, dest, _, context) => 
                    src.Keywords != null ? context.Mapper.Map<ICollection<KeywordDto>>(src.Keywords) : new List<KeywordDto>()))
                .ForMember(dest => dest.RelatedBooks, opt => opt.MapFrom((src, dest, _, context) => 
                    src.RelatedBooks != null ? context.Mapper.Map<ICollection<BookDto>>(src.RelatedBooks.Select(r => r.RelatedBook)) : new List<BookDto>()));

            CreateMap<BookDto, Book>();
            CreateMap<BookCreateDto, Book>()
                .ForMember(dest => dest.CoverImagePath, opt => opt.MapFrom(src => src.CoverImageUrl))
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => GenerateSlug(src.Title)))
                .ForMember(dest => dest.IsPublished, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.IsFree, opt => opt.MapFrom(src => src.Price == 0))
                .ForMember(dest => dest.PublishedYear, opt => opt.MapFrom(src => src.PublicationDate.Year))
                .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => $"books/{GenerateSlug(src.Title)}.pdf"))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.Isbn));
            CreateMap<BookUpdateDto, Book>()
                .ForMember(dest => dest.CoverImagePath, opt => opt.MapFrom(src => src.CoverImageUrl))
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => GenerateSlug(src.Title)))
                .ForMember(dest => dest.PublishedYear, opt => opt.MapFrom(src => src.PublicationDate.Year))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.Isbn))
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorIds != null && src.AuthorIds.Count > 0 ? src.AuthorIds[0] : 0))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryIds != null && src.CategoryIds.Count > 0 ? src.CategoryIds[0] : 0))
                .ForMember(dest => dest.RelatedBooks, opt => opt.Ignore());

            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography))
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slug))
                .ForMember(dest => dest.Books, opt => opt.Ignore());
            CreateMap<AuthorDto, Author>();
            CreateMap<AuthorCreateDto, Author>()
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => GenerateSlug(src.Name)));
            CreateMap<AuthorUpdateDto, Author>()
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => GenerateSlug(src.Name)));

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Books, opt => opt.Ignore());

            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryCreateDto, Category>()
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => GenerateSlug(src.Name)));
            CreateMap<CategoryUpdateDto, Category>()
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => GenerateSlug(src.Name)));

            CreateMap<Keyword, KeywordDto>()
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slug));
            CreateMap<KeywordDto, Keyword>();
            CreateMap<KeywordCreateDto, Keyword>()
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => GenerateSlug(src.Word)));
        }

        private static string GenerateSlug(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Convert to lowercase
            string slug = input.ToLower();
            
            // Remove special characters
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            
            // Replace spaces with hyphens
            slug = Regex.Replace(slug, @"\s+", "-");
            
            // Remove multiple hyphens
            slug = Regex.Replace(slug, @"-+", "-");
            
            // Trim hyphens from start and end
            slug = slug.Trim('-');
            
            return slug;
        }
    }
} 