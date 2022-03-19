
namespace USERMANAGEMENT
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnNhomNguoiDung = new DevExpress.XtraBars.BarButtonItem();
            this.btnNguoiDung = new DevExpress.XtraBars.BarButtonItem();
            this.btnCapNhatThongTin = new DevExpress.XtraBars.BarButtonItem();
            this.btnPQChucNang = new DevExpress.XtraBars.BarButtonItem();
            this.btnPQBaoCao = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnNhom = new System.Windows.Forms.Panel();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnThemNhom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnThemNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnPhanQuyenChucNang = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnPhanquyenBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnCapNhat = new System.Windows.Forms.ToolStripMenuItem();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DISABLED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISGROUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.USERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FULLNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDUSER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MACTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MADVI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnNhomNguoiDung,
            this.btnNguoiDung,
            this.btnCapNhatThongTin,
            this.btnPQChucNang,
            this.btnPQBaoCao,
            this.barButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 8;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(796, 126);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // btnNhomNguoiDung
            // 
            this.btnNhomNguoiDung.Caption = "Nhóm người dùng";
            this.btnNhomNguoiDung.Id = 1;
            this.btnNhomNguoiDung.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhomNguoiDung.ImageOptions.Image")));
            this.btnNhomNguoiDung.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNhomNguoiDung.ImageOptions.LargeImage")));
            this.btnNhomNguoiDung.Name = "btnNhomNguoiDung";
            this.btnNhomNguoiDung.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNhomNguoiDung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhomNguoiDung_ItemClick);
            // 
            // btnNguoiDung
            // 
            this.btnNguoiDung.Caption = "Người Dùng";
            this.btnNguoiDung.Id = 3;
            this.btnNguoiDung.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNguoiDung.ImageOptions.Image")));
            this.btnNguoiDung.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNguoiDung.ImageOptions.LargeImage")));
            this.btnNguoiDung.Name = "btnNguoiDung";
            this.btnNguoiDung.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnNguoiDung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNguoiDung_ItemClick);
            // 
            // btnCapNhatThongTin
            // 
            this.btnCapNhatThongTin.Caption = "Cập Nhật thông tin";
            this.btnCapNhatThongTin.Id = 4;
            this.btnCapNhatThongTin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhatThongTin.ImageOptions.Image")));
            this.btnCapNhatThongTin.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCapNhatThongTin.ImageOptions.LargeImage")));
            this.btnCapNhatThongTin.Name = "btnCapNhatThongTin";
            this.btnCapNhatThongTin.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnCapNhatThongTin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCapNhatThongTin_ItemClick);
            // 
            // btnPQChucNang
            // 
            this.btnPQChucNang.Caption = "Phân quyền chức năng";
            this.btnPQChucNang.Id = 5;
            this.btnPQChucNang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPQChucNang.ImageOptions.Image")));
            this.btnPQChucNang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPQChucNang.ImageOptions.LargeImage")));
            this.btnPQChucNang.Name = "btnPQChucNang";
            this.btnPQChucNang.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPQChucNang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPQChucNang_ItemClick);
            // 
            // btnPQBaoCao
            // 
            this.btnPQBaoCao.Caption = "Phân quyền báo cáo";
            this.btnPQBaoCao.Id = 6;
            this.btnPQBaoCao.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPQBaoCao.ImageOptions.Image")));
            this.btnPQBaoCao.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPQBaoCao.ImageOptions.LargeImage")));
            this.btnPQBaoCao.Name = "btnPQBaoCao";
            this.btnPQBaoCao.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnPQBaoCao.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPQBaoCao_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thoát";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.ImageOptions.Image = global::USERMANAGEMENT.Properties.Resources.user_icon;
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Chức năng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPageGroup1.ImageOptions.Image")));
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNhomNguoiDung);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNguoiDung, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCapNhatThongTin, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Tài Khoản";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPQChucNang, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPQBaoCao, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Phân quyền";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.AllowTextClipping = false;
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Hệ Thống";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Người Dùng";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pnNhom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 37);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(315, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đơn Vị";
            // 
            // pnNhom
            // 
            this.pnNhom.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnNhom.Location = new System.Drawing.Point(383, 0);
            this.pnNhom.Name = "pnNhom";
            this.pnNhom.Size = new System.Drawing.Size(413, 37);
            this.pnNhom.TabIndex = 0;
            // 
            // gcUser
            // 
            this.gcUser.ContextMenuStrip = this.contextMenuStrip1;
            this.gcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUser.Location = new System.Drawing.Point(0, 163);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.MenuManager = this.ribbonControl1;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(796, 357);
            this.gcUser.TabIndex = 2;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnThemNhom,
            this.toolStripSeparator4,
            this.mnThemNguoiDung,
            this.toolStripSeparator2,
            this.mnPhanQuyenChucNang,
            this.toolStripSeparator3,
            this.mnPhanquyenBaoCao,
            this.toolStripSeparator1,
            this.mnCapNhat});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 138);
            // 
            // mnThemNhom
            // 
            this.mnThemNhom.Name = "mnThemNhom";
            this.mnThemNhom.Size = new System.Drawing.Size(196, 22);
            this.mnThemNhom.Text = "Thêm mới Nhóm";
            this.mnThemNhom.Click += new System.EventHandler(this.thêmNhómToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(193, 6);
            // 
            // mnThemNguoiDung
            // 
            this.mnThemNguoiDung.Name = "mnThemNguoiDung";
            this.mnThemNguoiDung.Size = new System.Drawing.Size(196, 22);
            this.mnThemNguoiDung.Text = "Thêm mới Người Dùng";
            this.mnThemNguoiDung.Click += new System.EventHandler(this.thêmNgườiDùngToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // mnPhanQuyenChucNang
            // 
            this.mnPhanQuyenChucNang.Name = "mnPhanQuyenChucNang";
            this.mnPhanQuyenChucNang.Size = new System.Drawing.Size(196, 22);
            this.mnPhanQuyenChucNang.Text = "Phân quyền chức năng";
            this.mnPhanQuyenChucNang.Click += new System.EventHandler(this.phânQuyềnChứcNăngToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(193, 6);
            // 
            // mnPhanquyenBaoCao
            // 
            this.mnPhanquyenBaoCao.Name = "mnPhanquyenBaoCao";
            this.mnPhanquyenBaoCao.Size = new System.Drawing.Size(196, 22);
            this.mnPhanquyenBaoCao.Text = "Phân quyền báo cáo";
            this.mnPhanquyenBaoCao.Click += new System.EventHandler(this.phânQuyềnBáoCáoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // mnCapNhat
            // 
            this.mnCapNhat.Name = "mnCapNhat";
            this.mnCapNhat.Size = new System.Drawing.Size(196, 22);
            this.mnCapNhat.Text = "Cập nhật";
            this.mnCapNhat.Click += new System.EventHandler(this.mnCapNhat_Click);
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DISABLED,
            this.ISGROUP,
            this.USERNAME,
            this.FULLNAME,
            this.IDUSER,
            this.MACTY,
            this.MADVI});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsView.ShowGroupPanel = false;
            this.gvUser.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvUser_CustomDrawCell);
            this.gvUser.DoubleClick += new System.EventHandler(this.gvUser_DoubleClick);
            // 
            // DISABLED
            // 
            this.DISABLED.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DISABLED.AppearanceHeader.Options.UseFont = true;
            this.DISABLED.Caption = "DEL";
            this.DISABLED.FieldName = "DISABLED";
            this.DISABLED.MaxWidth = 50;
            this.DISABLED.MinWidth = 40;
            this.DISABLED.Name = "DISABLED";
            this.DISABLED.Visible = true;
            this.DISABLED.VisibleIndex = 0;
            this.DISABLED.Width = 40;
            // 
            // ISGROUP
            // 
            this.ISGROUP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ISGROUP.AppearanceHeader.Options.UseFont = true;
            this.ISGROUP.FieldName = "ISGROUP";
            this.ISGROUP.MaxWidth = 70;
            this.ISGROUP.MinWidth = 55;
            this.ISGROUP.Name = "ISGROUP";
            this.ISGROUP.Visible = true;
            this.ISGROUP.VisibleIndex = 3;
            this.ISGROUP.Width = 55;
            // 
            // USERNAME
            // 
            this.USERNAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.USERNAME.AppearanceHeader.Options.UseFont = true;
            this.USERNAME.FieldName = "USERNAME";
            this.USERNAME.MaxWidth = 150;
            this.USERNAME.MinWidth = 100;
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.Visible = true;
            this.USERNAME.VisibleIndex = 1;
            this.USERNAME.Width = 100;
            // 
            // FULLNAME
            // 
            this.FULLNAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FULLNAME.AppearanceHeader.Options.UseFont = true;
            this.FULLNAME.FieldName = "FULLNAME";
            this.FULLNAME.MaxWidth = 200;
            this.FULLNAME.MinWidth = 150;
            this.FULLNAME.Name = "FULLNAME";
            this.FULLNAME.Visible = true;
            this.FULLNAME.VisibleIndex = 2;
            this.FULLNAME.Width = 150;
            // 
            // IDUSER
            // 
            this.IDUSER.Caption = "ID";
            this.IDUSER.FieldName = "IDUSER";
            this.IDUSER.Name = "IDUSER";
            // 
            // MACTY
            // 
            this.MACTY.FieldName = "MACTY";
            this.MACTY.Name = "MACTY";
            // 
            // MADVI
            // 
            this.MADVI.FieldName = "MADVI";
            this.MADVI.Name = "MADVI";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "user.png");
            this.imageList1.Images.SetKeyName(1, "users.png");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(796, 520);
            this.Controls.Add(this.gcUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Image = global::USERMANAGEMENT.Properties.Resources.User_Group_icon;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnNhomNguoiDung;
        private DevExpress.XtraBars.BarButtonItem btnNguoiDung;
        private DevExpress.XtraBars.BarButtonItem btnCapNhatThongTin;
        private DevExpress.XtraBars.BarButtonItem btnPQChucNang;
        private DevExpress.XtraBars.BarButtonItem btnPQBaoCao;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnNhom;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn DISABLED;
        private DevExpress.XtraGrid.Columns.GridColumn IDUSER;
        private DevExpress.XtraGrid.Columns.GridColumn USERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn FULLNAME;
        private DevExpress.XtraGrid.Columns.GridColumn MACTY;
        private DevExpress.XtraGrid.Columns.GridColumn MADVI;
        private DevExpress.XtraGrid.Columns.GridColumn ISGROUP;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnThemNhom;
        private System.Windows.Forms.ToolStripMenuItem mnThemNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem mnPhanQuyenChucNang;
        private System.Windows.Forms.ToolStripMenuItem mnPhanquyenBaoCao;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnCapNhat;
    }
}

