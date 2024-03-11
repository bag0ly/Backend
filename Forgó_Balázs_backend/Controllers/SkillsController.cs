using Forgó_Balázs_backend.Models;
using Forgó_Balázs_backend.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;
using ZstdSharp.Unsafe;

namespace Forgó_Balázs_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly EuroskillsContext _context;
        public string UserId = "FKB3F4FEA09CE43C";

        public SkillsController(EuroskillsContext context)
        {
            _context = context;
        }
        //8.feladat
        [HttpGet("GetVersenyzok")]
        public async Task<ActionResult<Versenyzo>> GetVersenyzok()
        {
            return StatusCode(201, await _context.Versenyzos.ToListAsync());
        }
        //9.feladat
        [HttpGet("GetVersenyzo/{Id}")]
        public async Task<ActionResult<Versenyzo>> GetVersenyzoById(int Id) 
        {
            var result = await _context.Versenyzos.FirstOrDefaultAsync(x => x.Id == Id);

            if (result == null) { return NotFound(); }

            return Ok(result);
        }
        //10.feladat
        [HttpGet("osszesOrszagSzama")]
        public async Task<ActionResult<string>> OsszesOrszag() 
        {
            var result = _context.Orszags.Count();

            if (result == 0) { return BadRequest(); }

            return Ok($"Az összes ország száma: {result}");
        }
        //11.feladat
        [HttpPost("addVersenyzo/{UserId}")]
        public async Task<ActionResult<Versenyzo>> addVersenyzo(string UserId, CreateVersenyzoDto createVersenyzoDto) 
        {


            if (UserId == "FKB3F4FEA09CE43C")
            {

                var orszagid = _context.Orszags.FirstOrDefaultAsync(x => x.Id == createVersenyzoDto.OrszagId);

                var szakmaid = _context.Szakmas.FirstOrDefaultAsync(x => x.Id == createVersenyzoDto.SzakmaId);

                if (szakmaid == null && orszagid == null)   
                {
                    return NotFound();  
                }

                var versenyzo = new Versenyzo
                {
                    Nev = createVersenyzoDto.Nev,
                    SzakmaId = createVersenyzoDto.SzakmaId,
                    OrszagId = createVersenyzoDto.OrszagId,
                    Pont = 0
                };

                return Ok(versenyzo); 
            }

            return Unauthorized();


           

        }


    }
}
