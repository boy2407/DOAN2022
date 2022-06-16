using DevExpress.XtraEditors;
using System;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using DataLayer;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace KHACHSAN
{
    public partial class frmDatPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmDatPhong()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
        }
        public frmDatPhong(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
            CheckForIllegalCrossThreadCalls = false;
        }
        tb_SYS_USER _user;
        int _right;

        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        bool _them,_GiamSoPhong;
        public bool _thanhtoan ;
        DATPHONG _datphong;
        DATPHONG_CT _datphong_ct;
        DATPHONG_SP _datphong_sp;
        KHACHHANG _khachhang;
        SANPHAM _sanpham;
        PHONG _phong;
        TANG _tang;
        LOAIPHONG _loaiphong;
        GridHitInfo downhitInfo = null;
        SYS_DATPHONG_PHONG_NGAYO _dcn;
        SYS_RIGHT _sysRight;
        int _idPhong=0;
        string _tenPhong;
        public int _idDP = 0;
        int _rowDatPhong = 0;
        List<OBJ_DPSP> lstDPSP;
        List<OBJ_DP_CT> lstDP_CT;
        List<OBJ_DP_CT> lstDP_CT_temp;
        //SYS_PARAM _param;
        string _madvi;
        string _macty;
        private Thread demoThread = null;

        int count = 0;
        private void frmDatPhong_Load(object sender,EventArgs e)
        {           
            _khachhang = new KHACHHANG();
            _sanpham = new SANPHAM();
            _datphong = new DATPHONG();
            _datphong_ct = new DATPHONG_CT();
            _datphong_sp = new DATPHONG_SP();
            _loaiphong = new LOAIPHONG();
            _phong = new PHONG();
            _tang = new TANG();
            _dcn = new SYS_DATPHONG_PHONG_NGAYO();
            lstDPSP = new List<OBJ_DPSP>();
            lstDP_CT = new List<OBJ_DP_CT>();
            _sysRight = new SYS_RIGHT();
            dtTuNgay.Value = Friend.GetFirstDayInMont(DateTime.Now.Year, DateTime.Now.Month);
            dtDenNgay.Value = Friend.GetLastDayInMont(DateTime.Now.Year, DateTime.Now.Month);            
            cboTrangThai.DataSource = TRANGTHAI.getList();
            cboTrangThai.ValueMember = "_value";
            chkTheoDoan.Enabled = false;
            chkTheoDoan.Checked = true;
            cboTrangThai.DisplayMember = "_display";
            dtNgayDat.Value = DateTime.Now;
            dtNgayTra.Value = DateTime.Now.AddDays(1);
            dtNgayDat.Enabled = false;

            _macty = Friend._macty;
            _madvi = Friend._madvi;            
            gvPhong.ExpandAllGroups();////sổ hết các phòng trong tầng trên gridview gvphong
            loadKH();
            loadSP();
            loadPhong();
            loadDanhSach();
            _enabled(false);
            txtThanhTien.Enabled = false;
            _datphong = new DATPHONG();
            showHideControl(true);          
            TabControl.SelectedTabPage = PageDanhSach;

            if(!_them)
            {
                gcPhong.Enabled = false;
            }    
            if (_thanhtoan == true)
            {
                TabControl.SelectedTabPage = PageChiTiet;
                var dp = _datphong.GetItem(_idDP, Friend._macty, Friend._madvi);
                cboKhachHang.SelectedValue = dp.IDKH;
                dtNgayDat.Value = dp.NGAYDAT.Value;
                dtNgayTra.Value = dp.NGAYTRA.Value;
                txtGhiChu.Text = dp.GHICHU.ToString();
                cboTrangThai.SelectedValue = dp.STATUS;
                spSoNguoi.Text = dp.SONGUOIO.ToString();
                txtThanhTien.Text = dp.SOTIEN.Value.ToString("N0");
                loadDPCT_id();
                loadSPDV();
                _enabled(false);
                _them = false;
                showHideControl(true);
                TabControl.SelectedTabPage = PageChiTiet;                 
            }
        }

        //load lại list phòng theo _iddp
        void loadDP()
        {
            //gcDatPhong.DataSource = Friend.laydulieu("select A.IDPHONG,A.TENPHONG,C.DONGIA,A.IDTANG,B.TENTANG from tb_Phong A, tb_Tang B,tb_LoaiPhong C , tb_DatPhong_CT D where A.IDTANG = B.IDTANG and A.IDLOAIPHONG=C.IDLOAIPHONG and A.IDPHONG=D.IDPHONG and D.IDDP='" + _idDP + "'");
            _rowDatPhong = 0;
            gcDatPhong.DataSource = Friend.laydulieu("select A.IDPHONG,A.TENPHONG,C.DONGIA,A.IDTANG,B.TENTANG,D.SONGAYO,D.THANHTIEN from tb_Phong A, tb_Tang B,tb_LoaiPhong C , tb_DatPhong_CT D where A.IDTANG = B.IDTANG and A.IDLOAIPHONG=C.IDLOAIPHONG and A.IDPHONG=D.IDPHONG and D.IDDP='" + _idDP + "'");
            _rowDatPhong = gvDatPhong.RowCount;     
        }
        void loadDPCT_id()
        {
            gcDatPhong.DataSource = Friend.ConvertToDataTable(_datphong_ct.getAllDPCT(_idDP, Friend._macty, Friend._madvi));
            lstDP_CT = _datphong_ct.getAllDPCT(_idDP, Friend._macty, Friend._madvi);            
            gvPhong.ExpandAllGroups();
        }
        void add_LSTDP_CT()
        {
            if(lstDP_CT.Count>0)
            {
                foreach(var i in lstDP_CT)
                {
                    if(i.IDPHONG==_idPhong)
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
            p.DONGIA =donggia.DONGIA;
            p.SONGUOI = (int)donggia.SONGUOI;
            p.NGAY = DateTime.Now;
            int t = int_Days();
            p.SONGAYO = t;            
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
                    XoaSPDVBy_Idphong(idphong);
                    //_phong.updateStatus(idphong, false);
                    // _datphong_ct.delete(_idDP, idphong);
                    loadDPCT();
                    update_txtThanhTien();
                    //objMain.gControl.Gallery.Groups.Clear();
                    //objMain.showRoom();
                    return;
                }

            }
        }
        void Check_SP()
        {

        }
        int int_Days()
        {
                int temp = 0;
                TimeSpan s = dtNgayTra.Value - dtNgayDat.Value;
                temp = (int)Math.Round(s.TotalDays);
            return temp;
        }
        void update_songayo()
        {
            

            foreach (var item in lstDP_CT)
            {
                int t = int_Days();
                item.SONGAYO = t;     
                item.THANHTIEN = item.DONGIA * item.SONGAYO;
            }
            loadDPCT_id();
            loadSPDV();
            loadDPCT();
            loadDPSP();
            
        }
        void loadDPCT()
        {
           
            List<OBJ_DP_CT> lst = new List<OBJ_DP_CT>();
            foreach(var item in lstDP_CT)
            {
                lst.Add(item);
            }
            gcDatPhong.DataSource = Friend.ConvertToDataTable(lst);
            //update_txtThanhTien();
        }
        void loadDPSP()
        {
            
            List<OBJ_DPSP> lsDP = new List<OBJ_DPSP>();
            foreach (var item in lstDPSP)
            {
                lsDP.Add(item);
            }
            gcSPDV.DataSource = lsDP;
            //update_txtThanhTien();
        }
        void loadSPDV()
        {
            gcSPDV.DataSource = _datphong_sp.getAllByDatPhong(_idDP);
            lstDPSP = _datphong_sp.getAllByDatPhong(_idDP);
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
            gcSanPham.DataSource = _sanpham.getAll(Friend._macty, Friend._madvi);
            gvSanPham.OptionsBehavior.Editable = false;
        }
        
        void loadPhong()
        {
            //DataTable table = Friend.laydulieu("SELECT A.IDPHONG, A.TENPHONG, A.IDTANG, B.TENTANG, C.DONGIA FROM tb_PHONG A, tb_Tang B, tb_LOAIPHONG C WHERE A.IDTANG = B.IDTANG AND A.TRANGTHAI=0 AND A.IDLOAIPHONG = C.IDLOAIPHONG");
            //gcPhong.DataSource = table;
            //gvPhong.ExpandAllGroups();

            _phong = new PHONG();
            lstDP_CT = new List<OBJ_DP_CT>();
            DataTable table = new DataTable();
            table = Friend.ConvertToDataTable(_phong.getAll_Vacancies(dtNgayDat.Value, dtNgayTra.Value,Friend._macty,Friend._madvi));
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
           // dtNgayDat.Enabled = t;
            dtNgayTra.Enabled = t;           
            cboTrangThai.Enabled = t;
           
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
           
           
            loadPhong();           
            ResetLoadDP();
            ResetloadSPDV();
        }
        void AddReset()
        {
            //DataTable table = Friend.laydulieu("SELECT A.IDPHONG, A.TENPHONG, A.IDTANG, B.TENTANG, C.DONGIA FROM tb_PHONG A, tb_Tang B, tb_LOAIPHONG C WHERE A.IDTANG = B.IDTANG AND A.TRANGTHAI=0 AND A.IDLOAIPHONG = C.IDLOAIPHONG");
            DataTable table = Friend.ConvertToDataTable(_phong.getAll_Vacancies(dtNgayDat.Value, dtNgayTra.Value, Friend._macty, Friend._madvi));
            gcPhong.DataSource = table;
            gcDatPhong.DataSource = table.Clone(); //nhân bảng      
            gvPhong.ExpandAllGroups();
           
            gcSPDV.DataSource = _datphong_sp.getAllByDatPhong(0);
            txtThanhTien.Text = "0";
        }
        void LoadData()
        {
            _datphong = new DATPHONG();          
            gcDanhSach.DataSource = _datphong.GetAllTheoDoan();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadDanhSach()
        {
            _datphong = new DATPHONG();
            gcDanhSach.DataSource = _datphong.GetAll_DanhSach( _macty, _madvi);
            gvDanhSach.OptionsBehavior.Editable = false;
            loadLichSu();
        }
        void loadLichSu()
        {
            _datphong = new DATPHONG();
            gcLichSu.DataSource = _datphong.GetAll_LichSu(dtTuNgay.Value, dtDenNgay.Value.AddDays(1), _macty, _madvi);
            gvLichSu.OptionsBehavior.Editable = false;

        }

        private void test()
        {
            PageDanhSach.PageEnabled = false;
        }
        private void test1()
        {
            PageDanhSach.PageEnabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
          
            _them = true;
            _idDP = 0;
            lstDPSP = new List<OBJ_DPSP>();
            lstDP_CT = new List<OBJ_DP_CT>();
            _reset();
            AddReset();
            _enabled(true);
            showHideControl(false);
            loadPhong();
            //loadphongByNgayDat(DateTime.Now);
            TabControl.SelectedTabPage = PageChiTiet;
                      
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           

            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_idDP == 0)
            {
                
                MessageBox.Show("Vui long chọn Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            else
            {
            
                var dp = _datphong.GetItem(_idDP, Friend._macty, Friend._madvi);
                if(dp.STATUS==true)
                {

                    MessageBox.Show("Hóa đơn đã thanh toán không được sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
               
                _enabled(true);
                _them = false;
                showHideControl(false);
                cboKhachHang.SelectedValue = dp.IDKH;
                dtNgayDat.Value = dp.NGAYDAT.Value;
                dtNgayTra.Value = dp.NGAYTRA.Value;
                txtGhiChu.Text = dp.GHICHU.ToString();
                cboTrangThai.SelectedValue = dp.STATUS;
                spSoNguoi.Text = dp.SONGUOIO.ToString();
                txtThanhTien.Text = dp.SOTIEN.Value.ToString("N0");
                loadDPCT_id();
                loadSPDV();
                TabControl.SelectedTabPage = PageChiTiet;             
            }

        
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                objMain.gControl.Gallery.Groups.Clear();
                objMain.showRoom();
                LoadData();
            }
          
           
          
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (gvDatPhong.RowCount < 0 )
            {
                MessageBox.Show("Vui lòng chọn phòng");
                return;
            }    
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
            update_txtThanhTien();
            _them = false;
            _enabled(false);           
            showHideControl(true);                   
            loadDPCT_id();
            loadSPDV();
           // _tongtien = double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())+
            //    + _datphong_ct.SumByIddp(_idDP);
            var dp_ = _datphong.GetItem(_idDP, Friend._macty, Friend._madvi);
            dp_.SOTIEN = double.Parse(txtThanhTien.Text);
            loadDanhSach();
            _idDP = dp_.IDDP;
            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
                     
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
            if(gvDatPhong.RowCount<0)
            {

                if (MessageBox.Show("Danh sách phòng đặt đang trống bạn có muốn tiếp tục", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                }
                else
                    return;
                  
            }    

            if (_them )
            {
                tb_DatPhong dp = new tb_DatPhong();
                tb_DatPhong_CT dpct;
                tb_DatPhong_SP dpsp;
                tb_DatPhong_Phong_NgayO dcn;
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
                dp.BOOKING = false;
                dp.NHAN = true;
                var _dp = _datphong.add(dp);
                _idDP = _dp.IDDP;
                for (int i = 0; i < gvDatPhong.RowCount; i++)
                {
                    
                    dpct = new tb_DatPhong_CT();
                    dpct.IDDP = _dp.IDDP;
                    dpct.IDPHONG = int.Parse(gvDatPhong.GetRowCellValue(i,"IDPHONG").ToString());
                    int t = int_Days();
                    dpct.SONGAYO = t;
                    dpct.DONGIA = double.Parse(gvDatPhong.GetRowCellValue(i,"DONGIA").ToString());
                    dpct.THANHTIEN = dpct.SONGAYO * dpct.DONGIA;
                    dpct.NGAY = DateTime.Now;
                    dpct.MACTY = Friend._macty;
                    dpct.MADVI = Friend._madvi;
                  var _dpct =  _datphong_ct.add(dpct);      
                    //for(int k =1; k<t+1;++k)
                    //{
                    //    dcn = new tb_DatPhong_Phong_NgayO();
                    //    dcn.IDDP = dpct.IDDPCT;
                    //    dcn.IDPHONG = int.Parse(gvDatPhong.GetRowCellValue(i, "IDPHONG").ToString());
                    //    dcn.NGAYO = dtNgayDat.Value.AddDays(k);
                    //    _dcn.add(dcn);
                    //}
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
                                dpsp.MACTY = Friend._macty;
                                dpsp.MADVI = Friend._madvi;
                                _datphong_sp.add(dpsp);
                            }                         
                        }
                    }
                }
            }
            else if(_them == false)
            {
                
                tb_DatPhong dp = _datphong.GetItem(_idDP, Friend._macty, Friend._madvi);
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

             //_phong.updateStatusBy_IDDP(_idDP,false);                  
                foreach(var i in _datphong_ct.getAll(_idDP))
                {
                    _phong.updateStatus(i.IDPHONG, false);
                }    
                _datphong_ct.deleteAll(_idDP);
                _datphong_sp.deleteAll(_idDP);
                
                for (int i = 0; i < gvDatPhong.RowCount; i++)
                {
                    dpct = new tb_DatPhong_CT();
                    dpct.IDDP = _dp.IDDP;
                    dpct.IDPHONG = int.Parse(gvDatPhong.GetRowCellValue(i, "IDPHONG").ToString());
                    int t = int_Days();
                    dpct.SONGAYO = t;
                    dpct.DONGIA = double.Parse(gvDatPhong.GetRowCellValue(i, "DONGIA").ToString());
                    dpct.THANHTIEN = dpct.SONGAYO * dpct.DONGIA;
                    dpct.NGAY = DateTime.Now;
                    dpct.MACTY = Friend._macty;
                    dpct.MADVI = Friend._madvi;
                    var _dpct = _datphong_ct.add(dpct);
                    
                    _phong.updateStatus(dpct.IDPHONG,true);

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
                                dpsp.MACTY = Friend._macty;
                                dpsp.MADVI = Friend._madvi;
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
            lstDP_CT = lstDP_CT_temp;
            _GiamSoPhong = false;
            showHideControl(true);
            _enabled(false);            
            _idDP = 0;
            lstDP_CT = new List<OBJ_DP_CT>();
            lstDPSP = new List<OBJ_DPSP>();
            loadPhong();
            AddReset();
            //PageDanhSach.PageEnabled = true;
            TabControl.SelectedTabPage = PageDanhSach;
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
            _idPhong =(int) row["IDPHONG"];
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
            _idPhong =(int)row["IDPHONG"];
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
       
       void update_txtThanhTien()
        {
            txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())).ToString("N0");
        }
        //======================================================
        //Thêm SPDV vào phòng
        private void gcSanPham_DoubleClick(object sender, EventArgs e)
        {
            
            if (_idPhong==0)
            {
                MessageBox.Show("Vui lòng chọn phòng?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (gvSanPham.GetFocusedRowCellValue("IDSP") != null )
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
                        if(_them)
                        {

                            //txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["DONGIA"].SummaryItem.SummaryValue.ToString())).ToString("N0");
                           txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())).ToString("N0");
                        }
                        else
                        {
                            //txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _datphong_ct.SumByIddp(_idDP)).ToString("N0");
                            txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())).ToString("N0");

                        }

                        return;
                    }
                }
                lstDPSP.Add(sp);
            }            
            loadDPSP();
            //txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _datphong_ct.SumByIddp(_idDP)).ToString("N0");
            if (!_them)
            {
               // txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _datphong_ct.SumByIddp(_idDP)).ToString("N0");
                txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())).ToString("N0");
            }
            else
            {
                txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())).ToString("N0");
            }
        }
        private void gcSanPham_Click(object sender, EventArgs e)
        {
            
           
        }      
        //khi thay đổi Ô số lượng thì Ô thành tiền thay đổi
        private void XoaSPDVBy_Iddpsp(int iddpsp)
        {

            foreach (var item in lstDPSP)
            {
                
                if (item.IDDPSP == iddpsp)
                {
                    lstDPSP.Remove(item);
                    loadDPSP();
                    return;
                }
            }

        }
        private void XoaSPDVBy_Idphong(int idphong)
        {
                
            List<OBJ_DPSP> lst = new List<OBJ_DPSP>();
                foreach (var item in lstDPSP)
                {
                    if (item.IDPHONG != idphong)
                    {
                         lst.Add(item);   
                    }
                }
            lstDPSP = lst;
            loadDPSP();
            update_txtThanhTien();
        }
        
        private void gvSPDV_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
            if (e.Value==null)
            {
                MessageBox.Show("vui lòng nhập số lượng");
            }
           else
            {
                if (e.Column.FieldName == "SOLUONG")
                {
                    int sl = int.Parse(e.Value.ToString());
                    double gia = double.Parse(gvSPDV.GetRowCellValue(gvSPDV.FocusedRowHandle, "DONGIA").ToString());
                    if (sl < 1)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng");
                        
                        gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "SOLUONG", 1);                      
                        gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "THANHTIEN",   gia);
                        return;

                    }
                    gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "THANHTIEN", sl * gia);
                }
                gvSPDV.UpdateTotalSummary();///update lại sum 
                if (_them)
                {
                    txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + double.Parse(gvDatPhong.Columns["DONGIA"].SummaryItem.SummaryValue.ToString())).ToString("N0");
                }
                else
                {
                    txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _datphong_ct.SumByIddp(_idDP)).ToString("N0");
                }
              // txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _datphong_ct.SumByIddp(_idDP)).ToString("N0");

            }    
                                 
        }
       
        private void mnXoa_Click(object sender, EventArgs e)
        {
            XoaSPDVBy_Iddpsp(int.Parse(gvSPDV.GetRowCellValue(gvSPDV.FocusedRowHandle, "IDDPSP").ToString()));
            gvSPDV.UpdateTotalSummary();
            txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _datphong_ct.SumByIddp(_idDP)).ToString("N0");
        }
        private void gvDatPhong_RowCountChanged(object sender, EventArgs e)
        {
            //if (count < gvDatPhong.RowCount)
            //    count = gvDatPhong.RowCount;


            //if (gvDatPhong.RowCount < _rowDatPhong && _them == false && _GiamSoPhong == true)//xóa lúc mới sữa dữ liễu đã lưu
            //{

            //    if (MessageBox.Show("Cảnh Báo Dữ Liễu Sẻ Mất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {

            //        MessageBox.Show(_idPhong.ToString());
            //        _phong.updateStatus(_idPhong, false);
            //        _datphong_ct.delete(_idDP, _idPhong);
            //        _datphong_sp.deletAllByPhong(_idDP, _idPhong);
            //        XoaSPDVBy_Idphong(_idPhong);
            //        LoadData();
            //        loadDPSP();
            //        objMain.gControl.Gallery.Groups.Clear();
            //        objMain.showRoom();
            //        btnBoQua.Visible = false;
            //        _rowDatPhong = gvDatPhong.RowCount;
            //    }
            //    else
            //    {
            //        loadDPCT_id();
            //    }

            //}
            //else if (_them == true && _GiamSoPhong == true)//xóa lúc mới thêm dữ liễu chưa lưu
            //{
            //    if (gvDatPhong.RowCount < count)
            //    {

            //        XoaSPDVBy_Idphong(_idPhong);
            //        count = gvDatPhong.RowCount;
            //    }
            //}

            //_GiamSoPhong = false;
            //double t = 0;
            //if (gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue == null)
            //{
            //    t = 0;
            //}
            //else
            //{
            //    t = double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString());
            //}

            //double tienphong = 0;
            //if (_them)
            //{
            //    if (gvDatPhong.Columns["DONGIA"].SummaryItem.SummaryValue == null)
            //    {
            //        tienphong = 0;
            //    }
            //    else
            //    {
            //        tienphong = double.Parse(gvDatPhong.Columns["DONGIA"].SummaryItem.SummaryValue.ToString());
            //    }

            //    txtThanhTien.Text = (tienphong + t).ToString("N0");
            //}
            //else
            //{
            //    txtThanhTien.Text = (_datphong_ct.SumByIddp(_idDP) + t).ToString("N0");
            //}

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var _uRight = _sysRight.getRight(_user.IDUSER, "KHACHHANG");
            if(_uRight.USER_RIGHT.Value==0)
            {
                MessageBox.Show("Bạn không có quyền thao tác", "Thông báo");
                return;
            }    
            frmKhachHang frm = new frmKhachHang(_user, _uRight.USER_RIGHT.Value);
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

            if(gvDanhSach.RowCount>0)
            {
                _datphong = new DATPHONG();
                _idDP = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDDP").ToString());
                var dp = _datphong.GetItem(_idDP, Friend._macty, Friend._madvi);
                cboKhachHang.SelectedValue = dp.IDKH;
                dtNgayDat.Value = dp.NGAYDAT.Value;
                dtNgayTra.Value = dp.NGAYTRA.Value;
                txtGhiChu.Text = dp.GHICHU.ToString();
                cboTrangThai.SelectedValue = dp.STATUS;
                spSoNguoi.Text = dp.SONGUOIO.ToString();
                txtThanhTien.Text = dp.SOTIEN.Value.ToString("N0");
                loadDPCT_id();
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
            for(int i = rowCount-1;i>=0;i--)
            {
                gvSPDV.SelectRow(i);
                gvSPDV.DeleteSelectedRows();
            }    
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
            if(dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtDenNgay.Value = dtNgayTra.Value.AddDays(1);
                return;
            }
            else
              loadLichSu();
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
                loadLichSu();
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
                var dp = _datphong.GetItem(_idDP, Friend._macty, Friend._madvi);
                loadDPCT_id();
                loadSPDV();
                cboKhachHang.SelectedValue = dp.IDKH;
                dtNgayDat.Value = dp.NGAYDAT.Value;               
                dtNgayTra.Value = dp.NGAYTRA.Value;
                txtGhiChu.Text = dp.GHICHU.ToString();
                cboTrangThai.SelectedValue = dp.STATUS;
                spSoNguoi.Text = dp.SONGUOIO.ToString();
                txtThanhTien.Text = dp.SOTIEN.Value.ToString("N0");                           
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
            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            if (_idDP==0)
            {                
                MessageBox.Show("Vui long chọn Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }    
                
            if(_datphong.GetItem(_idDP, Friend._macty, Friend._madvi).STATUS==true&&_them==false)
            {
                Friend.XuatReport("@IDDP", _idDP.ToString(), "PHIEU_DATPHONG", "Phiếu đặt phòng chi tiết");
            }    
            if(!_them)
            {  
                if(_datphong.GetItem(_idDP, Friend._macty, Friend._madvi).STATUS == true)
                {
                    Friend.XuatReport("@IDDP", _idDP.ToString(), "PHIEU_DATPHONG", "Phiếu đặt phòng chi tiết");
                    return;
                }
                if(DateTime.Now>_datphong.GetItem(_idDP, Friend._macty, Friend._madvi).NGAYTRA)
                {
                    if(MessageBox.Show("Hóa đơn có ngày trả nhỏ hơn hoặc bằng ngày hiện tại. Bạn có muốn tiếp tục","Cảnh Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                    {
                     
                        Friend.XuatReport("@IDDP", _idDP.ToString(), "PHIEU_DATPHONG", "Phiếu đặt phòng chi tiết");
                        _datphong.updateStatus(_idDP);
                        _phong.updateStatusBy_IDDP(_idDP, false);
                        cboTrangThai.SelectedValue = true;
                        objMain.gControl.Gallery.Groups.Clear();
                        objMain.showRoom();
                    }
         
                }
               else if (DateTime.Now < _datphong.GetItem(_idDP, Friend._macty, Friend._madvi).NGAYTRA)
                {
                    if (MessageBox.Show("Hóa đơn có ngày trả lớn hơn ngày hiện tại. Bạn có muốn tiếp tục", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                      
                        Friend.XuatReport("@IDDP", _idDP.ToString(), "PHIEU_DATPHONG", "Phiếu đặt phòng chi tiết");
                        _datphong.updateStatus(_idDP);
                        _phong.updateStatusBy_IDDP(_idDP, false);
                        cboTrangThai.SelectedValue = true;
                        objMain.gControl.Gallery.Groups.Clear();
                        objMain.showRoom();
                    }
                }
                else
                {
                    Friend.XuatReport("@IDDP", _idDP.ToString(), "PHIEU_DATPHONG", "Phiếu đặt phòng chi tiết");
                    _datphong.updateStatus(_idDP);
                    _phong.updateStatusBy_IDDP(_idDP, false);
                    cboTrangThai.SelectedValue = true;
                    objMain.gControl.Gallery.Groups.Clear();
                    objMain.showRoom();
                }
                var dp = _datphong.GetItem(_idDP, Friend._macty, Friend._madvi);
                var ct = _datphong_ct.getAllByDatPhong(_idDP);
                TimeSpan t = dp.NGAYTRA.Value - dp.NGAYDAT.Value;
                tb_DatPhong_Phong_NgayO dcn;
                foreach(var i in ct)
                {
                    for (int k = 1; k < t.Days + 2; ++k)
                    {
                        dcn = new tb_DatPhong_Phong_NgayO();
                        dcn.IDDP = dp.IDDP;
                        dcn.MAKY = int.Parse(dp.NGAYDAT.Value.Year.ToString()) * 100 + int.Parse(dp.NGAYDAT.Value.Month.ToString());
                        dcn.IDPHONG = i.IDPHONG;                        
                        dcn.NGAYO = dtNgayDat.Value.AddDays(k);
                        dcn.MACTY = Friend._macty;
                        dcn.MADV = Friend._madvi;
                        _dcn.add(dcn);
                    }
                }
                loadDanhSach();
               
            }    
           objMain._lstphong=_phong.getPhongCheckOut(Friend._macty, Friend._madvi);
        }

        private void dtNgayDat_ValueChanged(object sender, EventArgs e)
        {                      
            update_songayo();
            if (_them)
            {
                loadPhong();
            }
        }
        private void dtNgayTra_ValueChanged(object sender, EventArgs e)
        {
            if(dtNgayTra.Value<dtNgayDat.Value)
            {
                MessageBox.Show("Ngày trả Không hợp lợi vui lòng nhập lại ngày ","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtNgayTra.Value = dtNgayDat.Value.AddDays(1);
            }   
            if(_them)
            {
                loadPhong();

                txtThanhTien.Text = "0";
            }    
            update_songayo();
            
        }

        private void gcDatPhong_TextChanged(object sender, EventArgs e)
        {
            //if(_them)
            //{
            //    txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())
            //        + double.Parse(gvDatPhong.Columns["DONGIA"].SummaryItem.SummaryValue.ToString())).ToString("N0");
            //}    
            //else
            //{
            //    txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())
            //        + double.Parse(gvDatPhong.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())).ToString("N0");
            //}    
            
        }

        private void gvDatPhong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (_them)
            {
                txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())
                    + double.Parse(gvDatPhong.Columns["DONGIA"].SummaryItem.SummaryValue.ToString())).ToString("N0");
            }
          
        }

        private void chuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _idPhong= int.Parse(gvDatPhong.GetFocusedRowCellValue("IDPHONG").ToString());
            var t = _datphong_sp.getItem(_idDP, _idPhong);
            if (t is null)
            {               
                subtract_LSTDP_CT(_idPhong);
            }
            else
            {
                if(MessageBox.Show("Phòng có sản phẩm bạn có muốn xóa không","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    subtract_LSTDP_CT(_idPhong);
                }    
            }    
           
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
 
                    _idDP = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDDP").ToString());
                    var dp = _datphong.GetItem(_idDP, Friend._macty, Friend._madvi);
                    loadDPCT_id();
                    loadSPDV();
                    cboKhachHang.SelectedValue = dp.IDKH;
                    dtNgayDat.Value = dp.NGAYDAT.Value;
                    dtNgayTra.Value = dp.NGAYTRA.Value;
                    txtGhiChu.Text = dp.GHICHU.ToString();
                    cboTrangThai.SelectedValue = dp.STATUS;
                    spSoNguoi.Text = dp.SONGUOIO.ToString();
                    txtThanhTien.Text = dp.SOTIEN.Value.ToString("N0");
                
            }                              
        }


        private void gvLichSu_Click(object sender, EventArgs e)
        {
            if (gvLichSu.RowCount > 0)
            {
                _idDP = int.Parse(gvLichSu.GetFocusedRowCellValue("IDDP").ToString());
                var dp = _datphong.GetItem(_idDP, Friend._macty, Friend._madvi);
                loadDPCT_id();
                loadSPDV();
                cboKhachHang.SelectedValue = dp.IDKH;
                dtNgayDat.Value = dp.NGAYDAT.Value;
                dtNgayTra.Value = dp.NGAYTRA.Value;
                txtGhiChu.Text = dp.GHICHU.ToString();
                cboTrangThai.SelectedValue = dp.STATUS;
                spSoNguoi.Text = dp.SONGUOIO.ToString();
                txtThanhTien.Text = dp.SOTIEN.Value.ToString("N0");
            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.Name=="DISABLED"&& bool.Parse(e.CellValue.ToString())==true)
            {
                Image img = Properties.Resources.delete_icon;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }       
    }
}