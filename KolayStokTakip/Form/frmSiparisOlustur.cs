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
    public partial class frmSiparisOlustur : DevExpress.XtraEditors.XtraForm
    {
        public frmSiparisOlustur()
        {
            InitializeComponent();
        }

        private void frmSiparisOlustur_Load(object sender, EventArgs e)
        {
            TedarikciRepo tedarikciRepo = new TedarikciRepo();
            lookUpTedarikci.Properties.DataSource = tedarikciRepo.GetAll();
            lookUpTedarikci.Properties.DisplayMember = "SirketAdi";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SiparisRepo siparis = new SiparisRepo();
                siparis.Insert(new Siparis()
                {
                    SiparisNotu = memoEditSiparisNotu.Text,
                    SiparisTarihi = (DateTime)dateEditSiparisTarihi.EditValue,
                    TeslimAlindiMi = checkEditAlindiMi.Checked,
                    ToplamFiyat = Convert.ToDecimal(textEditFiyat.Text),
                    Tedarikci = (Tedarikci)lookUpTedarikci.GetSelectedDataRow()
                });
                MessageBox.Show("Sipariş kaydedilmiştir.", "İşlem başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}