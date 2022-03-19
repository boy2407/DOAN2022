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
using DevExpress.XtraGrid.Views.Grid;

namespace USERMANAGEMENT
{
    public partial class frmPhanQuyeneChucNang : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyeneChucNang()
        {
            InitializeComponent();
        }
        public int _idUser;
        public string _macty;
        public string _madvi;
        SYS_USER _sysUser;
        SYS_RIGHT _sysRight;
        private void frmPhanQuyeneChucNang_Load(object sender, EventArgs e)
        {
            _sysRight = new SYS_RIGHT();
            _sysUser = new SYS_USER();
            gvChucNang.RowStyle += GvChucNang_RowStyle;
            loadUser();
            loadFuncByUser();
        }

        private void GvChucNang_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            
            if(e.RowHandle>=0)
            {
                bool isRed = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, view.Columns["ISGROUP"]));
                 if(isRed)
                 {
                    
                    e.Appearance.BackColor = Color.DeepSkyBlue;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.Font = new Font("Tahoma",12, FontStyle.Bold);
                    
                 }    
            }    
        }

        void loadUser()
        {
            if(_macty==null && _madvi==null)
            {
                gcUser.DataSource = _sysUser.getUserByDVIFunc("CTYME", "~");
                gvUser.OptionsBehavior.Editable = false;
            }
            else
            {
                gcUser.DataSource = _sysUser.getUserByDVIFunc(_macty, _madvi);
                gvUser.OptionsBehavior.Editable = false;
            }    
        }
        void loadFuncByUser()
        {
            VIEW_FUNC_SYS_RIGHT _vFuncRight = new VIEW_FUNC_SYS_RIGHT();
            gcChucNang.DataSource = _vFuncRight.getFuncByUser(_idUser);
            gvChucNang.OptionsBehavior.Editable = false;
            
            for (int i = 0; i < gvUser.RowCount; i++)
            {
                if(int.Parse(gvUser.GetRowCellValue(i,"IDUSER").ToString())==_idUser)
                {
                    gvUser.ClearSelection();
                    gvUser.FocusedRowHandle = i;
                }    
            }
            gvChucNang.ClearSelection();
        }
        private void gvUser_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.Name== "ISGROUP" && bool.Parse(e.CellValue.ToString())==true)
            {
                Image img = Properties.Resources.User_Group_icon;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
            if (e.Column.Name == "ISGROUP" && bool.Parse(e.CellValue.ToString()) == false)
            {
                Image img = Properties.Resources.user_icon;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }

        }

        private void mnCamQuyen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvChucNang.RowCount; i++)
            {
                if (gvChucNang.IsRowSelected(i) && bool.Parse(gvChucNang.GetRowCellValue(i, "ISGROUP").ToString()) == false)
                {
                        _sysRight.update(_idUser, gvChucNang.GetRowCellValue(i, "FUNC_CODE").ToString(), 0);
                    
                }
              
            }
            loadFuncByUser();
        }

        private void mnChiXem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < gvChucNang.RowCount; i++)
            {
               
                if (gvChucNang.IsRowSelected(i)&&bool.Parse(gvChucNang.GetRowCellValue(i, "ISGROUP").ToString())==false)
                {
                    _sysRight.update(_idUser, gvChucNang.GetRowCellValue(i, "FUNC_CODE").ToString(), 1);
                }

            }
            loadFuncByUser();
        }

        private void mnToanQuyen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvChucNang.RowCount; i++)
             {
                if (gvChucNang.IsRowSelected(i) && bool.Parse(gvChucNang.GetRowCellValue(i, "ISGROUP").ToString()) == false)
                {
                        _sysRight.update(_idUser, gvChucNang.GetRowCellValue(i, "FUNC_CODE").ToString(), 2);
                    
                }
            }
            loadFuncByUser();
        }

        private void gcUser_Click(object sender, EventArgs e)
        {
            _idUser = int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString());
            loadFuncByUser();
        }
    }
}