
namespace WindowsFormsApp1
{
    partial class XtraForm1
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
            this.dtNgayTra = new System.Windows.Forms.DateTimePicker();
            this.dtNgayDat = new System.Windows.Forms.DateTimePicker();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TANG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GIUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtNgayTra
            // 
            this.dtNgayTra.CustomFormat = "dd/MM/yyyy";
            this.dtNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayTra.Location = new System.Drawing.Point(502, 101);
            this.dtNgayTra.Name = "dtNgayTra";
            this.dtNgayTra.Size = new System.Drawing.Size(201, 21);
            this.dtNgayTra.TabIndex = 10;
            // 
            // dtNgayDat
            // 
            this.dtNgayDat.CustomFormat = "dd/MM/yyyy";
            this.dtNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayDat.Location = new System.Drawing.Point(502, 34);
            this.dtNgayDat.Name = "dtNgayDat";
            this.dtNgayDat.Size = new System.Drawing.Size(201, 21);
            this.dtNgayDat.TabIndex = 9;
            this.dtNgayDat.Leave += new System.EventHandler(this.dtNgayDat_Leave);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(441, 598);
            this.gridControl1.TabIndex = 11;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TEN,
            this.TANG,
            this.GIA,
            this.GIUONG});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // TEN
            // 
            this.TEN.Caption = "gridColumn1";
            this.TEN.FieldName = "TENPHONG";
            this.TEN.Name = "TEN";
            this.TEN.Visible = true;
            this.TEN.VisibleIndex = 0;
            // 
            // TANG
            // 
            this.TANG.Caption = "gridColumn2";
            this.TANG.FieldName = "TENTANG";
            this.TANG.Name = "TANG";
            this.TANG.Visible = true;
            this.TANG.VisibleIndex = 1;
            // 
            // GIA
            // 
            this.GIA.Caption = "gridColumn3";
            this.GIA.FieldName = "DONGIA";
            this.GIA.Name = "GIA";
            this.GIA.Visible = true;
            this.GIA.VisibleIndex = 2;
            // 
            // GIUONG
            // 
            this.GIUONG.Caption = "gridColumn4";
            this.GIUONG.FieldName = "SOGIUONG";
            this.GIUONG.Name = "GIUONG";
            this.GIUONG.Visible = true;
            this.GIUONG.VisibleIndex = 3;
            // 
            // XtraForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 598);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dtNgayTra);
            this.Controls.Add(this.dtNgayDat);
            this.Name = "XtraForm1";
            this.Text = "XtraForm1";
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtNgayTra;
        private System.Windows.Forms.DateTimePicker dtNgayDat;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn TEN;
        private DevExpress.XtraGrid.Columns.GridColumn TANG;
        private DevExpress.XtraGrid.Columns.GridColumn GIA;
        private DevExpress.XtraGrid.Columns.GridColumn GIUONG;
    }
}