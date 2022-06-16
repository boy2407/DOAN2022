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
using System.Runtime.Serialization.Formatters.Binary;
using DataLayer;
using BusinessLayer;
using System.IO;
using System.Threading;
namespace KHACHSAN
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();

        }
        public frmLogin(frmSetParam frm)
        {
            this._frmsetparam = frm;
            InitializeComponent();
        }

        public frmSetParam _frmsetparam { get; set; }
        SYS_PARAM _sysparam;
        SYS_USER _sysUser;
        BinaryFormatter bf;
        FileStream fs;
        tb_SYS_USER _user;
        private void frmLogin_Load(object sender, EventArgs e)
        {
            _sysUser = new SYS_USER();
            bf = new BinaryFormatter();
            fs = File.Open("sysparam.ini", FileMode.Open, FileAccess.Read);
            _sysparam = bf.Deserialize(fs) as SYS_PARAM;
            if (_sysparam.macty == null || _sysparam.madvi == null)
                return;
            Friend._macty = _sysparam.macty;
            Friend._madvi = _sysparam.madvi;
            this.Text = _sysparam.macty + " - " + _sysparam.madvi;
            fs.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_sysparam.macty == null || _sysparam.madvi == null)
                return;
            login();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                login();
            }

        }
        void login()
        {

            if (txtUserNam.Text.Trim() == "")
            {
                MessageBox.Show("Tên Đăng nhập không để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (checkadmin.Checked == true)
            //{

            //    tb_Admin admin = _sysUser.getAdmin(txtUserNam.Text);
            //    bool ad = _sysUser.checkUserExist_admin(txtUserNam.Text);
            //    if (ad == false)
            //    {
            //        MessageBox.Show("Tên Đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //    if (admin.PASS.Equals(txtPass.Text.Trim()))
            //    {
            //        using (USERMANAGEMENT.frmMainAdmin frm = new USERMANAGEMENT.frmMainAdmin())
            //        { 
            //            this.Hide();
            //            frm.ShowDialog();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Sai mật khẩu vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}
            bool us = _sysUser.checkUserExist(_sysparam.macty, _sysparam.madvi, txtUserNam.Text);
            if (us == false)
            {
                MessageBox.Show("Tên Đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string pass = Encryptor.Encrypt(txtPass.Text, "qwert@123!poiuy", true);
            _user = _sysUser.getItem(txtUserNam.Text, _sysparam.macty, _sysparam.madvi);
            if (_user.DISABLED == true)
            {
                MessageBox.Show("Thông báo tài khoản bị vô hiệu hóa vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Thread.Sleep(7000);
            }
            if (_user.PASSWD.Equals(pass))
            {
                //using (frmLoading frm = new frmLoading(_user))
                //{
                //    this.Hide();
                //    frm.ShowDialog();
                //}
                using (frmMain frm = new frmMain(_user))
                {
                    this.Hide();
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Sai mật khẩu vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.0)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                timer1.Stop();
                this.Hide();
                frmMain frm = new frmMain(_user);
                frm.ShowDialog();
            }
        }



        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserNam_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}