
namespace KHACHSAN
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnHeThong = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBaoCao = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navMain = new DevExpress.XtraNavBar.NavBarControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.gControl = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnDatPhong = new DevExpress.XtraBars.BarButtonItem();
            this.btnChuyenPhong = new DevExpress.XtraBars.BarButtonItem();
            this.btnSPDV = new DevExpress.XtraBars.BarButtonItem();
            this.btnThanhToan = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timerCheckIn = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gControl)).BeginInit();
            this.gControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHeThong,
            this.toolStripSeparator1,
            this.btnBaoCao,
            this.toolStripSeparator2,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1123, 53);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnHeThong
            // 
            this.btnHeThong.Image = global::KHACHSAN.Properties.Resources.system_icon;
            this.btnHeThong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHeThong.Name = "btnHeThong";
            this.btnHeThong.Size = new System.Drawing.Size(66, 50);
            this.btnHeThong.Text = "Hệ Thộng";
            this.btnHeThong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHeThong.Click += new System.EventHandler(this.btnHeThong_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Image = global::KHACHSAN.Properties.Resources.report;
            this.btnBaoCao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(54, 50);
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 53);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::KHACHSAN.Properties.Resources.system_shutdown_icon;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(44, 50);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 53);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.navMain);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gControl);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1123, 597);
            this.splitContainerControl1.SplitterPosition = 321;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // navMain
            // 
            this.navMain.Appearance.Item.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navMain.Appearance.Item.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.navMain.Appearance.Item.Options.UseFont = true;
            this.navMain.Appearance.Item.Options.UseForeColor = true;
            this.navMain.Appearance.ItemHotTracked.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navMain.Appearance.ItemHotTracked.Options.UseFont = true;
            this.navMain.Appearance.ItemPressed.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navMain.Appearance.ItemPressed.ForeColor = System.Drawing.Color.Gray;
            this.navMain.Appearance.ItemPressed.Options.UseFont = true;
            this.navMain.Appearance.ItemPressed.Options.UseForeColor = true;
            this.navMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navMain.Font = new System.Drawing.Font("Tahoma", 12.5F);
            this.navMain.LargeImages = this.imageList1;
            this.navMain.Location = new System.Drawing.Point(0, 0);
            this.navMain.Margin = new System.Windows.Forms.Padding(4);
            this.navMain.Name = "navMain";
            this.navMain.OptionsNavPane.ExpandedWidth = 321;
            this.navMain.Size = new System.Drawing.Size(321, 597);
            this.navMain.SmallImages = this.imageList2;
            this.navMain.TabIndex = 0;
            this.navMain.Text = "navBarControl1";
            this.navMain.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navMain_LinkClicked);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "category-icon.png");
            this.imageList1.Images.SetKeyName(1, "System-settings-icon.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "map-marker-icon.png");
            // 
            // gControl
            // 
            this.gControl.Controls.Add(this.galleryControlClient1);
            this.gControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gControl.Location = new System.Drawing.Point(0, 0);
            this.gControl.Name = "gControl";
            this.barManager1.SetPopupContextMenu(this.gControl, this.popupMenu1);
            this.gControl.Size = new System.Drawing.Size(792, 597);
            this.gControl.TabIndex = 0;
            this.gControl.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.gControl;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(771, 593);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "2-Hot-Home-icon.png");
            this.imageList3.Images.SetKeyName(1, "3-Gray-Home-icon.png");
            this.imageList3.Images.SetKeyName(2, "One-storied-house-icon.png");
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDatPhong),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnChuyenPhong),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSPDV),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThanhToan)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Popup += new System.EventHandler(this.popupMenu1_Popup);
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.Caption = "Đặt phòng";
            this.btnDatPhong.Id = 0;
            this.btnDatPhong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDatPhong.ImageOptions.Image")));
            this.btnDatPhong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDatPhong.ImageOptions.LargeImage")));
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDatPhong_ItemClick);
            // 
            // btnChuyenPhong
            // 
            this.btnChuyenPhong.Caption = "Chuyển Phòng";
            this.btnChuyenPhong.Id = 3;
            this.btnChuyenPhong.ImageOptions.Image = global::KHACHSAN.Properties.Resources.convert_16x16;
            this.btnChuyenPhong.ImageOptions.LargeImage = global::KHACHSAN.Properties.Resources.convert_32x321;
            this.btnChuyenPhong.Name = "btnChuyenPhong";
            this.btnChuyenPhong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChuyenPhong_ItemClick);
            // 
            // btnSPDV
            // 
            this.btnSPDV.Caption = "Cập nhật Sản phẩm - dịch vụ";
            this.btnSPDV.Id = 1;
            this.btnSPDV.ImageOptions.Image = global::KHACHSAN.Properties.Resources.refreshpivottable_16x161;
            this.btnSPDV.ImageOptions.LargeImage = global::KHACHSAN.Properties.Resources.refreshpivottable_32x321;
            this.btnSPDV.Name = "btnSPDV";
            this.btnSPDV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSPDV_ItemClick);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Caption = "Thanh toán";
            this.btnThanhToan.Id = 2;
            this.btnThanhToan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThanhToan.ImageOptions.Image")));
            this.btnThanhToan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThanhToan.ImageOptions.LargeImage")));
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThanhToan_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDatPhong,
            this.btnSPDV,
            this.btnThanhToan,
            this.btnChuyenPhong});
            this.barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1123, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 650);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1123, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 650);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1123, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 650);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timerCheckIn
            // 
            this.timerCheckIn.Interval = 5000;
            this.timerCheckIn.Tick += new System.EventHandler(this.timerCheckIn_Tick);
            // 
            // frmMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 650);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý khách sạn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gControl)).EndInit();
            this.gControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnHeThong;
        private System.Windows.Forms.ToolStripButton btnBaoCao;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navMain;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
        private System.Windows.Forms.ImageList imageList3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnDatPhong;
        private DevExpress.XtraBars.BarButtonItem btnSPDV;
        private DevExpress.XtraBars.BarButtonItem btnThanhToan;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        public DevExpress.XtraBars.Ribbon.GalleryControl gControl;
        private DevExpress.XtraBars.BarButtonItem btnChuyenPhong;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timerCheckIn;
    }
}

