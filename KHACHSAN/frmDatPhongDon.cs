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
namespace KHACHSAN
{
    public partial class frmDatPhongDon : DevExpress.XtraEditors.XtraForm
    {
        public frmDatPhongDon()
        {
            InitializeComponent();
        }
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
      public  bool _them;
        public int _idPhong;
        int _idDP=0;
        string _madvi;
        string _macty;
        DATPHONG _datphong;
        DATPHONG_CT _datphong_ct;
        DATPHONG_SP _datphong_sp;
        OBJ_PHONG _phonghientai;
        PHONG _phong;
        KHACHHANG _khachhang;
        SANPHAM _sanpham;
        List<OBJ_DPSP> lstDPSP;
        
        double _tongtien = 0;
        private void XoaSPDVBy_Idsp(int idsp)
        {

            foreach (var item in lstDPSP)
            {

                if (item.IDSP == idsp)
                {
                    lstDPSP.Remove(item);
                    loadDPSP();
                    return;
                }
            }

        }
         double checkforRoombyday(DateTime checkin, DateTime checkout)
        {

            return checkout.Subtract(checkin).Days / (365.25 / 12) ;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (searchKH.EditValue == null || searchKH.EditValue.ToString() == "")
            {
                MessageBox.Show("Vui Lòng Chọn Khách Hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            saveData();
            //_tongtien = (double)(double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + 
            //    _phong.getItemFull(_idPhong).DONGIA*(dtNgayTra.Value.Day- dtNgayDat.Value.Day));
            TimeSpan s = dtNgayTra.Value - dtNgayDat.Value;
            _tongtien = (double)(double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + 
                (_phong.getItemFull(_idPhong).DONGIA * s.Days));

            var dp = _datphong.GetItem(_idDP);
            dp.SOTIEN = _tongtien;
            _datphong.update(dp);
            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
            txtThanhTien.Text = dp.SOTIEN.Value.ToString("N0");
            btnSua.Visible = true;
            btnLuu.Visible = false;
            _enabled(false);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if(!_them)
            {
                if (DateTime.Now > _datphong.GetItem(_idDP).NGAYTRA)
                {
                    if (MessageBox.Show("Hóa đơn có ngày trả nhỏ hơn hoặc bằng ngày hiện tại. Bạn có muốn tiếp tục", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                       
                        _datphong.updateStatus(_idDP);
                        _phong.updateStatus(_idPhong, false);
                        Friend.XuatReport("@IDDP", _idDP.ToString(), "PHIEU_DATPHONGDON", "Phiếu đặt phòng chi tiết");
                        cboTrangThai.SelectedValue = true;
                        objMain.gControl.Gallery.Groups.Clear();
                        objMain.showRoom();
                    }
                }
              else  if (DateTime.Now < _datphong.GetItem(_idDP).NGAYTRA)
                {
                    if (MessageBox.Show("Hóa đơn có ngày trả lớn hơn ngày hiện tại. Bạn có muốn tiếp tục", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                       
                        _datphong.updateStatus(_idDP);
                        _phong.updateStatus(_idPhong, false);
                        Friend.XuatReport("@IDDP", _idDP.ToString(), "PHIEU_DATPHONGDON", "Phiếu đặt phòng chi tiết");
                        cboTrangThai.SelectedValue = true;
                        objMain.gControl.Gallery.Groups.Clear();
                        objMain.showRoom();
                    }
                }
                else
                {
                    _datphong.updateStatus(_idDP);
                    _phong.updateStatus(_idPhong, false);
                    Friend.XuatReport("@IDDP", _idDP.ToString(), "PHIEU_DATPHONGDON", "Phiếu đặt phòng chi tiết");
                    cboTrangThai.SelectedValue = true;
                    objMain.gControl.Gallery.Groups.Clear();
                    objMain.showRoom();
                }

                _enabled(false);
                btnSua.Visible = false;
                btnLuu.Visible = false;

            }    
          
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                dp.THEODOAN = false;
                dp.IDKH = int.Parse(searchKH.EditValue.ToString());
                dp.SOTIEN = double.Parse(txtThanhTien.Text);
                dp.GHICHU = txtGhiChu.Text;
                dp.UID = 1;
                dp.DISABLED = false;
                dp.CREATED_DATE = DateTime.Now;
                dp.MACTY = _macty;
                dp.MADVI = _madvi;

                var _dp = _datphong.add(dp);
                _idDP = _dp.IDDP;
               
                    dpct = new tb_DatPhong_CT();
                    dpct.IDDP = _dp.IDDP;
                    dpct.IDPHONG = _idPhong;
                //dpct.SONGAYO = dtNgayTra.Value.Day - dtNgayDat.Value.Day;
                TimeSpan s = dtNgayTra.Value - dtNgayDat.Value;
                dpct.SONGAYO = s.Days;
                    dpct.DONGIA = _phonghientai.DONGIA;
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
            
            else if (_them == false)
            {
             
                
             
                    tb_DatPhong dp = _datphong.GetItem(_idDP);
                    tb_DatPhong_CT dpct;
                    tb_DatPhong_SP dpsp;

                    dp.NGAYDAT = dtNgayDat.Value;
                    dp.NGAYTRA = dtNgayTra.Value;
                    dp.SONGUOIO = int.Parse(spSoNguoi.EditValue.ToString());
                    dp.STATUS = bool.Parse(cboTrangThai.SelectedValue.ToString());
                    dp.IDKH = int.Parse(searchKH.EditValue.ToString());
                    dp.SOTIEN = double.Parse(txtThanhTien.Text);
                    dp.GHICHU = txtGhiChu.Text;
                    dp.UID = 1;
                    dp.UPDATE_BY = 1;
                    dp.UPDATE_DATE = DateTime.Now;
                    var _dp = _datphong.update(dp);

                    _datphong_ct.deleteAll(_idDP);
                    _datphong_sp.deleteAll(_idDP);

                    dpct = new tb_DatPhong_CT();
                    dpct.IDDP = _dp.IDDP;
                    dpct.IDPHONG = _idPhong;
                  TimeSpan s = dtNgayTra.Value - dtNgayDat.Value;
                //dpct.SONGAYO = dtNgayTra.Value.Day - dtNgayDat.Value.Day;
                dpct.SONGAYO = s.Days;
                     dpct.DONGIA = _phonghientai.DONGIA;
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
        private void frmDatPhongDon_Load(object sender, EventArgs e)
        {
            _datphong = new DATPHONG();
            _datphong_ct = new DATPHONG_CT();
            _datphong_sp = new DATPHONG_SP();
            _phong = new PHONG();
            lstDPSP = new List<OBJ_DPSP>();
            _sanpham = new SANPHAM();
            btnSua.Visible = false;
            _phonghientai = _phong.getItemFull(_idPhong);
            string dongia = _phonghientai.DONGIA.Value.ToString("N0");
            lblPhong.Text = _phonghientai.TENPHONG+" - Đơn giá: "+ dongia + "VNĐ";

            _macty = Friend._macty;
            _madvi = Friend._madvi;
            dtNgayDat.Enabled = false;
            dtNgayDat.Value = DateTime.Now;
            dtNgayTra.Value = DateTime.Now.AddDays(1);
            txtThanhTien.Enabled = false;
            txtThanhTien.Text = _phonghientai.DONGIA.Value.ToString("N0");
            cboTrangThai.DataSource = TRANGTHAI.getList();
            cboTrangThai.ValueMember = "_value";
            cboTrangThai.DisplayMember = "_display";
            spSoNguoi.Text = "1";
           
            loadKH();
            loadSP();
            var dpct = _datphong_ct.getIDDPByPhong(_idPhong);
            if(!_them &&dpct!=null)
            {
                _idDP = (int)dpct.IDDP;
                var dp = _datphong.GetItem(_idDP);
                searchKH.EditValue = dp.IDKH;
                dtNgayDat.Value = dp.NGAYDAT.Value;
                dtNgayTra.Value = dp.NGAYTRA.Value;
                cboTrangThai.SelectedValue = dp.STATUS;
                spSoNguoi.Text = dp.SONGUOIO.ToString();
                txtGhiChu.Text = dp.GHICHU.ToString();
                txtThanhTien.Text = dp.SOTIEN.Value.ToString("N0");
                
            }
            loadSPDV();
        }
        void loadSPDV()
        {
           
            
                gcSPDV.DataSource = _datphong_sp.getAllByDatPhong(_idDP);
                lstDPSP = _datphong_sp.getAllByDatPhong(_idDP);
            

        }
        void loadSP()
        {
             gcSanPham.DataSource = _sanpham.getAll();
              gvSanPham.OptionsBehavior.Editable = false;
         
        }
      public  void loadKH()
        {
            _khachhang = new KHACHHANG();
            searchKH.Properties.DataSource = _khachhang.getAll();
            searchKH.Properties.ValueMember = "IDKH";
            searchKH.Properties.DisplayMember = "HOTEN";
        }
      
        public void setKH(int idkh)
        {
           
            searchKH.EditValue = idkh;
          
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.kh_dp = "datphongdon";
            frm.ShowDialog();
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
        private void gvSanPham_DoubleClick(object sender, EventArgs e)
        {
            TimeSpan s = dtNgayTra.Value - dtNgayDat.Value;
            if (_idPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(bool.Parse(cboTrangThai.SelectedValue.ToString())==true)
            {
                MessageBox.Show("Phiếu đã hoàn tất không được chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if (gvSanPham.GetFocusedRowCellValue("IDSP") != null)
            {
               
                OBJ_DPSP sp = new OBJ_DPSP();
                sp.IDSP = int.Parse(gvSanPham.GetFocusedRowCellValue("IDSP").ToString());
                sp.TENSP = gvSanPham.GetFocusedRowCellValue("TENSP").ToString();
                sp.IDPHONG = _idPhong;
                sp.TENPHONG = _phonghientai.TENPHONG;
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
                        txtThanhTien.Text = ((double)(double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _phonghientai.DONGIA*s.Days)).ToString("N0");
                        return;
                    }
                }
                lstDPSP.Add(sp);
            }
            loadDPSP();

            txtThanhTien.Text = ((double)(double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _phonghientai.DONGIA*s.Days)).ToString("N0");
        }

        private  void XoaSPDV(int idsp)
        {
            if(!_them)
            {
                foreach (var item in lstDPSP)
                {                  
                    if (item.IDSP==idsp)
                    {
                        lstDPSP.Remove(item);
                        loadDPSP();
                        return;
                    }
                }
            }    
            
        }
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
                    double gia = double.Parse(gvSPDV.GetRowCellValue(gvSPDV.FocusedRowHandle, "DONGIA").ToString());
                    if (sl < 1)
                    {
                        MessageBox.Show("Vui lòng nhập số lượng");

                        gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "SOLUONG", 1);
                        gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "THANHTIEN", gia);
                        return;

                    }
                    gvSPDV.SetRowCellValue(gvSPDV.FocusedRowHandle, "THANHTIEN", sl * gia);
                }
                gvSPDV.UpdateTotalSummary();///update lại sum 

                TimeSpan s = dtNgayTra.Value - dtNgayDat.Value;
                    txtThanhTien.Text = ((double)(double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _phonghientai.DONGIA *s.Days)).ToString("N0");
                

            }
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaSPDVBy_Idsp(int.Parse(gvSPDV.GetRowCellValue(gvSPDV.FocusedRowHandle, "IDSP").ToString()));
            gvSPDV.UpdateTotalSummary();
          
            
                txtThanhTien.Text = (double.Parse(gvSPDV.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + _datphong_ct.SumByIddp(_idDP)).ToString("N0");
              
           
        }
        private void gvSPDV_HiddenEditor(object sender, EventArgs e)
        {
            gvSPDV.UpdateCurrentRow();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Visible = true;
            btnSua.Visible = false;
            _enabled(true);
        }
        void _enabled(bool t)
        {
            searchKH.Enabled = t;
            btnAddNew.Enabled = t;
            dtNgayDat.Enabled = t;
            dtNgayTra.Enabled = t;
            cboTrangThai.Enabled = t;

            spSoNguoi.Enabled = t;
            txtGhiChu.Enabled = t;           
            gcSPDV.Enabled = t;
            gcSanPham.Enabled = t;
        }

        
    }


}