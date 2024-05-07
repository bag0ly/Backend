using fb_backend_gyakorlas_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fb_backend_gyakorlas_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TanarokController : ControllerBase
    {
        private readonly OsztalynaploContext _context;

        public TanarokController(OsztalynaploContext context)
        {
            _context = context;
        }
        //11.feladat
        [HttpGet("GetTanarok")]
        public async Task<ActionResult<Tanarok>> getTanarok()
        {
            var result = await _context.Tanaroks.Include(x => x.Jegyeks).ToListAsync();
            if (result.Count == 0)
            {
                return StatusCode(400, "Unable to connect to any mysql hosts");
            }
            return Ok(result);
        }
    }
}
