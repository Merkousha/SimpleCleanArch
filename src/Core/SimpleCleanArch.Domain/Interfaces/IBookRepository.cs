using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCleanArch.Domain.Entities;

namespace SimpleCleanArch.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<Book> GetBookWithDetailsAsync(int id);
        Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<Book>> GetRelatedBooksAsync(int bookId);
        Task<IEnumerable<Book>> GetBooksByKeywordAsync(int keywordId);
        Task<Book> GetBookBySlugAsync(string slug);
        Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
        Task<IEnumerable<Book>> GetBooksByKeywordIdAsync(int keywordId);
    }
} 