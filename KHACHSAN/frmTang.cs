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
    public partial class frmTang : DevExpress.XtraEditors.XtraForm
    {
        public frmTang()
        {
            InitializeComponent();
        }
        TANG _tang;
        PHONG _phong;
        bool _them;
        string _idtang;
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        private void frmTang_Load(object sender, EventArgs e)
        {
            _tang = new TANG();
            _phong = new PHONG();
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
        }
        void LoadData()
        {
            gcDanhSach.DataSource = _tang.getALL();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            showHideControl(false);
            txtTen.Text = "";
            txtMa.Text = "";
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
            if(MessageBox.Show("Bạn có chắc chắn xóa không?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                var lsp = _phong.getByTang(int.Parse(_idtang));
                foreach(var item in lsp)
                {
                    if(item.TRANGTHAI==true)
                    {
                        MessageBox.Show("Hiện tại có phòng đang được đặt không được xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }    
                }    
                _tang.delete(int.Parse(_idtang));
            }
            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
            LoadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(_them)
            {
                tb_Tang t = new tb_Tang();
                t.TENTANG = txtTen.Text;
                _tang.add(t);
            }   
            else
            {
                tb_Tang t = _tang.getItem(int.Parse(_idtang));
                t.TENTANG = txtTen.Text;
                _tang.update(t);
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
            if(gvDanhSach.RowCount>0)
            {
                _idtang = gvDanhSach.GetFocusedRowCellValue("IDTANG").ToString();
                txtMa.Text = gvDanhSach.GetFocusedRowCellValue("IDTANG").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENTANG").ToString();
            }    
        }
    }
}