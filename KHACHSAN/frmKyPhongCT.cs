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
namespace KHACHSAN
{
    public partial class frmKyPhongCT : DevExpress.XtraEditors.XtraForm
    {
        public frmKyPhongCT()
        {
            InitializeComponent();
        }
        public int _thang, _nam,_maky;
        KYPHONG_CT _kpct;


        private void frmKyPhongCT_Load(object sender, EventArgs e)
        {
            _kpct = new KYPHONG_CT();         
            loaddata();
        }
        void loaddata()
        {
            gcDanhSach.DataSource = _kpct.GetList(_nam * 100 + _thang, Friend._macty, Friend._madvi);
        }
    }
}