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

namespace KHACHSAN
{
    public partial class frmKyPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmKyPhong()
        {
            InitializeComponent();
        }
		public KYPHONG_CT _kpct;

		bool _them;
		KYPHONG _kyphong;
		int _maky;
		private void frmPhongTrongTuan_Load(object sender, EventArgs e)
		{
			_them = true;
			_kyphong = new KYPHONG();
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

			cboNam.Text = DateTime.Now.Year.ToString();
			cboNam.DataSource = nam;
			cboThang.DataSource = thang;
			cboThang.Text = DateTime.Now.Month.ToString();
			
			loadData();
			showHideControl(true);
			_enabled(false);
			//CustomView(_thang,_nam);
		}
		void showHideControl(bool t)
		{
			btnThem.Visible = t;
			btnThongKe.Visible = t;
			btnSua.Visible = t;
			btnXoa.Visible = t;
			btnThoat.Visible = t;
			btnLuu.Visible = !t;
			btnBoQua.Visible = !t;
		}
		void _enabled(bool t)
		{
			cboNam.Enabled = t;
			cboThang.Enabled = t;
		}


		void savedata()
        {
			if (_them == true)
			{
				var i = _kyphong.getItem(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text),Friend._macty,Friend._madvi);
				if (i!=null)
				{
					MessageBox.Show("Mã Kỳ đã tồn tại .Vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);				
					return;
				}
				tb_KyPhong ky = new tb_KyPhong();
				ky.MAKY = int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text);
				ky.MACTY = Friend._macty;
				ky.MADV = Friend._madvi;
				ky.NGAY = DateTime.Now;
				ky.THANG = int.Parse(cboThang.Text);
				ky.NAM = int.Parse(cboNam.Text);
				ky.SONGAY = Friend.laySoNgayCuaThang(int.Parse(cboThang.Text), int.Parse(cboThang.Text));
				_kyphong.add(ky);
			}
			else
			{
				tb_KyPhong ky = _kyphong.getItem(_maky,Friend._macty,Friend._madvi);
				ky.NGAY = DateTime.Now;
				ky.THANG = int.Parse(cboThang.Text);
				ky.NAM = int.Parse(cboNam.Text);
				ky.SONGAY = Friend.laySoNgayCuaThang(int.Parse(cboThang.Text), int.Parse(cboThang.Text));
				_kyphong.update(ky);
			}
			
			_them = false;
						
