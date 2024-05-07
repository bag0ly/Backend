using fb_backend_gyakorlas_01.Dtos;
using fb_backend_gyakorlas_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fb_backend_gyakorlas_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JegyekController : ControllerBase
    {
        private readonly OsztalynaploContext _context;

        public JegyekController(OsztalynaploContext context)
        {
            _context = context;
        }

        [HttpGet("OsszesJegy")]
        public async Task<ActionResult<Jegyek>> osszesJegy() 
        {
            var result = await _context.Jegyeks.CountAsync();
            if (result == 0)
            {
                return StatusCode(400, "Adatbazis nem elerheto");
            }
            return Ok(result);
        }

        [HttpPost("JegyHozzaadas/${Uid}/")]
        public async Task<ActionResult<Jegyek>> jegyHozzaadas(JegyHozzaadasDto jegyHozzaadas, string Uid) 
        {
            var tantargy = await _context.Tantargyaks.FirstOrDefaultAsync(t => t.TantargyNev == jegyHozzaadas.Tantargy);
            var tanar = await _context.Tanaroks.FirstOrDefaultAsync(t=>t.VezetekNev == jegyHozzaadas.TanarVez && t.KeresztNev == jegyHozzaadas.TanarKer);
            if (tanar == null || tantargy == null)
            {
                return NotFound();
            }
            else if (Uid != "FKB3F4FEA09CE43C") 
            {
                return StatusCode(401, "Unauthorized");
            }
            

            var jegyek = new Jegyek
            {
                JegySzammal = jegyHozzaadas.JegySzammal,
                JegySzoveggel = jegyHozzaadas.JegySzoveggel,
                BeirasDatuma = DateTime.UtcNow,
                ModositasDatuma = DateTime.UtcNow,
                IdTanarok = tanar.Id,
                IdTantargyak = tantargy.Id,
            };

            await _context.Jegyeks.AddAsync(jegyek);
            await _context.SaveChangesAsync();

            return Ok(); 
        }
    }
}
