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
using System.Text.RegularExpressions;
using KHACHSAN;
namespace USERMANAGEMENT
{
    public partial class frmGroup : DevExpress.XtraEditors.XtraForm
    {
        public frmGroup()
        {
            InitializeComponent();
        }
        public string _macty;
        public string _madvi;
        public bool _them;
        public int _idUser;
        public string _username;
        public string _fullname;
        SYS_USER _sysUser;
        VIEW_USER_IN_GROUP _vInGroup;
        tb_SYS_USER _user;
        frmMainAdmin objMain = (frmMainAdmin)Application.OpenForms["frmMainAdmin"];
        SYS_GROUP _sysgroup;
        private void frmGroup_Load(object sender, EventArgs e)
        {
            _sysgroup = new SYS_GROUP();
             _sysUser = new SYS_USER();
            if(!_them)
            {
                var user = _sysUser.getItem(_idUser);
                txtTenNhom.Text = user.USERNAME;
                txtTenNhom.ReadOnly = true;
                txtMoTa.Text = user.FULLNAME;
                _macty = user.MACTY;
                _madvi = user.MADVI;
                loadUserInGroup(_idUser);
               
            }    
            else
            {
                txtMoTa.Text = "";
                txtTenNhom.Text = "";
                paneThanhVien.PageVisible = false;
            }    
           
        }
        public void loadUserInGroup(int idgroud)
        {
            _vInGroup = new VIEW_USER_IN_GROUP();
            gcThanhVien.DataSource = _vInGroup.getUserInGroup(_macty, _madvi,idgroud);
            gvThanhVien.OptionsBehavior.Editable = false;
        }    
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtTenNhom.Text.Trim()=="")
            {
                MessageBox.Show("Chưa nhập tên nhóm. Tên nhóm nhập không dấu","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhom.SelectAll();
                txtTenNhom.Focus();
                return;
            }
            saveData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void saveData()
        {
            if(ContainsUnicodeCharacter(txtTenNhom.Text))
            {
                MessageBox.Show("Tên nhóm không được có dấu vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhom.SelectAll();
                txtTenNhom.Focus();
                return;
            }    
            if(_them)
            {
               bool checkUser= _sysUser.checkUserExist(_macty,_madvi,txtTenNhom.Text.Trim());
                if(checkUser)
                {
                    MessageBox.Show("Nhóm đã tồn tại.Vui lòng kiểm tra lại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtTenNhom.SelectAll();
                    txtTenNhom.Focus();
                    return;
                }
                _user = new tb_SYS_USER();
                _user.USERNAME = txtTenNhom.Text.Trim();
                _user.FULLNAME = txtMoTa.Text;
                _user.ISGROUP = true;
                _user.DISABLED = false;
                _user.MACTY = _macty;
                _user.MADVI = _madvi;
                _sysUser.add(_user);
              
            }   
            else
            {
                _user = _sysUser.getItem(_idUser);
                _user.FULLNAME = txtMoTa.Text;
                _sysUser.update(_user);
               
            }
            objMain.loadUser(_macty, _madvi);
        }
        public bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;

            return input.ToCharArray().Any(c => c > MaxAnsiCode);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmShowMenbers frm = new frmShowMenbers();
            frm._idGroup = _idUser;
            frm._macty = _macty;
            frm._madvi = _madvi;
            frm.ShowDialog();
        }

        private void btnBo_Click(object sender, EventArgs e)
        {
            if(gvThanhVien.GetFocusedRowCellValue("IDUSER")!=null)
            {
                _sysgroup.delGroup(int.Parse(gvThanhVien.GetFocusedRowCellValue("IDUSER").ToString()), _idUser);
                loadUserInGroup(_idUser);
            }    
        }

        private void btnXoaUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _sysUser.delete(_idUser);
                _sysgroup.delete(_idUser);
                objMain.loadUser(Friend._macty, Friend._madvi);
                this.Close();
            }
            objMain.loadUser(_macty, _madvi);
        }
    }
}