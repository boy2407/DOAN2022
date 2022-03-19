﻿using DevExpress.XtraEditors;
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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace KHACHSAN
{
    public partial class frmBooking : DevExpress.XtraEditors.XtraForm
    {
        public frmBooking()
        {
            InitializeComponent();
          
        }
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        bool _them, _GiamSoPhong;
        DATPHONG _datphong;
        DATPHONG_CT _datphong_ct;
        DATPHONG_SP _datphong_sp;
        KHACHHANG _khachhang;
        SANPHAM _sanpham;
        PHONG _phong;
        VIEW_PHONGBYNGAY _vphongbyngay;
        GridHitInfo downhitInfo = null;
        int _idPhong = 0;
        string _tenPhong;
        int _idDP = 0;
        int _rowDatPhong = 0;
        List<OBJ_DPSP> lstDPSP;
        //SYS_PARAM _param;
        string _madvi;
        string _macty;
        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            _vphongbyngay = new VIEW_PHONGBYNGAY();
            _khachhang = new KHACHHANG();
            _sanpham = new SANPHAM();
            _datphong = new DATPHONG();
            _datphong_ct = new DATPHONG_CT();
            _datphong_sp = new DATPHONG_SP();
            _phong = new PHONG();
            lstDPSP = new List<OBJ_DPSP>();
            dtTuNgay.Value = Friend.GetFirstDayInMont(DateTime.Now.Year, DateTime.Now.Month);
            dtDenNgay.Value = DateTime.Now;
            cboTrangThai.DataSource = TRANGTHAI.getList();
            cboTrangThai.ValueMember = "_value";
            cboTrangThai.DisplayMember = "_display";
            loadphongByNgayDat(DateTime.Now);

            _macty = Friend._macty;
            _madvi = Friend._madvi;
           //  loadphongByNgayDat(dtNgayDat.Value);
            gvPhong.ExpandAllGroups();////sổ hết các phòng trong tầng trên gridview gvphong
            loadKH();
            loadSP();
            loadDanhSach();
            _enabled(false);
            txtThanhTien.Enabled = false;
            _datphong = new DATPHONG();
            showHideControl(true);
            TabControl.SelectedTabPage = PageDanhSach;
        }
        public void loadKH()
        {
            _khachhang = new KHACHHANG();
            cboKhachHang.DataSource = _khachhang.getAll();
            cboKhachHang.DisplayMember = "HOTEN";
            cboKhachHang.ValueMember = "IDKH";
        }
        void loadSP()
        {
            gcSanPham.DataSource = _sanpham.getAll();
            gvSanPham.OptionsBehavior.Editable = false;
        }
        void loadphongByNgayDat(DateTime time)
        {
     
            
            List<V_PHONGBYNGAY> lstPhongByNgay = _vphongbyngay.getlistPhongKhongTrungDateTime(time);
            gcPhong.DataSource = lstPhongByNgay;
            gcDatPhong.DataSource = _vphongbyngay.getlistItem(0);
            gvPhong.ExpandAllGroups();
        }
        void loadPhong()
        {
            DataTable table = Friend.laydulieu("SELECT A.IDPHONG, A.TENPHONG, A.IDTANG, B.TENTANG, C.DONGIA FROM tb_PHONG A, tb_Tang B, tb_LOAIPHONG C WHERE A.IDTANG = B.IDTANG AND A.TRANGTHAI=0 AND A.IDLOAIPHONG = C.IDLOAIPHONG");
            gcPhong.DataSource = table;
            gcDatPhong.DataSource = table.Clone();
            gvPhong.ExpandAllGroups();

        }
        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnIn.Visible = t;
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
            chkTheoDoan.Enabled = t;
            spSoNguoi.Enabled = t;
            txtGhiChu.Enabled = t;

            gcDatPhong.Enabled = t;
            gcPhong.Enabled = t;
            gcSPDV.Enabled = t;
            gcSanPham.Enabled = t;
        }
        void _reset()
        {

            chkTheoDoan.Checked = true;
            dtNgayDat.Value = DateTime.Now;
            dtNgayTra.Value = DateTime.Now.AddDays(1);
            cboTrangThai.SelectedValue = false;
            txtGhiChu.Text = "";
            spSoNguoi.Text = "1";
            txtThanhTien.Text = "0";

            //loadPhong();
            loadphongByNgayDat(DateTime.Now);
            ResetLoadDP();
            ResetloadSPDV();
        }
        void AddReset()
        {
            //loadPhong();
            loadphongByNgayDat(DateTime.Now);
            gcSPDV.DataSource = _datphong_sp.getAllByDatPhong(0);
            txtThanhTien.Text = "0";
        }
        void LoadData()
        {
            _datphong = new DATPHONG();
            gcDanhSach.DataSource = _datphong.GetAllBooking();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadDanhSach()
        {

            gcDanhSach.DataSource = _datphong.GetAll(dtTuNgay.Value, dtDenNgay.Value.AddDays(1), _macty, _madvi);
            gvDanhSach.OptionsBehavior.Editable = false;
            _datphong = new DATPHONG();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            _reset();
            AddReset();
            _them = true;
            _enabled(true);
            showHideControl(false);
            //loadPhong();
            loadphongByNgayDat(DateTime.Now);
            TabControl.SelectedTabPage = PageChiTiet;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            _enabled(true);
            _them = false;
            showHideControl(false);
           // loadPhong();
            loadphongByNgayDat(DateTime.Now);
            TabControl.SelectedTabPage = PageChiTiet;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _datphong.delete(_idDP);
                var lstDPCT = _datphong_ct.getAllByDatPhong(_idDP);
                foreach (var item in lstDPCT)
                {
                    _phong.updateStatus(item.IDPHONG, false);
                }
            }

            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
            LoadData();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            saveData();

            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
            LoadData();

            loadphongByNgayDat(DateTime.Now);
            //loadPhong();
            _them = false;
            _enabled(false);
            showHideControl(true);
            TabControl.SelectedTabPage = PageDanhSach;

        }
        //Phòng trống trong tầng
        private void gvPhong_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            GridGroupRowInfo info = e.Info as GridGroupRowInfo;
            string caption = info.Column.Caption;
            if (info.Column.Caption == string.Empty)////nếu tiêu đề không có gì thì cho nó bằng colum
            {
                caption = info.Column.ToString();

            }
            //0. tiêu đề cột, 1.tiêu đề group, 2. số dòng đếm được trong group
            info.GroupText = string.Format("{0}: {1} ({2} phòng trống )", caption, info.GroupValueText, view.GetChildRowCount(e.RowHandle));

        }
        void saveData()
        {
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
                for (int i = 0; i < gvDatPhong.RowCount; i++)
                {
                    dpct = new tb_DatPhong_CT();
                    dpct.IDDP = _dp.IDDP;
                    dpct.IDPHONG = int.Parse(gvDatPhong.GetRowCellValue(i, "IDPHONG").ToString());
                    dpct.SONGAYO = dtNgayTra.Value.Day - dtNgayDat.Value.Day;
                    dpct.DONGIA = double.Parse(gvDatPhong.GetRowCellValue(i, "DONGIA").ToString());
                    dpct.THANHTIEN = dpct.SONGAYO * dpct.DONGIA;
                    dpct.NGAY = DateTime.Now;
                    var _dpct = _datphong_ct.add(dpct);
                    _phong.updateStatus(int.Parse(_dpct.IDPHONG.ToString()), true);

                    if (gvSPDV.RowCount > 0)
                    {
                        for (int j = 0; j < gvSPDV.RowCount; j++)
                        {
                            if (_dpct.IDPHONG == int.Parse(gvSPDV.GetRowCellValue(j, "IDPHONG").ToString()))
                            {

                                dpsp = new tb_DatPhong_SP();
                                dpsp.IDDP = _dp.IDDP;
                                dpsp.IDSP = int.Parse(gvSPDV.GetRowCellValue(j, "IDSP").ToString());

                                dpsp.IDDPCT = _dpct.IDDPCT;
                                dpsp.NGAY = _dpct.NGAY;
                                dpsp.IDPHONG = int.Parse(gvSPDV.GetRowCellValue(j, "IDPHONG").ToString());
                                dpsp.SOLUONG = int.Parse(gvSPDV.GetRowCellValue(j, "SOLUONG").ToString());
                                dpsp.DONGIA = Double.Parse(gvSPDV.GetRowCellValue(j, "DONGIA").ToString());
                                dpsp.THANHTIEN = Double.Parse((dpsp.SOLUONG * dpsp.DONGIA).ToString());
                                _datphong_sp.add(dpsp);

                            }
                        }
                    }
                }
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
                _datphong_sp.deleteAll(_idDP);

                for (int i = 0; i < gvDatPhong.RowCount; i++)
                {
                    dpct = new tb_DatPhong_CT();
                    dpct.IDDP = _dp.IDDP;
                    dpct.IDPHONG = int.Parse(gvDatPhong.GetRowCellValue(i, "IDPHONG").ToString());
                    dpct.SONGAYO = dtNgayTra.Value.Day - dtNgayDat.Value.Day;
                    dpct.DONGIA = double.Parse(gvDatPhong.GetRowCellValue(i, "DONGIA").ToString());
                    dpct.THANHTIEN = dpct.SONGAYO * dpct.DONGIA;
                    dpct.NGAY = DateTime.Now;
                    var _dpct = _datphong_ct.add(dpct);
                    _phong.updateStatus(int.Parse(_dpct.IDPHONG.ToString()), true);
                    if (gvSPDV.RowCount > 0)
                    {
                        for (int j = 0; j < gvSPDV.RowCount; j++)
                        {
                            if (dpct.IDPHONG == int.Parse(gvSPDV.GetRowCellValue(j, "IDPHONG").ToString()))
                            {
                                dpsp = new tb_DatPhong_SP();
                                dpsp.IDDP = _dp.IDDP;
                                dpsp.IDSP = int.Parse(gvSPDV.GetRowCellValue(j, "IDSP").ToString());
                                dpsp.IDDPCT = _dpct.IDDPCT;
                                dpsp.NGAY = _dpct.NGAY;
                                dpsp.IDPHONG = int.Parse(gvSPDV.GetRowCellValue(j, "IDPHONG").ToString());
                                dpsp.SOLUONG = int.Parse(gvSPDV.GetRowCellValue(j, "SOLUONG").ToString());
                                dpsp.DONGIA = Double.Parse(gvSPDV.GetRowCellValue(j, "DONGIA").ToString());
                                dpsp.THANHTIEN = Double.Parse((dpsp.SOLUONG * dpsp.DONGIA).ToString());
                                _datphong_sp.add(dpsp);
                            }
                        }
                    }

                }

            }

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            _GiamSoPhong = false;
            showHideControl(true);
            _enabled(false);
            TabControl.SelectedTabPage = PageDanhSach;
           //loadPhong();
            loadphongByNgayDat(DateTime.Now);
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //========================================================

        //Sự Kiện Di Chuyển Chuột Ở GridView DatPhong
        private void gvDatPhong_MouseDown(object sender, MouseEventArgs e)
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
        //========================================================
        //Sựu Kiện Đánh Cột Thứ Tự
        bool STT(Int32 _width, GridView _view)///lấy độ rộng
        {
            _view.IndicatorWidth = _view.IndicatorWidth < _width ? _width : _view.IndicatorWidth;
            return true;

        }

        private void gvPhong_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gvPhong.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu không phải là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //STT tăng dần
                    }
                    SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước vùng hiển thị text
                    Int32 _width = Convert.ToInt32(_size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { STT(_width, gvPhong); })); //tăng kích thước lên nếu vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * (-1))); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước vùng hiển thị text
                Int32 _width = Convert.ToInt32(_size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { STT(_width, gvPhong); })); //tăng kích thước lên nếu vượt quá
            }
        }
        private void gvSanPham_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gvSanPham.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu không phải là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //STT tăng dần
                    }
                    SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước vùng hiển thị text
                    Int32 _width = Convert.ToInt32(_size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { STT(_width, gvPhong); })); //tăng kích thước lên nếu vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * (-1))); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước vùng hiển thị text
                Int32 _width = Convert.ToInt32(_size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { STT(_width, gvPhong); })); //tăng kích thước lên nếu vượt quá
            }
        }
        private void gvDatPhong_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gvDatPhong.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu không phải là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //STT tăng dần
                    }
                    SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước vùng hiển thị text
                    Int32 _width = Convert.ToInt32(_size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { STT(_width, gvPhong); })); //tăng kích thước lên nếu vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * (-1))); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước vùng hiển thị text
                Int32 _width = Convert.ToInt32(_size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { STT(_width, gvPhong); })); //tăng kích thước lên nếu vượt quá
            }
        }
        private void gvSPDV_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gvSPDV.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu không phải là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //STT tăng dần
                    }
                    SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước vùng hiển thị text
                    Int32 _width = Convert.ToInt32(_size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { STT(_width, gvPhong); })); //tăng kích thước lên nếu vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * (-1))); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước vùng hiển thị text
                Int32 _width = Convert.ToInt32(_size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { STT(_width, gvPhong); })); //tăng kích thước lên nếu vượt quá
            }
        }


        //======================================================
        //Thêm SPDV vào phòng
        private void gcSanPham_DoubleClick(object sender, EventArgs e)
        {

            if (_idPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (gvSanPham.GetFocusedRowCellValue("IDSP") != null)
            {

                OBJ_DPSP sp = new OBJ_DPSP();
                sp.IDSP = int.Parse(gvSanPham.GetFocusedRowCellValue("IDSP").ToString());
                sp.TENSP = gvSanPham.GetFocusedRowCellValue("TENSP").ToString();
                sp.IDPHONG = _idPhong;
                sp.TENPHONG = _tenPhong;
                sp.DONGIA = float.Parse(gvSanPham.GetFocusedRowCellValue("DONGIA").ToString());
                sp.SOLUONG = 1;
                sp.THANHTIEN = sp.SOLUONG * sp.DONGIA;
                foreach (var item in lstDPSP)
                {
                    if (item.IDSP == sp.IDSP && item.IDPHONG == sp.IDPHONG)
                    {

                        item.SOLUONG = item.SOLUONG + 1;
                        item.THANHTIEN = item.SOLUONG * item.DONGIA;
                        loadDPSP();
                        txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["DONGIA"].SummaryItem.SummaryValue.ToString())).ToString("N0");

                        return;
                    }
                }
                lstDPSP.Add(sp);
            }

            loadDPSP();
            txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["DONGIA"].SummaryItem.SummaryValue.ToString())).ToString("N0");
        }
        void loadDPSP()
        {

            List<OBJ_DPSP> lsDP = new List<OBJ_DPSP>();
            foreach (var item in lstDPSP)
            {
                lsDP.Add(item);
            }

            gcSPDV.DataSource = lsDP;
        }
        //khi thay đổi Ô số lượng thì Ô thành tiền thay đổi
        private void gvSPDV_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value == null)
            {
                MessageBox.Show("vui lòng nhập số lượng");
            }
            else
            {
                if (e.Column.FieldName == "SOLUONG")
                {
                    int sl = int.Parse(e.Value.ToString());
                    if (sl != 0)
                    {
                        double gia = double.Parse(gvSPDV.GetRowCellValue(gvSPDV.FocusedRowHandle, "DONGIA").ToString());
                        gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "THANHTIEN", sl * gia);
                    }
                    else
                    {
                        gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "THANHTIEN", "0");
                    }
                }
                gvSPDV.UpdateTotalSummary();///update lại sum 
                txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["DONGIA"].SummaryItem.SummaryValue.ToString())).ToString("N0");

            }



        }

        private void gvDatPhong_RowCountChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("số rowdatphong"+_rowDatPhong.ToString() +"số gvdatphong"+gvDatPhong.RowCount.ToString());

            if (gvDatPhong.RowCount < _rowDatPhong && _them == false && _GiamSoPhong == true)
            {
                if (MessageBox.Show("Cảnh Báo Dữ Liễu Sẻ Mất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    MessageBox.Show(_idPhong.ToString());
                    _phong.updateStatus(_idPhong, false);
                    _datphong_ct.delete(_idDP, _idPhong);
                    _datphong_sp.deletAllByPhong(_idDP, _idPhong);
                    LoadData();
                    objMain.gControl.Gallery.Groups.Clear();
                    objMain.showRoom();
                    btnBoQua.Visible = false;

                }
                _rowDatPhong = gvDatPhong.RowCount;
            }

            _GiamSoPhong = false;


            double t = 0;
            if (gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue == null)
            {
                t = 0;
            }
            else
            {
                t = double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString());
            }
            txtThanhTien.Text = (double.Parse(gvDatPhong.Columns["DONGIA"].SummaryItem.SummaryValue.ToString()) + t).ToString("N0");
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();

        }
        public void setKhachHang(int idkh)
        {
            var _kh = _khachhang.getItem(idkh);
            cboKhachHang.SelectedValue = _kh.IDKH;
            cboKhachHang.Text = _kh.HOTEN;
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {

            if (gvDanhSach.RowCount > 0)
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
                loadDP();
                loadSPDV();
            }
        }
        void ResetLoadDP()
        {
            int rowCount = gvDatPhong.DataRowCount;
            for (int i = rowCount - 1; i >= 0; i--)
            {
                gvDatPhong.SelectRow(i);
                gvDatPhong.DeleteSelectedRows();
            }

        }
        void ResetloadSPDV()
        {
            int rowCount = gvSPDV.DataRowCount;
            for (int i = rowCount - 1; i >= 0; i--)
            {
                gvSPDV.SelectRow(i);
                gvSPDV.DeleteSelectedRows();
            }
        }
        void loadDP()
        {
            _rowDatPhong = 0;
            gcDatPhong.DataSource = Friend.laydulieu("select A.IDPHONG,A.TENPHONG,C.DONGIA,A.IDTANG,B.TENTANG from tb_Phong A, tb_Tang B,tb_LoaiPhong C , tb_DatPhong_CT D where A.IDTANG = B.IDTANG and A.IDLOAIPHONG=C.IDLOAIPHONG and A.IDPHONG=D.IDPHONG and D.IDDP='" + _idDP + "'");
            _rowDatPhong = gvDatPhong.RowCount;
        }
        void loadSPDV()
        {
            gcSPDV.DataSource = _datphong_sp.getAllByDatPhong(_idDP);
            lstDPSP = _datphong_sp.getAllByDatPhong(_idDP);
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtDenNgay.Value = dtNgayTra.Value.AddDays(1);
                return;
            }
            else
                loadDanhSach();

        }

        private void dtTuNgay_Leave(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtDenNgay.Value = dtNgayTra.Value.AddDays(1);
                return;
            }
            else
                loadDanhSach();
        }

        private void dtDenNgay_Leave(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtDenNgay.Value = dtNgayTra.Value.AddDays(1);
                return;
            }
            else
                loadDanhSach();
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtDenNgay.Value = dtNgayTra.Value.AddDays(1);
                return;
            }
            else
                loadDanhSach();
        }

        private void gcDanhSach_DoubleClick(object sender, EventArgs e)
        {

            if (gvDanhSach.RowCount > 0)
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
                loadDP();
                loadSPDV();
                TabControl.SelectedTabPage = PageChiTiet;
            }

        }

        private void gvDanhSach_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!gvDanhSach.IsGroupRow(e.RowHandle))
            {
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1;
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                    SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                    Int32 _width = Convert.ToInt32(_size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { STT(_width, gvDanhSach); }));
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * (-1)));
                SizeF _size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _width = Convert.ToInt32(_size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { STT(_width, gvDanhSach); }));
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Friend.XuatReport("@IDDP", _idDP.ToString(), "PHIEU_DATPHONG", "Phiếu đặt phòng chi tiết");
        }

        private void dtNgayDat_ValueChanged(object sender, EventArgs e)
        {
            // loadphongByNgayDat(dtNgayDat.Value);
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


    
    }
}