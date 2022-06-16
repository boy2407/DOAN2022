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
    public partial class frmBooking_Web : DevExpress.XtraEditors.XtraForm
    {
        public frmBooking_Web()
        {
            InitializeComponent();
        }
        ROOM_BOOKING_DETAILS _roombookingdetails;
        int _id;
        private void frmBooking_Web_Load(object sender, EventArgs e)
        {
               _id = 0;
               _roombookingdetails = new ROOM_BOOKING_DETAILS();
            loadDanhSach();
        }
        void loadDanhSach()
        {
            gcDanhSach.DataSource = _roombookingdetails.getAll_Receive();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            if(gvDanhSach.RowCount>0)
            {
                _id= int.Parse(gvDanhSach.GetFocusedRowCellValue("id").ToString());
            }    
        }
    }
}