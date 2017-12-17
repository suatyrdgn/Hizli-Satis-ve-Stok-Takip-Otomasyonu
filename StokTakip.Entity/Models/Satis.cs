using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.Models
{
    [Table("Satislar")]
    public class Satis
    {
        [Key]
        public int SatisID { get; set; }

        public DateTime SatisTarihi { get; set; } = DateTime.Now;

        public OdemeTipi OdemeTipi { get; set; }

        [Range(0, 100, ErrorMessage = "İndirim oranı 0-100 arası olmalıdır.")]
        public int Indirim { get; set; }
    }
}

public enum OdemeTipi
{
    Nakit, KrediKarti
}