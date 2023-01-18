using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teknik_Test
{
    public class Siparis
    {
        public int Id { get; set; }
        public string S_Veren_Adi { get; set; } = string.Empty;
        public DateTime S_Tarihi { get; set; }
        public int FirmaID { get; set; }
        public int UrunID { get; set; }

        [ForeignKey("FirmaID")]
        public Firma Firma { get; set; }


        [ForeignKey("UrunID")]
        public Urun Urun { get; set; }




    }
}
