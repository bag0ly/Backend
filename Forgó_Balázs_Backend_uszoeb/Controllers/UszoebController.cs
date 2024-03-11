using Forgó_Balázs_Backend_uszoeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forgó_Balázs_Backend_uszoeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UszoebController : ControllerBase
    {
        private readonly UszoebContext _context;

        public UszoebController(UszoebContext context)
        {
            _context = context;
        }

        [HttpGet("GetVersenyzoNev")]
        public async Task<ActionResult<Versenyzok>> GetVersenyzoNev(string Nev) 
        {
            var result = await _context.Versenyzoks
                                            .Include(o => o.Orszag)
                                            .Include(sz => sz.Szamoks)
                                            .FirstOrDefaultAsync(x => x.Nev == Nev);
                                            
            return Ok(result);
        }
    }
}
