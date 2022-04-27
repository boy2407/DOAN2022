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
using DevExpress.XtraScheduler;
using System.Data.SqlClient;

namespace KHACHSAN
{
    public partial class frmBooking : DevExpress.XtraEditors.XtraForm
    {
        public frmBooking()
        {
            InitializeComponent();
      
        }
        bool _them, _GiamSoPhong;
        public bool _thanhtoan;
        DATPHONG _datphong;
        DATPHONG_CT _datphong_ct;
        DATPHONG_SP _datphong_sp;
        KHACHHANG _khachhang;
        SANPHAM _sanpham;
        PHONG _phong;
        
        int _idPhong = 0;
        string _tenPhong;
        public int _idDP = 0;
        int _rowDatPhong = 0;
        //SYS_PARAM _param;
        string _madvi;
        string _macty;
        Double _tongtien = 0;

        private void frmBooking_Load(object sender, EventArgs e)
        {
            _datphong = new DATPHONG();
            _datphong_ct = new DATPHONG_CT();
            _datphong_sp = new DATPHONG_SP();
            _phong = new PHONG();
            _khachhang = new KHACHHANG();
            dtNgayDat.Value = DateTime.Now;
            dtNgayTra.Value = DateTime.Now.AddDays(1);
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
            cboKhachHang.Enabled = t;
            btnAddNew.Enabled = t;
            dtNgayDat.Enabled = t;
            dtNgayTra.Enabled = t;
            cboTrangThai.Enabled = t;

            spSoNguoi.Enabled = t;
            txtGhiChu.Enabled = t;
            gcDatPhong.Enabled = t;
            gcPhong.Enabled = t;
          
        }
        void loadphong()
        {
            _phong = new PHONG();
            gcPhong.DataSource = _phong.getAll_AnyVacancies(dtNgayDat.Value, dtNgayTra.Value);
            MessageBox.Show("cps");
        }    
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            _idDP = 0;
                    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_idDP == 0)
            {

                MessageBox.Show("Vui long chọn Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (_idDP != 0 && _datphong.GetItem(_idDP).STATUS.Equals(true))
            {
                _idDP = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDDP").ToString());
                var dp = _datphong.GetItem(_idDP);
                cboKhachHang.SelectedValue = dp.IDKH;
                dtNgayDat.Value = dp.NGAYDAT.Value;
                dtNgayTra.Value = dp.NGAYTRA.Value;
                txtGhiChu.Text = dp.GHICHU.ToString();
                cboTrangThai.SelectedValue = dp.STATUS;
                spSoNguoi.Text = dp.SONGUOIO.ToString();
              
            }
            else
            {
                _enabled(true);
                _them = false;
                showHideControl(false);
              
                // loadphongByNgayDat(DateTime.Now);
                if (DateTime.Now > _datphong.GetItem(_idDP).NGAYTRA)
                {
                    MessageBox.Show("Không được thêm xóa phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //gcDatPhong.Enabled = false;
                    gcPhong.Enabled = false;

                }
               
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_idDP == 0)
            {

                MessageBox.Show("Vui long chọn Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _datphong.delete(_idDP);
                var lstDPCT = _datphong_ct.getAllByDatPhong(_idDP);
                foreach (var item in lstDPCT)
                {
                    _phong.updateStatus(item.IDPHONG, false);
                }
               
              
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

        }

        private void dtNgayDat_Leave(object sender, EventArgs e)
        {
            if (dtNgayDat.Value > dtNgayTra.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayDat.Value = DateTime.Now;
                dtNgayTra.Value = DateTime.Now.AddDays(1);
                return;
            }
            loadphong();
        }

        private void dtNgayTra_Leave(object sender, EventArgs e)
        {
        //    if (dtNgayDat.Value > dtNgayTra.Value)
        //    {
        //        MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        dtNgayDat.Value = DateTime.Now;
        //        dtNgayTra.Value = DateTime.Now.AddDays(1);
        //        return;
        //    }
        //    loadphong();
        }

        private void dtNgayDat_ValueChanged(object sender, EventArgs e)
        {
            //if (dtNgayDat.Value > dtNgayTra.Value )
            //{
            //    MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dtNgayDat.Value = DateTime.Now;
            //    dtNgayTra.Value = DateTime.Now.AddDays(1);
            //    return;
            //}
            //loadphong();
        }

        private void dtNgayTra_ValueChanged(object sender, EventArgs e)
        {
            //if (dtNgayDat.Value > dtNgayTra.Value )
            //{
            //    MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    dtNgayDat.Value = DateTime.Now;
            //    dtNgayTra.Value = DateTime.Now.AddDays(1);
            //    return;
            //}
            //loadphong();
        }

     
        

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}