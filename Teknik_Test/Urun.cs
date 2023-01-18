
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Teknik_Test
{
    public class Urun
    {

        public int Id { get; set; }

        public string U_Adi { get; set; } = string.Empty;
        public int Stok { get; set; }
        public int Fiyati { get; set; }
        public int FirmaID { get; set; }

        [ForeignKey("FirmaID")]
        public Firma Firma { get; set; }


        [JsonIgnore]
        public List<Siparis>? Siparis { get; set; }

    }
}
