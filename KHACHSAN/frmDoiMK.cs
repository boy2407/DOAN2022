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
using BusinessLayer;
using DataLayer;
namespace KHACHSAN
{
    public partial class frmDoiMK : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMK()
        {
            InitializeComponent();
        }
        public frmDoiMK(tb_SYS_USER user)
        {
            this._user = user;
            InitializeComponent();
        }
        SYS_USER _sysUser; 
        tb_SYS_USER _user;
        private void frmDoiMK_Load(object sender, EventArgs e)
        {
            string pass = Encryptor.Decrypt(_user.PASSWD, "qwert@123!poiuy", true);
            _sysUser = new SYS_USER();
            txtUsername.Enabled = false;
            txtUsername.Text = _user.USERNAME;
            txtHoTen.Text = _user.FULLNAME;
            txtPass.Text = pass;
            txtRepass.Text = pass;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            saveData();
        }

        public bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;

            return input.ToCharArray().Any(c => c > MaxAnsiCode);
        }
        void saveData()
        {
            if (txtRepass.Text != txtPass.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khắp. Vui lòng nhập lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.SelectAll();
                txtUsername.Focus();
                return;
            }
            if (txtHoTen.Text == "" || txtPass.Text == "" || txtRepass.Text == "")
            {
                MessageBox.Show(" Vui lòng nhập nhập đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.SelectAll();
                txtUsername.Focus();
                return;
            }
            if (ContainsUnicodeCharacter(txtUsername.Text))
            {
                MessageBox.Show("Tên người dùng không được có dấu vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.SelectAll();
                txtUsername.Focus();
                return;
            }
                _user.FULLNAME = txtHoTen.Text;
                _user.PASSWD = Encryptor.Encrypt(txtPass.Text.Trim(), "qwert@123!poiuy", true);
                _sysUser.update(_user);
                 MessageBox.Show("Thay đổi thành công", "Thông Báo");
                 this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRepass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Keys)e.KeyChar == Keys.Enter)
            {
                saveData();
            }    
               
        }
    }
}