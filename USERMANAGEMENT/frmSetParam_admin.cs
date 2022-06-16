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
using BusinessLayer;
using KHACHSAN;
namespace USERMANAGEMENT
{
    public partial class frmSetParam_admin : DevExpress.XtraEditors.XtraForm
    {
        public frmSetParam_admin(tb_SYS_USER admin)
        {
            InitializeComponent();
            this._admin = admin;
        }
        frmSetParam_admin objSetParam = (frmSetParam_admin)Application.OpenForms["frmSetParam"];
        tb_SYS_USER _admin;
        int _right;
        CONGTY _congty;
        DONVI _donvi;
        frmMain _frmmain;
        private void frmSetParam_Load(object sender, EventArgs e)
        {
            if (objSetParam != null)
            {
                objSetParam.Hide();
            }
            _donvi = new DONVI();
            _congty = new CONGTY();
            loadCongty();
            cboCongty.SelectedIndexChanged += CboCongty_SelectedIndexChanged; ;
            loadDonvi();
        }

        private void CboCongty_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDonvi();
        }
        void loadCongty()
        {
            cboCongty.DataSource = _congty.getAll();
            cboCongty.DisplayMember = "TENCTY";
            cboCongty.ValueMember = "MACTY";
        }
        void loadDonvi()
        {
            cboDonvi.DataSource = _donvi.getAll(cboCongty.SelectedValue.ToString());
            cboDonvi.DisplayMember = "TENDVI";
            cboDonvi.ValueMember = "MADVI";
            cboDonvi.SelectedIndex = -1;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string macty = cboCongty.SelectedValue.ToString();
            string madvi =  cboDonvi.SelectedValue.ToString();

            using (frmMain frm =new frmMain(_admin))
            {
                Friend._macty = macty;
                Friend._madvi = madvi;
                frm.ShowDialog();
            }    
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}