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
namespace USERMANAGEMENT
{
    public partial class frmShowMenbers : DevExpress.XtraEditors.XtraForm
    {
        public frmShowMenbers()
        {
            InitializeComponent();
        }
        public string _macty;
        public string _madvi;
        public int _idGroup;
        SYS_GROUP _sysGroup;
        VIEW_USER_NOTIN_GROUP _vNotGroup;
        VIEW_USER_IN_GROUP _vUserNotInGroup;
        frmGroup objGroup = (frmGroup)Application.OpenForms["frmGroup"];
        private void frmShowMenbers_Load(object sender, EventArgs e)
        {
            
            _vNotGroup = new VIEW_USER_NOTIN_GROUP();
            _vUserNotInGroup = new VIEW_USER_IN_GROUP();
            _sysGroup = new SYS_GROUP();
            loadUserNotInGroup();
        }
        void loadUserNotInGroup()
        {
            gcThanhVien.DataSource = _vUserNotInGroup.getUserNotInGroup(_macty, _madvi,_idGroup);
            gvThanhVien.OptionsBehavior.Editable = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (gvThanhVien.RowCount > 0)
            {
                tb_SYS_GROUP gr = new tb_SYS_GROUP();
                gr.GROUP = _idGroup;
                gr.MENBER = int.Parse(gvThanhVien.GetFocusedRowCellValue("IDUSER").ToString());
                _sysGroup.add(gr);
                objGroup.loadUserInGroup(_idGroup);
                this.Close();
            }
            else
            {
                MessageBox.Show("Chưa có Nhóm người dùng trong Công Ty - Dơn vị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}