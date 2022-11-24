using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AspWebAPI.Data.Models;
using AspWebAPI.Data.Services;
using AspWebAPI.Data.ViewModels;

namespace AspWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorService;
        public AuthorsController(AuthorsService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("")]
        public IActionResult GetAuthors()
        {
            return Ok(_authorService.GetAuthors());
        }

        [HttpGet("author/{author}")]
        public IActionResult GetAuthor(int author)
        {
            Author _author = _authorService.GetAuthor(author);
            if (_author != null)
            {
                return Ok(_author);
            } else {
                return NotFound();
            }
        }

        [HttpDelete("author/{author}/delete")]
        public IActionResult DeleteAuthor(int author)
        {
            int _deleted = _authorService.DeleteAuthor(author);
            if (_deleted == 1)
            {
                return Ok();
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("author/{author}/update")]
        public IActionResult UpdateAuthor(int author, [FromBody]AuthorVM authorVM)
        {
            return Ok(_authorService.UpdateAuthor(author, authorVM));
        }

        [HttpPost("author/insert")]
        public IActionResult InsertAuthor([FromBody] AuthorVM authorVM)
        {
            _authorService.InsertAuthor(authorVM);
            return Ok();
        }

        [HttpGet("author/{author}/books")]
        public IActionResult GetAuthorBooks(int author)
        {
            return Ok(_authorService.GetAuthorBooks(author));
        }
    }
}
