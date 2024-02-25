using Forgó_Balázs_Backend.Models;
using Forgó_Balázs_Backend.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forgó_Balázs_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsztalynaploController : ControllerBase
    {
        private readonly OsztalynaploContext _context;

        public OsztalynaploController(OsztalynaploContext context)
        {
            _context = context;
        }

        [HttpGet("feladat9")]
        public async Task<ActionResult<Tantargyak>> Get()
        {
            try
            {
                var megoldas = await _context.Tantargyaks.ToListAsync();

                if (megoldas == null)
                {
                    throw new Exception("unable to connect any MySql hosts");
                }

                return StatusCode(201, megoldas);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("feladat10")]
        public async Task<ActionResult<Tantargyak>> GetByTantargyNev(string TantargyNev)
        {
            try
            {
                var megoldas = await _context.Tantargyaks.FirstOrDefaultAsync(x => x.TantargyNev == TantargyNev);

                if (megoldas == null)
                {
                    throw new Exception("The tantargy field is required");
                }

                return StatusCode(201, megoldas);
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
        }

        [HttpGet("feladat11")]
        public async Task<ActionResult<Tanarok>> GetTanarokAllInfo()
        {
            try
            {
                var megoldas = await _context.Tanaroks
                                                      .Include(x => x.Jegyeks)
                                                      .ToListAsync();

                if (megoldas == null)
                {
                    throw new Exception("unable to connect any MySql hosts");
                }

                return StatusCode(201, megoldas);
            }
            catch (Exception e)
            {

                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("feladat12")]
        public async Task<ActionResult<Jegyek>> GetAllJegy()
        {
            try
            {
                var megoldas = await _context.Jegyeks.SumAsync(x => x.JegySzammal);

                if (megoldas == 0)
                {
                    throw new Exception("unable to connect any MySql hosts");
                }

                return StatusCode(201, $"Az osszes jegy szama: {megoldas}");
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpPost("feladat13")]
        public async Task<ActionResult<Jegyek>> PostUjJegy(string uid,JegyekDto jegyekDto) 
        {
            try
            {
                var jegyek = new Jegyek
                {
                    JegySzammal = jegyekDto.JegySzammal,
                    JegySzoveggel = jegyekDto.JegySzoveggel,
                    BeirasDatuma = DateTime.Now,
                };

                if (uid != "FKB3F4FEA09CE43C")
                {
                    throw new Exception("„Nincs jogosultsága új versenyző felvételéhez!”");
                }

                return StatusCode(201,  "A jegy hozzaadasa sikeresen megtortent");
            }
            catch (Exception e)
            {
                return StatusCode(401, e.Message);
            }
        }
    }
}
