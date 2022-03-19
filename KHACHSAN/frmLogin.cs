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

namespace KHACHSAN
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
           
        }
        SYS_PARAM _sysparam;
        SYS_USER _sysUser;
         
        private void frmLogin_Load(object sender, EventArgs e)
        {
            _sysUser = new SYS_USER();

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open("sysparam.ini", FileMode.Open, FileAccess.Read);
            _sysparam = (SYS_PARAM)bf.Deserialize(fs);
            fs.Close();
            Friend._macty = _sysparam.macty;
            Friend._madvi = _sysparam.madvi;
            this.Text = _sysparam.macty + " - " + _sysparam.madvi;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            if(txtUserNam.Text.Trim()=="")
            {
                MessageBox.Show("Tên Đăng nhập không để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool us = _sysUser.checkUserExist(_sysparam.macty, _sysparam.madvi, txtUserNam.Text);
            if(us==false)
            {
                MessageBox.Show("Tên Đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string pass = Encryptor.Encrypt(txtPass.Text, "qwert@123!poiuy", true);
            tb_SYS_USER user = _sysUser.getItem(txtUserNam.Text, _sysparam.macty, _sysparam.madvi);
            if(user.PASSWD.Equals(pass))
            {
                frmMain frm = new frmMain(user);
                frm.ShowDialog();
                this.Close();

            }    
            else
            {
                MessageBox.Show("Sai mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (txtUserNam.Text.Trim() == "")
                {
                    MessageBox.Show("Tên Đăng nhập không để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                bool us = _sysUser.checkUserExist(_sysparam.macty, _sysparam.madvi, txtUserNam.Text);
                if (us == false)
                {
                    MessageBox.Show("Tên Đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string pass = Encryptor.Encrypt(txtPass.Text, "qwert@123!poiuy", true);
                tb_SYS_USER user = _sysUser.getItem(txtUserNam.Text, _sysparam.macty, _sysparam.madvi);
                if (user.PASSWD.Equals(pass))
                {
                    frmMain frm = new frmMain(user);
                    frm.ShowDialog();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Sai mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }    
           
        }
    }
}