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
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => ba.Author)))
                .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.BookKeywords.Select(bk => bk.Keyword)))
                .ForMember(dest => dest.RelatedBooks, opt => opt.MapFrom(src => src.RelatedToBooks.Select(br => br.RelatedBook)))
                .ReverseMap();

            CreateMap<BookCreateDto, Book>();
            CreateMap<BookUpdateDto, Book>();

            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<AuthorUpdateDto, Author>();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();

            CreateMap<Keyword, KeywordDto>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            
            // Add mapping for KeywordCreateDto
            CreateMap<KeywordCreateDto, Keyword>();
        }
    }
} 