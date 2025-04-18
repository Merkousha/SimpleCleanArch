using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Application.DTOs;
using SimpleCleanArch.Application.Interfaces;
using SimpleCleanArch.Application.Services;
using SimpleCleanArch.Application.Validators;
using SimpleCleanArch.Domain.Interfaces;
using SimpleCleanArch.Infrastructure.Data;
using SimpleCleanArch.Infrastructure.Repositories;
using AutoMapper;
using SimpleCleanArch.Application.Mappings;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers()
    .AddFluentValidation(fv => 
    {
        fv.RegisterValidatorsFromAssemblyContaining<BookDtoValidator>();
        fv.ImplicitlyValidateChildProperties = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "SimpleCleanArch API", 
        Version = "v1",
        Description = "A simple Clean Architecture example API"
    });
});

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IKeywordRepository, KeywordRepository>();

// Register Services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IKeywordService, KeywordService>();

// Register Validators
builder.Services.AddScoped<IValidator<BookDto>, BookDtoValidator>();
builder.Services.AddScoped<IValidator<BookCreateDto>, BookCreateDtoValidator>();
builder.Services.AddScoped<IValidator<BookUpdateDto>, BookUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<AuthorDto>, AuthorDtoValidator>();
builder.Services.AddScoped<IValidator<AuthorCreateDto>, AuthorCreateDtoValidator>();
builder.Services.AddScoped<IValidator<AuthorUpdateDto>, AuthorUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<CategoryDto>, CategoryDtoValidator>();
builder.Services.AddScoped<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
builder.Services.AddScoped<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();

builder.Services.AddScoped<IValidator<KeywordDto>, KeywordDtoValidator>();
builder.Services.AddScoped<IValidator<KeywordCreateDto>, KeywordCreateDtoValidator>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleCleanArch API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
