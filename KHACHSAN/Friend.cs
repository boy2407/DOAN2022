using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KHACHSAN
{
   public class Friend
    {
        public static string _macty;
        public static string _madvi;
        public static string _srv;
        public static string _us;
        public static string _pw;
        public static string _db;
        static SqlConnection con = new SqlConnection();
        public static string ThemDauPhay(string s)
        {
            int length = s.Length;
            while (length - 3 > 0)
            {
                int vitri = length - 3;
                s = s.Insert(vitri, ",");
                length = vitri;
            }
            return s;
        }
      public static  string ResetHetDauPhay(string s) 
        {
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == ',')
                {
                    s = s.Remove(i, 1);
                }
            }

            return s; 
        }
        
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        public static void taoketnoi()
        {
            con.ConnectionString = Program.connoi;
            try
            {
                con.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void dongketnoi()
        {
            con.Close();
        }
        public static DataTable laydulieu(string qr)
        {
            taoketnoi();
            DataTable datatbl = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter();
            dap.SelectCommand = new SqlCommand(qr, con);
            dap.Fill(datatbl);
            dongketnoi();
            return datatbl;
        }
        public static DateTime GetFirstDayInMont(int year, int month)
        {
            return new DateTime(year, month, 1);
        }
        public static void XuatReport(string _bien,string _nhan,string _reportName, string _tieude)
        {
            if (_nhan != null)
            {
                Form frm = new Form();
                CrystalReportViewer Crv = new CrystalReportViewer();
                Crv.ShowGroupTreeButton = false;
                Crv.ShowParameterPanelButton = false;
                Crv.ToolPanelView = ToolPanelViewType.None;
                TableLogOnInfo Thongtin;
                ReportDocument doc = new ReportDocument();
                doc.Load(System.Windows.Forms.Application.StartupPath + "\\Report\\" + _reportName + @".rpt");
                Thongtin = doc.Database.Tables[0].LogOnInfo;
                Thongtin.ConnectionInfo.ServerName = Friend._srv;
                Thongtin.ConnectionInfo.DatabaseName = Friend._db;
                Thongtin.ConnectionInfo.UserID = Friend._us;
                Thongtin.ConnectionInfo.Password = Friend._pw;
                doc.Database.Tables[0].ApplyLogOnInfo(Thongtin);
                try
                {
                    doc.SetParameterValue(_bien, _nhan.ToString());
                    Crv.Dock = DockStyle.Fill;
                    Crv.ReportSource = doc;
                    frm.Controls.Add(Crv);
                    Crv.Refresh();
                    frm.Text = _tieude;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi : " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
