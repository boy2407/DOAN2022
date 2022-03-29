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
using DevExpress.XtraScheduler;
using System.Data.SqlClient;

namespace KHACHSAN
{
    public partial class frmBooking : DevExpress.XtraEditors.XtraForm
    {
        public frmBooking()
        {
            InitializeComponent();
      
        }
        APPOINTMENTS _appointments;
        RESOURCES _resources;
        private void frmBooking_Load(object sender, EventArgs e)
        {
          

        }
        private void OnApptChangedInsertedDeleted(object sender, PersistentObjectsEventArgs e)
        {
         
        }


      
      
    }
}