using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projects_dolgozat.Dtos;
using Projects_dolgozat.Models;
using Projects_dolgozat.Repositories;

namespace Projects_dolgozat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskService : ControllerBase
    {
        private readonly ITaskInterface taskInterface;

        public TaskService(ITaskInterface taskInterface)
        {
            this.taskInterface = taskInterface;
        }
        [HttpPost]
        public async Task<ActionResult<Tasks>> Post(UserDto user,string taskDescription)
        {
            return StatusCode(201, await taskInterface.Post(user,taskDescription));
        }
        [HttpGet]
        public async Task<ActionResult<Tasks>> Get()
        {
            return StatusCode(201, await taskInterface.Get());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<TaskDto>> GetById(Guid Id)
        {
            return StatusCode(201, await taskInterface.GetById(Id));
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid Id)
        {
            await taskInterface.Delete(Id);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<TaskDto>> Put(Guid Id, string taskDescription)
        {
            var result = await taskInterface.Put(Id, taskDescription);

            if (result == null)
            {
                return NotFound();
            }
            return StatusCode(201, result);
        }
    }
}
