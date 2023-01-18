using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Teknik_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : Controller
    {
       
        private readonly DBContext _context;
        public FirmaController(DBContext context, IConfiguration configuration)
        {
            _context = context;
           
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Firma>>> GetFirmalar()
        {
            if (_context.Firmalar == null)
            {
                return NotFound();
            }
            return _context.Firmalar.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Firma>> GetFirma(int id)
        {
            if (_context.Firmalar == null)
            {
                return NotFound();
            }
            var f = await _context.Firmalar.FindAsync(id);

            if (f == null)
            {
                return NotFound();
            }

            return f;
        }


        [HttpPost]
        public async Task<ActionResult<Firma>> PostFirma(Firma firma)
        {
            if (_context.Firmalar == null)
            {
                return Problem("Entity set 'DataContext.Books'  is null.");
            }
            _context.Firmalar.Add(firma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirma", new { id = firma.Id }, firma);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFrima(Firma request)
        {
            var dbFirma = await _context.Firmalar.FindAsync(request.Id);
            if (dbFirma == null)
            {
                return BadRequest();
            }
            request.F_Adi = dbFirma.F_Adi;
            dbFirma.Onay_Durumu = request.Onay_Durumu;
            dbFirma.S_I_Bas_Saati = request.S_I_Bas_Saati;
            dbFirma.S_I_Bit_Saati = request.S_I_Bit_Saati;

            await _context.SaveChangesAsync();
          

            return NoContent();
        }

    }
}
