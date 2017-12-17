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

namespace KolayStokTakip.Form
{
    public partial class frmNakitSatis : DevExpress.XtraEditors.XtraForm
    {
        public decimal ToplamTutar { get; set; }
        public frmNakitSatis()
        {
            InitializeComponent();
        }

        private void frmNakitSatis_Load(object sender, EventArgs e)
        {
            txtAlinan.Focus();
        }

        private void txtAlinan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }

        }

        private void frmNakitSatis_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void frmNakitSatis_FormClosed(object sender, FormClosedEventArgs e)
        {
            

        }

        private void txtAlinan_EditValueChanged(object sender, EventArgs e)
        {
            label1.Text = $"{(Convert.ToDecimal(txtAlinan.Text) - ToplamTutar):c2}";
        }
    }
}