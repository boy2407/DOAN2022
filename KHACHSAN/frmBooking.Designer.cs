
namespace KHACHSAN
{
    partial class frmBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ResoursTreePhong = new DevExpress.XtraScheduler.UI.ResourcesTree();
            this.IDPHONG = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.TENPHONG = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.TRANGTHAI = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResoursTreePhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ResoursTreePhong);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.schedulerControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(824, 627);
            this.splitContainerControl1.SplitterPosition = 295;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // ResoursTreePhong
            // 
            this.ResoursTreePhong.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.IDPHONG,
            this.TENPHONG,
            this.TRANGTHAI});
            this.ResoursTreePhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResoursTreePhong.Location = new System.Drawing.Point(0, 0);
            this.ResoursTreePhong.Name = "ResoursTreePhong";
            this.ResoursTreePhong.OptionsBehavior.Editable = false;
            this.ResoursTreePhong.SchedulerControl = this.schedulerControl1;
            this.ResoursTreePhong.Size = new System.Drawing.Size(295, 627);
            this.ResoursTreePhong.TabIndex = 0;
            // 
            // IDPHONG
            // 
            this.IDPHONG.Caption = "IDPHONG";
            this.IDPHONG.FieldName = "IDPHONG";
            this.IDPHONG.Name = "IDPHONG";
            this.IDPHONG.Visible = true;
            this.IDPHONG.VisibleIndex = 0;
            // 
            // TENPHONG
            // 
            this.TENPHONG.Caption = "TÊN PHÒNG";
            this.TENPHONG.FieldName = "TENPHONG";
            this.TENPHONG.Name = "TENPHONG";
            this.TENPHONG.Visible = true;
            this.TENPHONG.VisibleIndex = 1;
            // 
            // TRANGTHAI
            // 
            this.TRANGTHAI.Caption = "TRANGTHAI";
            this.TRANGTHAI.FieldName = "TRANGTHAI";
            this.TRANGTHAI.Name = "TRANGTHAI";
            this.TRANGTHAI.Visible = true;
            this.TRANGTHAI.VisibleIndex = 2;
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(519, 627);
            this.schedulerControl1.Start = new System.DateTime(2022, 3, 24, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.AgendaView.Enabled = false;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.GanttView.Enabled = false;
            this.schedulerControl1.Views.TimelineView.Enabled = false;
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            // 
            // schedulerDataStorage1
            // 
            // 
            // 
            // 
            this.schedulerDataStorage1.AppointmentDependencies.AutoReload = false;
            this.schedulerDataStorage1.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerDataStorage1_AppointmentsInserted);
            this.schedulerDataStorage1.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerDataStorage1_AppointmentsChanged);
            this.schedulerDataStorage1.AppointmentsDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerDataStorage1_AppointmentsDeleted);
            this.schedulerDataStorage1.AppointmentDependenciesInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerDataStorage1_AppointmentDependenciesInserted);
            this.schedulerDataStorage1.AppointmentDependenciesChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerDataStorage1_AppointmentDependenciesChanged);
            this.schedulerDataStorage1.AppointmentDependenciesDeleted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.schedulerDataStorage1_AppointmentDependenciesDeleted);
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 627);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmBooking";
            this.Text = "frmBooking";
            this.Load += new System.EventHandler(this.frmBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResoursTreePhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraScheduler.UI.ResourcesTree ResoursTreePhong;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn IDPHONG;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn TENPHONG;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn TRANGTHAI;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
    }
}