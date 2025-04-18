using SimpleCleanArch.Domain.Entities;

namespace SimpleCleanArch.Domain.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(int bookId);
        Task<Author> GetBySlugAsync(string slug);
    }
}