			showHideControl(true);
		}
      
		//private void CustomView(int thang, int nam)
		//{
		//	//gvDanhSach.RestoreLayoutFromXml(Application.StartupPath + @"\BangCong_Layout.xml");
		//	int i;
		//	foreach (GridColumn gridColumn in gvDanhSach.Columns)
		//	{
		//		if (gridColumn.FieldName == "TENPHONG") continue;

		//		RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
		//		textEdit.Mask.MaskType = MaskType.RegEx;
		//		textEdit.Mask.EditMask = @"\p{Lu}+";
		//		gridColumn.ColumnEdit = textEdit;
		//	}

		//	for (i = 1; i <= GetDayNumber(thang, nam); i++)
		//	{
		//		DateTime newDate = new DateTime(nam, thang, i);

		//		GridColumn column = new GridColumn();
		//		column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
		//		string fieldName = "D" + i;
		//		switch (newDate.DayOfWeek.ToString())
		//		{
		//			case "Monday":
		//				column = gvDanhSach.Columns[fieldName];
		//				column.Caption = "T.Hai " + Environment.NewLine + i;
		//				column.OptionsColumn.AllowEdit = true;
		//				column.AppearanceHeader.ForeColor = Color.Blue;
		//				column.AppearanceHeader.BackColor = Color.Transparent;
		//				column.AppearanceHeader.BackColor2 = Color.Transparent;
		//				column.AppearanceCell.ForeColor = Color.Black;
		//				column.AppearanceCell.BackColor = Color.Transparent;
		//				column.OptionsColumn.AllowFocus = true;
		//				//column.Width = 30;
		//				//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
		//				break;

		//			case "Tuesday":
		//				column = gvDanhSach.Columns[fieldName];
		//				column.Caption = "T.Ba " + Environment.NewLine + i;
		//				column.OptionsColumn.AllowEdit = true;
		//				column.AppearanceHeader.ForeColor = Color.Blue;
		//				column.AppearanceHeader.BackColor = Color.Transparent;
		//				column.AppearanceHeader.BackColor2 = Color.Transparent;
		//				column.AppearanceCell.ForeColor = Color.Black;
		//				column.AppearanceCell.BackColor = Color.Transparent;
		//				column.OptionsColumn.AllowFocus = true;
		//				//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
		//				//column.Width = 30;
		//				break;

		//			case "Wednesday":
		//				column = gvDanhSach.Columns[fieldName];
		//				column.Caption = "T.Tư " + Environment.NewLine + i;
		//				column.OptionsColumn.AllowEdit = true;
		//				column.AppearanceHeader.ForeColor = Color.Blue;
		//				column.AppearanceHeader.BackColor = Color.Transparent;
		//				column.AppearanceHeader.BackColor2 = Color.Transparent;
		//				column.AppearanceCell.ForeColor = Color.Black;
		//				column.AppearanceCell.BackColor = Color.Transparent;
		//				column.OptionsColumn.AllowFocus = true;
		//				//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
		//				//column.Width = 30;
		//				break;
		//			case "Thursday":
		//				column = gvDanhSach.Columns[fieldName];
		//				column.Caption = "T.Năm " + Environment.NewLine + i;
		//				column.OptionsColumn.AllowEdit = true;
		//				column.AppearanceHeader.ForeColor = Color.Blue;
		//				column.AppearanceHeader.BackColor = Color.Transparent;
		//				column.AppearanceHeader.BackColor2 = Color.Transparent;
		//				column.AppearanceCell.ForeColor = Color.Black;
		//				column.AppearanceCell.BackColor = Color.Transparent;
		//				column.OptionsColumn.AllowFocus = true;
		//				//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
		//				//column.Width = 30;
		//				break;
		//			case "Friday":
		//				column = gvDanhSach.Columns[fieldName];
		//				column.Caption = "T.Sáu " + Environment.NewLine + i;
		//				column.OptionsColumn.AllowEdit = true;
		//				column.AppearanceHeader.ForeColor = Color.Blue;
		//				column.AppearanceHeader.BackColor = Color.Transparent;
		//				column.AppearanceHeader.BackColor2 = Color.Transparent;
		//				column.AppearanceCell.ForeColor = Color.Black;
		//				column.AppearanceCell.BackColor = Color.Transparent;
		//				column.OptionsColumn.AllowFocus = true;
		//				//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
		//				//column.Width = 30;
		//				break;
		//			case "Saturday":
		//				column = gvDanhSach.Columns[fieldName];
		//				column.Caption = "T.Bảy " + Environment.NewLine + i;
		//				column.OptionsColumn.AllowEdit = true;
		//				column.AppearanceHeader.ForeColor = Color.Red;
		//				column.AppearanceHeader.BackColor = Color.Violet;
		//				column.AppearanceHeader.BackColor2 = Color.Violet;
		//				column.AppearanceCell.ForeColor = Color.Black;
		//				column.AppearanceCell.BackColor = Color.Khaki;
		//				column.OptionsColumn.AllowFocus = true;
		//				//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
		//				//column.Width = 30;
		//				break;
		//			case "Sunday":
		//				column = gvDanhSach.Columns[fieldName];
		//				column.Caption = "CN " + Environment.NewLine + i;
		//				column.OptionsColumn.AllowEdit = false;
		//				column.AppearanceHeader.ForeColor = Color.Red;
		//				column.AppearanceHeader.BackColor = Color.GreenYellow;
		//				column.AppearanceHeader.BackColor2 = Color.GreenYellow;
		//				column.AppearanceCell.ForeColor = Color.Black;
		//				column.AppearanceCell.BackColor = Color.Orange;
		//				//column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
		//				//column.Width = 30;
		//				//column.OptionsColumn.AllowFocus = false;
		//				break;
		//		}
		//	}

		//	//while (i <= 31)
		//	//{
		//	//	gvDanhSach.Columns[i + 1].Visible = false;
		//	//	i++;
		//	//}

		//}
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
		void loadData()
        {
			gcDanhSach.DataSource = _kyphong.getlist(Friend._macty,Friend._madvi);
			gvDanhSach.OptionsBehavior.Editable = false;
        }
  

        private void btnXoa_Click(object sender, EventArgs e)
        {
			if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				if(!_kyphong.checkUserExist(_maky,Friend._macty,Friend._madvi))
                {
					MessageBox.Show("Vui lòng chọn Kỳ Phòng", "Thông báo");
					return;
                }					
				_kyphong.delete(_maky,Friend._macty,Friend._madvi);
			}
			loadData();
		}

        private void btnSua_Click(object sender, EventArgs e)
        {
			
			_them = false;
			showHideControl(false);
			loadData();
		}
        private void btnThem_Click(object sender, EventArgs e)
        {			
			showHideControl(false);
			_enabled(true);
			_them = true;
		}

        private void btnLuu_Click(object sender, EventArgs e)
        {
			savedata();
			loadData();
			_enabled(false);
		}

        private void btnBoQua_Click(object sender, EventArgs e)
        {
			_them = false;
			showHideControl(true);
			_enabled(false);

		}

        private void btnThoat_Click(object sender, EventArgs e)
        {
			this.Close();
		}

        private void btnThongKe_Click(object sender, EventArgs e)
        {
			if (!_kyphong.checkUserExist(_maky, Friend._macty, Friend._madvi))
			{
				MessageBox.Show("Vui lòng chọn Kỳ Phòng", "Thông báo");
				return;
			}
			var t = _kyphong.getItem(_maky, Friend._macty, Friend._madvi);
			frmKyPhongCT frm = new frmKyPhongCT();
			frm._maky = _maky;
			frm._thang = t.THANG.Value;
			frm._nam = t.NAM.Value;
			frm.ShowDialog();
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
			if(gvDanhSach.RowCount>0)
            {
				_maky = int.Parse(gvDanhSach.GetFocusedRowCellValue("MAKY").ToString());
            }				
        }
    }
}