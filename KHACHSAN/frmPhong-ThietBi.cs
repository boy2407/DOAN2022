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
    public partial class frmPhong_ThietBi : DevExpress.XtraEditors.XtraForm
    {
        public frmPhong_ThietBi()
        {
            InitializeComponent();
        }
        public frmPhong_ThietBi(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
        tb_SYS_USER _user;
        int _right;
        PHONG _phong;
        THIETBI _thietbi;
        PHONG_THIETBI _phong_thietbi;
        int _idPhong ;
        int _idTB ;
        bool _them;
        private void frmPhong_ThietBi_Load(object sender, EventArgs e)
        {
            _phong = new PHONG();
            _thietbi = new THIETBI();
            _phong_thietbi = new PHONG_THIETBI();
            showHideControl(true);
            _enabled(false);
            searchPhong.TextChanged += SearchPhong_TextChanged;
            cboThietBi.TextChanged += CboThietBi_TextChanged;
            spSoLuong.EditValueChanged += SpSoLuong_EditValueChanged;
            loadphong();
            loadthietbi();
            loadDanhSach();
            cboThietBi.SelectedIndex = 0;
            _idTB = int.Parse(cboThietBi.SelectedValue.ToString());

        }

        private void SpSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            if (spSoLuong.Value < 0)
            {
                MessageBox.Show("quá nhỏ");
                spSoLuong.EditValue = 0;
                return;
            }
            if (_them && _idTB != 0)
            {

                if (spSoLuong.Value > _thietbi.UsebleQuantily(_idTB))
                {
                    MessageBox.Show("quá lớn");
                    spSoLuong.EditValue = 0;
                }
            }
        }

     
        private void CboThietBi_TextChanged(object sender, EventArgs e)
        {          
            if(_them==true)
            {
                
                _idTB = (int)cboThietBi.SelectedValue;
                MessageBox.Show(_idTB.ToString());
            }                  
        }

        private void SearchPhong_TextChanged(object sender, EventArgs e)
        {
            _idPhong = int.Parse(searchPhong.EditValue.ToString());
            loadDanhSach();          
        }

        void savedata()
        {
            if(_them)
            {

                tb_Phong_ThietBi ptb = new tb_Phong_ThietBi();

                ptb = _phong_thietbi.getItem(_idPhong,int.Parse(cboThietBi.SelectedValue.ToString()));
                if(ptb==null)
                {
                    ptb = new tb_Phong_ThietBi();
                    ptb.SOLUONG = (int)spSoLuong.Value;
                    ptb.IDPHONG = _idPhong;
                    ptb.IDTB = int.Parse(cboThietBi.SelectedValue.ToString());
                    _phong_thietbi.add(ptb);

                    tb_ThietBi tb = _thietbi.getItem(_idTB);
                    tb.TONGSLX = tb.TONGSLX + (int)spSoLuong.Value;
                    _thietbi.update(tb);
                }   
                else
                {
                    MessageBox.Show("Phòng có thiết bị vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
                           
            }    
            else
            {

                int temp;
                tb_ThietBi tb = _thietbi.getItem(_idTB);             
                tb_Phong_ThietBi ptb = new tb_Phong_ThietBi();
                ptb = _phong_thietbi.getItem(_idPhong, _idTB);
                if (ptb.SOLUONG< (int)spSoLuong.Value)
                {
                     temp = (int)((int)spSoLuong.Value - ptb.SOLUONG);
                    tb.TONGSLX = temp + tb.TONGSLX;
                }    
                else
                {
                    temp = ((int)(ptb.SOLUONG - (int)spSoLuong.Value));
                    tb.TONGSLX = tb.TONGSLX - temp;
                }
                
                ptb.SOLUONG = (int)spSoLuong.Value;            
                _phong_thietbi.update(ptb);
                _thietbi.update(tb);
            }    
        }    

        void loadDanhSach()
        {
            //gcDanhSach.DataSource = Friend.laydulieu("SELECT A.IDPHONG, A.IDTB, A.SOLUONG, B.TENPHONG, C.TENTB, C.TONGSLN, C.TONGSLX FROM tb_Phong_ThietBi A INNER JOIN tb_Phong B ON A.IDPHONG = B.IDPHONG INNER JOIN tb_ThietBi C ON C.IDTB = A.IDTB WHERE A.IDPHONG= '"+_idPhong+"'");
            gcDanhSach.DataSource = _phong_thietbi.getALLByIDPHONG(_idPhong);             
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadthietbi()
        {
            _thietbi = new THIETBI();
            cboThietBi.DataSource = _thietbi.getALL(Friend._macty,Friend._madvi);
            cboThietBi.DisplayMember = "TENTB";
            cboThietBi.ValueMember = "IDTB";
        }
        void loadphong()
        {
            _phong = new PHONG();
           searchPhong.Properties.DataSource = _phong.getAll(Friend._macty,Friend._madvi);
           searchPhong.Properties.DisplayMember = "TENPHONG";
           searchPhong.Properties.ValueMember = "IDPHONG";
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
            cboThietBi.Enabled = t;
            spSoLuong.Enabled = t;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (searchPhong.EditValue == null || searchPhong.EditValue.ToString() == "")
            {
                MessageBox.Show("Vui Lòng phòng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _them = true;
            showHideControl(false);
            _enabled(true);
            spSoLuong.Value = 0;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_idTB==0)
            {
                MessageBox.Show("Vui lòng chọn thiết bị đã có trong phòng");
                return;
            }    
            _them = false;
            showHideControl(false);
            _enabled(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Bạn không có quyền thao tác?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _phong_thietbi.delete(_idPhong,_idTB);
                loadDanhSach();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (spSoLuong.Value > _thietbi.UsebleQuantily(_idTB))
            {
                MessageBox.Show("quá lớn");
                spSoLuong.EditValue = 0;
                return;
            }
            savedata();
            loadDanhSach();
            showHideControl(true);
            _enabled(false);
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

        private void gcDanhSach_Click(object sender, EventArgs e)
        {

        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _idPhong = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDPHONG").ToString());
                _idTB = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDTB").ToString());
                cboThietBi.SelectedValue = int.Parse(gvDanhSach.GetFocusedRowCellValue("IDTB").ToString());
                spSoLuong.Value = (decimal)_phong_thietbi.getItem(_idPhong, _idTB).SOLUONG;
            }
        }

        private void spSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (spSoLuong.Value > _thietbi.UsebleQuantily(_idTB))
                {
                    MessageBox.Show("quá lớn");
                    spSoLuong.EditValue = 0;
                    return;
                }
                savedata();
                loadDanhSach();
                showHideControl(true);
                _enabled(false);
            }    
        }
    }
}