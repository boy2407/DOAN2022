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
namespace WindowsFormsApp1
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }
        VIEW_PHONGBYNGAY _vphongbyngay;
        PHONG p;
        private void XtraForm1_Load(object sender, EventArgs e)
        {
            _vphongbyngay = new VIEW_PHONGBYNGAY();
            p = new PHONG();
            loadphongByNgayDat(DateTime.Now);
        }
        void loadphongByNgayDat(DateTime time)
        {
            _vphongbyngay = new VIEW_PHONGBYNGAY();
            gridControl1.DataSource = _vphongbyngay.getlistPhongKhongTrungDateTime(time);
            gridView1.ExpandAllGroups();
        }

        private void dtNgayDat_Leave(object sender, EventArgs e)
        {
            
            loadphongByNgayDat(dtNgayDat.Value);
        }
    }
}