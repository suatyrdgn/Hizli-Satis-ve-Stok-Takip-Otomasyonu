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
using static StokTakip.BLL.Repositories.Repository;
using StokTakip.Entity.Models;

namespace KolayStokTakip.Form
{
    public partial class frmKategoriIslemleri : DevExpress.XtraEditors.XtraForm
    {
        public frmKategoriIslemleri()
        {
            InitializeComponent();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                KategoriRepo repo = new KategoriRepo();
                repo.Insert(new Kategori
                {
                    Aciklama = txtAciklama.Text,
                    KategoriAdi = txtKategoriAdi.Text,
                    KDV = Convert.ToInt32(txtKDVOrani.Text)
                });
                MessageBox.Show("Kategori başarılı bir şekilde eklenmiştir.", "Başarılı");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : "+ex.Message);
            }
            
        }
        Kategori seciliKategori;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetSelectedRows().Length == 0) return;
            seciliKategori = gridView1.GetFocusedRow() as Kategori;
            txtKategoriAdiGuncelle.Text = seciliKategori.KategoriAdi;
            txtKDVGuncelle.Text = seciliKategori.KDV.ToString(); 
            txtAciklamaGuncelle.Text = seciliKategori.Aciklama;
        
        }

        private void frmKategoriIslemleri_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = new KategoriRepo().GetAll();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult cevap = MessageBox.Show("Seçili kategori kalıcı olarak silinecektir.\nEmin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cevap == DialogResult.Yes)
                {
                    KategoriRepo kategorisil = new KategoriRepo();
                    kategorisil.Delete(seciliKategori);
                    MessageBox.Show("Ürün kalıcı olarak silinmiştir.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}