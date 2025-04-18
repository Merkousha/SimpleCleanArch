using SimpleCleanArch.Application.DTOs;

namespace SimpleCleanArch.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<IEnumerable<BookDto>> GetTop10BooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task<BookDto> GetBookBySlugAsync(string slug);
        Task<IEnumerable<BookDto>> GetBooksByCategoryIdAsync(int categoryId);
        Task<IEnumerable<BookDto>> GetBooksByAuthorIdAsync(int authorId);
        Task<BookDto> CreateBookAsync(BookCreateDto bookCreateDto);
        Task UpdateBookAsync(int id, BookUpdateDto bookUpdateDto);
        Task DeleteBookAsync(int id);
    }
}