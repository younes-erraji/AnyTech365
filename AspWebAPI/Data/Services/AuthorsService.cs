using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using AspWebAPI.Data.Models;
using AspWebAPI.Data.ViewModels;

namespace AspWebAPI.Data.Services
{
    public class AuthorsService
    {
        private _DBContext _context;
        public AuthorsService(_DBContext context)
        {
            _context = context;
        }

        public List<Author> GetAuthors() => _context.Authors.ToList();

        public Author GetAuthor(int Id) => _context.Authors.FirstOrDefault(author => author.Id == Id);

        public int DeleteAuthor(int Id)
        {
            Author _author = _context.Authors.FirstOrDefault(author => author.Id == Id);
            if (_author != null) {
                _context.Authors.Remove(_author);
                _context.SaveChanges();
                return 1;
            } else {
                return 0;
            }
        }

        public Author InsertAuthor(AuthorVM authorVM)
        {
            Author _author = new()
            {
                FirstName = authorVM.FirstName,
                LastName = authorVM.LastName,
                NickName = authorVM.NickName,
                Username = authorVM.Username,
                Password = authorVM.Password,
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();

            return _author;
        }

        public Author UpdateAuthor(int Id, AuthorVM authorVM)
        {
            Author _author = _context.Authors.FirstOrDefault(author => author.Id == Id);
            if (_author != null)
            {
                _author.FirstName = authorVM.FirstName;
                _author.LastName = authorVM.LastName;
                _author.NickName = authorVM.NickName;
                _author.Username = authorVM.Username;
                _author.Password = authorVM.Password;

                _context.SaveChanges();
            }

            return _author;
        }

        public List<Book> GetAuthorBooks(int authorId)
        {
            List<Book> books = _context.Authors
                // .Include(x => x.Books)
                .Where(author => author.Id == authorId).SelectMany(author => author.Books).ToList();

            return books;
        }
    }
}
