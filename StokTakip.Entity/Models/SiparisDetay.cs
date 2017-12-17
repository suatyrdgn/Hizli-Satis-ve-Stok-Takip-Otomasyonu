using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Models
{
    [Table("SiparisDetaylar")]
    public class SiparisDetay
    {
        [Key]
        [Column(Order = 1)]
        public int SiparisID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int UrunID { get; set; }

        [Required]
        public decimal Fiyat { get; set; }

        public int Adet { get; set; } = 1;

        public int Indirim { get; set; }=0;

        [ForeignKey("UrunID")]
        public virtual Urun Urun { get; set; }

        [ForeignKey("SiparisID")]
        public virtual Siparis Siparis { get; set; }
    }
}
