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

namespace USERMANAGEMENT
{
    public partial class frmLogin_admin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin_admin()
        {
            InitializeComponent();
           
        }
        
        SYS_USER _sysUser;
 
        tb_SYS_USER _user;
        private void frmLogin_Load(object sender, EventArgs e)
        {
            _sysUser = new SYS_USER();
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

           
            bool us = _sysUser.checkUserExist("~", "~", txtUserNam.Text);
            if (us == false)
            {
                MessageBox.Show("Tên Đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string pass = Encryptor.Encrypt(txtPass.Text, "qwert@123!poiuy", true);
            _user = _sysUser.getItem(txtUserNam.Text,"~", "~");
            if (_user.PASSWD.Equals(pass))
            {
                using (frmChon frm = new frmChon(_user))
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
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void txtUserNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                login();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}