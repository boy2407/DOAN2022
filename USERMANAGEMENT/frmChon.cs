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
    public partial class frmChon : DevExpress.XtraEditors.XtraForm
    {
        public frmChon(tb_SYS_USER admin)
        {
            InitializeComponent();
            this._admin = admin;
        }
        tb_SYS_USER _admin;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (frmMainAdmin frm  = new frmMainAdmin ())
            {
                this.Hide();
                frm.ShowDialog();
            }    
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            using (frmSetParam_admin frm = new frmSetParam_admin(_admin))
            {
                this.Hide();
                frm.ShowDialog();
            }    
        }
    }
}