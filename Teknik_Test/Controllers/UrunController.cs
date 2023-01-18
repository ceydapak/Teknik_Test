using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace Teknik_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : Controller
    {
        private readonly DBContext _context;
        public UrunController(DBContext context, IConfiguration configuration)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Urun>>> GetUrunler()
        {
            if (_context.Urunler == null)
            {
                return NotFound();
            }
            return _context.Urunler.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<Urun>> PostUrun(Urun request)
        {

            if (_context.Urunler == null)
            {
                return Problem("Urunler bos.");
            }
            var urun = new Urun();
            request.Id = urun.Id;
            urun.U_Adi = request.U_Adi;
            urun.Stok = request.Stok;
            urun.Fiyati = request.Fiyati;
            urun.FirmaID = request.FirmaID;
            _context.Urunler.Add(urun);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
