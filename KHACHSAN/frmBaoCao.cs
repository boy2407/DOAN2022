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
using KHACHSAN.MyControls;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace KHACHSAN
{
    public partial class frmBaoCao : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }
        public frmBaoCao(tb_SYS_USER user)
        {
            InitializeComponent();
            this._user = user;
        }
        tb_SYS_USER _user;

        SYS_USER _sysUser;
        SYS_REPORT _sysReport;
        SYS_RIGHT_REP _sysRightRep;
        Panel _panel;
        uTuNgay _uTuNgay;
        uCongTy _uCongTy;
        uDonVi _uDonvi;
        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            _sysUser = new SYS_USER();///122
            _sysReport = new SYS_REPORT();
            _sysRightRep = new SYS_RIGHT_REP();
            lstDanhSach.DataSource = _sysReport.getlListByRight(_sysRightRep.getListByUser(_user.IDUSER));
            lstDanhSach.DisplayMember = "DESCRIPTION";
            lstDanhSach.ValueMember = "REP_CODE";
            lstDanhSach.SelectedIndexChanged += LstDanhSach_SelectedIndexChanged;
            loadUserControls();
        }

        private void LstDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUserControls();
        }
        //Lấy giùm tui tài khoản có quyền thao tác
        void loadUserControls()
        {
            tb_SYS_REPORT rep = _sysReport.getItem(int.Parse(lstDanhSach.SelectedValue.ToString()));
            if(_panel!=null)
            {
                _panel.Dispose();
            }
            _panel = new Panel();
            _panel.Dock = DockStyle.Top;
            _panel.MinimumSize = new Size(_panel.Width, 500);

            List<Control> _ctr = new List<Control>();
            if (rep.TUNGAY==true)
            {
                _uTuNgay = new uTuNgay();
                _uTuNgay.Dock = DockStyle.Top;
                _ctr.Add(_uTuNgay);
            }
            if (rep.MACTY == true)
            {
                _uCongTy = new uCongTy();
                _uCongTy.Dock = DockStyle.Top;
                _uCongTy.Width = splBaoCao.Width-20;
                _ctr.Add(_uCongTy);
            }
            if (rep.MADVI == true)
            {
                _uDonvi = new uDonVi();
                
                _uDonvi.Dock = DockStyle.Top;
                _ctr.Add(_uDonvi);
            }
            _ctr.Reverse();
            _panel.Controls.AddRange(_ctr.ToArray());
            this.splBaoCao.Panel2.Controls.Add(_panel);
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            tb_SYS_REPORT rp = _sysReport.getItem(int.Parse(lstDanhSach.SelectedValue.ToString()));

            Form frm = new Form();
            CrystalReportViewer Crv = new CrystalReportViewer();
            Crv.ShowGroupTreeButton = false;
            Crv.ShowParameterPanelButton = false;
            Crv.ToolPanelView = ToolPanelViewType.None;
            TableLogOnInfo Thongtin;
            ReportDocument doc = new ReportDocument();
            doc.Load(System.Windows.Forms.Application.StartupPath + "\\Report\\" + rp.REP_NAME + @".rpt");
            Thongtin = doc.Database.Tables[0].LogOnInfo;
            Thongtin.ConnectionInfo.ServerName = Friend._srv;
            Thongtin.ConnectionInfo.DatabaseName = Friend._db;
            Thongtin.ConnectionInfo.UserID = Friend._us;
            Thongtin.ConnectionInfo.Password = Friend._pw;
            doc.Database.Tables[0].ApplyLogOnInfo(Thongtin);
            if(rp.TUNGAY==true)
            {
                doc.SetParameterValue("@NGAYD", _uTuNgay.dtTuNgay.Value);
                doc.SetParameterValue("@NGAYC", _uTuNgay.dtDenNgay.Value);
            }
            if (rp.MACTY == true)
            {
                doc.SetParameterValue("@MACTY", _uCongTy.cboCongTy.SelectedValue.ToString());                
            }
            if (rp.MADVI == true)
            {
                doc.SetParameterValue("@MACTY", _uCongTy.cboCongTy.SelectedValue.ToString());
                doc.SetParameterValue("@MADVI", _uDonvi.cboDonVi.SelectedValue.ToString());
            }



            Crv.Dock = DockStyle.Fill;
            Crv.ReportSource = doc;
            frm.Controls.Add(Crv);
            Crv.Refresh();
            frm.Text = rp.DESCRIPTION;
           
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
         
        }
    }
}