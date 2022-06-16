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
    public partial class frmThietBi : DevExpress.XtraEditors.XtraForm
    {
        public frmThietBi()
        {
            InitializeComponent();
        }
        public frmThietBi(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
        tb_SYS_USER _user;
        int _right;
        bool _them;
        THIETBI _thietbi;
        string _idtb;
        private void frmThietBi_Load(object sender, EventArgs e)
        {
            string []donvi =
            {
                "Cái",
                "Chiếc",
                "Đôi",
                "Cuốn",
            };
            comboBox1.DataSource = donvi;
            _thietbi = new THIETBI();           
            _enabled(false);
            showHideControl(true);
            LoadData();
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
            txtSoluong.Enabled = t;
            txtDonGia.Enabled = t;
            comboBox1.Enabled = t;
        }
        void LoadData()
        {
            _thietbi = new THIETBI();
            gcDanhSach.DataSource = _thietbi.getALL(Friend._macty,Friend._madvi);
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            gcDanhSach.Enabled = false;
            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _them = true;
            showHideControl(false);
            txtTen.Text = "";           
            txtDonGia.Text = "";
            txtSoluong.Text = "";
            _enabled(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            gcDanhSach.Enabled = false;
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
                _thietbi.delete(int.Parse(_idtb));
            }
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            if (_them)
            {
                tb_ThietBi tb = new tb_ThietBi();
                tb.TENTB = txtTen.Text;
                tb.DONGIA = double.Parse(txtDonGia.Text);
                tb.MACTY = Friend._macty;
                tb.MADVI = Friend._madvi;
                tb.TONGSLN = int.Parse(txtSoluong.Text);
                tb.TONGSLX = 0;
                tb.DONVITINH = comboBox1.SelectedValue.ToString();
                _thietbi.add(tb);
            }
            else
            {
                tb_ThietBi tb = _thietbi.getItem(int.Parse(_idtb));
                tb.TENTB = txtTen.Text;
                tb.DONGIA = double.Parse(txtDonGia.Text);
                tb.TONGSLN = int.Parse(txtSoluong.Text);
                tb.DONVITINH = comboBox1.SelectedValue.ToString();
                _thietbi.update(tb);
            }
            LoadData();
            _enabled(false);
            showHideControl(true);
            gcDanhSach.Enabled = true;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(false);
            showHideControl(true);
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
                _idtb = gvDanhSach.GetFocusedRowCellValue("IDTB").ToString();            
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENTB").ToString();
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
                txtSoluong.Text = gvDanhSach.GetFocusedRowCellValue("TONGSLN").ToString();
                
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}