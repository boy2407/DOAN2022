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
using System.Threading;
using DataLayer;
namespace KHACHSAN
{
    public partial class frmLoading : DevExpress.XtraEditors.XtraForm
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        public frmLoading(tb_SYS_USER user)
        {
            this._user = user;
            InitializeComponent();
        }
        tb_SYS_USER _user;
        private void frmLoading_Load(object sender, EventArgs e)
        {
           


            timer1.Start();
            toado();
       
        }
        void toado()
        {
       
            label1.Location = new Point((this.Width - label1.Width) / 2, 60 );
            labelName.Location = new Point((this.Width - labelName.Width) / 2, label1.Location.Y + 60);
            labelpercent.Location = new Point((this.Width - labelpercent.Width) / 2, (this.Height - 80));
            pictureBox1.Location = new Point(20, 0);
            progressBarControl1.Location =new  Point((this.Width - progressBarControl1.Width) / 2, (this.Height -100));
         
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBarControl1.Position<100)
            {
                
                Random rnd = new Random();
                int t = rnd.Next(1, 60);
                if (progressBarControl1.Position==t||t==DateTime.Now.Millisecond)
                {
                    Thread.Sleep(t * 100);
                    progressBarControl1.Position += t;
                }   
                else
                {
                    progressBarControl1.Position += 1;
                }
                labelpercent.Text = progressBarControl1.Position.ToString() + "%";
            }    
            else
            {
                timer1.Stop();
                using (frmMain frm = new frmMain(_user))
                {
                    this.Hide();
                    frm.ShowDialog();
                }    
            }    
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}