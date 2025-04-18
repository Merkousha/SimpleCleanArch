using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCleanArch.Application.DTOs;
using SimpleCleanArch.Application.Interfaces;
using SimpleCleanArch.Application.Services;
using SimpleCleanArch.Application.Validators;

namespace SimpleCleanArch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Register Application services
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IKeywordService, KeywordService>();

            // Register validators
            services.AddScoped<IValidator<BookDto>, BookDtoValidator>();
            services.AddScoped<IValidator<BookCreateDto>, BookCreateDtoValidator>();
            services.AddScoped<IValidator<BookUpdateDto>, BookUpdateDtoValidator>();
            services.AddScoped<IValidator<AuthorDto>, AuthorDtoValidator>();
            services.AddScoped<IValidator<AuthorCreateDto>, AuthorCreateDtoValidator>();
            services.AddScoped<IValidator<AuthorUpdateDto>, AuthorUpdateDtoValidator>();
            services.AddScoped<IValidator<CategoryDto>, CategoryDtoValidator>();
            services.AddScoped<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
            services.AddScoped<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();
            services.AddScoped<IValidator<KeywordDto>, KeywordDtoValidator>();
            services.AddScoped<IValidator<KeywordCreateDto>, KeywordCreateDtoValidator>();


            return services;
        }
    }
}