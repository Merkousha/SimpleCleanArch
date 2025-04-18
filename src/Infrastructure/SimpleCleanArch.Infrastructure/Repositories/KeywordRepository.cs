using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;
using SimpleCleanArch.Infrastructure.Data;

namespace SimpleCleanArch.Infrastructure.Repositories
{
    public class KeywordRepository : Repository<Keyword>, IKeywordRepository
    {
        public KeywordRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Keyword>> GetKeywordsByBookIdAsync(int bookId)
        {
            return await _context.Keywords
                .Include(k => k.BookKeywords)
                .Where(k => k.BookKeywords.Any(bk => bk.BookId == bookId))
                .ToListAsync();
        }

        public async Task<Keyword> GetKeywordWithBooksAsync(int id)
        {
            return await _context.Keywords
                .Include(k => k.BookKeywords)
                    .ThenInclude(bk => bk.Book)
                .FirstOrDefaultAsync(k => k.Id == id);
        }
    }
}