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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Mask;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _kpct.incurred_KyPhong_CT(Friend._macty,Friend._madvi,_thang,_nam);
            loaddata();
        }

        private void frmKyPhongCT_Load(object sender, EventArgs e)
		{
			string[] thang = {
								 "1",
								 "2",
								 "3",
								 "4",
								 "5",
								 "6",
								 "7",
								 "8",
								 "9",
								 "10",
								 "11",
								 "12",
								 };
			string[] nam = {
				"2022",
				"2023",
				"2024",
				"2025",
				"2026",
				"2027",
				"2028",
				"2029",
				"2030",
				"2031",
				"2032",
				"2033",
				"2034",
				"2035",
			};
			cboNam.DataSource = nam;
			cboThang.DataSource = thang;
			cboNam.Text = _nam.ToString();
			cboThang.Text = _thang.ToString();
			_kpct = new KYPHONG_CT();         
            loaddata();
		

		}
		private void CustomView(int thang, int nam)
		{
			bandedgvDanhSach.RestoreLayoutFromXml(Application.StartupPath + @"\BangKyPhongCT.xml");
			int i;
			foreach (GridColumn gridColumn in bandedgvDanhSach.Columns)
			{
				if (gridColumn.FieldName == "TENPHONG") continue;

				RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
				textEdit.Mask.MaskType = MaskType.RegEx;
				textEdit.Mask.EditMask = @"\p{Lu}+";
				gridColumn.ColumnEdit = textEdit;
			}

			for (i = 1; i <= GetDayNumber(thang, nam); i++)
			{
				DateTime newDate = new DateTime(nam, thang, i);

				GridColumn column = new GridColumn();
				column.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Regular);
				string fieldName = "D" + i;
				
				switch (newDate.DayOfWeek.ToString())
				{
					
					case "Monday":
						column = bandedgvDanhSach.Columns[fieldName];
						column.Caption = "T.Hai " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						//column.Width = 30;
						column.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
						break;

					case "Tuesday":
						column = bandedgvDanhSach.Columns[fieldName];
						column.Caption = "T.Ba " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						column.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
						
						//column.Width = 30;
						break;

					case "Wednesday":
						column = bandedgvDanhSach.Columns[fieldName];
						column.Caption = "T.Tư " + Environment.NewLine + i.ToString();
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						column.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
						//column.Width = 30;
						break;
					case "Thursday":
						column = bandedgvDanhSach.Columns[fieldName];
						column.Caption = "T.Năm " + Environment.NewLine + i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						column.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
						//column.Width = 30;
						break;
					case "Friday":
						column = bandedgvDanhSach.Columns[fieldName];
						column.Caption = "T.Sáu " + Environment.NewLine +i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Blue;
						column.AppearanceHeader.BackColor = Color.Transparent;
						column.AppearanceHeader.BackColor2 = Color.Transparent;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Transparent;
						column.OptionsColumn.AllowFocus = true;
						column.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
						//column.Width = 30;
						break;
					case "Saturday":
						column = bandedgvDanhSach.Columns[fieldName];
						column.Caption = "T.Bảy " + Environment.NewLine +i;
						column.OptionsColumn.AllowEdit = true;
						column.AppearanceHeader.ForeColor = Color.Red;
						column.AppearanceHeader.BackColor = Color.Violet;
						column.AppearanceHeader.BackColor2 = Color.Violet;
						column.AppearanceCell.ForeColor = Color.Black;
						column.AppearanceCell.BackColor = Color.Khaki;
						column.OptionsColumn.AllowFocus = true;
						column.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
						//column.Width = 30;
						break;
					case "Sunday":
                        column = bandedgvDanhSach.Columns[fieldName];
                        column.Caption = "CN " + Environment.NewLine + i;
                        column.OptionsColumn.AllowEdit = false;
                        column.AppearanceHeader.ForeColor = Color.Red;
                        column.AppearanceHeader.BackColor = Color.GreenYellow;
                        column.AppearanceHeader.BackColor2 = Color.GreenYellow;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Orange;
						column.AppearanceHeader.Font = new Font("Tahoma", 9, FontStyle.Bold);
						column.Width = 30;
                        column.OptionsColumn.AllowFocus = false;
						
                        break;
				}
			}

			while (i <= 31)
			{
				bandedgvDanhSach.Columns[i ].Visible = false;
				i++;
			}

		}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
			_nam = int.Parse(cboNam.Text);
			_thang = int.Parse(cboThang.Text);
			loaddata();
        }

        private void btnXem_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
			Form frm = new Form();
			CrystalReportViewer Crv = new CrystalReportViewer();
			Crv.ShowGroupTreeButton = false;
			Crv.ShowParameterPanelButton = false;
			Crv.ToolPanelView = ToolPanelViewType.None;
			TableLogOnInfo Thongtin;
			ReportDocument doc = new ReportDocument();
			doc.Load(System.Windows.Forms.Application.StartupPath + "\\Report\\"  + @"REP_KYPHONGCT.rpt");
			Thongtin = doc.Database.Tables[0].LogOnInfo;
			Thongtin.ConnectionInfo.ServerName = Friend._srv;
			Thongtin.ConnectionInfo.DatabaseName = Friend._db;
			Thongtin.ConnectionInfo.UserID = Friend._us;
			Thongtin.ConnectionInfo.Password = Friend._pw;
			doc.Database.Tables[0].ApplyLogOnInfo(Thongtin);
				
			doc.SetParameterValue("@MACTY",Friend._macty);			
			doc.SetParameterValue("@MADVI",Friend._madvi );
			doc.SetParameterValue("@MAKY", _maky);						
			try
			{
				Crv.Dock = DockStyle.Fill;
				Crv.ReportSource = doc;
				frm.Controls.Add(Crv);
				Crv.Refresh();
				frm.Text = "Bảng Phỏng Tổng Hợp";
				frm.WindowState = FormWindowState.Maximized;
				frm.ShowDialog();
				frm.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi : " + ex.ToString());
			}
		}

        private int GetDayNumber(int thang, int nam)
		{
			int dayNumber = 0;
			switch (thang)
			{
				case 2:
					dayNumber = (nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0 ? 29 : 28;
					break;

				case 4:
				case 6:
				case 9:
				case 11:
					dayNumber = 30;
					break;

				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					dayNumber = 31;
					break;
			}

			return dayNumber;
		}
		void loaddata()
        {
			_maky = _nam * 100 + _thang;
			gcDanhSach.DataSource = _kpct.GetList(_nam * 100 + _thang, Friend._macty, Friend._madvi);			
			CustomView(_thang, _nam);
			bandedgvDanhSach.OptionsBehavior.Editable = false;
		}
    }
}