using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;
using SimpleCleanArch.Infrastructure.Data;

namespace SimpleCleanArch.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Book> GetBookWithDetailsAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookKeywords)
                    .ThenInclude(bk => bk.Keyword)
                .Include(b => b.RelatedToBooks)
                    .ThenInclude(br => br.RelatedBook)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            return await _context.Books
                .Where(b => b.CategoryId == categoryId)
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
        {
            return await _context.Books
                .Include(b => b.BookAuthors)
                .Where(b => b.BookAuthors.Any(ba => ba.AuthorId == authorId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetRelatedBooksAsync(int bookId)
        {
            return await _context.Books
                .Where(b => b.RelatedFromBooks.Any(br => br.BookId == bookId))
                .ToListAsync();
        }

        public async Task<Book> GetBookBySlugAsync(string slug)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookKeywords)
                    .ThenInclude(bk => bk.Keyword)
                .FirstOrDefaultAsync(b => b.Slug == slug);
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryIdAsync(int categoryId)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookKeywords)
                    .ThenInclude(bk => bk.Keyword)
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookKeywords)
                    .ThenInclude(bk => bk.Keyword)
                .Where(b => b.BookAuthors.Any(ba => ba.AuthorId == authorId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByKeywordAsync(int keywordId)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookKeywords)
                    .ThenInclude(bk => bk.Keyword)
                .Where(b => b.BookKeywords.Any(bk => bk.KeywordId == keywordId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByKeywordIdAsync(int keywordId)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookKeywords)
                    .ThenInclude(bk => bk.Keyword)
                .Where(b => b.BookKeywords.Any(bk => bk.KeywordId == keywordId))
                .ToListAsync();
        }

        public override async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .Include(b => b.BookKeywords)
                    .ThenInclude(bk => bk.Keyword)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
} 