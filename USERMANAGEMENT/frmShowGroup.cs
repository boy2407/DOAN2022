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
namespace USERMANAGEMENT
{
    public partial class frmShowGroup : DevExpress.XtraEditors.XtraForm
    {
        public frmShowGroup()
        {
            InitializeComponent();
        }
        public string _macty;
        public string _madvi;
        public int _idUser;
        SYS_GROUP _sysGroup;
        VIEW_USER_IN_GROUP _vGroup;

        frmUser objUser = (frmUser)Application.OpenForms["frmUser"];
        private void frmShowGroup_Load(object sender, EventArgs e)
        {
            _sysGroup = new SYS_GROUP();
            _vGroup = new VIEW_USER_IN_GROUP();
            loadGroup();
        }
        void loadGroup()
        {
            gcNhom.DataSource = _vGroup.getGroupByDonVi(_macty, _madvi,_idUser);
            gvNhom.OptionsBehavior.Editable = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(gvNhom.RowCount>0)
            {
                if (_vGroup.CheckGroupByUser(_idUser, int.Parse(gvNhom.GetFocusedRowCellValue("IDUSER").ToString())))
                {
                    MessageBox.Show("Người dùng đã tồn tại trong Nhóm. Vui lòng chọn nhóm khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                tb_SYS_GROUP gr = new tb_SYS_GROUP();
                gr.GROUP = int.Parse(gvNhom.GetFocusedRowCellValue("IDUSER").ToString());
                gr.MENBER = _idUser;
                _sysGroup.add(gr);
                objUser.loadGroupByUser(_idUser);
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