using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace Teknik_Test
{
    public class Firma
    {
        public int Id { get; set; }
        public string F_Adi { get; set; } = string.Empty;
        public bool Onay_Durumu { get; set; }
        public DateTime S_I_Bas_Saati { get; set; }
        public DateTime S_I_Bit_Saati { get; set; }

        [JsonIgnore]
        public List<Urun>? Urun { get; set; }
        [JsonIgnore]
        public List<Siparis>? Siparis { get; set; }
    }
}
