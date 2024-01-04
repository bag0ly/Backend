using BlogApi.Models;
using BlogApi.Models.Dtos;
using BlogApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogUserContentController : ControllerBase
    {
        private readonly IBlogUserContentInterface blogUserContent;

        public BlogUserContentController(IBlogUserContentInterface blogUserContent)
        {
            this.blogUserContent = blogUserContent;
        }

        [HttpPost]

        public async Task<ActionResult<BlogUserContent>> Post(CreateBlogUserContentDto createBlogUserContent)
        {
            return StatusCode(201, await blogUserContent.Post(createBlogUserContent));
        }

        [HttpGet]
        public async Task<ActionResult<BlogUserContent>> Get()
        {
            return StatusCode(201, await blogUserContent.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<BlogUserContentDto>> GetById(Guid Id)
        {
            var result = await blogUserContent.GetById(Id);

            if (result == null)
            {

                return NotFound();
            }


            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await blogUserContent.Delete(Id);
            return Ok();
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<BlogUserContentDto>> UpdateBlogUserContent(Guid Id, [FromBody] UpdateBlogUserContentDto updateBlogUserContent)
        {
            var result = await blogUserContent.Put(Id, updateBlogUserContent);

            if (result == null)
            {
                
                return NotFound();
            }

            return StatusCode(201, result);
        }






    }
}
