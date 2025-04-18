using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;
using SimpleCleanArch.Infrastructure.Data;

namespace SimpleCleanArch.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbSet
                .Include(c => c.Books)
                .ToListAsync();
        }

        public override async Task<Category> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> GetBySlugAsync(string slug)
        {
            return await _dbSet
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Slug == slug);
        }

        public async Task<Category> GetCategoryWithBooksAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Books)
                    .ThenInclude(b => b.Author)
                .Include(c => c.Books)
                    .ThenInclude(b => b.Keywords)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
} 