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
        PHONG _phong;
        THIETBI _thietbi;
        int _idPhong ;
        int _idTB ;
        bool _them;
        private void frmPhong_ThietBi_Load(object sender, EventArgs e)
        {
            _phong = new PHONG();
            _thietbi = new THIETBI();

            showHideControl(true);
            _enabled(false);
            //searchPhong.TextChanged += SearchPhong_TextChanged;
            cboThietBi.TextChanged += CboThietBi_TextChanged;
            spSoLuong.TextChanged += SpSoLuong_TextChanged;
            loadphong();
            loadthietbi();
            loadDanhSach();

        }
        private void spSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            if (_them && _idTB != 0)
            {
               
                if (spSoLuong.Value > _thietbi.UsebleQuantily(_idTB)) 
                {
                    MessageBox.Show("quá lớn");
                    spSoLuong.Value = 0;
                }
            }
        }
        private void SpSoLuong_TextChanged(object sender, EventArgs e)
        {
           
         
          
        }

        private void CboThietBi_TextChanged(object sender, EventArgs e)
        {          
            if(_them==true)
            {
                _idTB = (int)cboThietBi.SelectedValue;              
            }                  
        }

        private void SearchPhong_TextChanged(object sender, EventArgs e)
        {
            _idPhong = int.Parse(searchPhong.EditValue.ToString());
            

        }

      

        void loadDanhSach()
        {
            gcDanhSach.DataSource = Friend.laydulieu("SELECT A.IDPHONG, A.IDTB, A.SOLUONG, B.TENPHONG, C.TENTB, C.TONGSLN, C.TONGSLX FROM tb_Phong_ThietBi A INNER JOIN tb_Phong B ON A.IDPHONG = B.IDPHONG INNER JOIN tb_ThietBi C ON C.IDTB = A.IDTB ");
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        void loadthietbi()
        {
            _thietbi = new THIETBI();
            cboThietBi.DataSource = _thietbi.getALL();
            cboThietBi.DisplayMember = "TENTB";
            cboThietBi.ValueMember = "IDTB";
        }
        void loadphong()
        {
            _phong = new PHONG();
           searchPhong.Properties.DataSource = _phong.getAll();
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
            _them = true;
            showHideControl(false);
            _enabled(true);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        
    }
}