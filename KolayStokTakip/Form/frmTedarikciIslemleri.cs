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
using System.Data.Entity;
using static StokTakip.BLL.Repositories.Repository;
using StokTakip.Entity.Models;

namespace KolayStokTakip.Form
{
    public partial class frmTedarikciIslemleri : DevExpress.XtraEditors.XtraForm
    {
        public frmTedarikciIslemleri()
        {
            InitializeComponent();
        }

        private void frmTedarikciIslemleri_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = new TedarikciRepo().GetAll();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                TedarikciRepo tedarikci = new TedarikciRepo();
                tedarikci.Insert(new Tedarikci()
                {
                    SirketAdi = txtSirketAdi.Text,
                    Adres = txtAdres1.Text,
                    Adres2 = txtAdres2.Text,
                    CalisanAdi = txtCalisanAdi.Text,
                    CalisanTelefonu = txtCalisanTelefon.Text,
                    Fax = txtFax.Text,
                    Telefon = txtTelefon.Text,
                    SirketMail = txtSirketMaili.Text,
                });
                MessageBox.Show("Tedarikçi kaydedilmiştir.", "İşlem başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Tedarikci seciliTedarikci = null;
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (gridView1.GetSelectedRows().Length == 0) return;
                seciliTedarikci = gridView1.GetFocusedRow() as Tedarikci;
                txtSirketAdiGuncelle.Text = seciliTedarikci.SirketAdi;
                txtSirketFaxGuncelle.Text = seciliTedarikci.Fax;
                txtSirketMailGuncelle.Text = seciliTedarikci.SirketMail;
                txtSirketTelefonGuncelle.Text = seciliTedarikci.Telefon;
                txtCalisanAdiGuncelle.Text = seciliTedarikci.CalisanAdi;
                txtCalisanTelefonGuncelle.Text = seciliTedarikci.CalisanTelefonu;
                txtAdresGuncelle.Text = seciliTedarikci.Adres;
                txtAdres2Guncelle.Text = seciliTedarikci.Adres2;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                TedarikciRepo tedarikci = new TedarikciRepo();
                seciliTedarikci.SirketAdi = txtSirketAdiGuncelle.Text;
                seciliTedarikci.SirketMail = txtSirketMailGuncelle.Text;
                seciliTedarikci.Telefon = txtSirketTelefonGuncelle.Text;
                seciliTedarikci.Fax = txtSirketFaxGuncelle.Text;
                seciliTedarikci.Adres = txtAdresGuncelle.Text;
                seciliTedarikci.Adres2 = txtAdres2Guncelle.Text;
                seciliTedarikci.CalisanAdi = txtCalisanAdiGuncelle.Text;
                seciliTedarikci.CalisanTelefonu = txtCalisanTelefonGuncelle.Text;
                tedarikci.Update();
                MessageBox.Show("Tedarikçi başarıyla güncellenmiştir", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}