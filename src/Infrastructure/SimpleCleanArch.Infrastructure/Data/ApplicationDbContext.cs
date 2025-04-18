using Microsoft.EntityFrameworkCore;
using SimpleCleanArch.Domain.Entities;

namespace SimpleCleanArch.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookKeyword> BookKeywords { get; set; }
        public DbSet<BookRelation> BookRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationships
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<BookKeyword>()
                .HasKey(bk => new { bk.BookId, bk.KeywordId });

            modelBuilder.Entity<BookRelation>()
                .HasKey(br => new { br.BookId, br.RelatedBookId });

            // Configure relationships
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);

            modelBuilder.Entity<BookKeyword>()
                .HasOne(bk => bk.Book)
                .WithMany(b => b.BookKeywords)
                .HasForeignKey(bk => bk.BookId);

            modelBuilder.Entity<BookKeyword>()
                .HasOne(bk => bk.Keyword)
                .WithMany(k => k.BookKeywords)
                .HasForeignKey(bk => bk.KeywordId);

            modelBuilder.Entity<BookRelation>()
                .HasOne(br => br.Book)
                .WithMany(b => b.RelatedToBooks)
                .HasForeignKey(br => br.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookRelation>()
                .HasOne(br => br.RelatedBook)
                .WithMany(b => b.RelatedFromBooks)
                .HasForeignKey(br => br.RelatedBookId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
} 