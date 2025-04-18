using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;
using SimpleCleanArch.Infrastructure.Data;

namespace SimpleCleanArch.Infrastructure.Repositories
{
    public class KeywordRepository : Repository<Keyword>, IKeywordRepository
    {
        public KeywordRepository(IApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Keyword>> GetAllAsync()
        {
            return await _dbSet
                .Include(k => k.Books)
                .ToListAsync();
        }

        public override async Task<Keyword> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(k => k.Books)
                .FirstOrDefaultAsync(k => k.Id == id);
        }

        public async Task<IEnumerable<Keyword>> GetKeywordsByBookIdAsync(int bookId)
        {
            return await _dbSet
                .Include(k => k.Books)
                .Where(k => k.Books.Any(b => b.Id == bookId))
                .ToListAsync();
        }

        public async Task<Keyword> GetBySlugAsync(string slug)
        {
            return await _dbSet
                .Include(k => k.Books)
                .FirstOrDefaultAsync(k => k.Slug == slug);
        }

        public async Task<Keyword> GetKeywordWithBooksAsync(int id)
        {
            return await _dbSet
                .Include(k => k.Books)
                    .ThenInclude(b => b.Author)
                .Include(k => k.Books)
                    .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(k => k.Id == id);
        }
    }
}