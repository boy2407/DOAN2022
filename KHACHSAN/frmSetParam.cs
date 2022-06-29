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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace KHACHSAN
{
    public partial class frmSetParam : DevExpress.XtraEditors.XtraForm
    {
        public frmSetParam()
        {
            InitializeComponent();
        }
        public frmSetParam(frmLogin frmlogin)
        {          
            this._frmlogin = frmlogin;
            InitializeComponent();
        }

        frmSetParam objSetParam = (frmSetParam)Application.OpenForms["frmSetParam"];
        tb_SYS_USER _user;
        int _right;
        CONGTY _congty;
        DONVI _donvi;
        frmMain _frmmain;
        frmLogin _frmlogin;
        private void frmSetParam_Load(object sender, EventArgs e)
        {
            if(objSetParam!=null)
            {
                objSetParam.Hide();
            }    
            _donvi = new DONVI();
            _congty = new CONGTY();
            loadCongty();           
            cboCongty.SelectedIndexChanged += CboCongty_SelectedIndexChanged;
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
            if(cboDonvi.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn đơn vị trực thuộc", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //string madvi = (cboDonvi.Text.Trim() == "") ? "~" : cboDonvi.SelectedValue.ToString();
            string madvi =cboDonvi.SelectedValue.ToString();
            SYS_PARAM _sysparam = new SYS_PARAM(macty,madvi);
            _sysparam.SaveFile();
           
            MessageBox.Show("Xác nhận đơn vị sử dụng thành công", "Thông Báo");
            BinaryFormatter bf = new BinaryFormatter();

            using (frmLogin frmlogin = new frmLogin(this))
            {
                this.Visible = false;
                frmlogin.ShowDialog();
            }    

                                  
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCongty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}