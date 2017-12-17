using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Models
{
    [Table("Kategoriler")]
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [StringLength(40)]
        [Index(IsUnique = true)]
        [Required]
        public string KategoriAdi { get; set; }

        public string Aciklama { get; set; }

        public int KDV { get; set; }

        public List<Urun> Urunler { get; set; } = new List<Urun>();

        public override string ToString()
        {
            return KategoriAdi;
        }
    }
}
