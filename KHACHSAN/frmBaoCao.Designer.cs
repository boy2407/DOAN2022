
namespace KHACHSAN
{
    partial class frmBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            this.splBaoCao = new DevExpress.XtraEditors.SplitContainerControl();
            this.lstDanhSach = new DevExpress.XtraEditors.ImageListBoxControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splBaoCao)).BeginInit();
            this.splBaoCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // splBaoCao
            // 
            this.splBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splBaoCao.Location = new System.Drawing.Point(0, 0);
            this.splBaoCao.Name = "splBaoCao";
            this.splBaoCao.Panel1.Controls.Add(this.lstDanhSach);
            this.splBaoCao.Panel1.Text = "Panel1";
            this.splBaoCao.Panel2.Controls.Add(this.simpleButton2);
            this.splBaoCao.Panel2.Controls.Add(this.btnThucHien);
            this.splBaoCao.Panel2.Text = "Panel2";
            this.splBaoCao.Size = new System.Drawing.Size(902, 563);
            this.splBaoCao.SplitterPosition = 307;
            this.splBaoCao.TabIndex = 0;
            // 
            // lstDanhSach
            // 
            this.lstDanhSach.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lstDanhSach.Appearance.Options.UseFont = true;
            this.lstDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDanhSach.Location = new System.Drawing.Point(0, 0);
            this.lstDanhSach.Name = "lstDanhSach";
            this.lstDanhSach.Size = new System.Drawing.Size(307, 563);
            this.lstDanhSach.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(435, 511);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(119, 40);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Đóng";
            // 
            // btnThucHien
            // 
            this.btnThucHien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThucHien.ImageOptions.Image")));
            this.btnThucHien.Location = new System.Drawing.Point(300, 511);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(119, 40);
            this.btnThucHien.TabIndex = 0;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 563);
            this.Controls.Add(this.splBaoCao);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splBaoCao)).EndInit();
            this.splBaoCao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splBaoCao;
        private DevExpress.XtraEditors.ImageListBoxControl lstDanhSach;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnThucHien;
    }
}