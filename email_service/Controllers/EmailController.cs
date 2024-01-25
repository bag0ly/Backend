using email_service.Models;
using email_service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace email_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EController : ControllerBase
    {
        private readonly IEmailInterface emailInterface;

        public EController(IEmailInterface emailInterface)
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
