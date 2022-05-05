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
            MessageBox.Show(length.ToString());
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
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
            gcDanhSach.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(false);
            _enabled(true);
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tb_KhachHang kh = _khachhang.getItem(int.Parse(_idkh));
                kh.DISABLED = true;
                _khachhang.update(kh);
            }
            loadData();
        }
        void savedata()
        {
            if (!IsVaildCCCD(txtCCCD.Text))
            {
                MessageBox.Show("CCCD/CMND không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }
            if(string.IsNullOrEmpty(txtTen.Text)|| string.IsNullOrEmpty(txtDiaChi.Text))
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
            if (_them)
            {
                if (_khachhang.checkCCCD(txtCCCD.Text))
                {
                    MessageBox.Show("CCCD/CMND đã bị trùng xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                _khachhang.add(_kh);
            }
            else
            {
                if (_khachhang.checkCCCD(txtCCCD.Text))
                {
                    MessageBox.Show("CCCD/CMND đã bị trùng xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }
                tb_KhachHang _kh = _khachhang.getItem(int.Parse(_idkh));
                _kh.CCCD = txtCCCD.Text;
                _kh.DIACHI = txtDiaChi.Text;
                _kh.DIENTHOAI = txtDienThoai.Text;
                _kh.EMAIL = txtEmail.Text;
                _kh.HOTEN = txtTen.Text;
                _kh.GIOITINH = chkGioiTinh.Checked;
                _khachhang.update(_kh);
            }
          
        }    
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!IsVaildCCCD(txtCCCD.Text))
            {
                MessageBox.Show("CCCD/CMND không đúng định dạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
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
            if (_them)
            {
                if (_khachhang.checkCCCD(txtCCCD.Text))
                {
                    MessageBox.Show("CCCD/CMND đã bị trùng xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                _khachhang.add(_kh);
            }
            else
            {
                if (_khachhang.checkCCCD(txtCCCD.Text))
                {
                    MessageBox.Show("CCCD/CMND đã bị trùng xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return;
                }
                tb_KhachHang _kh = _khachhang.getItem(int.Parse(_idkh));
                _kh.CCCD = txtCCCD.Text;
                _kh.DIACHI = txtDiaChi.Text;
                _kh.DIENTHOAI = txtDienThoai.Text;
                _kh.EMAIL = txtEmail.Text;
                _kh.HOTEN = txtTen.Text;
                _kh.GIOITINH = chkGioiTinh.Checked;
                _khachhang.update(_kh);

            }
            //savedata();
            loadData();
            showHideControl(true);
            _enabled(false);
            gcDanhSach.Enabled = true;
            _them = false;
        }
        void loadData()
        {
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

            }
        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if(gvDanhSach.GetFocusedRowCellValue("IDKH")!=null&&(objDP!=null||objDPdon!=null))
            {
                MessageBox.Show("có vào");
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
            if((Keys)e.KeyChar==Keys.Enter)
            {
                savedata();
            }    
        }
    }
}