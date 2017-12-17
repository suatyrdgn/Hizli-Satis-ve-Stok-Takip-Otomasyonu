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
using StokTakip.DAL;
using StokTakip.Entity.Models;
using System.Data.Entity;
using static StokTakip.BLL.Repositories.Repository;

namespace KolayStokTakip.Form
{
    public partial class frmKategoriSec : DevExpress.XtraEditors.XtraForm
    {
        public Kategori SeciliKategori { get; set; }
        public frmKategoriSec()
        {
            InitializeComponent();
        }

        private void frmKategoriSec_Load(object sender, EventArgs e)
        {
            gridKategoriSec.DataSource = new KategoriRepo().GetAll();
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            List<Kategori> kategorilistesi = gridKategoriSec.DataSource as List<Kategori>;
            SeciliKategori = kategorilistesi[gridView1.FocusedRowHandle];
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frmKategoriIslemleri frm = new frmKategoriIslemleri();
            frm.ShowDialog();
        }
    }
}