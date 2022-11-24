using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AspWebAPI.Data.Services;
using AspWebAPI.Data.ViewModels;
using AspWebAPI.Data.Models;

namespace AspWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("book/insert")]
        public IActionResult InsertBook([FromBody]BookVM bookVM)
        {
            _booksService.InsertBook(bookVM);
            return Ok(bookVM);
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            List<Book> books = await _booksService.GetBooks();
            return Ok(books);
        }

        [HttpGet("book/{book}")]
        public IActionResult GetBook(int book)
        {
            return Ok(_booksService.GetBook(book));
        }

        [HttpPut("book/{book}/update")]
        public IActionResult UpdateBook(int book, [FromBody] BookVM bookVM)
        {
            return Ok(_booksService.UpdateBook(book, bookVM));
        }

        [HttpDelete("book/{book}/delete")]
        public IActionResult DeleteBook(int book)
        {
            int deleted = _booksService.DeleteBook(book);
            if (deleted == 1) {
                return Ok();
            } else {
                return NotFound();
                // return Problem();
            }
        }

        [HttpGet("search")]
        [HttpGet("search/{title}")]
        public async Task<IActionResult> Search(string title)
        {
            return Ok(await _booksService.Search(title));
        }
        /*
        [HttpGet("get/{id:int:min(1):max(10)}")]
        public IActionResult Get(int id)
        {
            return Ok(_booksService.GetBook(id));
        }

        [Route("get/{title:length(8):minlength(4):maxlength(20)}")]
        public IActionResult Get(string title)
        {
            return Ok(_booksService.GetBook(title));
        }

        [Route("get/book/alpha_range/{title:range(8, 20):alpha}")]
        public IActionResult GetBook_Alpha_Range(string title)
        {
            return Ok(_booksService.GetBook(title));
        }
        
        [Route("get/book/regex/{title:regex(^[A-z]+|A(B|C)$)}")]
        public IActionResult GetBook_Regex(string title)
        {
            return Ok(_booksService.GetBook(title));
        }
        */
    }
}
