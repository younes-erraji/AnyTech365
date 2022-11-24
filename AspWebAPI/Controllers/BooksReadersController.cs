using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AspWebAPI.Data.Services;
using AspWebAPI.Data.ViewModels;

namespace AspWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksReadersController : ControllerBase
    {
        private readonly BooksReadersService _booksReadersService;
        public BooksReadersController(BooksReadersService booksReadersService)
        {
            _booksReadersService = booksReadersService;
        }

        [HttpGet("book/{book}/readers")]
        public IActionResult GetBookReaders(int book)
        {
            return Ok(_booksReadersService.GetBookReaders(book));
        }

        [HttpGet("reader/{reader}/books")]
        public IActionResult GetReaderBooks(int reader)
        {
            return Ok(_booksReadersService.GetReaderBooks(reader));
        }

        [HttpPost("book/{book}/insert/reader")]
        public IActionResult InsertBookReader(int book, [FromBody]BookReaderVM bookReaderVM)
        {
            _booksReadersService.InsertBookReader(book, bookReaderVM);
            return Ok(bookReaderVM);
        }

        [HttpPost("reader/{reader}/insert/book")]
        public IActionResult InsertReaderBook(int reader, [FromBody]BookReaderVM bookReaderVM)
        {
            _booksReadersService.InsertReaderBook(reader, bookReaderVM);
            return Ok(bookReaderVM);
        }

        [HttpDelete("delete/reader/{reader}/book/{book}")]
        public IActionResult DeleteBookReader(int reader, int book)
        {
            int deleted = _booksReadersService.DeleteBookReaders(reader, book);
            if (deleted == 1)
                return Ok();
            else
                return NotFound();
        }
    }
}
