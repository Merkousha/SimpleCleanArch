using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;

namespace SimpleCleanArch.Domain.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Author> Authors { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Keyword> Keywords { get; set; }
    DbSet<BookRelation> BookRelations { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    void Update<TEntity>(TEntity entity) where TEntity : class;
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
} 