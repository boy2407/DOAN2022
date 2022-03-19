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
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Text.RegularExpressions;

namespace KHACHSAN
{
    public partial class frmCongTy : DevExpress.XtraEditors.XtraForm
    {
        public frmCongTy()
        {
            InitializeComponent();
        }
        public frmCongTy(tb_SYS_USER user,int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
        tb_SYS_USER _user;
        int _right;
        CONGTY _congty;
        bool _them;
        string _macty;
        private void frmCongTy_Load(object sender, EventArgs e)
        {
            _congty = new CONGTY();
            LoadData();
            showHideControl(true);
            _enabled(false);
            txtMa.Enabled = false;
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
        void LoadData()
        {
            gcDanhSach.DataSource = _congty.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {   if(_right==1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            txtMa.Enabled = true;
            showHideControl(false);
            _them = true;     

            _enabled(true);
            _reset();
        
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            txtMa.Enabled = false;
            _enabled(true);
            _them = false;
            showHideControl(false);
        }
    
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                _congty.delete(_macty);
            }
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(_them==true)
            {
                bool var = _congty.checkUserExist(txtMa.Text);
                if(var)
                {
                    MessageBox.Show("Mã Công Ty đã tồn tại .Vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMa.SelectAll();
                    txtMa.Focus();
                    return;
                }    
                tb_CongTy cty = new tb_CongTy();
                cty.MACTY = txtMa.Text;
                cty.TENCTY = txtTen.Text;
                cty.DIACHI = txtDiaChi.Text;
                cty.FAX = txtFax.Text;
                cty.EMAIL = txtEmail.Text;
                cty.DIENTHOAI = txtDienThoai.Text;
                cty.DISABLED = chkDisabled.Checked;
                _congty.add(cty);
            }  
            else
            {
                tb_CongTy cty = _congty.getItem(_macty);
                cty.MACTY = txtMa.Text;
                cty.TENCTY = txtTen.Text;
                cty.DIACHI = txtDiaChi.Text;
                cty.EMAIL = txtEmail.Text;
                cty.FAX = txtFax.Text;
                cty.DIENTHOAI = txtDienThoai.Text;
                cty.DISABLED = chkDisabled.Checked;
                _congty.update(cty);
            }
            LoadData();
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

        
               
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if(gvDanhSach.RowCount>0)
            {
                
                _macty = gvDanhSach.GetFocusedRowCellValue("MACTY").ToString();
                
                txtMa.Text = gvDanhSach.GetFocusedRowCellValue("MACTY").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENCTY").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL").ToString();
                txtFax.Text = gvDanhSach.GetFocusedRowCellValue("FAX").ToString();
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());

            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.Name=="DISABLED"&&bool.Parse(e.CellValue.ToString())==true)
            {
                Image img = Properties.Resources.delete_icon;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }    
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string arr="";
            for (int i = 0; i < gvDanhSach.RowCount; i++)
            {
                if (gvDanhSach.IsRowSelected(i))
                {
                    
                    arr = arr + gvDanhSach.GetRowCellValue(i, "MACTY").ToString()+",";
                    
                }
            }
            try
            {
                Friend.XuatReport("@array", arr, "DM_CONGTY", "Danh mục Công Ty");
            }
            catch (Exception ex)
            {

                throw new Exception ("lỗi in danh sách công ty"+ex.Message);
            }
           
            
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (txtEmail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("E-mail không đúng định dạng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                }
            }
        }
    }
}