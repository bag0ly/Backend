using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projects_dolgozat.Dtos;
using Projects_dolgozat.Models;
using Projects_dolgozat.Repositories;

namespace Projects_dolgozat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface userInterface;

        public UserController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        [HttpPost]
        public async Task<ActionResult<Users>> Post(CreateUserDto createUserDto) 
        {
            return StatusCode(201, await userInterface.Post(createUserDto));
        }
        [HttpGet]
        public async Task<ActionResult<Users>> Get() 
        {
            return StatusCode(201, await userInterface.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<UserDto>> GetById(Guid Id) 
        {
            return StatusCode(201, await userInterface.GetById(Id));
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id) 
        {
            await userInterface.Delete(Id);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<UserDto>> Put(Guid Id, UpdateUserDto updateUserDto) 
        {
            var result = await userInterface.Put(Id, updateUserDto);

            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(201,result);
        }
    }
}
