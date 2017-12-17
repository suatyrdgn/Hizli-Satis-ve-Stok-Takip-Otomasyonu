using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using KolayStokTakip.Form;
using StokTakip.Entity.ViewModels;
using static StokTakip.BLL.Repositories.Repository;
using StokTakip.Entity.Models;

namespace KolayStokTakip
{
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public AnaForm()
        {
            InitializeComponent();
        }
        List<UrunListViewModel> SepetListesi = new List<UrunListViewModel>();
        void UrunSatisKontrol(Urun urun)
        {
            if (urun.Stok ==0 || urun.SatistaMi==false)
            {
                throw new Exception("Ürün satıştan kaldırılmış veya stokta bulunamamıştır.");
            }
        }
        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Multiply)
            {
                txtAdet.Text = txtBarkod.Text;
                txtBarkod.Text = string.Empty;
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarkod.Text == string.Empty) return;
                e.Handled = true;
                e.SuppressKeyPress = true;
                int miktar = int.Parse(txtAdet.Text);
                try
                {
                    string barkod = txtBarkod.Text;
                    UrunRepo urn = new UrunRepo();
                    if (urn.BarkodaGoreGetir(barkod) == null)
                    {
                        DialogResult cevap = MessageBox.Show("Barkod veritabanında bulunmamaktadır.\n Yeni ürün olarak eklemek ister misiniz?", "Kayıtsız stok!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (cevap == DialogResult.Yes)
                        {
                            frmStokIslemleri frm = new frmStokIslemleri();
                            frm.txtBarkod.Text = barkod;
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        bool listedevarMi = false;
                        Urun gelenUrun = urn.BarkodaGoreGetir(barkod);
                        UrunSatisKontrol(gelenUrun);
                        foreach (var item in SepetListesi)
                        {
                            if (item.Barkod == gelenUrun.Barkod)
                            {
                                item.Adet += miktar;
                                listedevarMi = true;
                            }
                        }
                        if (!listedevarMi)
                        {
                            UrunListViewModel yeni = new UrunListViewModel();
                            yeni.Adet = miktar;
                            yeni.UrunAdi = gelenUrun.UrunAdi;
                            yeni.Barkod = gelenUrun.Barkod;
                            yeni.BirimFiyat = gelenUrun.UrunSatisFiyati;
                            if (gelenUrun.Kategori == null)
                             yeni.KDV = 1;
                            else
                            yeni.KDV = gelenUrun.Kategori.KDV;
                            yeni.StokKodu = gelenUrun.UrunID;
                            SepetListesi.Add(yeni);
                        }

                    }
                    UrunEklemeSonrasi();
                    SepetToplaminiYaz();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    txtBarkod.Text = string.Empty;
                    txtBarkod.Focus();
                }
            }
        }

        void SepetToplaminiYaz()
        {
            lbltoplam.Text = $"{SepetListesi.Sum(x => x.decToplamTutar):c2}";
        }
        void UrunEklemeSonrasi()
        {
            txtAdet.Text = "1";
            gridControl1.DataSource = null;
            gridControl1.DataSource = SepetListesi;
        }
        private void txtBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //frmNakitSatis frm = new frmNakitSatis();
            //frm.ToplamTutar = SepetListesi.Sum(x => x.decToplamTutar);
            //frm.ShowDialog();

            try
            {
                SatisRepo satisRepo = new SatisRepo();
                Satis satis = new Satis()
                {
                    OdemeTipi = OdemeTipi.Nakit,
                    SatisTarihi = DateTime.Now
                };
                List<SatisDetay> stlst = new List<SatisDetay>();
                foreach (var item in SepetListesi)
                {
                  
                  stlst.Add(  new SatisDetay()
                    {
                        Adet = item.Adet,
                        Fiyat = item.BirimFiyat,
                        UrunID = item.StokKodu
                    });
                    satisRepo.Satis(satis, stlst);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnStokİslemleri_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmStokIslemleri frm = new frmStokIslemleri();
            frm.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTedarikciIslemleri frm = new frmTedarikciIslemleri();
            frm.ShowDialog();
        }
        private void btnStokHareketleri_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void AnaForm_Load(object sender, EventArgs e)
        {
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmKategoriIslemleri frm = new frmKategoriIslemleri();
            frm.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSiparisOlustur frm = new frmSiparisOlustur();
            frm.Show();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            decimal alinan = Convert.ToDecimal(textEdit1.Text);
            decimal toplam = SepetListesi.Sum(x => x.decToplamTutar);
            decimal kalan = alinan - toplam;
            textEdit2.Text = kalan.ToString();
        }
    }
}