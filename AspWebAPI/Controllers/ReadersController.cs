using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AspWebAPI.Data.Services;
using AspWebAPI.Data.ViewModels;

namespace AspWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly ReadersService _readersService;
        public ReadersController(ReadersService readersService)
        {
            _readersService = readersService;
        }

        [HttpPost("reader/insert")]
        public IActionResult InsertReader([FromBody] ReaderVM readerVM)
        {
            _readersService.InsertReader(readerVM);
            return Ok(readerVM);
        }

        [HttpGet("")]
        public IActionResult GetReaders()
        {
            return Ok(_readersService.GetReaders());
        }

        [HttpGet("reader/{reader}")]
        public IActionResult GetReader(int reader)
        {
            return Ok(_readersService.GetReader(reader));
        }

        [HttpPut("reader/{reader}/update")]
        public IActionResult UpdateReader(int reader, [FromBody] ReaderVM readerVM)
        {
            return Ok(_readersService.UpdateReader(reader, readerVM));
        }

        [HttpDelete("reader/{reader}/delete")]
        public IActionResult DeleteBook(int reader)
        {
            int deleted = _readersService.DeleteReader(reader);
            if (deleted == 1)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
