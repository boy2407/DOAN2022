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
namespace KHACHSAN.MyControls
{
    public partial class uDonVi : UserControl
    {
        public uDonVi()
        {
            InitializeComponent();
        }

        CONGTY _congty;
        DONVI _donvi;
        private void uDonVi_Load(object sender, EventArgs e)
        {
            _congty = new CONGTY();
            _donvi = new DONVI();
            loadCongTy();
            loadDonVi();
            cboCongTy.Enabled = false;
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged;
            if (Friend._madvi == "~")
            {
                cboDonVi.Enabled = true;
            }
            else            
            {
                cboDonVi.Enabled = false;
                cboDonVi.SelectedValue = Friend._madvi;
            }
        }

        private void CboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCongTy();
        }

        void loadCongTy()
        {
           
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
            cboCongTy.SelectedValue = Friend._macty;
        }
        void loadDonVi()
        {
            cboDonVi.DataSource = _donvi.getAll(Friend._macty);
            cboDonVi.DisplayMember = "TENDVI";
            cboDonVi.ValueMember = "MADVI";
            
        }
        
    }
}
