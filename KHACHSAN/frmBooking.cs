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
    public partial class frmBooking : DevExpress.XtraEditors.XtraForm
    {
        public frmBooking()
        {
            InitializeComponent();
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
           
        }
        void loadphong()
        {
            
        }

        private void schedulerDataStorage1_AppointmentsChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {

        }

        private void schedulerDataStorage1_AppointmentsDeleted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {

        }

        private void schedulerDataStorage1_AppointmentsInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {

        }

        private void schedulerDataStorage1_AppointmentDependenciesChanged(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {

        }

        private void schedulerDataStorage1_AppointmentDependenciesDeleted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {

        }

        private void schedulerDataStorage1_AppointmentDependenciesInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {

        }
    }
}