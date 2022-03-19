using BusinessLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;

namespace KHACHSAN.MyControls
{
    public partial class frmShowDonVi : DevExpress.XtraEditors.XtraForm
    {
        public frmShowDonVi()
        {
            InitializeComponent();
        }
        public frmShowDonVi(TextBox txtDovi)
        {
            InitializeComponent();
            this._txtDonVi = txtDovi;
        }
        TextBox _txtDonVi;
        DONVI _donvi;
        CONGTY _congty;
        private void btnThucHien_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDonVi_Load(object sender, EventArgs e)
        {
            _donvi = new DONVI();
             _congty = new CONGTY();
            loadCongTy();
            loadDonVi();
            cboCongTy.SelectedValueChanged += CboCongTy_SelectedValueChanged;
            
        }

        private void CboCongTy_SelectedValueChanged(object sender, EventArgs e)
        {
            loadDonVi();
        }
        void loadCongTy()
        {
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
            cboCongTy.SelectedValue = Friend._macty;
        }
        void loadDonVi()
        {
            gcDanhSach.DataSource = _donvi.getAll(cboCongTy.SelectedValue.ToString());
            gvDanhSach.OptionsBehavior.Editable = false;
        }
    }
}