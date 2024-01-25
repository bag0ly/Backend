using BlogApi.Models.Dtos;
using BlogApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailInterface emailInterface;

        public EmailController(IEmailInterface emailInterface)
        {
            this.emailInterface = emailInterface;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDTO request)
        {
            emailInterface.SendEmail(request);
            return StatusCode(200, "Email sent.");
        }
    }
}
