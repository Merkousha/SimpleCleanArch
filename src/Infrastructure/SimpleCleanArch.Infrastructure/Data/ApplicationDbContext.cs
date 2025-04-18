using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;
using SimpleCleanArch.Domain.Interfaces;

namespace SimpleCleanArch.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<BookRelation> BookRelations { get; set; }

        void IApplicationDbContext.Update<TEntity>(TEntity entity)
        {
            base.Update(entity);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookRelation>()
                .HasOne(br => br.Book)
                .WithMany(b => b.RelatedBooks)
                .HasForeignKey(br => br.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookRelation>()
                .HasOne(br => br.RelatedBook)
                .WithMany()
                .HasForeignKey(br => br.RelatedBookId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
} 