using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using AspWebAPI.Data.Models;
using AspWebAPI.Data.ViewModels;

namespace AspWebAPI.Data.Services
{
    public class BooksService
    {
        private readonly _DBContext _context;
        public BooksService(_DBContext context)
        {
            _context = context;
        }

        public void InsertBook(BookVM book) {
            Book _book = new()
            {
                Title = book.Title,
                Description = book.Description,
                Rate = book.Rate,
                CoverUrl = book.CoverUrl,
                Genre = book.Genre,
                Author_ID = book.Author_ID,
                Price = book.Price,
            };

            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public Task<List<Book>> GetBooks() => Task.FromResult(_context.Books.ToList());

        public Book GetBook(int Id) => _context.Books.Find(Id);
        public Book GetBook(string title) => _context.Books.Where(book => book.Title == title).FirstOrDefault();

        public Book UpdateBook(int Id, BookVM book)
        {
            Book _book = _context.Books.FirstOrDefault(book => book.Id == Id);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.Rate = book.Rate;
                _book.CoverUrl = book.CoverUrl;
                _book.Genre = book.Genre;
                _book.Author_ID = book.Author_ID;
                _book.Price = book.Price;

                _context.SaveChanges();
            }

            return _book;
        }

        public int DeleteBook(int Id)
        {
            Book _book = _context.Books.FirstOrDefault(book => book.Id == Id);
            if (_book != null) {
                _context.Books.Remove(_book);
                _context.SaveChanges();
                return 1;
            } else {
                return 0;
            }
        }

        public Task<List<Book>> Search(string title)
        {
            return Task.Run(() =>
            {
                List<Book> books = _context.Books.Where(book => book.Title.Contains(title)).Select(book => book).ToList();

                return Task.FromResult(books);
            });
        }
    }
}
