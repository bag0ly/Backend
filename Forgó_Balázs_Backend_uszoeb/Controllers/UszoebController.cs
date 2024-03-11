using Forgó_Balázs_Backend_uszoeb.Models;
using Forgó_Balázs_Backend_uszoeb.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Forgó_Balázs_Backend_uszoeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UszoebController : ControllerBase
    {
        private readonly UszoebContext _context;

        public string UserId = "FEB3F4FEA09CE43E";

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

            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpGet("GetVersenyzokSzama")]
        public async Task<ActionResult<Versenyzok>> GetVersenyzokSzama()
        {
            var result = await _context.Versenyzoks.CountAsync();

            if (result == 0) { BadRequest(); }

            return Ok(result);
        }

        [HttpPost("AddVersenyzo")]
        public async Task<ActionResult<Versenyzok>> AddVersenyzo(string UserId, CreateVersenyzoDto versenyzoDto)
        {
            if (UserId == "FEB3F4FEA09CE43E")
            {
                var result = await _context.Versenyzoks.AnyAsync(x => x.Id == versenyzoDto.Id || x.Nev == versenyzoDto.Nev);

                if (result)
                {
                    return BadRequest();
                }

                var versenyzo = new Versenyzok
                {
                    Id = versenyzoDto.Id,
                    Nev = versenyzoDto.Nev,
                    OrszagId = versenyzoDto.OrszagId,
                    Nem = versenyzoDto.Nem,
                };

                await _context.AddAsync(versenyzo);
                await _context.SaveChangesAsync();

                return StatusCode(201, versenyzo);

            }
            return Unauthorized();


        }

        [HttpPut("UpdateVersenyzo/{Id}")]
        public async Task<ActionResult<Versenyzok>> UpdateVersenyzo(string UserId, int Id, UpdateVersenyzoDto versenyzoDto)
        {
            if (UserId == "FEB3F4FEA09CE43E")
            {

                var existingVersenyzo = await _context.Versenyzoks.FindAsync(Id);

                if (existingVersenyzo == null)
                {
                    return BadRequest();
                }

                existingVersenyzo.Nev = versenyzoDto.Nev;
                existingVersenyzo.OrszagId = versenyzoDto.OrszagId;
                existingVersenyzo.Nem = versenyzoDto.Nem;

                await _context.SaveChangesAsync();

                return Ok(existingVersenyzo);
            }

            return Unauthorized();
        }

        [HttpDelete("DeleteVersenyzo")]
        public async Task<ActionResult<Versenyzok>> DeleteVersenyzoById(int Id, string UserId) 
        {
            if (UserId == "FEB3F4FEA09CE43E")
            {
                var existingVersenyzo = await _context.Versenyzoks.FindAsync(Id);

                if (existingVersenyzo == null)
                {
                    BadRequest();
                }

                 _context.Versenyzoks.Remove(existingVersenyzo);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            return Unauthorized();
        }
    }

}
