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
using System.Text.RegularExpressions;

namespace KHACHSAN
{
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
            DataTable datatbl = Friend.laydulieu("select HOTEN ,IDKH,DIACHI,EMAIL,DIENTHOAI,CCCD,GIOITINH=(case GIOITINH when 'true' then N'Nam' when 'false' then N'Nữ' end) from tb_KhachHang");
            gcDanhSach.DataSource = datatbl;
        }
        public frmKhachHang(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
        tb_SYS_USER _user;
        int _right;

        //Có thể truy cấp đến frmdatphong kieu pubilc
        frmDatPhong objDP = (frmDatPhong)Application.OpenForms["frmDatPhong"];
        frmDatPhongDon objDPdon = (frmDatPhongDon)Application.OpenForms["frmDatPhongDon"];
        KHACHHANG _khachhang;
        bool _them;
        public string kh_dp;
        string _idkh;
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            _khachhang = new KHACHHANG();
            showHideControl(true);
            loadData();
            _enabled(false);
          

        }

        public bool IsVaildCCCD(string cccd)
        {
            int length = cccd.Length;
            
            if (length == 9 || length == 12)
            {
                return true;
            }           
            return false;
        }
        public bool IsValidEmail(string email)
        {

            if (string.IsNullOrEmpty(email))
                return true;

            string sMailPattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            return Regex.IsMatch(email.Trim(), sMailPattern);

        }
        public bool IsValidVietNamPhoneNumber(string phoneNum)
        {

            if (string.IsNullOrEmpty(phoneNum))
                return true;

            string sMailPattern = @"^((09(\d){8})|(086(\d){7})|(088(\d){7})|(089(\d){7})|(01(\d){9}))$";
            return Regex.IsMatch(phoneNum.Trim(), sMailPattern);
        }
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }
        void _enabled(bool t)
        {
            txtDiaChi.Enabled = t;
            txtDienThoai.Enabled = t;
            txtEmail.Enabled = t;           
            txtTen.Enabled = t;
            txtCCCD.Enabled = t;
           
        }
        void _reset()
        {
            txtDiaChi.Text = "";          
            txtTen.Text = "";
            txtCCCD.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";

         
        }
       
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
            gcDanhSach.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_right ==1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _them = false;
            showHideControl(false);
            _enabled(true);
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_right == 1 )
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var kh = _khachhang.getItem(int.Parse(_idkh));
                if(kh.DISABLED==true)
                {
                    MessageBox.Show("Khách hàng đã bị xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }    
                kh.DISABLED = true;
                _khachhang.update(kh);
            }
            loadData();
        }
        void savedata()
        {
            
           
            if (_them)
            {
                if (_khachhang.checkCCCD(txtCCCD.Text))
                {
                    MessageBox.Show("CCCD/CMND đã bị trùng xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }
                if (_khachhang.checkSTD(txtDienThoai.Text))
                {
                    MessageBox.Show("Số điện thoại đã bị trùng xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }
                tb_KhachHang _kh = new tb_KhachHang();
                _kh.CCCD = txtCCCD.Text;
                _kh.DIACHI = txtDiaChi.Text;
                _kh.DIENTHOAI = txtDienThoai.Text;
                _kh.EMAIL = txtEmail.Text;
                _kh.HOTEN = txtTen.Text;
                _kh.GIOITINH = chkGioiTinh.Checked;
                _kh.DISABLED = false;
                _khachhang.add(_kh);
            }
            else
            {
               
                tb_KhachHang _kh = _khachhang.getItem(int.Parse(_idkh));
                if (_khachhang.checkCCCD_sua(txtCCCD.Text,_kh))
                {
                    MessageBox.Show("CCCD/CMND đã bị trùng xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }
                if (_khachhang.checkSTD_sua(txtDienThoai.Text,_kh))
                {
                    MessageBox.Show("Số điện thoại đã bị trùng xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }
                _kh.CCCD = txtCCCD.Text;
                _kh.DIACHI = txtDiaChi.Text;
                _kh.DIENTHOAI = txtDienThoai.Text;
                _kh.EMAIL = txtEmail.Text;
                _kh.HOTEN = txtTen.Text;
                _kh.GIOITINH = chkGioiTinh.Checked;
                _kh.DISABLED = checkDisable.Checked;
                _khachhang.update(_kh);
            }
          
        }    
        private void btnLuu_Click(object sender, EventArgs e)
        {
            //if (!IsVaildCCCD(txtCCCD.Text))
            //{
            //    MessageBox.Show("CCCD/CMND không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCCCD.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (!IsValidEmail(txtEmail.Text))
            //{
            //    MessageBox.Show("E-mail không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtEmail.Focus();
            //    return;
            //}

            //if (!IsValidVietNamPhoneNumber(txtDienThoai.Text))
            //{
            //    MessageBox.Show("Số điện thoại của bạn không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtDienThoai.Focus();
            //    return;
            //}
            //if (_khachhang.checkSTD(txtDienThoai.Text))
            //{
            //    MessageBox.Show("Số điện thoại đã bị trùng xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCCCD.Focus();
            //    return;
            //}
            if (_them)
            {
                if (!IsVaildCCCD(txtCCCD.Text))
                {
                    MessageBox.Show("CCCD/CMND không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTen.Text) || string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("E-mail không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (!IsValidVietNamPhoneNumber(txtDienThoai.Text))
                {
                    MessageBox.Show("Số điện thoại của bạn không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDienThoai.Focus();
                    return;
                }
                if (_khachhang.checkSTD(txtDienThoai.Text))
                {
                    MessageBox.Show("Số điện thoại đã bị trùng xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }
            }
            savedata();
            loadData();
            showHideControl(true);
            _enabled(false);
            gcDanhSach.Enabled = true;
            _them = false;
        }
        void loadData()
        {
             _khachhang = new KHACHHANG();           
             gcDanhSach.DataSource = _khachhang.getAll();             
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            showHideControl(true);      
            _enabled(false);
            gcDanhSach.Enabled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _idkh = gvDanhSach.GetFocusedRowCellValue("IDKH").ToString();                 
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("HOTEN").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL").ToString();
                txtCCCD.Text = gvDanhSach.GetFocusedRowCellValue("CCCD").ToString();
                chkGioiTinh.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("GIOITINH").ToString());
                checkDisable.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
            }
        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if(gvDanhSach.GetFocusedRowCellValue("IDKH")!=null&&(objDP!=null||objDPdon!=null))
            {
                
                if(kh_dp== "datphongdon")
                {
                    objDPdon.loadKH();
                    objDPdon.setKH(int.Parse(gvDanhSach.GetFocusedRowCellValue("IDKH").ToString()));
                }    
                else
                {
                    objDP.loadKH();
                    objDP.setKhachHang(int.Parse(gvDanhSach.GetFocusedRowCellValue("IDKH").ToString()));
                }            
                this.Close();
            }    
        }

    

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {                               
            if ((Keys)e.KeyChar==Keys.Enter)
            {
                savedata();
                loadData();
                showHideControl(true);
                _enabled(false);
                gcDanhSach.Enabled = true;
                _them = false;
            }    
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                savedata();
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                savedata();
            }
        }

       
    }
}