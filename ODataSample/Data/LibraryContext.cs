using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ODataSample.Model;

namespace ODataSample.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity => {
                entity.ToTable("Authors");
                entity.Property(e => e.FirstName).HasMaxLength(40);
                entity.Property(e => e.LastName).HasMaxLength(40);
            });

            modelBuilder.Entity<Genre>(entity => {
                entity.ToTable("Genres");
                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");
                entity.Property(e => e.Name).HasMaxLength(40);

                entity.OwnsMany(e => e.Authors, c =>
                {
                    c.ToTable("BookAuthors");
                    c.HasKey(p => new { p.BookId, p.AuthorId });
                    c.WithOwner(p => p.Book).HasForeignKey(p => p.BookId);
                    c.HasOne(p => p.Author).WithMany().HasForeignKey(p => p.AuthorId);
                });

                entity.OwnsMany(e => e.Genres, c =>
                {
                    c.ToTable("BookGenres");
                    c.HasKey(p => new { p.BookId, p.GenreId });
                    c.WithOwner(p => p.Book).HasForeignKey(p => p.BookId);
                    c.HasOne(p => p.Genre).WithMany().HasForeignKey(p => p.GenreId);
                });

            });

            modelBuilder.Entity<CookBook>(entity =>
            {
                entity.ToTable("CookBooks");
                entity.Property(p => p.Id).ValueGeneratedNever();
                entity.Property(p => p.Theme).HasMaxLength(100);
                entity.HasOne<Book>().WithOne(e => e.CookBook).HasForeignKey<CookBook>(p => p.Id).OnDelete(DeleteBehavior.Cascade);

                entity.OwnsMany(p => p.Recipes, r => {
                    r.ToTable("CookRecipes");
                    r.Property(x => x.Title).HasMaxLength(100);
                    r.WithOwner(x => x.CookBook).HasForeignKey(x => x.CookBookId);
                });

            });

            modelBuilder.Entity<RoadAtlas>(entity =>
            {
                entity.ToTable("RoadAtlases");
                entity.Property(p => p.Id).ValueGeneratedNever();
                entity.Property(p => p.Country).HasMaxLength(40);
                entity.HasOne<Book>().WithOne(e => e.RoadAtlas).HasForeignKey<RoadAtlas>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TextBook>(entity =>
            {
                entity.ToTable("TextBooks");
                entity.Property(p => p.Id).ValueGeneratedNever();
                entity.Property(p => p.Subject).HasMaxLength(100);
                entity.HasOne<Book>().WithOne(e => e.TextBook).HasForeignKey<TextBook>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
