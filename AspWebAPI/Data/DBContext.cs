using System;

using AspWebAPI.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace AspWebAPI.Data
{
    public class _DBContext: DbContext
    {
        public _DBContext() { }
        public _DBContext(DbContextOptions<_DBContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<BookReader> BooksReaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "Younes",
                    LastName = "ERRAJI",
                    Username = "younes-erraji",
                    Password = "1234560"
                }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Rich Dad Poor Dad",
                    Author_ID = 1,
                    Price = 17.8M,
                }
            );

            modelBuilder.Entity<BookReader>()
                .HasOne(x => x.Book)
                .WithMany(x => x.BookReaders)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<BookReader>()
                .HasOne(x => x.Reader)
                .WithMany(x => x.ReaderBooks)
                .HasForeignKey(x => x.ReaderId);
        }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EFLibrary;Integrated Security=True;");
        }
        */
    }
}
