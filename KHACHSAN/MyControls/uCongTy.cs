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
namespace KHACHSAN.MyControls
{
    public partial class uCongTy : UserControl
    {
        public uCongTy()
        {
            InitializeComponent();
        }

        private void uCongTy_Load(object sender, EventArgs e)
        {
            CONGTY _congty = new CONGTY();
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
            cboCongTy.SelectedValue = Friend._macty;
        }
    }
}
