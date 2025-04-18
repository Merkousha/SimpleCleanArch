using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCleanArch.Domain.Entities;

namespace SimpleCleanArch.Domain.Interfaces
{
    public interface IKeywordRepository : IRepository<Keyword>
    {
        Task<IEnumerable<Keyword>> GetKeywordsByBookIdAsync(int bookId);
        Task<Keyword> GetKeywordWithBooksAsync(int id);
    }
} 