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
        bool _them;
        THIETBI _thietbi;
        string _idtb;
        private void frmThietBi_Load(object sender, EventArgs e)
        {
            _thietbi = new THIETBI();
            txtMa.Enabled = false;
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
            txtDonGia.Enabled = t;
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _thietbi.getALL();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            showHideControl(false);
            txtTen.Text = "";
            txtMa.Text = "";
            txtDonGia.Text = "";
            _enabled(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(false);
            _enabled(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _thietbi.delete(int.Parse(_idtb));
            }
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_ThietBi tb = new tb_ThietBi();
                tb.TENTB = txtTen.Text;
                tb.DONGIA = double.Parse(txtDonGia.Text);
                _thietbi.add(tb);
            }
            else
            {
                tb_ThietBi tb = _thietbi.getItem(int.Parse(_idtb));
                tb.TENTB = txtTen.Text;
                tb.DONGIA = double.Parse(txtDonGia.Text);
                _thietbi.update(tb);
            }
            LoadData();
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

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _idtb = gvDanhSach.GetFocusedRowCellValue("IDTB").ToString();
                txtMa.Text = gvDanhSach.GetFocusedRowCellValue("IDTB").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENTB").ToString();
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();

            }
        }
    }
}