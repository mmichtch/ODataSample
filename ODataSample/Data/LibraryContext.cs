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
            });

            modelBuilder.Entity<BookAuthor>(entity => {
                entity.ToTable("BookAuthors");
                entity.HasKey(e => new { e.BookId, e.AuthorId });
                entity.HasOne(e => e.Book).WithMany(e => e.Authors).HasForeignKey(e => e.BookId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Author).WithMany().HasForeignKey(e => e.AuthorId);
            });

            modelBuilder.Entity<BookGenre>(entity => {
                entity.ToTable("BookGenres");
                entity.HasKey(e => new { e.BookId, e.GenreId });
                entity.HasOne(e => e.Book).WithMany(e => e.Genres).HasForeignKey(e => e.BookId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.Genre).WithMany().HasForeignKey(e => e.GenreId);
            });

            modelBuilder.Entity<CookBook>(entity =>
            {
                entity.ToTable("CookBooks");
                entity.Property(p => p.Id).ValueGeneratedNever();
                entity.Property(p => p.Theme).HasMaxLength(100);
                entity.HasOne<Book>().WithOne(e => e.CookBook).HasForeignKey<CookBook>(p => p.Id).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CookRecipe>(entity => {
                entity.ToTable("CookRecipes");
                entity.Property(x => x.Title).HasMaxLength(100);
                entity.HasOne(e => e.CookBook).WithMany(x => x.Recipes).HasForeignKey(x => x.CookBookId).OnDelete(DeleteBehavior.Cascade);
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
