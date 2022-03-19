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
using System.Globalization;
namespace KHACHSAN
{
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        public frmSanPham()
        {
            InitializeComponent();
        }
        bool _them;
        SANPHAM _sanpham;
        string _idsp;
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            _sanpham = new SANPHAM();
            LoadData();
            _enabled(false);
            showHideControl(true);
            txtDonGia.Text = string.Format("{0:#.##0.00}", 12,34);
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
            txtTen.Enabled = t;
            txtDonGia.Enabled = t;
          
        }
        void _reset()
        {                    
            txtTen.Text = "";
            txtDonGia.Text = "";   
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _sanpham.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _enabled(true);
            _them = true;
            _reset();
            showHideControl(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
          
            _enabled(true);
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _sanpham.delete(int.Parse(_idsp));
            }
            LoadData();
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them == true)
            {
                tb_SanPham sp = new tb_SanPham();
                sp.TENSP = txtTen.Text;
                sp.DONGIA = double.Parse(txtDonGia.Text);
                _sanpham.add(sp);
            }
            else
            {
                tb_SanPham sp =_sanpham.getItem(int.Parse(_idsp));
                sp.TENSP = txtTen.Text;
                sp.DONGIA = double.Parse(txtDonGia.Text);
                _sanpham.update(sp);
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
                _idsp = gvDanhSach.GetFocusedRowCellValue("IDSP").ToString();
               
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENSP").ToString();
                txtDonGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
          
            //if (e.Column.Name == "DISABLED" && bool.Parse(e.CellValue.ToString()) == true)
            //{
            //    Image img = Properties.Resources.delete_icon;
            //    e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
            //    e.Handled = true;
            //}
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar)&&(e.KeyChar!='.'))
            {
                e.Handled = true;
            } 
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
           
        }

       

        private void txtDonGia_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}