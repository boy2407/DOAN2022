using BusinessLayer;
using DataLayer;
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
namespace USERMANAGEMENT
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        public frmUser()
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
        SYS_GROUP _sysGroup;
        tb_SYS_USER _user;
        VIEW_USER_IN_GROUP _vUserInGroup;
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
       

        private void frmUser_Load(object sender, EventArgs e)
        {
            _sysGroup = new SYS_GROUP();
            _sysUser = new SYS_USER();

            if (!_them)
            {
                var user = _sysUser.getItem(_idUser);
                
                txtUsernam.Text = user.USERNAME;
                txtUsernam.ReadOnly = true;
                txtHoTen.Text = user.FULLNAME;
                _macty = user.MACTY;
                _madvi = user.MADVI;
                chkVoHieuHoa.Checked = user.DISABLED.Value;
                txtPass.Text = Encryptor.Decrypt(user.PASSWD, "qwert@123!poiuy", true);
                txtRepass.Text = Encryptor.Decrypt(user.PASSWD, "qwert@123!poiuy", true);
                loadGroupByUser(_idUser);
                xtraTabPage2.PageVisible = true;
     
                          
            }
            else
            {
                txtHoTen.Text = "";
                txtPass.Text = "";
                txtRepass.Text = "";
                chkVoHieuHoa.Checked = false;
                xtraTabPage2.PageVisible = false;
            }
           
        }
        public bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;

            return input.ToCharArray().Any(c => c > MaxAnsiCode);
        }
        void saveData()
        {
            if (ContainsUnicodeCharacter(txtUsernam.Text))
            {
                MessageBox.Show("Tên người dùng không được có dấu vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsernam.SelectAll();
                txtUsernam.Focus();
                return;
            }
            if (_them)
            {
                bool checkUser = _sysUser.checkUserExist(_macty, _madvi, txtUsernam.Text.Trim());
                if (checkUser)
                {
                    MessageBox.Show("Tên người đã tồn tại.Vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsernam.SelectAll();
                    txtUsernam.Focus();
                    return;
                }
                _user = new tb_SYS_USER();
                _user.USERNAME = txtUsernam.Text.Trim();
                _user.FULLNAME = txtHoTen.Text;
                _user.ISGROUP = false;
                _user.DISABLED = false;
                _user.MACTY = _macty;
                _user.MADVI = _madvi;
                _user.PASSWD = Encryptor.Encrypt(txtPass.Text.Trim(),"qwert@123!poiuy",true);
                _sysUser.add(_user);

            }
            else
            {
                _user = _sysUser.getItem(_idUser);         
                _user.FULLNAME = txtHoTen.Text;
                _user.ISGROUP = false;
                _user.DISABLED = chkVoHieuHoa.Checked;
                _user.MACTY = _macty;
                _user.MADVI = _madvi;
                _user.PASSWD = Encryptor.Encrypt(txtPass.Text.Trim(), "qwert@123!poiuy",true);
                _sysUser.update(_user);

            }
            objMain.loadUser(_macty, _madvi);
        }
        public void loadGroupByUser(int idUser)
        {
            _vUserInGroup = new VIEW_USER_IN_GROUP();
            gcThanhVien.DataSource = _vUserInGroup.getGroupByUser(_macty, _madvi, idUser);
            gvThanhVien.OptionsBehavior.Editable = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtUsernam.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên người dùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsernam.SelectAll();
                txtUsernam.Focus();
                return;
            }
            if(txtRepass.Text!=txtPass.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khắp. Vui lòng nhập lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsernam.SelectAll();
                txtUsernam.Focus();
                return;
            }  
            if(txtHoTen.Text==""||txtUsernam.Text==""||txtPass.Text==""||txtRepass.Text=="")
            {
                MessageBox.Show(" Vui lòng nhập nhập đầy đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsernam.SelectAll();
                txtUsernam.Focus();
                return;
            }    
            saveData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmShowGroup frm = new frmShowGroup();
            frm._idUser = _idUser;
            frm._macty = _macty;
            frm._madvi = _madvi;
            frm.ShowDialog();

        }

        private void btnBo_Click(object sender, EventArgs e)
        {
            if(gvThanhVien.RowCount>0)
            {
                _sysGroup.delGroup(_idUser, int.Parse(gvThanhVien.GetFocusedRowCellValue("IDUSER").ToString()));
                loadGroupByUser(_idUser);
            }    
            else
            {
                MessageBox.Show("Hiện tại User không có nhóm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
            
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }
    }
}