
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBooking));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnBoQua = new System.Windows.Forms.ToolStripButton();
            this.btnIn = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gcDatPhong = new DevExpress.XtraGrid.GridControl();
            this.gvDatPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dpIDPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dpTENPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dpDONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dpTENTANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dpSONGAYO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dpTHANHTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcPhong = new DevExpress.XtraGrid.GridControl();
            this.gvPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDTANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENTANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENLOAIPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pDONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label9 = new System.Windows.Forms.Label();
            this.spSoNguoi = new DevExpress.XtraEditors.SpinEdit();
            this.lblHuy = new System.Windows.Forms.Label();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkTheoDoan = new System.Windows.Forms.CheckBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtNgayTra = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtNgayDat = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDatPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDatPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSoNguoi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.btnLuu,
            this.btnBoQua,
            this.btnIn,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1100, 41);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnThem
            // 
            this.btnThem.Image = global::KHACHSAN.Properties.Resources.add_1_icon;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(51, 38);
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnSua
            // 
            this.btnSua.Image = global::KHACHSAN.Properties.Resources.Apps_menu_editor_icon;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(37, 38);
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::KHACHSAN.Properties.Resources.Trash_Empty_icon;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(37, 38);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KHACHSAN.Properties.Resources.floppy_icon;
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(36, 38);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnBoQua
            // 
            this.btnBoQua.Image = global::KHACHSAN.Properties.Resources.undo_icon;
            this.btnBoQua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(58, 38);
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnIn
            // 
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(26, 38);
            this.btnIn.Text = "In";
            this.btnIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::KHACHSAN.Properties.Resources.system_shutdown_icon1;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(51, 38);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.groupControl3.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl3.Controls.Add(this.gcDatPhong);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl3.Location = new System.Drawing.Point(543, 41);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(557, 530);
            this.groupControl3.TabIndex = 30;
            this.groupControl3.Text = "Danh sách đặt phòng";
            // 
            // gcDatPhong
            // 
            this.gcDatPhong.AllowDrop = true;
            this.gcDatPhong.Dock = System.Windows.Forms.DockStyle.Right;
            this.gcDatPhong.Location = new System.Drawing.Point(2, 23);
            this.gcDatPhong.MainView = this.gvDatPhong;
            this.gcDatPhong.Name = "gcDatPhong";
            this.gcDatPhong.Size = new System.Drawing.Size(553, 505);
            this.gcDatPhong.TabIndex = 0;
            this.gcDatPhong.UseDisabledStatePainter = false;
            this.gcDatPhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDatPhong,
            this.gridView1});
            // 
            // gvDatPhong
            // 
            this.gvDatPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.dpIDPHONG,
            this.dpTENPHONG,
            this.dpDONGIA,
            this.dpTENTANG,
            this.dpSONGAYO,
            this.dpTHANHTIEN});
            this.gvDatPhong.GridControl = this.gcDatPhong;
            this.gvDatPhong.Name = "gvDatPhong";
            this.gvDatPhong.OptionsBehavior.Editable = false;
            this.gvDatPhong.OptionsView.ShowFooter = true;
            this.gvDatPhong.OptionsView.ShowGroupPanel = false;
            // 
            // dpIDPHONG
            // 
            this.dpIDPHONG.FieldName = "IDPHONG";
            this.dpIDPHONG.Name = "dpIDPHONG";
            // 
            // dpTENPHONG
            // 
            this.dpTENPHONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.dpTENPHONG.AppearanceHeader.Options.UseFont = true;
            this.dpTENPHONG.Caption = "TÊN PHÒNG";
            this.dpTENPHONG.FieldName = "TENPHONG";
            this.dpTENPHONG.MaxWidth = 120;
            this.dpTENPHONG.MinWidth = 100;
            this.dpTENPHONG.Name = "dpTENPHONG";
            this.dpTENPHONG.Visible = true;
            this.dpTENPHONG.VisibleIndex = 0;
            this.dpTENPHONG.Width = 100;
            // 
            // dpDONGIA
            // 
            this.dpDONGIA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.dpDONGIA.AppearanceHeader.Options.UseFont = true;
            this.dpDONGIA.Caption = "ĐƠN GIÁ";
            this.dpDONGIA.DisplayFormat.FormatString = "{0:#,#}";
            this.dpDONGIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dpDONGIA.FieldName = "DONGIA";
            this.dpDONGIA.MaxWidth = 120;
            this.dpDONGIA.MinWidth = 100;
            this.dpDONGIA.Name = "dpDONGIA";
            this.dpDONGIA.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DONGIA", "{0:n0}")});
            this.dpDONGIA.Visible = true;
            this.dpDONGIA.VisibleIndex = 1;
            this.dpDONGIA.Width = 100;
            // 
            // dpTENTANG
            // 
            this.dpTENTANG.Caption = "TẦNG";
            this.dpTENTANG.FieldName = "TENTANG";
            this.dpTENTANG.Name = "dpTENTANG";
            // 
            // dpSONGAYO
            // 
            this.dpSONGAYO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpSONGAYO.AppearanceHeader.Options.UseFont = true;
            this.dpSONGAYO.Caption = "SỐ NGÀY Ở";
            this.dpSONGAYO.FieldName = "SONGAYO";
            this.dpSONGAYO.Name = "dpSONGAYO";
            this.dpSONGAYO.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SONGAYO", "{0:n0}")});
            this.dpSONGAYO.Visible = true;
            this.dpSONGAYO.VisibleIndex = 2;
            // 
            // dpTHANHTIEN
            // 
            this.dpTHANHTIEN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpTHANHTIEN.AppearanceHeader.Options.UseFont = true;
            this.dpTHANHTIEN.Caption = "THÀNH TIỀN";
            this.dpTHANHTIEN.DisplayFormat.FormatString = "{0:#,#}";
            this.dpTHANHTIEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dpTHANHTIEN.FieldName = "THANHTIEN";
            this.dpTHANHTIEN.Name = "dpTHANHTIEN";
            this.dpTHANHTIEN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "THANHTIEN", "{0:0.##}")});
            this.dpTHANHTIEN.Visible = true;
            this.dpTHANHTIEN.VisibleIndex = 3;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcDatPhong;
            this.gridView1.Name = "gridView1";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.gcPhong);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 197);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(543, 374);
            this.groupControl1.TabIndex = 31;
            this.groupControl1.Text = "Danh Sách phòng trống";
            // 
            // gcPhong
            // 
            this.gcPhong.AllowDrop = true;
            this.gcPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPhong.Location = new System.Drawing.Point(2, 23);
            this.gcPhong.MainView = this.gvPhong;
            this.gcPhong.Name = "gcPhong";
            this.gcPhong.Size = new System.Drawing.Size(539, 349);
            this.gcPhong.TabIndex = 0;
            this.gcPhong.UseDisabledStatePainter = false;
            this.gcPhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPhong});
            // 
            // gvPhong
            // 
            this.gvPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDPHONG,
            this.TENPHONG,
            this.IDTANG,
            this.TENTANG,
            this.TENLOAIPHONG,
            this.pDONGIA});
            this.gvPhong.GridControl = this.gcPhong;
            this.gvPhong.GroupCount = 1;
            this.gvPhong.Name = "gvPhong";
            this.gvPhong.OptionsBehavior.Editable = false;
            this.gvPhong.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.TENTANG, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // IDPHONG
            // 
            this.IDPHONG.Caption = "ID";
            this.IDPHONG.FieldName = "IDPHONG";
            this.IDPHONG.Name = "IDPHONG";
            // 
            // TENPHONG
            // 
            this.TENPHONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.TENPHONG.AppearanceHeader.Options.UseFont = true;
            this.TENPHONG.Caption = "TÊN PHÒNG";
            this.TENPHONG.FieldName = "TENPHONG";
            this.TENPHONG.MaxWidth = 100;
            this.TENPHONG.MinWidth = 80;
            this.TENPHONG.Name = "TENPHONG";
            this.TENPHONG.Visible = true;
            this.TENPHONG.VisibleIndex = 0;
            this.TENPHONG.Width = 80;
            // 
            // IDTANG
            // 
            this.IDTANG.FieldName = "IDTANG";
            this.IDTANG.Name = "IDTANG";
            // 
            // TENTANG
            // 
            this.TENTANG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.TENTANG.AppearanceHeader.Options.UseFont = true;
            this.TENTANG.Caption = "TẦNG";
            this.TENTANG.FieldName = "TENTANG";
            this.TENTANG.MaxWidth = 80;
            this.TENTANG.MinWidth = 50;
            this.TENTANG.Name = "TENTANG";
            this.TENTANG.Visible = true;
            this.TENTANG.VisibleIndex = 1;
            this.TENTANG.Width = 80;
            // 
            // TENLOAIPHONG
            // 
            this.TENLOAIPHONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.TENLOAIPHONG.AppearanceHeader.Options.UseFont = true;
            this.TENLOAIPHONG.Caption = "LOẠI PHONG";
            this.TENLOAIPHONG.FieldName = "TENLOAIPHONG";
            this.TENLOAIPHONG.Name = "TENLOAIPHONG";
            // 
            // pDONGIA
            // 
            this.pDONGIA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.pDONGIA.AppearanceHeader.Options.UseFont = true;
            this.pDONGIA.Caption = "ĐƠN GIÁ";
            this.pDONGIA.DisplayFormat.FormatString = "{0:#,#}";
            this.pDONGIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.pDONGIA.FieldName = "DONGIA";
            this.pDONGIA.MaxWidth = 150;
            this.pDONGIA.MinWidth = 100;
            this.pDONGIA.Name = "pDONGIA";
            this.pDONGIA.Visible = true;
            this.pDONGIA.VisibleIndex = 1;
            this.pDONGIA.Width = 100;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.label9);
            this.groupControl2.Controls.Add(this.spSoNguoi);
            this.groupControl2.Controls.Add(this.lblHuy);
            this.groupControl2.Controls.Add(this.btnAddNew);
            this.groupControl2.Controls.Add(this.txtGhiChu);
            this.groupControl2.Controls.Add(this.label7);
            this.groupControl2.Controls.Add(this.chkTheoDoan);
            this.groupControl2.Controls.Add(this.cboTrangThai);
            this.groupControl2.Controls.Add(this.label6);
            this.groupControl2.Controls.Add(this.dtNgayTra);
            this.groupControl2.Controls.Add(this.label5);
            this.groupControl2.Controls.Add(this.dtNgayDat);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.cboKhachHang);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 41);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(543, 156);
            this.groupControl2.TabIndex = 32;
            this.groupControl2.Text = "groupControl2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Số Người";
            // 
            // spSoNguoi
            // 
            this.spSoNguoi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spSoNguoi.Location = new System.Drawing.Point(72, 94);
            this.spSoNguoi.Name = "spSoNguoi";
            this.spSoNguoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spSoNguoi.Size = new System.Drawing.Size(197, 20);
            this.spSoNguoi.TabIndex = 43;
            // 
            // lblHuy
            // 
            this.lblHuy.AutoSize = true;
            this.lblHuy.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblHuy.ForeColor = System.Drawing.Color.Red;
            this.lblHuy.Location = new System.Drawing.Point(463, 42);
            this.lblHuy.Name = "lblHuy";
            this.lblHuy.Size = new System.Drawing.Size(17, 17);
            this.lblHuy.TabIndex = 42;
            this.lblHuy.Text = "*";
            // 
            // btnAddNew
            // 
            this.btnAddNew.ImageOptions.Image = global::KHACHSAN.Properties.Resources.add_16x16;
            this.btnAddNew.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAddNew.Location = new System.Drawing.Point(403, 39);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(21, 21);
            this.btnAddNew.TabIndex = 41;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(72, 120);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(352, 21);
            this.txtGhiChu.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Ghi chú";
            // 
            // chkTheoDoan
            // 
            this.chkTheoDoan.AutoSize = true;
            this.chkTheoDoan.Location = new System.Drawing.Point(445, 124);
            this.chkTheoDoan.Name = "chkTheoDoan";
            this.chkTheoDoan.Size = new System.Drawing.Size(79, 17);
            this.chkTheoDoan.TabIndex = 38;
            this.chkTheoDoan.Text = "Theo Đoàn";
            this.chkTheoDoan.UseVisualStyleBackColor = true;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(338, 95);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(186, 21);
            this.cboTrangThai.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Trạng Thái";
            // 
            // dtNgayTra
            // 
            this.dtNgayTra.CustomFormat = "dd/MM/yyyy";
            this.dtNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayTra.Location = new System.Drawing.Point(338, 67);
            this.dtNgayTra.Name = "dtNgayTra";
            this.dtNgayTra.Size = new System.Drawing.Size(186, 21);
            this.dtNgayTra.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Ngày Trả";
            // 
            // dtNgayDat
            // 
            this.dtNgayDat.CustomFormat = "dd/MM/yyyy";
            this.dtNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayDat.Location = new System.Drawing.Point(72, 67);
            this.dtNgayDat.Name = "dtNgayDat";
            this.dtNgayDat.Size = new System.Drawing.Size(201, 21);
            this.dtNgayDat.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Ngày Đặt";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(73, 40);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(309, 21);
            this.cboKhachHang.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Khách Hàng";
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 571);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmBooking";
            this.Text = "Quan Lý Booking";
            this.Load += new System.EventHandler(this.frmBooking_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDatPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDatPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSoNguoi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnBoQua;
        private System.Windows.Forms.ToolStripButton btnIn;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gcDatPhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDatPhong;
        private DevExpress.XtraGrid.Columns.GridColumn dpIDPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn dpTENPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn dpDONGIA;
        private DevExpress.XtraGrid.Columns.GridColumn dpTENTANG;
        private DevExpress.XtraGrid.Columns.GridColumn dpSONGAYO;
        private DevExpress.XtraGrid.Columns.GridColumn dpTHANHTIEN;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcPhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPhong;
        private DevExpress.XtraGrid.Columns.GridColumn IDPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn TENPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn IDTANG;
        private DevExpress.XtraGrid.Columns.GridColumn TENTANG;
        private DevExpress.XtraGrid.Columns.GridColumn TENLOAIPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn pDONGIA;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SpinEdit spSoNguoi;
        private System.Windows.Forms.Label lblHuy;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkTheoDoan;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtNgayTra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtNgayDat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label label3;
    }
}