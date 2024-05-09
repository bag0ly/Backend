using fb_backend_gyakorlas_01.Dtos;
using fb_backend_gyakorlas_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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

        [HttpPost("PostTanar")]
        public async Task<ActionResult<Tanarok>> PostTanarok(TanarPost tanar)
        {
            var tanarExist = await _context.Tanaroks.AnyAsync(x => x.Email == tanar.Email);

            if (tanarExist)
            {
                return Conflict();
            }

            var result = new Tanarok
            {
                VezetekNev = tanar.VezetekNev,
                KeresztNev = tanar.KeresztNev,
                Email = tanar.Email,
                Nem = tanar.Nem,
            };

            await _context.Tanaroks.AddAsync(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("PutTanar")]
        public async Task<ActionResult<Tanarok>> PutTanarok(int Id, TanarPost tanar)
        {
            var tanarExist = await _context.Tanaroks.FirstOrDefaultAsync(x => x.Id == Id);
            if (tanarExist == null) return BadRequest();

            tanarExist.VezetekNev = tanar.VezetekNev;
            tanarExist.KeresztNev = tanar.KeresztNev;
            tanarExist.Email = tanar.Email;
            tanarExist.Nem = tanar.Nem;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tanarok>> GetTanarokById(int id) 
        {
            var result = await _context.Tanaroks.Include(x=>x.Jegyeks).FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tanarok>> DeleteTanarokById(int id) 
        {
            var result = await _context.Tanaroks.FirstOrDefaultAsync(y => y.Id == id);
            var jegyek = await _context.Jegyeks.Where(j=>j.IdTanarok==id).ToListAsync();
            if (result == null) return BadRequest();
            _context.Jegyeks.RemoveRange(jegyek);
            await _context.SaveChangesAsync();

            _context.Tanaroks.Remove(result);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
