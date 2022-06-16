
namespace KHACHSAN
{
    partial class frmBooking_Web
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNhan = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.room_type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.check_in_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.check_in_time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.check_out_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Occupancy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNhan,
            this.btnXoa,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1347, 41);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNhan
            // 
            this.btnNhan.Image = global::KHACHSAN.Properties.Resources.add_1_icon;
            this.btnNhan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNhan.Name = "btnNhan";
            this.btnNhan.Size = new System.Drawing.Size(46, 38);
            this.btnNhan.Text = "Nhận";
            this.btnNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
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
            // btnThoat
            // 
            this.btnThoat.Image = global::KHACHSAN.Properties.Resources.system_shutdown_icon1;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(51, 38);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtDenNgay);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtTuNgay);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1347, 92);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Ngày";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDenNgay.Location = new System.Drawing.Point(625, 47);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(200, 21);
            this.dtDenNgay.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Đến Ngày ";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTuNgay.Location = new System.Drawing.Point(279, 47);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(200, 21);
            this.dtTuNgay.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Từ Ngày ";
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDanhSach.Location = new System.Drawing.Point(0, 133);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(1347, 516);
            this.gcDanhSach.TabIndex = 14;
            this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            this.gcDanhSach.Click += new System.EventHandler(this.gcDanhSach_Click);
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.name,
            this.email,
            this.phone,
            this.address,
            this.room_type,
            this.check_in_date,
            this.check_in_time,
            this.check_out_date,
            this.Occupancy});
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // name
            // 
            this.name.Caption = "TÊN KHÁCH HÀNG";
            this.name.FieldName = "name";
            this.name.MaxWidth = 120;
            this.name.MinWidth = 80;
            this.name.Name = "name";
            this.name.Visible = true;
            this.name.VisibleIndex = 0;
            this.name.Width = 80;
            // 
            // email
            // 
            this.email.Caption = "EMAIL";
            this.email.FieldName = "email";
            this.email.MaxWidth = 120;
            this.email.MinWidth = 80;
            this.email.Name = "email";
            this.email.Visible = true;
            this.email.VisibleIndex = 1;
            this.email.Width = 80;
            // 
            // phone
            // 
            this.phone.Caption = "SỐ ĐIỆN THOẠI";
            this.phone.FieldName = "phone";
            this.phone.MaxWidth = 120;
            this.phone.MinWidth = 80;
            this.phone.Name = "phone";
            this.phone.Visible = true;
            this.phone.VisibleIndex = 2;
            this.phone.Width = 80;
            // 
            // address
            // 
            this.address.Caption = "ĐỊA CHỈ";
            this.address.FieldName = "address";
            this.address.MinWidth = 150;
            this.address.Name = "address";
            this.address.Visible = true;
            this.address.VisibleIndex = 8;
            this.address.Width = 150;
            // 
            // room_type
            // 
            this.room_type.Caption = "LOẠI PHÒNG";
            this.room_type.FieldName = "room_type";
            this.room_type.MaxWidth = 120;
            this.room_type.MinWidth = 80;
            this.room_type.Name = "room_type";
            this.room_type.Visible = true;
            this.room_type.VisibleIndex = 3;
            this.room_type.Width = 80;
            // 
            // check_in_date
            // 
            this.check_in_date.Caption = "NGÀY ";
            this.check_in_date.FieldName = "check_in_date";
            this.check_in_date.MaxWidth = 100;
            this.check_in_date.MinWidth = 50;
            this.check_in_date.Name = "check_in_date";
            this.check_in_date.Visible = true;
            this.check_in_date.VisibleIndex = 5;
            // 
            // check_in_time
            // 
            this.check_in_time.Caption = "NGÀY ĐẶT";
            this.check_in_time.FieldName = "check_in_time";
            this.check_in_time.MaxWidth = 100;
            this.check_in_time.MinWidth = 50;
            this.check_in_time.Name = "check_in_time";
            this.check_in_time.Visible = true;
            this.check_in_time.VisibleIndex = 6;
            this.check_in_time.Width = 100;
            // 
            // check_out_date
            // 
            this.check_out_date.Caption = "NGÀY TRẢ";
            this.check_out_date.FieldName = "check_out_date";
            this.check_out_date.MaxWidth = 150;
            this.check_out_date.MinWidth = 100;
            this.check_out_date.Name = "check_out_date";
            this.check_out_date.Visible = true;
            this.check_out_date.VisibleIndex = 7;
            this.check_out_date.Width = 150;
            // 
            // Occupancy
            // 
            this.Occupancy.Caption = "SỐ NGƯỜI";
            this.Occupancy.FieldName = "Occupancy";
            this.Occupancy.MaxWidth = 80;
            this.Occupancy.MinWidth = 60;
            this.Occupancy.Name = "Occupancy";
            this.Occupancy.Visible = true;
            this.Occupancy.VisibleIndex = 4;
            // 
            // frmBooking_Web
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 649);
            this.Controls.Add(this.gcDanhSach);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmBooking_Web";
            this.Text = "Booking Online";
            this.Load += new System.EventHandler(this.frmBooking_Web_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNhan;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private System.Windows.Forms.DateTimePicker dtDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTuNgay;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn name;
        private DevExpress.XtraGrid.Columns.GridColumn email;
        private DevExpress.XtraGrid.Columns.GridColumn phone;
        private DevExpress.XtraGrid.Columns.GridColumn address;
        private DevExpress.XtraGrid.Columns.GridColumn room_type;
        private DevExpress.XtraGrid.Columns.GridColumn check_in_date;
        private DevExpress.XtraGrid.Columns.GridColumn check_in_time;
        private DevExpress.XtraGrid.Columns.GridColumn check_out_date;
        private DevExpress.XtraGrid.Columns.GridColumn Occupancy;
    }
}