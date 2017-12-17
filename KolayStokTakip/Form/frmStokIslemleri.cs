using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using StokTakip.Entity.Models;
using StokTakip.DAL;
using DevExpress.XtraEditors.Camera;
using static StokTakip.BLL.Repositories.Repository;
using StokTakip.BLL;
using System.Data.Entity;

namespace KolayStokTakip.Form
{
    public partial class frmStokIslemleri : DevExpress.XtraEditors.XtraForm
    {
        public frmStokIslemleri()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult cevap = ofdResimSec.ShowDialog();

            if (cevap == DialogResult.OK)
                pictureUrunResmi.Image = Image.FromFile(ofdResimSec.FileName);
        }

        private void btnKamera_Click(object sender, EventArgs e)
        {
            var dialog = new TakePictureDialog();
            var cevap = dialog.ShowDialog();
            if (cevap == DialogResult.OK)
                pictureUrunResmi.Image = dialog.Image;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            try
            {
                UrunRepo urun = new UrunRepo();
                urun.Insert(new Urun()
                {
                    Barkod = txtBarkod.Text,
                    IndirimOrani = int.Parse(txtIndirimOrani.Text),
                    SatistaMi = chcSatistaMi.Checked,
                    Stok = int.Parse(txtStokMiktari.Text),
                    UrunAdi = txtUrunAdi.Text,
                    KategoriID = secilikategori?.KategoriID,
                    UrunSatisFiyati = Convert.ToDecimal(txtSatisFiyati.Text),
                    UrunResmi = StokTakipMethods.imageToByteArray(pictureUrunResmi.Image)
                });
                MessageBox.Show("Ürün kaydedilmiştir.", "İşlem başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        Kategori secilikategori = null;
        private void txtKategorisi_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmKategoriSec frm = new frmKategoriSec();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Yes)
            {
                txtKategorisi.Text = frm.SeciliKategori.KategoriAdi;
                secilikategori = frm.SeciliKategori;
            }
        }

        private void frmStokIslemleri_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = new UrunRepo().GetAll();

        }

        private void btnKameraGuncelle_Click(object sender, EventArgs e)
        {
            var dialog = new TakePictureDialog();
            var cevap = dialog.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                pictureUrunResmiGuncelle.Image = dialog.Image;
            }
        }

        private void btnResimSecGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult cevap = ofdResimSec.ShowDialog();
            if (cevap == DialogResult.OK)
                pictureUrunResmiGuncelle.Image = Image.FromFile(ofdResimSec.FileName);

        }
        Urun seciliUrun = null;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                secilikategori = null;
                txtKategorisi.Text = string.Empty;
                if (gridView1.GetSelectedRows().Length == 0) return;
                seciliUrun = gridView1.GetFocusedRow() as Urun;
                txtUrunAdiGuncelle.Text = seciliUrun.UrunAdi;
                txtStokMiktariGuncelle.Text = seciliUrun.Stok.ToString();
                txtBarkodGuncelle.Text = seciliUrun.Barkod;
                txtSatisFiyatiGuncelle.Text = seciliUrun.UrunSatisFiyati.ToString();
                txtIndirimOraniGuncelle.Text = ((int)seciliUrun.IndirimOrani).ToString();
                chcSatistaMiGuncelle.Checked = seciliUrun.SatistaMi;
                pictureUrunResmiGuncelle.Image = StokTakipMethods.byteArrayToImage(seciliUrun.UrunResmi);
                txtKategorisiGuncelle.Text = seciliUrun.Kategori.KategoriAdi;

            }
            catch (Exception ex)
            {
            }

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult cevap = MessageBox.Show("Seçili ürün kalıcı olarak silinecektir.\nEmin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cevap == DialogResult.Yes)
                {
                    UrunRepo urunsil = new UrunRepo();
                    urunsil.Delete(seciliUrun);
                    MessageBox.Show("Ürün kalıcı olarak silinmiştir.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                UrunRepo urun = new UrunRepo();

                seciliUrun.IndirimOrani = decimal.Parse(txtIndirimOraniGuncelle.Text);
                seciliUrun.SatistaMi = chcSatistaMi.Checked;
                seciliUrun.UrunAdi = txtUrunAdiGuncelle.Text;
                seciliUrun.SatistaMi = chcSatistaMiGuncelle.Checked;
                seciliUrun.UrunSatisFiyati = Convert.ToDecimal(txtSatisFiyatiGuncelle.Text);
                seciliUrun.Stok = int.Parse(txtStokMiktariGuncelle.Text);
                seciliUrun.UrunResmi = StokTakipMethods.imageToByteArray(pictureUrunResmiGuncelle.Image);
                seciliUrun.KategoriID = secilikategori?.KategoriID;
                urun.Update();
                MessageBox.Show("Ürün güncelleme işlemi başarılı","Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA : "+ex.Message); 
            }
            
        }

        private void txtKategorisiGuncelle_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmKategoriSec frm = new frmKategoriSec();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Yes)
            {
                txtKategorisiGuncelle.Text = frm.SeciliKategori.KategoriAdi;
                secilikategori = frm.SeciliKategori;
            }
        }
    }
}