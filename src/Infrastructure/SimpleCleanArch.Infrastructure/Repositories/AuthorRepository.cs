using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;
using SimpleCleanArch.Infrastructure.Data;

namespace SimpleCleanArch.Infrastructure.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(IApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _dbSet
                .Include(a => a.Books)
                .ToListAsync();
        }

        public override async Task<Author> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Author> GetAuthorWithBooksAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Books)
                    .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(int bookId)
        {
            return await _dbSet
                .Include(a => a.Books)
                .Where(a => a.Books.Any(b => b.Id == bookId))
                .ToListAsync();
        }

        public async Task<Author> GetBySlugAsync(string slug)
        {
            return await _dbSet
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Slug == slug);
        }
    }
}