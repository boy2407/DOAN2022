﻿using DevExpress.XtraEditors;
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
    public partial class frmSetParam : DevExpress.XtraEditors.XtraForm
    {
        public frmSetParam()
        {
            InitializeComponent();
        }
        CONGTY _congty;
        DONVI _donvi;
        private void frmSetParam_Load(object sender, EventArgs e)
        {
            _donvi = new DONVI();
            _congty = new CONGTY();
            loadCongty();
            
            cboCongty.SelectedIndexChanged += CboCongty_SelectedIndexChanged;
            loadDonvi();
        }

        private void CboCongty_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDonvi();
        }

        void loadCongty()
        {
            cboCongty.DataSource = _congty.getAll();
            cboCongty.DisplayMember = "TENCTY";
            cboCongty.ValueMember = "MACTY";
        }
        void loadDonvi()
        {
            cboDonvi.DataSource = _donvi.getAll(cboCongty.SelectedValue.ToString());
            cboDonvi.DisplayMember = "TENDVI";
            cboDonvi.ValueMember = "MADVI";
            cboDonvi.SelectedIndex = -1;
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string macty = cboCongty.SelectedValue.ToString();
            string madvi = (cboDonvi.Text.Trim() == "") ? "~" : cboDonvi.SelectedValue.ToString();
            SYS_PARAM _sysparam = new SYS_PARAM(macty,madvi);
            _sysparam.SaveFile();
            MessageBox.Show("Xác nhận đơn vị sử dụng thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}