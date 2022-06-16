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
namespace KHACHSAN
{
    public partial class frmLoaiPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
        }
        public frmLoaiPhong(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
        tb_SYS_USER _user;
        int _right;
        bool _them;
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        int _idlp = 0;
        LOAIPHONG _loaiphong;
        PHONG _phong;
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            _phong = new PHONG();
            _loaiphong = new LOAIPHONG();
            
            loadLoaiPhong();
            showHideControl(true);
            _enabled(false);
            
        }
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnLuu.Visible = !t;
            btnThoat.Visible = t;
            btnBoQua.Visible = !t;
        }
        void _enabled(bool t)
        {
            txtTen.Enabled = t;
            txtDonGia.Enabled = t;
            txtSoGiuong.Enabled = t;
            txtSoNguoi.Enabled = t;           
        }
        void loadLoaiPhong()
        {
            gcDanhSach.DataSource = _loaiphong.getAll(Friend._macty, Friend._madvi);
            gvDanhSach.OptionsBehavior.Editable = false;

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
            txtTen.Text = "";          
            txtSoNguoi.Text = "";
            txtSoGiuong.Text = "";
            txtDonGia.Text = "";             
            _enabled(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (_right == 1)
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

            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {           
                if(_phong.checkloaiphong(_idlp))
                {
                    MessageBox.Show("Danh Sách phòng có phòng thuộc loại phòng", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return;
                }    
                _loaiphong.delete(_idlp);
            }       
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_LoaiPhong t = new tb_LoaiPhong();
                t.SOGIUONG = int.Parse(txtSoGiuong.Text);
                t.DONGIA = double.Parse(txtDonGia.Text);
                t.SONGUOI = int.Parse(txtSoNguoi.Text);
                t.TENLOAIPHONG = txtTen.Text;
                t.MACTY = Friend._macty;
                t.MADVI = Friend._madvi;
                _loaiphong.add(t);
            }
            else
            {
                tb_LoaiPhong t = new tb_LoaiPhong();
                t = _loaiphong.getItem(_idlp);
                t.SOGIUONG = int.Parse(txtSoGiuong.Text);
                t.DONGIA = double.Parse(txtDonGia.Text);
                t.SONGUOI = int.Parse(txtSoNguoi.Text);
                t.TENLOAIPHONG = txtTen.Text;
                
                _loaiphong.update(t); ;
            }
            loadLoaiPhong();
            _enabled(false);
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            showHideControl(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void txtSoGiuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _idlp = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDLOAIPHONG").ToString());
               
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENLOAIPHONG").ToString();
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
                txtSoNguoi.Text= gvDanhSach.GetFocusedRowCellValue("SONGUOI").ToString();
                txtSoGiuong.Text= gvDanhSach.GetFocusedRowCellValue("SOGIUONG").ToString();
            }
        }
    }
}