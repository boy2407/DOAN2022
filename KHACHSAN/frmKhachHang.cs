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
                _khachhang.delete(int.Parse(_idkh));
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(_them)
            {
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
                tb_KhachHang _kh = _khachhang.getItem(int.Parse(_idkh));
                _kh.CCCD = txtCCCD.Text;
                _kh.DIACHI = txtDiaChi.Text;
                _kh.DIENTHOAI = txtDienThoai.Text;
                _kh.EMAIL = txtEmail.Text;
                _kh.HOTEN = txtTen.Text;
                _kh.GIOITINH = chkGioiTinh.Checked;
                _khachhang.update(_kh);

            }
            loadData();
            showHideControl(true);
            _enabled(false);
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

        
    }
}