using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;

namespace SimpleCleanArch.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(IApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbSet
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Keywords)
                .Include(b => b.RelatedBooks)
                    .ThenInclude(br => br.RelatedBook)
                .ToListAsync();
        }


        public async Task<IEnumerable<Book>> GetTop10Async()
        {
            return await _dbSet
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Keywords)
                .Include(b => b.RelatedBooks)
                    .ThenInclude(br => br.RelatedBook)
                .OrderByDescending(b => b.CreatedAt)
                .Take(10)
                .ToListAsync();
        }

        public override async Task<Book> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Keywords)
                .Include(b => b.RelatedBooks)
                    .ThenInclude(br => br.RelatedBook)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> GetBySlugAsync(string slug)
        {
            return await _dbSet
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Keywords)
                .Include(b => b.RelatedBooks)
                    .ThenInclude(br => br.RelatedBook)
                .FirstOrDefaultAsync(b => b.Slug == slug);
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId)
        {
            return await _dbSet
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Keywords)
                .Include(b => b.RelatedBooks)
                    .ThenInclude(br => br.RelatedBook)
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await _dbSet
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Keywords)
                .Include(b => b.RelatedBooks)
                    .ThenInclude(br => br.RelatedBook)
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();
        }

        public override async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(b => b.Id == id);
        }

        public override async Task<Book> FindAsync(Expression<Func<Book, bool>> predicate)
        {
            return await _dbSet
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Keywords)
                .Include(b => b.RelatedBooks)
                    .ThenInclude(br => br.RelatedBook)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<Book> GetBookWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Include(b => b.Keywords)
                .Include(b => b.RelatedBooks)
                    .ThenInclude(br => br.RelatedBook)
                .Include(b => b.RelatedToBooks)
                    .ThenInclude(br => br.Book)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Where(b => b.CategoryId == categoryId)
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
        {
            return await _dbSet
                .Where(b => b.AuthorId == authorId)
                .Include(b => b.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetRelatedBooksAsync(int bookId)
        {
            return await _dbSet
                .Where(b => b.RelatedToBooks.Any(br => br.BookId == bookId))
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task<Book> GetBookBySlugAsync(string slug)
        {
            return await _dbSet
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Keywords)
                .FirstOrDefaultAsync(b => b.Slug == slug);
        }

        public async Task<IEnumerable<Book>> GetBooksByKeywordAsync(int keywordId)
        {
            return await _dbSet
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Keywords)
                .Where(b => b.Keywords.Any(k => k.Id == keywordId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByKeywordIdAsync(int keywordId)
        {
            return await _dbSet
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Include(b => b.Keywords)
                .Where(b => b.Keywords.Any(k => k.Id == keywordId))
                .ToListAsync();
        }
    }
}