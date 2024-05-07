using fb_backend_gyakorlas_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fb_backend_gyakorlas_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TantargyakController : ControllerBase
    {
        private readonly OsztalynaploContext _context;

        public TantargyakController(OsztalynaploContext context)
        {
            _context = context;
        }
        //9.feladat
        [HttpGet("GetTantargyak")]
        public async Task<ActionResult<Tantargyak>> getTantargyak()
        {
            var result = await _context.Tantargyaks.ToListAsync();
            if (result.Count == 0)
            {
                return StatusCode(400, "Unable to connect to any mysql hosts");
            }
            return Ok(result);
        }
        //10.feladat
        [HttpGet("GetTantargyByNev")]
        public async Task<ActionResult<Tantargyak>> getTantargyakByNev(string TantargyNev) 
        {
            var result = await _context.Tantargyaks.FirstOrDefaultAsync(x => x.TantargyNev == TantargyNev);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
