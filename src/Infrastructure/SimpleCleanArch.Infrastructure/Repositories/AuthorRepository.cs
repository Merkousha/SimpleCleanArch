using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;
using SimpleCleanArch.Infrastructure.Data;

namespace SimpleCleanArch.Infrastructure.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Author> GetAuthorWithBooksAsync(int id)
        {
            return await _context.Authors
                .Include(a => a.BookAuthors)
                    .ThenInclude(ba => ba.Book)
                        .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(int bookId)
        {
            return await _context.Authors
                .Include(a => a.BookAuthors)
                .Where(a => a.BookAuthors.Any(ba => ba.BookId == bookId))
                .ToListAsync();
        }

        public async Task<Author> GetBySlugAsync(string slug)
        {
            return await _context.Authors
                .Include(a => a.BookAuthors)
                    .ThenInclude(ba => ba.Book)
                        .ThenInclude(b => b.Category)
                .FirstOrDefaultAsync(a => a.Slug == slug);
        }
    }
}