namespace DuyThien_BTL.Childen
{
    partial class NhaCungCap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbThongTinNhaCungCap = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbXoa = new System.Windows.Forms.Label();
            this.dgvThongTinNCC = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cbbMaNCCTK = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.MessageBox = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.lbMaNhaCC = new System.Windows.Forms.Label();
            this.tbTenNhaCungCap = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbTenNhaCC = new System.Windows.Forms.Label();
            this.tbMaNhaCC = new Guna.UI2.WinForms.Guna2TextBox();
            this.grbThongTinNhaCungCap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinNCC)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThongTinNhaCungCap
            // 
            this.grbThongTinNhaCungCap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grbThongTinNhaCungCap.Controls.Add(this.tbMaNhaCC);
            this.grbThongTinNhaCungCap.Controls.Add(this.label1);
            this.grbThongTinNhaCungCap.Controls.Add(this.lbXoa);
            this.grbThongTinNhaCungCap.Controls.Add(this.dgvThongTinNCC);
            this.grbThongTinNhaCungCap.Controls.Add(this.cbbMaNCCTK);
            this.grbThongTinNhaCungCap.Controls.Add(this.btnHuy);
            this.grbThongTinNhaCungCap.Controls.Add(this.lbTenNhaCC);
            this.grbThongTinNhaCungCap.Controls.Add(this.tbTenNhaCungCap);
            this.grbThongTinNhaCungCap.Controls.Add(this.btnDong);
            this.grbThongTinNhaCungCap.Controls.Add(this.btnLuu);
            this.grbThongTinNhaCungCap.Controls.Add(this.btnThem);
            this.grbThongTinNhaCungCap.Controls.Add(this.lbMaNhaCC);
            this.grbThongTinNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grbThongTinNhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grbThongTinNhaCungCap.Location = new System.Drawing.Point(99, 34);
            this.grbThongTinNhaCungCap.Name = "grbThongTinNhaCungCap";
            this.grbThongTinNhaCungCap.Size = new System.Drawing.Size(836, 745);
            this.grbThongTinNhaCungCap.TabIndex = 5;
            this.grbThongTinNhaCungCap.Text = "Thông Tin Nhà Cung Cấp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.label1.Location = new System.Drawing.Point(28, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 21);
            this.label1.TabIndex = 46;
            this.label1.Text = "Mã Nhà Cung Cấp: ";
            // 
            // lbXoa
            // 
            this.lbXoa.AutoSize = true;
            this.lbXoa.BackColor = System.Drawing.Color.White;
            this.lbXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.lbXoa.Location = new System.Drawing.Point(28, 640);
            this.lbXoa.Name = "lbXoa";
            this.lbXoa.Size = new System.Drawing.Size(194, 21);
            this.lbXoa.TabIndex = 45;
            this.lbXoa.Text = "Kích đúp một hàng để xóa ";
            // 
            // dgvThongTinNCC
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvThongTinNCC.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvThongTinNCC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongTinNCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvThongTinNCC.ColumnHeadersHeight = 25;
            this.dgvThongTinNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongTinNCC.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvThongTinNCC.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongTinNCC.Location = new System.Drawing.Point(32, 271);
            this.dgvThongTinNCC.Name = "dgvThongTinNCC";
            this.dgvThongTinNCC.RowHeadersVisible = false;
            this.dgvThongTinNCC.RowHeadersWidth = 51;
            this.dgvThongTinNCC.RowTemplate.Height = 24;
            this.dgvThongTinNCC.Size = new System.Drawing.Size(781, 347);
            this.dgvThongTinNCC.TabIndex = 44;
            this.dgvThongTinNCC.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongTinNCC.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThongTinNCC.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThongTinNCC.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThongTinNCC.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThongTinNCC.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongTinNCC.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongTinNCC.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvThongTinNCC.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThongTinNCC.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvThongTinNCC.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThongTinNCC.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongTinNCC.ThemeStyle.HeaderStyle.Height = 25;
            this.dgvThongTinNCC.ThemeStyle.ReadOnly = false;
            this.dgvThongTinNCC.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongTinNCC.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongTinNCC.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvThongTinNCC.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgvThongTinNCC.ThemeStyle.RowsStyle.Height = 24;
            this.dgvThongTinNCC.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongTinNCC.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThongTinNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongTinNCC_CellClick);
            this.dgvThongTinNCC.DoubleClick += new System.EventHandler(this.dgvThongTinNCC_DoubleClick);
            // 
            // cbbMaNCCTK
            // 
            this.cbbMaNCCTK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbMaNCCTK.BackColor = System.Drawing.Color.Transparent;
            this.cbbMaNCCTK.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.cbbMaNCCTK.BorderRadius = 10;
            this.cbbMaNCCTK.BorderThickness = 2;
            this.cbbMaNCCTK.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMaNCCTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaNCCTK.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbMaNCCTK.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbMaNCCTK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbMaNCCTK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.cbbMaNCCTK.ItemHeight = 30;
            this.cbbMaNCCTK.Location = new System.Drawing.Point(178, 196);
            this.cbbMaNCCTK.Name = "cbbMaNCCTK";
            this.cbbMaNCCTK.Size = new System.Drawing.Size(194, 36);
            this.cbbMaNCCTK.TabIndex = 43;
            this.cbbMaNCCTK.SelectedIndexChanged += new System.EventHandler(this.cbbMaNCCTK_SelectedIndexChanged);
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
            this.btnHuy.Location = new System.Drawing.Point(460, 688);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 45);
            this.btnHuy.TabIndex = 39;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
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
            this.btnDong.Location = new System.Drawing.Point(623, 688);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(102, 45);
            this.btnDong.TabIndex = 35;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.White;
            this.btnLuu.BorderRadius = 10;
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(297, 688);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(110, 45);
            this.btnLuu.TabIndex = 34;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.BorderRadius = 10;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(111, 688);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(134, 45);
            this.btnThem.TabIndex = 33;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.MessageBox.Caption = null;
            this.MessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            this.MessageBox.Parent = null;
            this.MessageBox.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.MessageBox.Text = null;
            // 
            // lbMaNhaCC
            // 
            this.lbMaNhaCC.AutoSize = true;
            this.lbMaNhaCC.BackColor = System.Drawing.Color.White;
            this.lbMaNhaCC.Enabled = false;
            this.lbMaNhaCC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaNhaCC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.lbMaNhaCC.Location = new System.Drawing.Point(28, 96);
            this.lbMaNhaCC.Name = "lbMaNhaCC";
            this.lbMaNhaCC.Size = new System.Drawing.Size(144, 21);
            this.lbMaNhaCC.TabIndex = 15;
            this.lbMaNhaCC.Text = "Mã Nhà Cung Cấp: ";
            // 
            // tbTenNhaCungCap
            // 
            this.tbTenNhaCungCap.BackColor = System.Drawing.Color.White;
            this.tbTenNhaCungCap.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.tbTenNhaCungCap.BorderRadius = 10;
            this.tbTenNhaCungCap.BorderThickness = 2;
            this.tbTenNhaCungCap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTenNhaCungCap.DefaultText = "";
            this.tbTenNhaCungCap.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTenNhaCungCap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTenNhaCungCap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTenNhaCungCap.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTenNhaCungCap.Enabled = false;
            this.tbTenNhaCungCap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTenNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbTenNhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.tbTenNhaCungCap.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTenNhaCungCap.Location = new System.Drawing.Point(587, 87);
            this.tbTenNhaCungCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbTenNhaCungCap.Name = "tbTenNhaCungCap";
            this.tbTenNhaCungCap.PasswordChar = '\0';
            this.tbTenNhaCungCap.PlaceholderText = "";
            this.tbTenNhaCungCap.SelectedText = "";
            this.tbTenNhaCungCap.Size = new System.Drawing.Size(194, 39);
            this.tbTenNhaCungCap.TabIndex = 36;
            // 
            // lbTenNhaCC
            // 
            this.lbTenNhaCC.AutoSize = true;
            this.lbTenNhaCC.BackColor = System.Drawing.Color.White;
            this.lbTenNhaCC.Enabled = false;
            this.lbTenNhaCC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNhaCC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.lbTenNhaCC.Location = new System.Drawing.Point(425, 95);
            this.lbTenNhaCC.Name = "lbTenNhaCC";
            this.lbTenNhaCC.Size = new System.Drawing.Size(145, 21);
            this.lbTenNhaCC.TabIndex = 38;
            this.lbTenNhaCC.Text = "Tên Nhà Cung Cấp: ";
            // 
            // tbMaNhaCC
            // 
            this.tbMaNhaCC.BackColor = System.Drawing.Color.White;
            this.tbMaNhaCC.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.tbMaNhaCC.BorderRadius = 10;
            this.tbMaNhaCC.BorderThickness = 2;
            this.tbMaNhaCC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMaNhaCC.DefaultText = "";
            this.tbMaNhaCC.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbMaNhaCC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbMaNhaCC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMaNhaCC.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMaNhaCC.Enabled = false;
            this.tbMaNhaCC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMaNhaCC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbMaNhaCC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.tbMaNhaCC.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMaNhaCC.Location = new System.Drawing.Point(192, 87);
            this.tbMaNhaCC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMaNhaCC.Name = "tbMaNhaCC";
            this.tbMaNhaCC.PasswordChar = '\0';
            this.tbMaNhaCC.PlaceholderText = "";
            this.tbMaNhaCC.SelectedText = "";
            this.tbMaNhaCC.Size = new System.Drawing.Size(194, 39);
            this.tbMaNhaCC.TabIndex = 47;
            // 
            // NhaCungCap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1035, 803);
            this.Controls.Add(this.grbThongTinNhaCungCap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NhaCungCap";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.NhaCungCap_Load);
            this.grbThongTinNhaCungCap.ResumeLayout(false);
            this.grbThongTinNhaCungCap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTinNCC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox grbThongTinNhaCungCap;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2ComboBox cbbMaNCCTK;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThongTinNCC;
        private System.Windows.Forms.Label lbXoa;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2MessageDialog MessageBox;
        private Guna.UI2.WinForms.Guna2TextBox tbMaNhaCC;
        private System.Windows.Forms.Label lbTenNhaCC;
        private Guna.UI2.WinForms.Guna2TextBox tbTenNhaCungCap;
        private System.Windows.Forms.Label lbMaNhaCC;
    }
}