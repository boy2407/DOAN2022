using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using USERMANAGEMENT.MyComponents;

namespace USERMANAGEMENT
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        MyTreeViewComBo _treeView;
        CONGTY _congty;
        DONVI _donvi;
        string _macty;
        string _madvi;
        bool _isRoot;
        SYS_USER _sysUser;
        private void frmMain_Load(object sender, EventArgs e)
        {
            _sysUser = new SYS_USER();
            _congty = new CONGTY();
            _donvi = new DONVI();
            _isRoot = true;
            loadTreeView();
            loadUser("CTYME","~");
        }
         public void loadUser(string macty,string madvi)
        {
            _sysUser = new SYS_USER();
            gcUser.DataSource = _sysUser.getUserByDVI(macty,madvi);
            gvUser.OptionsBehavior.Editable = false;
        }
        void loadTreeView()
        {
            _treeView = new MyTreeViewComBo(pnNhom.Width,300);
            _treeView.Font = new Font("Tahoma", 10, FontStyle.Bold);
            var lstCTY = _congty.getAll();
         
            foreach(var item in lstCTY)
            {
                TreeNode parentNode = new TreeNode();
                parentNode.Text = item.MACTY + " - " + item.TENCTY;
                parentNode.Tag = item.MACTY;
                parentNode.Name = item.MACTY;
               
                _treeView.TreeView.Nodes.Add(parentNode);
                foreach (var dv in _donvi.getAll(item.MACTY))
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = dv.MADVI + " - " + dv.TENDVI;
                    childNode.Tag = dv.MACTY+"."+dv.MADVI;
                    childNode.Name = dv.MACTY + "." + dv.MADVI;
                   
                    _treeView.TreeView.Nodes[parentNode.Name].Nodes.Add(childNode);
                } 
                    
            }
            
            _treeView.TreeView.ExpandAll();
            pnNhom.Controls.Add(_treeView);
            _treeView.Width = pnNhom.Width;
            _treeView.Height = pnNhom.Height;
            _treeView.TreeView.AfterSelect += TreeView_AfterSelect;
            _treeView.TreeView.Click += TreeView_Click;
        }

        private void TreeView_Click(object sender, EventArgs e)
        {
            _treeView.dropDown.Focus();
            _treeView.SelectAll();
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _treeView.Text = _treeView.TreeView.SelectedNode.Text;
            if(_treeView.TreeView.SelectedNode.Parent==null)
            {
                _isRoot = true;
                _macty = _treeView.TreeView.SelectedNode.Tag.ToString();
                _madvi = "~";//cấp ngồi trung tâm
            }  
            else
            {
                _isRoot = false;
                int position = _treeView.TreeView.SelectedNode.Name.IndexOf(".");
                _macty = _treeView.TreeView.SelectedNode.Name.Substring(0,position);
                _madvi = _treeView.TreeView.SelectedNode.Name.Substring(position + 1);
            }
            loadUser(_macty, _madvi);
            _treeView.dropDown.Close();

        }
         private  void addGroup()
        {
            if (_treeView.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn vị.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            frmGroup frm = new frmGroup();
            frm._them = true;
            frm._macty = _macty;
            frm._madvi = _madvi;
            frm.ShowDialog();
        }
        private void addUser()
        {
            if (_treeView.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đơn vị.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            frmUser frm = new frmUser();
            frm._them = true;
            frm._macty = _macty;
            frm._madvi = _madvi;



            frm.ShowDialog();
        }
        private void updateInfor()
        {
            if (gvUser.RowCount > 0 && gvUser.GetFocusedRowCellValue("ISGROUP").Equals(true))
            {
                if (gvUser.GetFocusedRowCellValue("DISABLED").Equals(true))
                {
                    if (MessageBox.Show("Nhóm người Dùng đã bị vô hiệu hóa bạn có muốn tiếp tục", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        frmGroup frm = new frmGroup();
                        frm._them = false;
                        frm._idUser = int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString());
                        frm.ShowDialog();
                    }
                }
                else
                {
                    frmGroup frm = new frmGroup();
                    frm._them = false;
                    frm._idUser = int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString());
                    frm.ShowDialog();
                }    

            }
            else if (gvUser.RowCount > 0 && gvUser.GetFocusedRowCellValue("ISGROUP").Equals(false))
            {
                if (gvUser.GetFocusedRowCellValue("DISABLED").Equals(true))
                {
                    if (MessageBox.Show("Người Dùng đã bị vô hiệu hóa bạn có muốn tiếp tục", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        frmUser frm = new frmUser();
                        frm._them = false;
                        frm._idUser = int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString());
                        frm.ShowDialog();
                    }
                }
                else
                {
                    frmUser frm = new frmUser();
                    frm._them = false;
                    frm._idUser = int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString());
                    frm.ShowDialog();
                }    

            }
            else
            {
                MessageBox.Show("Hiện tại không có người dùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void chucnang()
        {
            if (gvUser.RowCount > 0)
            {
                tb_SYS_USER i = _sysUser.getItem(int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString()));
                if (i.DISABLED == true)
                {
                    MessageBox.Show("Vui lòng chọn Người Dùng khác. Người Dùng đã bị vô hiệu hóa!.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmPhanQuyeneChucNang frm = new frmPhanQuyeneChucNang();
                frm._idUser = int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString());
                frm._macty = _macty;
                frm._madvi = _madvi;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hiện tại không có người dùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void baocao()
        {
            if (gvUser.RowCount > 0)
            {
                tb_SYS_USER i = _sysUser.getItem(int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString()));
                if (i.DISABLED == true)
                {
                    MessageBox.Show("Vui lòng chọn Người Dùng khác. Người Dùng đã bị vô hiệu hóa!.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                frmPhanQuyenBaoCao frm = new frmPhanQuyenBaoCao();
                frm._idUser = int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString());
                frm._macty = _macty;
                frm._madvi = _madvi;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hiện tại không có người dùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private void btnNhomNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addGroup();
        }

        private void btnNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addUser();
        }

        private void btnCapNhatThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateInfor();
        }

        private void btnPQChucNang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang();

        }

        private void btnPQBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            baocao();
        }

        private void gvUser_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.Column.Name=="ISGROUP"&&bool.Parse(e.CellValue.ToString())==true)
            {
               
                e.Graphics.DrawImage(imageList1.Images[1], e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }    
            else if (e.Column.Name == "ISGROUP" && bool.Parse(e.CellValue.ToString()) == false)
            {
                e.Graphics.DrawImage(imageList1.Images[0], e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }    
        }

        private void gvUser_DoubleClick(object sender, EventArgs e)
        {
            if(gvUser.RowCount >0&&gvUser.GetFocusedRowCellValue("ISGROUP").Equals(true))
            {
                frmGroup frm = new frmGroup();
                frm._them = false;
                frm._idUser = int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString());
                frm.ShowDialog();
            }    
            else
            {
                frmUser frm = new frmUser();
                frm._them = false;
                frm._idUser = int.Parse(gvUser.GetFocusedRowCellValue("IDUSER").ToString());
                frm.ShowDialog();
            }    
        }

       

        private void thêmNhómToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvUser.RowCount; i++)
            {
                if (gvUser.IsRowSelected(i))
                {
                    addGroup();
                }

            }
           
        }

        private void thêmNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvUser.RowCount; i++)
            {
                if (gvUser.IsRowSelected(i))
                {
                    addUser();
                }

            }
            
        }

        private void phânQuyềnChứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvUser.RowCount; i++)
            {
                if (gvUser.IsRowSelected(i))
                {
                    chucnang();
                }

            }
        }

        private void phânQuyềnBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvUser.RowCount; i++)
            {
                if (gvUser.IsRowSelected(i))
                {
                    baocao();
                }

            }
        }

        private void mnCapNhat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvUser.RowCount; i++)
            {
                if (gvUser.IsRowSelected(i))
                {
                    updateInfor();
                }

            }
        }
    }
}
