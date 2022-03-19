
namespace USERMANAGEMENT
{
    partial class frmPhanQuyenBaoCao
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
            this.gcChucNang = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnCamQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnToanQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.gvChucNang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.REP_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUYEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ISGROUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.USERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FULLNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcChucNang)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvChucNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // gcChucNang
            // 
            this.gcChucNang.ContextMenuStrip = this.contextMenuStrip1;
            this.gcChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChucNang.Location = new System.Drawing.Point(296, 0);
            this.gcChucNang.MainView = this.gvChucNang;
            this.gcChucNang.Name = "gcChucNang";
            this.gcChucNang.Size = new System.Drawing.Size(530, 655);
            this.gcChucNang.TabIndex = 3;
            this.gcChucNang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChucNang});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnCamQuyen,
            this.toolStripSeparator1,
            this.mnToanQuyen,
            this.toolStripSeparator3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 60);
            // 
            // mnCamQuyen
            // 
            this.mnCamQuyen.Name = "mnCamQuyen";
            this.mnCamQuyen.Size = new System.Drawing.Size(137, 22);
            this.mnCamQuyen.Text = "Khóa quyền";
            this.mnCamQuyen.Click += new System.EventHandler(this.mnCamQuyen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // mnToanQuyen
            // 
            this.mnToanQuyen.Name = "mnToanQuyen";
            this.mnToanQuyen.Size = new System.Drawing.Size(137, 22);
            this.mnToanQuyen.Text = "Toàn Quyền";
            this.mnToanQuyen.Click += new System.EventHandler(this.mnToanQuyen_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(134, 6);
            // 
            // gvChucNang
            // 
            this.gvChucNang.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gvChucNang.Appearance.Row.Options.UseFont = true;
            this.gvChucNang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.REP_CODE,
            this.DESCRIPTION,
            this.QUYEN});
            this.gvChucNang.GridControl = this.gcChucNang;
            this.gvChucNang.Name = "gvChucNang";
            this.gvChucNang.OptionsSelection.MultiSelect = true;
            this.gvChucNang.OptionsView.ShowGroupPanel = false;
            this.gvChucNang.RowHeight = 35;
            // 
            // REP_CODE
            // 
            this.REP_CODE.FieldName = "REP_CODE";
            this.REP_CODE.Name = "REP_CODE";
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.Caption = "CHỨC NĂNG";
            this.DESCRIPTION.FieldName = "DESCRIPTION";
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.Visible = true;
            this.DESCRIPTION.VisibleIndex = 0;
            // 
            // QUYEN
            // 
            this.QUYEN.Caption = "QUYỀN";
            this.QUYEN.FieldName = "QUYEN";
            this.QUYEN.Name = "QUYEN";
            this.QUYEN.Visible = true;
            this.QUYEN.VisibleIndex = 1;
            // 
            // gcUser
            // 
            this.gcUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcUser.Location = new System.Drawing.Point(0, 0);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(296, 655);
            this.gcUser.TabIndex = 2;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // gvUser
            // 
            this.gvUser.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gvUser.Appearance.Row.Options.UseFont = true;
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ISGROUP,
            this.USERNAME,
            this.FULLNAME,
            this.ID});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsView.ShowGroupPanel = false;
            this.gvUser.RowHeight = 30;
            this.gvUser.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvUser_CustomDrawCell);
            this.gvUser.Click += new System.EventHandler(this.gvUser_Click);
            // 
            // ISGROUP
            // 
            this.ISGROUP.FieldName = "ISGROUP";
            this.ISGROUP.MaxWidth = 30;
            this.ISGROUP.Name = "ISGROUP";
            this.ISGROUP.Visible = true;
            this.ISGROUP.VisibleIndex = 0;
            this.ISGROUP.Width = 30;
            // 
            // USERNAME
            // 
            this.USERNAME.FieldName = "USERNAME";
            this.USERNAME.MaxWidth = 100;
            this.USERNAME.MinWidth = 80;
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.Visible = true;
            this.USERNAME.VisibleIndex = 1;
            this.USERNAME.Width = 85;
            // 
            // FULLNAME
            // 
            this.FULLNAME.FieldName = "FULLNAME";
            this.FULLNAME.MaxWidth = 200;
            this.FULLNAME.MinWidth = 150;
            this.FULLNAME.Name = "FULLNAME";
            this.FULLNAME.Visible = true;
            this.FULLNAME.VisibleIndex = 2;
            this.FULLNAME.Width = 165;
            // 
            // ID
            // 
            this.ID.FieldName = "IDUSER";
            this.ID.MaxWidth = 30;
            this.ID.Name = "ID";
            this.ID.Width = 30;
            // 
            // frmPhanQuyenBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 655);
            this.Controls.Add(this.gcChucNang);
            this.Controls.Add(this.gcUser);
            this.Name = "frmPhanQuyenBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân quyền báo cáo";
            this.Load += new System.EventHandler(this.frmPhanQuyenBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcChucNang)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvChucNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcChucNang;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChucNang;
        private DevExpress.XtraGrid.Columns.GridColumn REP_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn DESCRIPTION;
        private DevExpress.XtraGrid.Columns.GridColumn QUYEN;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn ISGROUP;
        private DevExpress.XtraGrid.Columns.GridColumn USERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn FULLNAME;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnCamQuyen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnToanQuyen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}