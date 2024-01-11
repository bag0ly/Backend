using Books_n_Authors.Dtos;
using Books_n_Authors.Models;
using Books_n_Authors.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books_n_Authors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface bookInterface;

        public BookController(IBookInterface bookInterface)
        {
            this.bookInterface = bookInterface;
        }
        [HttpPost]
        public async Task<ActionResult<Book>> Post(CreateBookDto createBookDto)
        {
            return StatusCode(201, await bookInterface.Post(createBookDto));
        }

        [HttpGet]
        public async Task<ActionResult<Book>> Get()
        {
            return StatusCode(201, await bookInterface.Get());
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Book>> UpdateBlogUserContent(Guid Id, UpdateBookDto updateBookDto)
        {
            var result = await bookInterface.Put(Id, updateBookDto);

            if (result == null)
            {

                return NotFound();
            }

            return StatusCode(201, result);
        }
        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(Guid authorId)
        {
            var books = await bookInterface.GetBooksByAuthor(authorId);

            if (books == null || !books.Any())
            {
                return NotFound();
            }

            return Ok(books);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<BookDto>> GetById(Guid Id)
        {
            var result = await bookInterface.GetById(Id);

            if (result == null)
            {

                return NotFound();
            }


            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await bookInterface.Delete(Id);
            return Ok();
        }
    }
}
