using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entity.ViewModels
{
    public class UrunListViewModel
    {

        public int StokKodu { get; set; }
        public string UrunAdi { get; set; }
        public string Barkod { get; set; }
        public decimal BirimFiyat { get; set; }
        public int KDV { get; set; }
        public int Adet { get; set; }
        public decimal KDVsizTutar
        {
            get
            {
                decimal Kdvsiz = BirimFiyat * 100 / (KDV + 100);

                return Kdvsiz;
            }
        }
        public decimal KdvTutari
        {
            get
            {
                return BirimFiyat * KDV / 100;
            }
        }
        public decimal decToplamTutar
        {
            get
            {
                return BirimFiyat * Adet;
            }
        }

        public decimal decToplamKDV
        {
            get
            {
                return Adet * KdvTutari;
            }
        }


    }
}
