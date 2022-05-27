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
    public partial class frmChuyenPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmChuyenPhong()
        {
            InitializeComponent();
        }
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        public int _iddp, _iddp_ct, _idPhong;        
        public DateTime ngaydat,ngaytra;
        
        PHONG _phong;
        DATPHONG_CT _datphong_ct;
        DATPHONG_SP _datphong_sp;
        DATPHONG _datphong;
        private void frmChuyenPhong_Load(object sender, EventArgs e)
        {
            _phong = new PHONG();
            _datphong_ct = new DATPHONG_CT();
            _datphong_sp = new DATPHONG_SP();
            _datphong = new DATPHONG();
            var p = _phong.getItemFull(_idPhong);
            lblPhongHienTai.Text += p.TENLOAIPHONG + " - Đơn Giá: " + p.DONGIA.Value.ToString("N0");
            loadPhongTrong();
        }
        void loadPhongTrong()
        {
           //searchPhong.Properties.DataSource = _phong.getPhongTrong();
            searchPhong.Properties.DataSource = _phong.PhongHienTai(ngaydat, ngaytra);

            searchPhong.Properties.ValueMember = "IDPHONG";
            searchPhong.Properties.DisplayMember = "TENPHONG";
        }

        private void btnChuyenPhong_Click(object sender, EventArgs e)
        {
            if(searchPhong.EditValue==null||searchPhong.EditValue.ToString()=="")
            {
                MessageBox.Show("Vui lòng chọn phòng muốn chuyển đến. ",
                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            double tongtien = 0;            
            var phonghientai = _datphong_ct.getIDDPByPhong(_idPhong);
            var phongchuyenden = _phong.getItemFull(int.Parse(searchPhong.EditValue.ToString()));

            List<tb_DatPhong_SP> lstDPSP = _datphong_sp.getAllByPhong(_iddp, _iddp_ct);
             foreach(var item in lstDPSP)
            {
                item.IDPHONG = int.Parse(searchPhong.EditValue.ToString());
                tongtien = tongtien + (int.Parse(item.DONGIA.ToString())*int.Parse(item.SOLUONG.ToString()));
                _datphong_sp.update(item);
            }
            var dpct = _datphong_ct.getItem(phonghientai.IDDP,_idPhong);
            dpct.IDPHONG = phongchuyenden.IDPHONG;
            dpct.DONGIA = phongchuyenden.DONGIA;
            dpct.THANHTIEN = dpct.SONGAYO * phongchuyenden.DONGIA;
            _datphong_ct.update(dpct);
            tongtien = double.Parse(dpct.THANHTIEN.ToString()) + tongtien;

            _phong.updateStatus(_idPhong, false);
            _phong.updateStatus(phongchuyenden.IDPHONG, true);
            var dp = _datphong.GetItem(phonghientai.IDDP, Friend._macty, Friend._madvi);
            dp.SOTIEN = _datphong_ct.SumByIddp(_iddp) + _datphong_sp.SumByIddp_Iddp_ct(_iddp, _iddp_ct);
            _datphong.update(dp);
            objMain.gControl.Gallery.Groups.Clear();
            objMain.showRoom();
            this.Close();
        }
    }
}