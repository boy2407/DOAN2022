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
   
        PHONG _phong;
        TANG _tang;
        LOAIPHONG _loaiphong;
        GridHitInfo downhitInfo = null;
        List<OBJ_DP_CT> lstDP_CT;
        int _idPhong = 0;
        string _tenPhong;
        public int _idDP = 0;     
        //SYS_PARAM _param;
        string _madvi;
        string _macty;
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];

        private void frmBooking_Load(object sender, EventArgs e)
        {
            
            lstDP_CT = new List<OBJ_DP_CT>();
            _datphong = new DATPHONG();
            _datphong_ct = new DATPHONG_CT();
            _datphong_sp = new DATPHONG_SP();
            _phong = new PHONG();
            _loaiphong = new LOAIPHONG();
            _tang = new TANG();
            _khachhang = new KHACHHANG();
            dtDenNgay.Value = Friend.GetLastDayInMont(DateTime.Now.Year, DateTime.Now.Month);
            dtTuNgay.Value = Friend.GetFirstDayInMont(DateTime.Now.Year, DateTime.Now.Month);   
            dtNgayDat.Value = DateTime.Now.AddDays(1);
            dtNgayTra.Value = DateTime.Now.AddDays(2);
            gvDatPhong.ExpandAllGroups();
            loadDanhSach();
            loadKH();
            loadphong();
            showHideControl(true);
            _enabled(false);
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
            lstDP_CT = new List<OBJ_DP_CT>();           
            DataTable table = new DataTable();
            table = Friend.ConvertToDataTable(_phong.getAll_Vacancies(dtNgayDat.Value, dtNgayTra.Value));
            gcPhong.DataSource = table;
            gcDatPhong.DataSource = table.Clone();
            gvPhong.ExpandAllGroups();
        
        }
        void loadDPCT_id()
        {
            _datphong_ct = new DATPHONG_CT();
            gcDatPhong.DataSource = Friend.ConvertToDataTable(_datphong_ct.getAllDPCT(_idDP));
            lstDP_CT = _datphong_ct.getAllDPCT(_idDP);
            gvPhong.ExpandAllGroups();
        }
        void add_LSTDP_CT()
        {
            if (lstDP_CT.Count > 0)
            {
                foreach (var i in lstDP_CT)
                {
                    if (i.IDPHONG == _idPhong)
                    {
                        return;
                    }
                }
            }
            OBJ_DP_CT p = new OBJ_DP_CT();
            //p.IDPHONG = int.Parse(gvPhong.GetFocusedRowCellValue("IDPHONG").ToString());
            tb_Phong phong = _phong.getItem(_idPhong);
            p.IDPHONG = _idPhong;
            p.TENPHONG = phong.TENPHONG;
            p.IDTANG = phong.IDTANG;
            tb_Tang tang = _tang.getItem(phong.IDTANG);
            p.TENTANG = tang.TENTANG;
            var donggia = _loaiphong.getItem(phong.IDLOAIPHONG);
            p.DONGIA = donggia.DONGIA;
            p.SONGUOI = (int)donggia.SONGUOI;
            p.NGAY = DateTime.Now;
            TimeSpan s = dtNgayTra.Value - dtNgayDat.Value;
            p.SONGAYO = s.Days;           
            p.THANHTIEN = p.DONGIA * p.SONGAYO;
            lstDP_CT.Add(p);
            loadDPCT();
            update_txtThanhTien();
        }
        void subtract_LSTDP_CT(int idphong)
        {
            foreach (var i in lstDP_CT)
            {
                if (i.IDPHONG == idphong)
                {
                    lstDP_CT.Remove(i);
                 
                    //_phong.updateStatus(idphong, false);
                    // _datphong_ct.delete(_idDP, idphong);
                    loadDPCT();
                    update_txtThanhTien();                   
                    return;
                }

            }
        }
        void update_songayo()
        {
            foreach (var item in lstDP_CT)
            {
                TimeSpan s = dtNgayTra.Value - dtNgayDat.Value;
                item.SONGAYO = s.Days;
                if (s.Days < 1)
                {
                    MessageBox.Show("Thông báo", "Ngày trả Không hợp lợi vui lòng nhập lại ngày ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtNgayTra.Value = dtNgayDat.Value.AddDays(1);
                }
                item.THANHTIEN = item.DONGIA * item.SONGAYO;
            }
            loadDPCT();
        }
        void loadDPCT()
        {
            List<OBJ_DP_CT> lst = new List<OBJ_DP_CT>();
            foreach (var item in lstDP_CT)
            {
                lst.Add(item);
            }
            gcDatPhong.DataSource = Friend.ConvertToDataTable(lst);
        }
        void update_txtThanhTien()
        {
            if(gvDatPhong.Columns["THANHTIEN"].SummaryItem.SummaryValue!= null)
            {
                txtThanhTien.Text = double.Parse(gvDatPhong.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()).ToString("N0");
            }    
            else
            {
                txtThanhTien.Text ="0";
            }    
            
        }
        void loadDanhSach()
        {
            _datphong = new DATPHONG();
            gcDanhSach.DataSource = _datphong.GetAllBooking(dtTuNgay.Value, dtDenNgay.Value.AddDays(1),true, _macty, _madvi);
            gvDanhSach.OptionsBehavior.Editable = false;
           
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
                dp.NGAYDAT = dtNgayDat.Value;
                dp.NGAYTRA = dtNgayTra.Value;
                dp.SONGUOIO = int.Parse(spSoNguoi.EditValue.ToString());
                dp.STATUS = false;
                dp.THEODOAN = chkTheoDoan.Checked;
                dp.IDKH = int.Parse(cboKhachHang.SelectedValue.ToString());
                dp.SOTIEN = double.Parse(txtThanhTien.Text);
                dp.GHICHU = txtGhiChu.Text;
                dp.UID = 1;
                dp.DISABLED = false;
                dp.CREATED_DATE = DateTime.Now;
                dp.MACTY = _macty;
                dp.MADVI = _madvi;
                dp.BOOKING = true;
                dp.NHAN = false;
                var _dp = _datphong.add(dp);
                _idDP = _dp.IDDP;
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
                    _datphong_ct.add(dpct);
                }
            }
            else if (_them == false)
            {

                tb_DatPhong dp = _datphong.GetItem(_idDP);
                tb_DatPhong_CT dpct;
                

                dp.NGAYDAT = dtNgayDat.Value;
                dp.NGAYTRA = dtNgayTra.Value;
                dp.SONGUOIO = int.Parse(spSoNguoi.EditValue.ToString());
                dp.STATUS = false;
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
                     _datphong_ct.add(dpct);                                     
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
            _idPhong = (int)row["IDPHONG"];
            if (row != null && table != null && row.Table != table)
            {
                table.ImportRow(row);
                subtract_LSTDP_CT(_idPhong);
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
        private void gcDatPhong_DragDrop(object sender, DragEventArgs e)
        {

            GridControl grid = sender as GridControl; //hiển thị data vào dưới dạng lưới
            DataTable table = grid.DataSource as DataTable;
            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            _idPhong = (int)row["IDPHONG"];
            if (row != null && table != null && row.Table != table)
            {
                table.ImportRow(row);
                add_LSTDP_CT();
                row.Delete();
            }

        }
        private void gcDatPhong_DragOver(object sender, DragEventArgs e)
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
            loadphong();
            _enabled(true);
            showHideControl(false);         
            xtraTabControl1.SelectedTabPage = pagechitiet;
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
                loadDanhSach();                            
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (spSoNguoi.Value < 0)
            {
                MessageBox.Show("quá nhỏ");
                spSoNguoi.EditValue = 0;
                return;
            }
            if (gvDatPhong.RowCount > 0 && spSoNguoi.Value > int.Parse(gvDatPhong.Columns["SONGUOI"].SummaryItem.SummaryValue.ToString()))
            {
                MessageBox.Show("Vượt quá số người cho phép", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spSoNguoi.EditValue = int.Parse(gvDatPhong.Columns["SONGUOI"].SummaryItem.SummaryValue.ToString());
                return;
            }
            ///test push 
            saveData();
            _them = false;
            _enabled(false);
            showHideControl(true);
            loadDPCT_id();
            loadDanhSach();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            _idDP = 0;
            _reset();
            loadphong();
            _enabled(false);
            showHideControl(true);
            xtraTabControl1.SelectedTabPage = pageDanhSach;
        }

        void loadKH()
        {
            _khachhang = new KHACHHANG();
            cboKhachHang.DataSource = _khachhang.getAll();
            cboKhachHang.DisplayMember = "HOTEN";
            cboKhachHang.ValueMember = "IDKH";
        }
  
        private void dtNgayTra_ValueChanged(object sender, EventArgs e)
        {
            if (dtNgayTra.Value < dtNgayDat.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayTra.Value = dtNgayDat.Value.AddDays(1);
                return;
            }
            update_songayo();
            loadphong();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            _idDP = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDDP").ToString());           
            var dp = _datphong.GetItem(_idDP);
            cboKhachHang.SelectedValue = dp.IDKH;
            dtNgayDat.Value = dp.NGAYDAT.Value;
            dtNgayTra.Value = dp.NGAYTRA.Value;
            txtGhiChu.Text = dp.GHICHU.ToString();
            cboTrangThai.SelectedValue = dp.STATUS;
            spSoNguoi.Text = dp.SONGUOIO.ToString();
            txtThanhTien.Text = dp.SOTIEN.Value.ToString("N0");
            loadDPCT_id();
        }

        private void gcDanhSach_DoubleClick(object sender, EventArgs e)
        {
            _idDP = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDDP").ToString());
            loadDPCT_id();
            var dp = _datphong.GetItem(_idDP);
            cboKhachHang.SelectedValue = dp.IDKH;
            dtNgayDat.Value = dp.NGAYDAT.Value;
            dtNgayTra.Value = dp.NGAYTRA.Value;
            txtGhiChu.Text = dp.GHICHU.ToString();
            cboTrangThai.SelectedValue = dp.STATUS;
            spSoNguoi.Text = dp.SONGUOIO.ToString();
            txtThanhTien.Text = dp.SOTIEN.Value.ToString("N0");
            xtraTabControl1.SelectedTabPage = pagechitiet;
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            if (_idDP == 0)
            {

                MessageBox.Show("Vui lòng chọn đã đặt trước phòng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (MessageBox.Show("Xác nhận khách hành đã nhận phòng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tb_DatPhong temp = _datphong.GetItem(_idDP);
                temp.NHAN = true;
                _datphong.update(temp);             
                _phong.updateStatusBy_IDDP(_idDP,true);
                objMain.gControl.Gallery.Groups.Clear();
                objMain.showRoom();
                loadDanhSach();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}