using System;
using System.Linq;
using System.Collections.Generic;

using AspWebAPI.Data.Models;
using AspWebAPI.Data.ViewModels;

namespace AspWebAPI.Data.Services
{
    public class ReadersService
    {
        private readonly _DBContext _context;
        public ReadersService(_DBContext context)
        {
            _context = context;
        }

        public void InsertReader(ReaderVM reader)
        {
            Reader _reader = new ()
            {
                FirstName = reader.FirstName,
                LastName = reader.LastName,
                Mail = reader.Mail,
            };

            _context.Readers.Add(_reader);
            _context.SaveChanges();
        }

        public List<Reader> GetReaders() => _context.Readers.ToList();

        public Reader GetReader(int Id) => _context.Readers.Find(Id);

        public Reader UpdateReader(int Id, ReaderVM reader)
        {
            Reader _reader = _context.Readers.FirstOrDefault(reader => reader.Id == Id);
            if (_reader != null)
            {
                _reader.FirstName = reader.FirstName;
                _reader.LastName = reader.LastName;
                _reader.Mail = reader.Mail;

                _context.SaveChanges();
            }

            return _reader;
        }

        public int DeleteReader(int Id)
        {
            Reader _reader = _context.Readers.FirstOrDefault(reader => reader.Id == Id);
            if (_reader != null)
            {
                _context.Readers.Remove(_reader);
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
