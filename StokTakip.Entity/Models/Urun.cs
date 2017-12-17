using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Models
{
    [Table("Urunler")]
    public class Urun
    {
        [Key]
        public int UrunID { get ; set; }

        [StringLength(20)]
        [Required]
        [Index(IsUnique = true)]
        public string Barkod { get; set; }

        [Required]
        public string UrunAdi { get; set; }

        public byte[] UrunResmi { get; set; }

        public decimal UrunSatisFiyati { get; set; }

        public int? KategoriID { get; set; }

        public bool SatistaMi { get; set; } = true;

        public int Stok { get; set; } = 0;

        public decimal IndirimOrani { get; set; }


        [ForeignKey("KategoriID")]
        public virtual Kategori Kategori { get; set; }









    }
}
