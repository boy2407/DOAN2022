
namespace KHACHSAN
{
    partial class frmDatPhongDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatPhongDon));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnIn = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.gcSPDV = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvSPDV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.spIDSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spTENPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spTENSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spIDPHONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spSOLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spDONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spTHANHTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.searchKH = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HOTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblPhong = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.spSoNguoi = new DevExpress.XtraEditors.SpinEdit();
            this.lblHuy = new System.Windows.Forms.Label();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtNgayTra = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtNgayDat = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gcSanPham = new DevExpress.XtraGrid.GridControl();
            this.gvSanPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSPDV)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSPDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchKH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSoNguoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLuu,
            this.btnSua,
            this.btnIn,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(858, 41);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KHACHSAN.Properties.Resources.floppy_icon;
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(36, 38);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnIn
            // 
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(26, 38);
            this.btnIn.Tag = "";
            this.btnIn.Text = "In";
            this.btnIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::KHACHSAN.Properties.Resources.system_shutdown_icon1;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(51, 38);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 41);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(858, 546);
            this.splitContainerControl1.SplitterPosition = 578;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // groupControl5
            // 
            this.groupControl5.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Critical;
            this.groupControl5.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl5.Controls.Add(this.txtThanhTien);
            this.groupControl5.Controls.Add(this.label8);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(0, 423);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(578, 123);
            this.groupControl5.TabIndex = 3;
            this.groupControl5.Text = "TỔNG THANH TOÁN";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtThanhTien.ForeColor = System.Drawing.Color.Red;
            this.txtThanhTien.Location = new System.Drawing.Point(200, 50);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(291, 22);
            this.txtThanhTien.TabIndex = 1;
            this.txtThanhTien.Text = "ffffffff";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(78, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "TỔNG TIỀN";
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl4.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl4.Controls.Add(this.gcSPDV);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl4.Location = new System.Drawing.Point(0, 190);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(578, 233);
            this.groupControl4.TabIndex = 2;
            this.groupControl4.Text = "Danh sách sản phẩm - Dịch vụ";
            // 
            // gcSPDV
            // 
            this.gcSPDV.ContextMenuStrip = this.contextMenuStrip1;
            this.gcSPDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSPDV.Location = new System.Drawing.Point(2, 23);
            this.gcSPDV.MainView = this.gvSPDV;
            this.gcSPDV.Name = "gcSPDV";
            this.gcSPDV.Size = new System.Drawing.Size(574, 208);
            this.gcSPDV.TabIndex = 1;
            this.gcSPDV.UseDisabledStatePainter = false;
            this.gcSPDV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSPDV});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // gvSPDV
            // 
            this.gvSPDV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.spIDSP,
            this.spTENPHONG,
            this.spTENSP,
            this.spIDPHONG,
            this.spSOLUONG,
            this.spDONGIA,
            this.spTHANHTIEN});
            this.gvSPDV.GridControl = this.gcSPDV;
            this.gvSPDV.Name = "gvSPDV";
            this.gvSPDV.OptionsView.ShowFooter = true;
            this.gvSPDV.OptionsView.ShowGroupPanel = false;
            this.gvSPDV.HiddenEditor += new System.EventHandler(this.gvSPDV_HiddenEditor);
            this.gvSPDV.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvSPDV_CellValueChanged);
            // 
            // spIDSP
            // 
            this.spIDSP.FieldName = "IDSP";
            this.spIDSP.Name = "spIDSP";
            // 
            // spTENPHONG
            // 
            this.spTENPHONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.spTENPHONG.AppearanceHeader.Options.UseFont = true;
            this.spTENPHONG.Caption = "Phòng";
            this.spTENPHONG.FieldName = "TENPHONG";
            this.spTENPHONG.Name = "spTENPHONG";
            this.spTENPHONG.OptionsColumn.AllowEdit = false;
            this.spTENPHONG.Visible = true;
            this.spTENPHONG.VisibleIndex = 0;
            // 
            // spTENSP
            // 
            this.spTENSP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.spTENSP.AppearanceHeader.Options.UseFont = true;
            this.spTENSP.Caption = "TÊN SP-DV";
            this.spTENSP.FieldName = "TENSP";
            this.spTENSP.MaxWidth = 120;
            this.spTENSP.MinWidth = 80;
            this.spTENSP.Name = "spTENSP";
            this.spTENSP.OptionsColumn.AllowEdit = false;
            this.spTENSP.Visible = true;
            this.spTENSP.VisibleIndex = 1;
            this.spTENSP.Width = 80;
            // 
            // spIDPHONG
            // 
            this.spIDPHONG.FieldName = "IDPHONG";
            this.spIDPHONG.Name = "spIDPHONG";
            // 
            // spSOLUONG
            // 
            this.spSOLUONG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.spSOLUONG.AppearanceHeader.Options.UseFont = true;
            this.spSOLUONG.Caption = "SỐ LƯỢNG";
            this.spSOLUONG.FieldName = "SOLUONG";
            this.spSOLUONG.MaxWidth = 100;
            this.spSOLUONG.Name = "spSOLUONG";
            this.spSOLUONG.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SOLUONG", "{0:0.##}")});
            this.spSOLUONG.Visible = true;
            this.spSOLUONG.VisibleIndex = 2;
            this.spSOLUONG.Width = 50;
            // 
            // spDONGIA
            // 
            this.spDONGIA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.spDONGIA.AppearanceHeader.Options.UseFont = true;
            this.spDONGIA.Caption = "ĐƠN GIÁ";
            this.spDONGIA.DisplayFormat.FormatString = "{0:#,#}";
            this.spDONGIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.spDONGIA.FieldName = "DONGIA";
            this.spDONGIA.MaxWidth = 100;
            this.spDONGIA.MinWidth = 80;
            this.spDONGIA.Name = "spDONGIA";
            this.spDONGIA.OptionsColumn.AllowEdit = false;
            this.spDONGIA.Visible = true;
            this.spDONGIA.VisibleIndex = 3;
            this.spDONGIA.Width = 80;
            // 
            // spTHANHTIEN
            // 
            this.spTHANHTIEN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.spTHANHTIEN.AppearanceHeader.Options.UseFont = true;
            this.spTHANHTIEN.Caption = "THÀNH TIỀN";
            this.spTHANHTIEN.DisplayFormat.FormatString = "{0:#,#}";
            this.spTHANHTIEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spTHANHTIEN.FieldName = "THANHTIEN";
            this.spTHANHTIEN.MaxWidth = 120;
            this.spTHANHTIEN.MinWidth = 80;
            this.spTHANHTIEN.Name = "spTHANHTIEN";
            this.spTHANHTIEN.OptionsColumn.AllowEdit = false;
            this.spTHANHTIEN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "THANHTIEN", "{0:n0}")});
            this.spTHANHTIEN.Visible = true;
            this.spTHANHTIEN.VisibleIndex = 4;
            this.spTHANHTIEN.Width = 80;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Blue;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.searchKH);
            this.groupControl1.Controls.Add(this.lblPhong);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.spSoNguoi);
            this.groupControl1.Controls.Add(this.lblHuy);
            this.groupControl1.Controls.Add(this.btnAddNew);
            this.groupControl1.Controls.Add(this.txtGhiChu);
            this.groupControl1.Controls.Add(this.label7);
            this.groupControl1.Controls.Add(this.cboTrangThai);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.dtNgayTra);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.dtNgayDat);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(578, 190);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông Tin Khách Hàng";
            // 
            // searchKH
            // 
            this.searchKH.EditValue = "  ";
            this.searchKH.Location = new System.Drawing.Point(87, 64);
            this.searchKH.Name = "searchKH";
            this.searchKH.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchKH.Properties.PopupView = this.searchLookUpEdit1View;
            this.searchKH.Size = new System.Drawing.Size(324, 20);
            this.searchKH.TabIndex = 30;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.HOTEN});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "IDKH";
            this.ID.MaxWidth = 50;
            this.ID.MinWidth = 30;
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 50;
            // 
            // HOTEN
            // 
            this.HOTEN.Caption = "HỌ TÊN";
            this.HOTEN.FieldName = "HOTEN";
            this.HOTEN.MaxWidth = 200;
            this.HOTEN.MinWidth = 150;
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Visible = true;
            this.HOTEN.VisibleIndex = 1;
            this.HOTEN.Width = 150;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblPhong.ForeColor = System.Drawing.Color.Red;
            this.lblPhong.Location = new System.Drawing.Point(116, 32);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(65, 19);
            this.lblPhong.TabIndex = 29;
            this.lblPhong.Text = "Phòng ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Số Người";
            // 
            // spSoNguoi
            // 
            this.spSoNguoi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spSoNguoi.Location = new System.Drawing.Point(86, 119);
            this.spSoNguoi.Name = "spSoNguoi";
            this.spSoNguoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spSoNguoi.Size = new System.Drawing.Size(151, 20);
            this.spSoNguoi.TabIndex = 27;
            // 
            // lblHuy
            // 
            this.lblHuy.AutoSize = true;
            this.lblHuy.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblHuy.ForeColor = System.Drawing.Color.Red;
            this.lblHuy.Location = new System.Drawing.Point(484, 69);
            this.lblHuy.Name = "lblHuy";
            this.lblHuy.Size = new System.Drawing.Size(17, 17);
            this.lblHuy.TabIndex = 26;
            this.lblHuy.Text = "*";
            // 
            // btnAddNew
            // 
            this.btnAddNew.ImageOptions.Image = global::KHACHSAN.Properties.Resources.add_16x16;
            this.btnAddNew.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnAddNew.Location = new System.Drawing.Point(417, 64);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(21, 21);
            this.btnAddNew.TabIndex = 25;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(86, 145);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(452, 21);
            this.txtGhiChu.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Ghi chú";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(352, 120);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(152, 21);
            this.cboTrangThai.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Trạng Thái";
            // 
            // dtNgayTra
            // 
            this.dtNgayTra.CustomFormat = "dd/MM/yyyy";
            this.dtNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayTra.Location = new System.Drawing.Point(352, 92);
            this.dtNgayTra.Name = "dtNgayTra";
            this.dtNgayTra.Size = new System.Drawing.Size(186, 21);
            this.dtNgayTra.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Ngày Trả";
            // 
            // dtNgayDat
            // 
            this.dtNgayDat.CustomFormat = "dd/MM/yyyy";
            this.dtNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayDat.Location = new System.Drawing.Point(86, 92);
            this.dtNgayDat.Name = "dtNgayDat";
            this.dtNgayDat.Size = new System.Drawing.Size(201, 21);
            this.dtNgayDat.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ngày Đặt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Khách Hàng";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.gcSanPham);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(270, 546);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Sản phẩm - Dịch vụ";
            // 
            // gcSanPham
            // 
            this.gcSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSanPham.Location = new System.Drawing.Point(2, 23);
            this.gcSanPham.MainView = this.gvSanPham;
            this.gcSanPham.Name = "gcSanPham";
            this.gcSanPham.Size = new System.Drawing.Size(266, 521);
            this.gcSanPham.TabIndex = 0;
            this.gcSanPham.UseDisabledStatePainter = false;
            this.gcSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSanPham});
            // 
            // gvSanPham
            // 
            this.gvSanPham.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDSP,
            this.TENSP,
            this.DONGIA});
            this.gvSanPham.GridControl = this.gcSanPham;
            this.gvSanPham.Name = "gvSanPham";
            this.gvSanPham.OptionsView.ShowGroupPanel = false;
            this.gvSanPham.DoubleClick += new System.EventHandler(this.gvSanPham_DoubleClick);
            // 
            // IDSP
            // 
            this.IDSP.FieldName = "IDSP";
            this.IDSP.Name = "IDSP";
            // 
            // TENSP
            // 
            this.TENSP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.TENSP.AppearanceHeader.Options.UseFont = true;
            this.TENSP.Caption = "TÊN SẢN PHẨM";
            this.TENSP.FieldName = "TENSP";
            this.TENSP.MaxWidth = 150;
            this.TENSP.MinWidth = 120;
            this.TENSP.Name = "TENSP";
            this.TENSP.Visible = true;
            this.TENSP.VisibleIndex = 0;
            this.TENSP.Width = 120;
            // 
            // DONGIA
            // 
            this.DONGIA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.DONGIA.AppearanceHeader.Options.UseFont = true;
            this.DONGIA.Caption = "ĐƠN GIÁ";
            this.DONGIA.DisplayFormat.FormatString = "{0:#,#}";
            this.DONGIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DONGIA.FieldName = "DONGIA";
            this.DONGIA.MaxWidth = 120;
            this.DONGIA.MinWidth = 100;
            this.DONGIA.Name = "DONGIA";
            this.DONGIA.Visible = true;
            this.DONGIA.VisibleIndex = 1;
            this.DONGIA.Width = 100;
            // 
            // btnSua
            // 
            this.btnSua.Image = global::KHACHSAN.Properties.Resources.Apps_menu_editor_icon;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(37, 38);
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmDatPhongDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 587);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmDatPhongDon";
            this.Text = "Đặt Phòng Khách Lẻ";
            this.Load += new System.EventHandler(this.frmDatPhongDon_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSPDV)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSPDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchKH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spSoNguoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnIn;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.SpinEdit spSoNguoi;
        private System.Windows.Forms.Label lblHuy;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtNgayTra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtNgayDat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl gcSPDV;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSPDV;
        private DevExpress.XtraGrid.Columns.GridColumn spIDSP;
        private DevExpress.XtraGrid.Columns.GridColumn spTENPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn spTENSP;
        private DevExpress.XtraGrid.Columns.GridColumn spIDPHONG;
        private DevExpress.XtraGrid.Columns.GridColumn spSOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn spDONGIA;
        private DevExpress.XtraGrid.Columns.GridColumn spTHANHTIEN;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gcSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn IDSP;
        private DevExpress.XtraGrid.Columns.GridColumn TENSP;
        private DevExpress.XtraGrid.Columns.GridColumn DONGIA;
        private DevExpress.XtraEditors.SearchLookUpEdit searchKH;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn HOTEN;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnSua;
    }
}