namespace DuyThien_BTL.Childen
{
    partial class QuanLyKho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbThongTinMatHang = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboMaSP = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvThongTinMatHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChiTietSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MauSac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.btnInThongTinSP = new Guna.UI2.WinForms.Guna2Button();
            this.MessageGuna = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.grbThongTinMatHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinMatHang)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThongTinMatHang
            // 
            this.grbThongTinMatHang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grbThongTinMatHang.Controls.Add(this.btnHuy);
            this.grbThongTinMatHang.Controls.Add(this.guna2HtmlLabel1);
            this.grbThongTinMatHang.Controls.Add(this.cboMaSP);
            this.grbThongTinMatHang.Controls.Add(this.dgvThongTinMatHang);
            this.grbThongTinMatHang.Controls.Add(this.btnDong);
            this.grbThongTinMatHang.Controls.Add(this.btnInThongTinSP);
            this.grbThongTinMatHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbThongTinMatHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grbThongTinMatHang.Location = new System.Drawing.Point(56, 36);
            this.grbThongTinMatHang.Name = "grbThongTinMatHang";
            this.grbThongTinMatHang.Size = new System.Drawing.Size(952, 748);
            this.grbThongTinMatHang.TabIndex = 4;
            this.grbThongTinMatHang.Text = "Thông Tin Các Mặt Hàng";
            this.grbThongTinMatHang.Click += new System.EventHandler(this.grbThongTinMatHang_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.BorderRadius = 10;
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(600, 683);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(132, 42);
            this.btnHuy.TabIndex = 43;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(28, 533);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(132, 23);
            this.guna2HtmlLabel1.TabIndex = 38;
            this.guna2HtmlLabel1.Text = "Chi Tiết Sản Phẩm";
            // 
            // cboMaSP
            // 
            this.cboMaSP.BackColor = System.Drawing.Color.Transparent;
            this.cboMaSP.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(68)))));
            this.cboMaSP.BorderRadius = 10;
            this.cboMaSP.BorderThickness = 2;
            this.cboMaSP.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMaSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaSP.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMaSP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMaSP.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboMaSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMaSP.ItemHeight = 30;
            this.cboMaSP.Location = new System.Drawing.Point(247, 533);
            this.cboMaSP.Name = "cboMaSP";
            this.cboMaSP.Size = new System.Drawing.Size(220, 36);
            this.cboMaSP.TabIndex = 37;
            this.cboMaSP.SelectedIndexChanged += new System.EventHandler(this.cboMaCTSP_SelectedIndexChanged);
            // 
            // dgvThongTinMatHang
            // 
            this.dgvThongTinMatHang.AllowUserToAddRows = false;
            this.dgvThongTinMatHang.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvThongTinMatHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThongTinMatHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvThongTinMatHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongTinMatHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThongTinMatHang.ColumnHeadersHeight = 30;
            this.dgvThongTinMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongTinMatHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.MaChiTietSP,
            this.MauSac,
            this.Size,
            this.SoLuong});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongTinMatHang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThongTinMatHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongTinMatHang.Location = new System.Drawing.Point(8, 54);
            this.dgvThongTinMatHang.Name = "dgvThongTinMatHang";
            this.dgvThongTinMatHang.ReadOnly = true;
            this.dgvThongTinMatHang.RowHeadersVisible = false;
            this.dgvThongTinMatHang.RowHeadersWidth = 62;
            this.dgvThongTinMatHang.RowTemplate.Height = 28;
            this.dgvThongTinMatHang.Size = new System.Drawing.Size(934, 444);
            this.dgvThongTinMatHang.TabIndex = 36;
            this.dgvThongTinMatHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongTinMatHang.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThongTinMatHang.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThongTinMatHang.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThongTinMatHang.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThongTinMatHang.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongTinMatHang.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongTinMatHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvThongTinMatHang.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dgvThongTinMatHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvThongTinMatHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThongTinMatHang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongTinMatHang.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvThongTinMatHang.ThemeStyle.ReadOnly = true;
            this.dgvThongTinMatHang.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongTinMatHang.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongTinMatHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvThongTinMatHang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvThongTinMatHang.ThemeStyle.RowsStyle.Height = 28;
            this.dgvThongTinMatHang.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongTinMatHang.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.MinimumWidth = 8;
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            // 
            // MaChiTietSP
            // 
            this.MaChiTietSP.DataPropertyName = "MaChiTietSP";
            this.MaChiTietSP.HeaderText = "Chi tiết SP";
            this.MaChiTietSP.MinimumWidth = 8;
            this.MaChiTietSP.Name = "MaChiTietSP";
            this.MaChiTietSP.ReadOnly = true;
            // 
            // MauSac
            // 
            this.MauSac.DataPropertyName = "MauSac";
            this.MauSac.HeaderText = "Màu sắc";
            this.MauSac.MinimumWidth = 8;
            this.MauSac.Name = "MauSac";
            this.MauSac.ReadOnly = true;
            // 
            // Size
            // 
            this.Size.DataPropertyName = "Size";
            this.Size.HeaderText = "Size";
            this.Size.MinimumWidth = 8;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.BorderRadius = 10;
            this.btnDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(790, 683);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(117, 42);
            this.btnDong.TabIndex = 35;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnInThongTinSP
            // 
            this.btnInThongTinSP.BackColor = System.Drawing.Color.White;
            this.btnInThongTinSP.BorderRadius = 10;
            this.btnInThongTinSP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInThongTinSP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInThongTinSP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInThongTinSP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInThongTinSP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnInThongTinSP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInThongTinSP.ForeColor = System.Drawing.Color.White;
            this.btnInThongTinSP.Location = new System.Drawing.Point(364, 683);
            this.btnInThongTinSP.Name = "btnInThongTinSP";
            this.btnInThongTinSP.Size = new System.Drawing.Size(178, 42);
            this.btnInThongTinSP.TabIndex = 34;
            this.btnInThongTinSP.Text = "In Thông Tin Kho";
            this.btnInThongTinSP.Click += new System.EventHandler(this.btnInThongTinSP_Click);
            // 
            // MessageGuna
            // 
            this.MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageGuna.Caption = null;
            this.MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.MessageGuna.Parent = null;
            this.MessageGuna.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.MessageGuna.Text = null;
            // 
            // QuanLyKho
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1035, 850);
            this.Controls.Add(this.grbThongTinMatHang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuanLyKho";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.QuanLyKho_Load);
            this.grbThongTinMatHang.ResumeLayout(false);
            this.grbThongTinMatHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinMatHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox grbThongTinMatHang;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox cboMaSP;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThongTinMatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiTietSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MauSac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2Button btnInThongTinSP;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageGuna;
    }
}