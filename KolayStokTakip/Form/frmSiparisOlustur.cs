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
            lookUpEdit1.Properties.DataSource = tedarikciRepo.GetAll();
            lookUpEdit1.Properties.DisplayMember = "SirketAdi";
        }
    }
}