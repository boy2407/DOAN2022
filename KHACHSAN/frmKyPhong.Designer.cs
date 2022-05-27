
namespace KHACHSAN
{
    partial class frmKyPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKyPhong));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnBoQua = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.btnThongKe = new System.Windows.Forms.ToolStripButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MAKY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SONGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NGAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
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
            this.btnThoat,
            this.btnThongKe});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1097, 41);
            this.toolStrip1.TabIndex = 3;
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
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
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
            // btnXoa
            // 
            this.btnXoa.Image = global::KHACHSAN.Properties.Resources.Trash_Empty_icon;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(37, 38);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
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
            // btnBoQua
            // 
            this.btnBoQua.Image = global::KHACHSAN.Properties.Resources.undo_icon;
            this.btnBoQua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(58, 38);
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
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
            // btnThongKe
            // 
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(76, 38);
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.cboNam);
            this.groupControl1.Controls.Add(this.cboThang);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 41);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1097, 105);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Nhập Tháng Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(495, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Năm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(199, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tháng";
            // 
            // cboNam
            // 
            this.cboNam.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(547, 49);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(135, 27);
            this.cboNam.TabIndex = 1;
            // 
            // cboThang
            // 
            this.cboThang.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(267, 49);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(135, 27);
            this.cboThang.TabIndex = 0;
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSach.Location = new System.Drawing.Point(0, 146);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(1097, 577);
            this.gcDanhSach.TabIndex = 6;
            this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            this.gcDanhSach.Click += new System.EventHandler(this.gcDanhSach_Click);
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MAKY,
            this.SONGAY,
            this.NGAY,
            this.NAM,
            this.THANG});
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Fast;
            this.gvDanhSach.OptionsView.BestFitUseErrorInfo = DevExpress.Utils.DefaultBoolean.True;
            this.gvDanhSach.OptionsView.EnableAppearanceOddRow = true;
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            this.gvDanhSach.PaintStyleName = "WindowsXP";
            // 
            // MAKY
            // 
            this.MAKY.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F);
            this.MAKY.AppearanceCell.Options.UseFont = true;
            this.MAKY.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.MAKY.AppearanceHeader.Options.UseFont = true;
            this.MAKY.Caption = "MÃ KỲ";
            this.MAKY.FieldName = "MAKY";
            this.MAKY.MaxWidth = 300;
            this.MAKY.MinWidth = 100;
            this.MAKY.Name = "MAKY";
            this.MAKY.Visible = true;
            this.MAKY.VisibleIndex = 0;
            this.MAKY.Width = 300;
            // 
            // SONGAY
            // 
            this.SONGAY.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F);
            this.SONGAY.AppearanceCell.Options.UseFont = true;
            this.SONGAY.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.SONGAY.AppearanceHeader.Options.UseFont = true;
            this.SONGAY.Caption = "SỐ NGÀY";
            this.SONGAY.FieldName = "SONGAY";
            this.SONGAY.MaxWidth = 300;
            this.SONGAY.MinWidth = 100;
            this.SONGAY.Name = "SONGAY";
            this.SONGAY.Visible = true;
            this.SONGAY.VisibleIndex = 3;
            this.SONGAY.Width = 300;
            // 
            // NGAY
            // 
            this.NGAY.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F);
            this.NGAY.AppearanceCell.Options.UseFont = true;
            this.NGAY.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.NGAY.AppearanceHeader.Options.UseFont = true;
            this.NGAY.Caption = "NGÀY TÍNH KỲ";
            this.NGAY.FieldName = "NGAY";
            this.NGAY.MaxWidth = 300;
            this.NGAY.MinWidth = 100;
            this.NGAY.Name = "NGAY";
            this.NGAY.Visible = true;
            this.NGAY.VisibleIndex = 4;
            this.NGAY.Width = 100;
            // 
            // NAM
            // 
            this.NAM.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F);
            this.NAM.AppearanceCell.Options.UseFont = true;
            this.NAM.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NAM.AppearanceHeader.Options.UseFont = true;
            this.NAM.Caption = "NĂM";
            this.NAM.FieldName = "NAM";
            this.NAM.Name = "NAM";
            this.NAM.Visible = true;
            this.NAM.VisibleIndex = 1;
            // 
            // THANG
            // 
            this.THANG.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 11F);
            this.THANG.AppearanceCell.Options.UseFont = true;
            this.THANG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.THANG.AppearanceHeader.Options.UseFont = true;
            this.THANG.Caption = "THẮNG";
            this.THANG.FieldName = "THANG";
            this.THANG.Name = "THANG";
            this.THANG.Visible = true;
            this.THANG.VisibleIndex = 2;
            // 
            // frmKyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 723);
            this.Controls.Add(this.gcDanhSach);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmKyPhong";
            this.Text = "Kỳ Phòng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPhongTrongTuan_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
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
        private System.Windows.Forms.ToolStripButton btnThoat;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.ComboBox cboThang;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn MAKY;
        private DevExpress.XtraGrid.Columns.GridColumn SONGAY;
        private DevExpress.XtraGrid.Columns.GridColumn NGAY;
        private System.Windows.Forms.ToolStripButton btnThongKe;
        private DevExpress.XtraGrid.Columns.GridColumn NAM;
        private DevExpress.XtraGrid.Columns.GridColumn THANG;
    }
}