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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Reflection;

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
        GridHitInfo downhitInfo = null;
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
            gvDatPhong.ExpandAllGroups();
            loadKH();
            loadphong();
        }
        void _reset()
        {

            chkTheoDoan.Checked = true;
            dtNgayDat.Value = DateTime.Now;
            dtNgayTra.Value = DateTime.Now.AddDays(1);
            cboTrangThai.SelectedValue = false;
            txtGhiChu.Text = "";
            spSoNguoi.Text = "1";
 
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
            DataTable table = new DataTable();
            table = Friend.ConvertToDataTable(_phong.getAll_Vacancies(dtNgayDat.Value, dtNgayTra.Value));
            gcPhong.DataSource = table;
            gcDatPhong.DataSource = table.Clone();
            gvPhong.ExpandAllGroups();
        }
        void saveData()
        {
            if (gvDatPhong.RowCount < 0)
            {

                if (MessageBox.Show("Danh sách phòng đặt đang trống bạn có muốn tiếp tục", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                }
                else
                    return;

            }

            if (_them)
            {
                tb_DatPhong dp = new tb_DatPhong();
                tb_DatPhong_CT dpct;
                tb_DatPhong_SP dpsp;

                dp.NGAYDAT = dtNgayDat.Value;
                dp.NGAYTRA = dtNgayTra.Value;
                dp.SONGUOIO = int.Parse(spSoNguoi.EditValue.ToString());
                dp.STATUS = bool.Parse(cboTrangThai.SelectedValue.ToString());
                dp.THEODOAN = chkTheoDoan.Checked;
                dp.IDKH = int.Parse(cboKhachHang.SelectedValue.ToString());
                dp.SOTIEN = double.Parse(txtThanhTien.Text);
                dp.GHICHU = txtGhiChu.Text;
                dp.UID = 1;
                dp.DISABLED = false;
                dp.CREATED_DATE = DateTime.Now;
                dp.MACTY = _macty;
                dp.MADVI = _madvi;

                var _dp = _datphong.add(dp);
                _idDP = _dp.IDDP;
               
            }
            else if (_them == false)
            {

                tb_DatPhong dp = _datphong.GetItem(_idDP);
                tb_DatPhong_CT dpct;
                tb_DatPhong_SP dpsp;

                dp.NGAYDAT = dtNgayDat.Value;
                dp.NGAYTRA = dtNgayTra.Value;
                dp.SONGUOIO = int.Parse(spSoNguoi.EditValue.ToString());
                dp.STATUS = bool.Parse(cboTrangThai.SelectedValue.ToString());
                dp.IDKH = int.Parse(cboKhachHang.SelectedValue.ToString());
                dp.SOTIEN = double.Parse(txtThanhTien.Text);
                dp.GHICHU = txtGhiChu.Text;
                dp.UID = 1;
                dp.UPDATE_BY = 1;
                dp.UPDATE_DATE = DateTime.Now;
                var _dp = _datphong.update(dp);

                _datphong_ct.deleteAll(_idDP);
                
                for (int i = 0; i < gvDatPhong.RowCount; i++)
                {
                    dpct = new tb_DatPhong_CT();
                    dpct.IDDP = _dp.IDDP;
                    dpct.IDPHONG = int.Parse(gvDatPhong.GetRowCellValue(i, "IDPHONG").ToString());
                    TimeSpan s = dtNgayTra.Value - dtNgayDat.Value;
                    dpct.SONGAYO = s.Days;
                    dpct.DONGIA = double.Parse(gvDatPhong.GetRowCellValue(i, "DONGIA").ToString());
                    dpct.THANHTIEN = dpct.SONGAYO * dpct.DONGIA;
                    dpct.NGAY = DateTime.Now;

                    var _dpct = _datphong_ct.add(dpct);
                   
                   
                }

            }

        }
        //========================================================

        //Sự Kiện Di Chuyển Chuột Ở GridView DatPhong
        private void gvDatPhong_MouseDown(object sender, MouseEventArgs e)
        {

            DevExpress.XtraGrid.Views.Grid.GridView view = sender as GridView; //hiển thị data vào dưới dạng lưới
            downhitInfo = null;                // các dòng được lưu sẽ về null      GridHitInfo downhitinfo = null -> lưu các dòng khi mình nhấn chuột 
            GridHitInfo hitinfo = view.CalcHitInfo(new Point(e.X, e.Y)); // tạo điểm lưu mới ở vị trí nhấp chuột hiện tại
            if (Control.ModifierKeys != Keys.None) return;               //nếu các phím CTRL SHIFT ALT được ấn thì sẽ trả kết quả
            if (e.Button == MouseButtons.Left && hitinfo.RowHandle >= 0)  //nếu ấn chuột trái và lấy hoặc đặt tay cầm của hàng nằm dưới điểm kiểm tra nhiều hơn 0 thì lưu điểm
            {
                downhitInfo = hitinfo;
            }

        }

        private void gvDatPhong_Click(object sender, EventArgs e)
        {
            if (gvDatPhong.GetFocusedRowCellValue("IDPHONG") != null)
            {
                _idPhong = int.Parse(gvDatPhong.GetFocusedRowCellValue("IDPHONG").ToString());
                _tenPhong = gvDatPhong.GetFocusedRowCellValue("TENPHONG").ToString();
            }
        }

        private void gvDatPhong_MouseMove(object sender, MouseEventArgs e)
        {
            if (gvDatPhong.GetFocusedRowCellValue("IDPHONG") != null)
            {
                _GiamSoPhong = true;
                _idPhong = int.Parse(gvDatPhong.GetFocusedRowCellValue("IDPHONG").ToString());
                _tenPhong = gvDatPhong.GetFocusedRowCellValue("TENPHONG").ToString();
            }

            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downhitInfo != null)  //nếu ấn chuột trái và lấy hoặc đặt tay cầm của hàng nằm dưới điểm kiểm tra không có gì thì lưu điểm
            {
                Size dragsize = SystemInformation.DragSize;
                Rectangle dragrect = new Rectangle(new Point(downhitInfo.HitPoint.X - dragsize.Width / 2, downhitInfo.HitPoint.Y - dragsize.Height / 2), dragsize); //khởi tạo một phiên bản mới của lớp hình chữ nhật với vị trí và kích thước cụ thể. một kích thước đại diện cho chiều rộng và chiều cao của vùng hình chữ nhật
                if (!dragrect.Contains(new Point(e.X, e.Y))) //khác hình chữ nhật
                {
                    DataRow row = view.GetDataRow(downhitInfo.RowHandle);
                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                    downhitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }
        //========================================================
        //Sự Kiện Di Chuyển Chuột Ở GridView Phong
        private void gvPhong_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downhitInfo != null)  //nếu ấn chuột trái và lấy hoặc đặt tay cầm của hàng nằm dưới điểm kiểm tra không có gì thì lưu điểm
            {
                Size dragsize = SystemInformation.DragSize;
                Rectangle dragrect = new Rectangle(new Point(downhitInfo.HitPoint.X - dragsize.Width / 2,
                    downhitInfo.HitPoint.Y - dragsize.Height / 2), dragsize); //khởi tạo một phiên bản mới của lớp hình chữ nhật với vị trí và kích thước cụ thể. một kích thước đại diện cho chiều rộng và chiều cao của vùng hình chữ nhật
                if (!dragrect.Contains(new Point(e.X, e.Y))) //khác hình chữ nhật
                {
                    DataRow row = view.GetDataRow(downhitInfo.RowHandle);
                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                    downhitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void gvPhong_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView; //hiển thị data vào dưới dạng lưới
            downhitInfo = null;                // các dòng được lưu sẽ về null      GridHitInfo downhitinfo = null -> lưu các dòng khi mình nhấn chuột 
            GridHitInfo hitinfo = view.CalcHitInfo(new Point(e.X, e.Y)); // tạo điểm lưu mới ở vị trí nhấp chuột hiện tại
            if (Control.ModifierKeys != Keys.None) return;               //nếu các phím CTRL SHIFT ALT được ấn thì sẽ trả kết quả
            if (e.Button == MouseButtons.Left && hitinfo.RowHandle >= 0)  //nếu ấn chuột trái và lấy hoặc đặt tay cầm của hàng nằm dưới điểm kiểm tra nhiều hơn 0 thì lưu điểm
            {
                downhitInfo = hitinfo;
            }
        }
        //========================================================

        //Sự Kiện Kéo Thả Giữa 2 Vùng GridView
        private void gcPhong_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl; //hiển thị data vào dưới dạng lưới
            DataTable table = grid.DataSource as DataTable;
            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            if (row != null && table != null && row.Table != table)
            {
                table.ImportRow(row);
                row.Delete();
            }
        }

        private void gcPhong_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            _idDP = 0;
            _reset();
           _enabled(true);
            showHideControl(false);
    
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

        void loadKH()
        {
            _khachhang = new KHACHHANG();
            cboKhachHang.DataSource = _khachhang.getAll();
            cboKhachHang.DisplayMember = "HOTEN";
            cboKhachHang.ValueMember = "IDKH";
        }

        private void dtNgayTra_Leave(object sender, EventArgs e)
        {
            if (dtNgayDat.Value > dtNgayTra.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayTra.Value = dtNgayDat.Value.AddDays(1);
                return;
            }
            loadphong();
        }

       
        private void dtNgayTra_ValueChanged(object sender, EventArgs e)
        {
            if (dtNgayDat.Value > dtNgayTra.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayTra.Value = dtNgayDat.Value.AddDays(1);
                return;
            }
            loadphong();
        }
           
        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}