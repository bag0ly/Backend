using Books_n_Authors.Dtos;
using Books_n_Authors.Models;
using Books_n_Authors.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books_n_Authors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityInterface nationalityInterface;

        public NationalityController(INationalityInterface nationalityInterface)
        {
            this.nationalityInterface = nationalityInterface;
        }
        [HttpPost]
        public async Task<ActionResult<Nationality>> Post(string Country)
        {
            return StatusCode(201, await nationalityInterface.Post(Country));
        }

        [HttpGet]
        public async Task<ActionResult<Nationality>> Get()
        {
            return StatusCode(201, await nationalityInterface.Get());
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Nationality>> Put(Guid Id, string Country)
        {
            var result = await nationalityInterface.Put(Id, Country);

            if (result == null)
            {

                return NotFound();
            }

            return StatusCode(201, result);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<NationalityDto>> GetById(Guid Id)
        {
            var result = await nationalityInterface.GetById(Id);

            if (result == null)
            {

                return NotFound();
            }


            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await nationalityInterface.Delete(Id);
            return Ok();
        }
    }
}
