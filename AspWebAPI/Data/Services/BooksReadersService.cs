using System.Linq;
using System.Collections.Generic;

using AspWebAPI.Data.Models;
using AspWebAPI.Data.ViewModels;

namespace AspWebAPI.Data.Services
{
    public class BooksReadersService
    {
        private readonly _DBContext _context;
        public BooksReadersService(_DBContext context)
        {
            _context = context;
        }

        public void InsertBookReader(int book, BookReaderVM bookReader)
        {
            BookReader _bookReader = new()
            {
                ReaderId = bookReader.ReaderId,
                BookId = book,
                Rate = bookReader.Rate,
                ExperationDate = bookReader.ExperationDate
            };

            _context.BooksReaders.Add(_bookReader);
            _context.SaveChanges();
        }

        public void InsertReaderBook(int reader, BookReaderVM bookReader)
        {
            BookReader _bookReader = new()
            {
                ReaderId = reader,
                BookId = bookReader.BookId,
                Rate = bookReader.Rate,
                ExperationDate = bookReader.ExperationDate
            };

            _context.BooksReaders.Add(_bookReader);
            _context.SaveChanges();
        }

        public List<Book> GetReaderBooks(int readerId) => _context.BooksReaders.Where(reader => reader.ReaderId == readerId).Select(readerBooks => readerBooks.Book).ToList();

        public List<Reader> GetBookReaders(int bookId) => _context.BooksReaders.Where(reader => reader.BookId == bookId).Select(bookReaders => bookReaders.Reader).ToList();

        /*
        public BookReader UpdateReader(int Id, BookReaderVM bookReader)
        {
            BookReader _bookReader = _context.BooksReaders.FirstOrDefault(reader => reader.Id == Id);
            if (_bookReader != null)
            {
                _bookReader.ReaderId = bookReader.ReaderId;
                _bookReader.BookId = bookReader.BookId;
                _bookReader.ExperationDate = bookReader.ExperationDate;

                _context.SaveChanges();
            }

            return _bookReader;
        }
        */
        public int DeleteBookReaders(int readerId, int bookId)
        {
            BookReader _bookReader = _context.BooksReaders
                .FirstOrDefault(reader => reader.ReaderId == readerId && reader.BookId == bookId);
            if (_bookReader is not null)
            {
                _context.BooksReaders.Remove(_bookReader);
                _context.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
