using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Models
{
    [Table("SatisDetaylar")]
    public class SatisDetay
    {
       
        [Key]
        [Column(Order =1)]
        public int SatisID { get; set; }
        [Key]
        [Column(Order =2)]
        public int UrunID { get; set; }

        public decimal Fiyat { get; set; }

        public int Adet { get; set; }
        
        [ForeignKey("UrunID")]
        public virtual Urun Urun { get; set; }

        [ForeignKey("SatisID")]
        public virtual Satis Satis { get; set; }
    }
}
