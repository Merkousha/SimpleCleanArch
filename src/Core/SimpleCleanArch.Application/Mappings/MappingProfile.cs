using AutoMapper;
using SimpleCleanArch.Application.DTOs;
using SimpleCleanArch.Domain.Entities;

namespace SimpleCleanArch.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Keywords))
                .ForMember(dest => dest.RelatedBooks, opt => opt.MapFrom(src => src.RelatedBooks));

            CreateMap<BookDto, Book>();
            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();

            CreateMap<Author, AuthorDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Biography, opt => opt.MapFrom(src => src.Biography))
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slug))
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
            CreateMap<AuthorDto, Author>();
            CreateMap<AuthorCreateDto, Author>()
                .ForMember(dest => dest.Slug, opt => opt.Ignore());
            CreateMap<AuthorUpdateDto, Author>()
                .ForMember(dest => dest.Slug, opt => opt.Ignore());

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();

            CreateMap<Keyword, KeywordDto>()
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slug));
            CreateMap<KeywordDto, Keyword>();
            CreateMap<KeywordCreateDto, Keyword>()
                .ForMember(dest => dest.Slug, opt => opt.Ignore());
        }
    }
} 