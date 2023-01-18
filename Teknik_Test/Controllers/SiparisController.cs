using Microsoft.AspNetCore.Mvc;

namespace Teknik_Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : Controller
    {
        public bool onay;

        private readonly DBContext _context;
        public SiparisController(DBContext context, IConfiguration configuration)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Siparis>>> GetSiparisler()
        {
            if (_context.Siparisler == null)
            {
                return NotFound();
            }
            return _context.Siparisler.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSiparis(Siparis request)
        {
            var firma = await _context.Firmalar.FindAsync(request.FirmaID);
            var siparis = new Siparis();
            onay = firma.Onay_Durumu;

                if (onay == true)
                {
                    if(firma.S_I_Bas_Saati<DateTime.Now && firma.S_I_Bit_Saati > DateTime.Now)
                    {
                         siparis.S_Veren_Adi = request.S_Veren_Adi;
                         siparis.S_Tarihi = request.S_Tarihi;
                         siparis.FirmaID = request.FirmaID;
                         siparis.UrunID = request.UrunID;
                         _context.Siparisler.Add(siparis);
                         await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return Problem("Firma şuan sipariş almıyor");
                    }

                }
                else
                {
                    return Problem("Firma onaylı değil");
                }
          

            return NoContent();
        }

    }
}
