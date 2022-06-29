using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHACHSAN.MyControls
{
    public partial class uTuNgay : UserControl
    {
        public uTuNgay()
        {
            InitializeComponent();
        }

        private void uTuNgay_Load(object sender, EventArgs e)
        {
            dtTuNgay.Value = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            dtDenNgay.Value = DateTime.Now;
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if(dtTuNgay.Value>dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtTuNgay.Select();
                dtTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtDenNgay.Value = DateTime.Now;
                return;
            }    
        }

        private void dtTuNgay_Leave(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtTuNgay.Select();
                dtTuNgay.Value = dtDenNgay.Value.AddDays(1);
                dtDenNgay.Value = DateTime.Now;
                return;
            }
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtTuNgay.Select();
                dtTuNgay.Value = dtDenNgay.Value.AddDays(1);
                dtDenNgay.Value = DateTime.Now;
                return;
            }
        }

        private void dtDenNgay_Leave(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtTuNgay.Select();
                dtTuNgay.Value = dtDenNgay.Value.AddDays(1);
                dtDenNgay.Value = DateTime.Now; 
                return;
            }
        }
    }
}
