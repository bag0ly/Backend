using Books_n_Authors.Dtos;
using Books_n_Authors.Models;
using Books_n_Authors.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books_n_Authors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface authorInterface;

        public AuthorController(IAuthorInterface authorInterface)
        {
            this.authorInterface = authorInterface;
        }
        [HttpPost]
        public async Task<ActionResult<Author>> Post(CreateAuthorDto createAuthorDto)
        {
            return StatusCode(201, await authorInterface.Post(createAuthorDto));
        }

        [HttpGet]
        public async Task<ActionResult<Author>> Get()
        {
            return StatusCode(201, await authorInterface.Get());
        }
        [HttpGet("nationality/{nationalityId}")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthorsByNationality(Guid nationalityId)
        {
            var authors = await authorInterface.GetAuthorsByNationality(nationalityId);

            if (authors == null)
            {
                return NotFound();
            }

            return Ok(authors);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Author>> UpdateBlogUserContent(Guid Id, UpdateAuthorDto updateAuthorDto)
        {
            var result = await authorInterface.Put(Id, updateAuthorDto);

            if (result == null)
            {

                return NotFound();
            }

            return StatusCode(201, result);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<AuthorDto>> GetById(Guid Id)
        {
            var result = await authorInterface.GetById(Id);

            if (result == null)
            {

                return NotFound();
            }


            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await authorInterface.Delete(Id);
            return Ok();
        }
    }
}
