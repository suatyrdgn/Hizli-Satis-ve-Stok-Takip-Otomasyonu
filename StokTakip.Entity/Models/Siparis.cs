using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Models
{
    [Table("Siparisler")]
    public class Siparis
    {
        [Key]
        public int SiparisID { get; set; }
        public int TedarikciID { get; set; }
        public DateTime SiparisTarihi { get; set; } = DateTime.Now;
        public string SiparisNotu { get; set; }
        public bool TeslimAlindiMi { get; set; } = false;
        public decimal ToplamFiyat { get; set; }=0;

        [ForeignKey("TedarikciID")]
        public virtual Tedarikci Tedarikci { get; set; }

    }
}
