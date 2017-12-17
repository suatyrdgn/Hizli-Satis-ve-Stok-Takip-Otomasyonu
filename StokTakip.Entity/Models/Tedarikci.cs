using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Models
{
    [Table("Tedarikciler")]
    public class Tedarikci
    {
        [Key]
        public int TedarikciID { get; set; }
        [Required]
        [StringLength(40)]
        public string SirketAdi { get; set; }
        [StringLength(40)]
        public string CalisanAdi { get; set; }
        [StringLength(30)]
        public string SirketMail { get; set; }
        [Required]
        public string Adres { get; set; }

        public string Adres2 { get; set; }
        [Required]
        public string Telefon { get; set; }

        public string CalisanTelefonu { get; set; }

        public string Fax { get; set; }

        public virtual List<Siparis> Siparisler { get; set; } = new List<Siparis>();

    }
}
