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
    public partial class frmDonVi : DevExpress.XtraEditors.XtraForm
    {
        public frmDonVi()
        {
            InitializeComponent();
        }
        DONVI _donvi;
        CONGTY _congty;
        bool _them;
        string _madvi;
        private void frmDonVi_Load(object sender, EventArgs e)
        {
            _donvi = new DONVI();
            _congty = new CONGTY();

            loadCongty();
            showHideControl(true);
            txtMa.Enabled = false;
            _enabled(false);
             loadData();

           loadDviByCty();           
           cboCty.SelectedIndexChanged += CboCty_SelectedIndexChanged;

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
        private void CboCty_SelectedIndexChanged(object sender, EventArgs e)
        {
           loadDviByCty();
        }

        void loadData()
        {
            gcDanhSach.DataSource = _donvi.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;

        }
        void loadDviByCty()
        {
            gcDanhSach.DataSource = _donvi.getAll(cboCty.SelectedValue.ToString());
            gvDanhSach.OptionsBehavior.Editable = false;

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
            txtFax.Enabled = t;
            txtTen.Enabled = t;
            chkDisabled.Enabled = t;
        }
        void _reset()
        {
            txtDiaChi.Text = "";
            txtMa.Text = "";
            txtTen.Text = "";
            txtFax.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
           
            chkDisabled.Checked = false;
        }
        void loadCongty()
        {
            cboCty.DataSource = _congty.getAll();
            cboCty.DisplayMember = "TENCTY";
            cboCty.ValueMember = "MACTY";
        }    

        private void btnThem_Click(object sender, EventArgs e)
        {
          
            showHideControl(false);
            _them = true;
            _enabled(true);
            _reset();
            txtMa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _enabled(true);
            _them = false;
            showHideControl(false);
            txtMa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _donvi.delete(_madvi);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("E-mail không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!IsValidVietNamPhoneNumber(txtDienThoai.Text))
            {
                MessageBox.Show("Số điện thoại của bạn không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_them == true)
            {
                

                tb_DonVi dvi = new tb_DonVi();
                dvi.MADVI = txtMa.Text;
                dvi.MACTY = cboCty.SelectedValue.ToString();
                dvi.TENDVI = txtTen.Text;
                dvi.DIACHI = txtDiaChi.Text;
                dvi.FAX = txtFax.Text;
                dvi.EMAIL = txtEmail.Text;
                dvi.DIENTHOAI = txtDienThoai.Text;
                dvi.DISABLED = chkDisabled.Checked;
                _donvi.add(dvi);
            }
            else
            {
                tb_DonVi dvi = _donvi.getItem(_madvi);
                dvi.MACTY = cboCty.SelectedValue.ToString();
                dvi.TENDVI = txtTen.Text;
                dvi.DIACHI = txtDiaChi.Text;
                dvi.EMAIL = txtEmail.Text;
                dvi.FAX = txtFax.Text;
                dvi.DIENTHOAI = txtDienThoai.Text;
                dvi.DISABLED = chkDisabled.Checked;
                _donvi.update(dvi);
            }
            loadDviByCty();
            _them = false;
            _enabled(false);
            txtMa.Enabled = false;
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enabled(false);
            txtMa.Enabled = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DISABLED" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.delete_icon;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {

                _madvi = gvDanhSach.GetFocusedRowCellValue("MADVI").ToString();

                cboCty.SelectedValue = gvDanhSach.GetFocusedRowCellValue("MACTY").ToString();

                
                txtMa.Text = gvDanhSach.GetFocusedRowCellValue("MADVI").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENDVI").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL").ToString();
                txtFax.Text = gvDanhSach.GetFocusedRowCellValue("FAX").ToString();

                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());

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
        }
    }
}