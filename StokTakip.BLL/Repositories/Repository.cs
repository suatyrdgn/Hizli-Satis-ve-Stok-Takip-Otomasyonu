
using StokTakip.DAL;
using StokTakip.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.BLL.Repositories
{
    public class Repository
    {
        public class UrunRepo : RepositoryBase<Urun, int>
        {
            public Urun BarkodaGoreGetir(string Barkod)
            {
                try
                {
                    dbContext = dbContext ?? new MyContext();
                    return dbContext.Urunler.Where(x => x.Barkod == Barkod).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public class KategoriRepo : RepositoryBase<Kategori, int> { }
        public class SatisRepo : RepositoryBase<Satis, int>
        {
            public void Satis(Satis satis, List<SatisDetay> satisdetayListesi)
            {
                if (dbContext == null) dbContext = new MyContext();
                using (var tran =  dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        Insert(satis);
                        foreach (var item in satisdetayListesi)
                        {
                            item.SatisID = satis.SatisID;
                        };
                        dbContext.SatisDetaylar.AddRange(satisdetayListesi);
                        dbContext.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                }

            }
            
        }
        public class SiparisRepo : RepositoryBase<Siparis, int> { }
        public class TedarikciRepo : RepositoryBase<Tedarikci, int> { }
        public class SiparisDetayRepo : RepositoryBaseMultiKey<SiparisDetay, int, int>
        {
            public List<SiparisDetay> SiparisIdGoreGetir(int siparisId)
            {
                try
                {
                    dbContext = dbContext ?? new MyContext();
                    return dbContext.SiparisDetaylar.Where(x => x.SiparisID == siparisId).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public List<SiparisDetay> UrunIdGoreGetir(int urunId)
            {
                try
                {
                    dbContext = dbContext ?? new MyContext();
                    return dbContext.SiparisDetaylar.Where(x => x.UrunID == urunId).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public class SatisDetayRepo : RepositoryBaseMultiKey<SatisDetay, int, int>
        {
            public List<SatisDetay> SatisIdGoreGetir(int satisID)
            {
                try
                {
                    dbContext = dbContext ?? new MyContext();
                    return dbContext.SatisDetaylar.Where(x => x.SatisID == satisID).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public List<SatisDetay> UrunIdGoreGetir(int UrunId)
            {
                try
                {
                    dbContext = dbContext ?? new MyContext();
                    return dbContext.SatisDetaylar.Where(x => x.UrunID == UrunId).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
