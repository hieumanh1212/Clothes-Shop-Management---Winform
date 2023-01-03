using System.Windows.Media.Media3D;
using System;
using System.Windows.Shapes;

namespace DuyThien_BTL
{
    partial class FormMain_QuanLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain_QuanLy));
            this.TimeMenu = new System.Windows.Forms.Timer(this.components);
            this.lbLogo = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.PanelHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.iconAn = new FontAwesome.Sharp.IconButton();
            this.iconClose = new FontAwesome.Sharp.IconButton();
            this.iconMaxMin = new FontAwesome.Sharp.IconButton();
            this.timeChilden = new System.Windows.Forms.Timer(this.components);
            this.timeForm = new System.Windows.Forms.Timer(this.components);
            this.timeSetting = new System.Windows.Forms.Timer(this.components);
            this.PanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.ptbLogo = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.panelChilden = new System.Windows.Forms.FlowLayoutPanel();
            this.iconHome = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyNhanVien = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyKhachHang = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyNhaCungCap = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyVocher = new FontAwesome.Sharp.IconButton();
            this.btnQuanLySanPham = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyChatLieu = new FontAwesome.Sharp.IconButton();
            this.btnQuanLyTheLoai = new FontAwesome.Sharp.IconButton();
            this.btnThongKeDoanhThu = new FontAwesome.Sharp.IconButton();
            this.iconSetting = new FontAwesome.Sharp.IconButton();
            this.iconAbout = new FontAwesome.Sharp.IconButton();
            this.iconHelp = new FontAwesome.Sharp.IconButton();
            this.panelSet = new System.Windows.Forms.Panel();
            this.ptbUser = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbMenu = new System.Windows.Forms.Label();
            this.ptbIconMenu = new FontAwesome.Sharp.IconPictureBox();
            this.panelContraint = new Guna.UI2.WinForms.Guna2Panel();
            this.panelSetting = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDoiMatKhau = new FontAwesome.Sharp.IconButton();
            this.btnDangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btnThongTinCaNhan = new FontAwesome.Sharp.IconButton();
            this.timeResetForm = new System.Windows.Forms.Timer(this.components);
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.PanelHeader.SuspendLayout();
            this.PanelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.panelChilden.SuspendLayout();
            this.panelSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIconMenu)).BeginInit();
            this.panelContraint.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeMenu
            // 
            this.TimeMenu.Interval = 10;
            this.TimeMenu.Tick += new System.EventHandler(this.TimeMenu_Tick);
            // 
            // lbLogo
            // 
            this.lbLogo.BackColor = System.Drawing.Color.Transparent;
            this.lbLogo.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogo.ForeColor = System.Drawing.Color.Turquoise;
            this.lbLogo.Location = new System.Drawing.Point(92, 57);
            this.lbLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbLogo.Name = "lbLogo";
            this.lbLogo.Size = new System.Drawing.Size(84, 27);
            this.lbLogo.TabIndex = 4;
            this.lbLogo.Text = "SHOP QA";
            this.lbLogo.Click += new System.EventHandler(this.lbLogo_Click);
            // 
            // PanelHeader
            // 
            this.PanelHeader.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PanelHeader.Controls.Add(this.iconAn);
            this.PanelHeader.Controls.Add(this.iconClose);
            this.PanelHeader.Controls.Add(this.iconMaxMin);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelHeader.Location = new System.Drawing.Point(0, 0);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(1500, 40);
            this.PanelHeader.TabIndex = 12;
            this.PanelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelHeader_MouseDown);
            // 
            // iconAn
            // 
            this.iconAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconAn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconAn.FlatAppearance.BorderSize = 0;
            this.iconAn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.iconAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconAn.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconAn.IconColor = System.Drawing.Color.Moccasin;
            this.iconAn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconAn.IconSize = 30;
            this.iconAn.Location = new System.Drawing.Point(1395, 5);
            this.iconAn.Name = "iconAn";
            this.iconAn.Size = new System.Drawing.Size(30, 30);
            this.iconAn.TabIndex = 8;
            this.iconAn.UseVisualStyleBackColor = true;
            this.iconAn.Click += new System.EventHandler(this.iconAn_Click);
            // 
            // iconClose
            // 
            this.iconClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconClose.FlatAppearance.BorderSize = 0;
            this.iconClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.iconClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconClose.IconChar = FontAwesome.Sharp.IconChar.RectangleXmark;
            this.iconClose.IconColor = System.Drawing.Color.Moccasin;
            this.iconClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconClose.IconSize = 30;
            this.iconClose.Location = new System.Drawing.Point(1467, 5);
            this.iconClose.Name = "iconClose";
            this.iconClose.Size = new System.Drawing.Size(30, 30);
            this.iconClose.TabIndex = 6;
            this.iconClose.UseVisualStyleBackColor = true;
            this.iconClose.Click += new System.EventHandler(this.iconClose_Click);
            // 
            // iconMaxMin
            // 
            this.iconMaxMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMaxMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconMaxMin.FlatAppearance.BorderSize = 0;
            this.iconMaxMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.iconMaxMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconMaxMin.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.iconMaxMin.IconColor = System.Drawing.Color.Moccasin;
            this.iconMaxMin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMaxMin.IconSize = 30;
            this.iconMaxMin.Location = new System.Drawing.Point(1431, 5);
            this.iconMaxMin.Name = "iconMaxMin";
            this.iconMaxMin.Size = new System.Drawing.Size(30, 30);
            this.iconMaxMin.TabIndex = 7;
            this.iconMaxMin.UseVisualStyleBackColor = true;
            this.iconMaxMin.Click += new System.EventHandler(this.iconMaxMin_Click);
            // 
            // timeChilden
            // 
            this.timeChilden.Interval = 50;
            this.timeChilden.Tick += new System.EventHandler(this.timeContraint_Tick);
            // 
            // timeForm
            // 
            this.timeForm.Interval = 10;
            this.timeForm.Tick += new System.EventHandler(this.timeForm_Tick);
            // 
            // timeSetting
            // 
            this.timeSetting.Interval = 10;
            this.timeSetting.Tick += new System.EventHandler(this.timeSetting_Tick);
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(69)))));
            this.PanelMenu.Controls.Add(this.panelLogo);
            this.PanelMenu.Controls.Add(this.panelChilden);
            this.PanelMenu.Controls.Add(this.iconSetting);
            this.PanelMenu.Controls.Add(this.iconAbout);
            this.PanelMenu.Controls.Add(this.iconHelp);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 40);
            this.PanelMenu.MaximumSize = new System.Drawing.Size(301, 1000);
            this.PanelMenu.MinimumSize = new System.Drawing.Size(80, 910);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(301, 910);
            this.PanelMenu.TabIndex = 12;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.ptbLogo);
            this.panelLogo.Location = new System.Drawing.Point(3, 2);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelLogo.Size = new System.Drawing.Size(298, 131);
            this.panelLogo.TabIndex = 0;
            // 
            // ptbLogo
            // 
            this.ptbLogo.BackColor = System.Drawing.Color.Transparent;
            this.ptbLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbLogo.Image = ((System.Drawing.Image)(resources.GetObject("ptbLogo.Image")));
            this.ptbLogo.ImageRotate = 0F;
            this.ptbLogo.Location = new System.Drawing.Point(3, -2);
            this.ptbLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbLogo.MaximumSize = new System.Drawing.Size(273, 131);
            this.ptbLogo.MinimumSize = new System.Drawing.Size(82, 131);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ptbLogo.Size = new System.Drawing.Size(273, 131);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbLogo.TabIndex = 0;
            this.ptbLogo.TabStop = false;
            this.ptbLogo.UseTransparentBackground = true;
            this.ptbLogo.Click += new System.EventHandler(this.ptbLogo_Click);
            // 
            // panelChilden
            // 
            this.panelChilden.Controls.Add(this.iconHome);
            this.panelChilden.Controls.Add(this.btnQuanLyNhanVien);
            this.panelChilden.Controls.Add(this.btnQuanLyKhachHang);
            this.panelChilden.Controls.Add(this.btnQuanLyNhaCungCap);
            this.panelChilden.Controls.Add(this.btnQuanLyVocher);
            this.panelChilden.Controls.Add(this.btnQuanLySanPham);
            this.panelChilden.Controls.Add(this.btnQuanLyChatLieu);
            this.panelChilden.Controls.Add(this.btnQuanLyTheLoai);
            this.panelChilden.Controls.Add(this.btnThongKeDoanhThu);
            this.panelChilden.Location = new System.Drawing.Point(3, 138);
            this.panelChilden.MaximumSize = new System.Drawing.Size(292, 482);
            this.panelChilden.MinimumSize = new System.Drawing.Size(253, 109);
            this.panelChilden.Name = "panelChilden";
            this.panelChilden.Size = new System.Drawing.Size(292, 109);
            this.panelChilden.TabIndex = 1;
            // 
            // iconHome
            // 
            this.iconHome.FlatAppearance.BorderSize = 0;
            this.iconHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconHome.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconHome.ForeColor = System.Drawing.Color.Turquoise;
            this.iconHome.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconHome.IconColor = System.Drawing.Color.Turquoise;
            this.iconHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconHome.IconSize = 45;
            this.iconHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconHome.Location = new System.Drawing.Point(3, 2);
            this.iconHome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconHome.Name = "iconHome";
            this.iconHome.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.iconHome.Size = new System.Drawing.Size(289, 107);
            this.iconHome.TabIndex = 5;
            this.iconHome.Text = "   Home";
            this.iconHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconHome.UseVisualStyleBackColor = true;
            this.iconHome.Click += new System.EventHandler(this.iconMenu_Click);
            // 
            // btnQuanLyNhanVien
            // 
            this.btnQuanLyNhanVien.FlatAppearance.BorderSize = 0;
            this.btnQuanLyNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyNhanVien.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyNhanVien.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnQuanLyNhanVien.IconColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyNhanVien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyNhanVien.IconSize = 35;
            this.btnQuanLyNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhanVien.Location = new System.Drawing.Point(3, 113);
            this.btnQuanLyNhanVien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
            this.btnQuanLyNhanVien.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnQuanLyNhanVien.Size = new System.Drawing.Size(253, 40);
            this.btnQuanLyNhanVien.TabIndex = 1;
            this.btnQuanLyNhanVien.Text = "     Quản Lý Nhân Viên";
            this.btnQuanLyNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhanVien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyNhanVien.UseVisualStyleBackColor = true;
            this.btnQuanLyNhanVien.Click += new System.EventHandler(this.btnQuanLyNhanVien_Click);
            // 
            // btnQuanLyKhachHang
            // 
            this.btnQuanLyKhachHang.FlatAppearance.BorderSize = 0;
            this.btnQuanLyKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyKhachHang.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyKhachHang.IconChar = FontAwesome.Sharp.IconChar.Vcard;
            this.btnQuanLyKhachHang.IconColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyKhachHang.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyKhachHang.IconSize = 35;
            this.btnQuanLyKhachHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyKhachHang.Location = new System.Drawing.Point(3, 157);
            this.btnQuanLyKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLyKhachHang.Name = "btnQuanLyKhachHang";
            this.btnQuanLyKhachHang.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnQuanLyKhachHang.Size = new System.Drawing.Size(253, 40);
            this.btnQuanLyKhachHang.TabIndex = 2;
            this.btnQuanLyKhachHang.Text = "     Quản Lý Khách Hàng";
            this.btnQuanLyKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyKhachHang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyKhachHang.UseVisualStyleBackColor = true;
            this.btnQuanLyKhachHang.Click += new System.EventHandler(this.btnQuanLyKhachHang_Click);
            // 
            // btnQuanLyNhaCungCap
            // 
            this.btnQuanLyNhaCungCap.FlatAppearance.BorderSize = 0;
            this.btnQuanLyNhaCungCap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyNhaCungCap.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyNhaCungCap.IconChar = FontAwesome.Sharp.IconChar.TruckArrowRight;
            this.btnQuanLyNhaCungCap.IconColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyNhaCungCap.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyNhaCungCap.IconSize = 35;
            this.btnQuanLyNhaCungCap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhaCungCap.Location = new System.Drawing.Point(3, 201);
            this.btnQuanLyNhaCungCap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLyNhaCungCap.Name = "btnQuanLyNhaCungCap";
            this.btnQuanLyNhaCungCap.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnQuanLyNhaCungCap.Size = new System.Drawing.Size(253, 40);
            this.btnQuanLyNhaCungCap.TabIndex = 3;
            this.btnQuanLyNhaCungCap.Text = "     Quản Lý Nhà Cung Cấp";
            this.btnQuanLyNhaCungCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyNhaCungCap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyNhaCungCap.UseVisualStyleBackColor = true;
            this.btnQuanLyNhaCungCap.Click += new System.EventHandler(this.btnNhaCC_Click);
            // 
            // btnQuanLyVocher
            // 
            this.btnQuanLyVocher.FlatAppearance.BorderSize = 0;
            this.btnQuanLyVocher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyVocher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyVocher.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyVocher.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.btnQuanLyVocher.IconColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyVocher.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyVocher.IconSize = 35;
            this.btnQuanLyVocher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyVocher.Location = new System.Drawing.Point(3, 245);
            this.btnQuanLyVocher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLyVocher.Name = "btnQuanLyVocher";
            this.btnQuanLyVocher.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnQuanLyVocher.Size = new System.Drawing.Size(253, 40);
            this.btnQuanLyVocher.TabIndex = 5;
            this.btnQuanLyVocher.Text = "     Quản Lý Voucher";
            this.btnQuanLyVocher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyVocher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyVocher.UseVisualStyleBackColor = true;
            this.btnQuanLyVocher.Click += new System.EventHandler(this.btnQuanLyVocher_Click);
            // 
            // btnQuanLySanPham
            // 
            this.btnQuanLySanPham.FlatAppearance.BorderSize = 0;
            this.btnQuanLySanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLySanPham.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLySanPham.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLySanPham.IconChar = FontAwesome.Sharp.IconChar.ProductHunt;
            this.btnQuanLySanPham.IconColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLySanPham.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLySanPham.IconSize = 35;
            this.btnQuanLySanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLySanPham.Location = new System.Drawing.Point(3, 289);
            this.btnQuanLySanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLySanPham.Name = "btnQuanLySanPham";
            this.btnQuanLySanPham.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnQuanLySanPham.Size = new System.Drawing.Size(253, 40);
            this.btnQuanLySanPham.TabIndex = 9;
            this.btnQuanLySanPham.Text = "     Quản Lý Sản Phẩm";
            this.btnQuanLySanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLySanPham.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLySanPham.UseVisualStyleBackColor = true;
            this.btnQuanLySanPham.Click += new System.EventHandler(this.btnQuanLySanPham_Click);
            // 
            // btnQuanLyChatLieu
            // 
            this.btnQuanLyChatLieu.FlatAppearance.BorderSize = 0;
            this.btnQuanLyChatLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyChatLieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyChatLieu.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyChatLieu.IconChar = FontAwesome.Sharp.IconChar.C;
            this.btnQuanLyChatLieu.IconColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyChatLieu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyChatLieu.IconSize = 35;
            this.btnQuanLyChatLieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyChatLieu.Location = new System.Drawing.Point(3, 333);
            this.btnQuanLyChatLieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLyChatLieu.Name = "btnQuanLyChatLieu";
            this.btnQuanLyChatLieu.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnQuanLyChatLieu.Size = new System.Drawing.Size(253, 40);
            this.btnQuanLyChatLieu.TabIndex = 10;
            this.btnQuanLyChatLieu.Text = "     Quản Lý Chất Liệu";
            this.btnQuanLyChatLieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyChatLieu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyChatLieu.UseVisualStyleBackColor = true;
            this.btnQuanLyChatLieu.Click += new System.EventHandler(this.btnQuanLyChatLieu_Click);
            // 
            // btnQuanLyTheLoai
            // 
            this.btnQuanLyTheLoai.FlatAppearance.BorderSize = 0;
            this.btnQuanLyTheLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyTheLoai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyTheLoai.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyTheLoai.IconChar = FontAwesome.Sharp.IconChar.T;
            this.btnQuanLyTheLoai.IconColor = System.Drawing.Color.AliceBlue;
            this.btnQuanLyTheLoai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuanLyTheLoai.IconSize = 35;
            this.btnQuanLyTheLoai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyTheLoai.Location = new System.Drawing.Point(3, 377);
            this.btnQuanLyTheLoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnQuanLyTheLoai.Name = "btnQuanLyTheLoai";
            this.btnQuanLyTheLoai.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnQuanLyTheLoai.Size = new System.Drawing.Size(253, 40);
            this.btnQuanLyTheLoai.TabIndex = 11;
            this.btnQuanLyTheLoai.Text = "     Quản Lý Thể Loại";
            this.btnQuanLyTheLoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuanLyTheLoai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuanLyTheLoai.UseVisualStyleBackColor = true;
            this.btnQuanLyTheLoai.Click += new System.EventHandler(this.btnQuanLyTheLoai_Click);
            // 
            // btnThongKeDoanhThu
            // 
            this.btnThongKeDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnThongKeDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKeDoanhThu.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnThongKeDoanhThu.IconChar = FontAwesome.Sharp.IconChar.LineChart;
            this.btnThongKeDoanhThu.IconColor = System.Drawing.Color.AliceBlue;
            this.btnThongKeDoanhThu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongKeDoanhThu.IconSize = 35;
            this.btnThongKeDoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKeDoanhThu.Location = new System.Drawing.Point(3, 421);
            this.btnThongKeDoanhThu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongKeDoanhThu.Name = "btnThongKeDoanhThu";
            this.btnThongKeDoanhThu.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnThongKeDoanhThu.Size = new System.Drawing.Size(253, 40);
            this.btnThongKeDoanhThu.TabIndex = 8;
            this.btnThongKeDoanhThu.Text = "     Thống Kê Doanh Thu";
            this.btnThongKeDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKeDoanhThu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKeDoanhThu.UseVisualStyleBackColor = true;
            this.btnThongKeDoanhThu.Click += new System.EventHandler(this.btnThongKeDoanhThu_Click);
            // 
            // iconSetting
            // 
            this.iconSetting.FlatAppearance.BorderSize = 0;
            this.iconSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconSetting.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconSetting.ForeColor = System.Drawing.Color.Turquoise;
            this.iconSetting.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.iconSetting.IconColor = System.Drawing.Color.Turquoise;
            this.iconSetting.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSetting.IconSize = 45;
            this.iconSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconSetting.Location = new System.Drawing.Point(3, 252);
            this.iconSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconSetting.Name = "iconSetting";
            this.iconSetting.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.iconSetting.Size = new System.Drawing.Size(292, 109);
            this.iconSetting.TabIndex = 6;
            this.iconSetting.Text = "   Setting";
            this.iconSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconSetting.UseVisualStyleBackColor = true;
            this.iconSetting.Click += new System.EventHandler(this.iconSetting_Click);
            // 
            // iconAbout
            // 
            this.iconAbout.FlatAppearance.BorderSize = 0;
            this.iconAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconAbout.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconAbout.ForeColor = System.Drawing.Color.Turquoise;
            this.iconAbout.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.iconAbout.IconColor = System.Drawing.Color.Turquoise;
            this.iconAbout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconAbout.IconSize = 45;
            this.iconAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconAbout.Location = new System.Drawing.Point(3, 365);
            this.iconAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconAbout.Name = "iconAbout";
            this.iconAbout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.iconAbout.Size = new System.Drawing.Size(292, 109);
            this.iconAbout.TabIndex = 10;
            this.iconAbout.Text = "   About";
            this.iconAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconAbout.UseVisualStyleBackColor = true;
            this.iconAbout.Click += new System.EventHandler(this.iconAbout_Click);
            // 
            // iconHelp
            // 
            this.iconHelp.FlatAppearance.BorderSize = 0;
            this.iconHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconHelp.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconHelp.ForeColor = System.Drawing.Color.Turquoise;
            this.iconHelp.IconChar = FontAwesome.Sharp.IconChar.CircleQuestion;
            this.iconHelp.IconColor = System.Drawing.Color.Turquoise;
            this.iconHelp.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconHelp.IconSize = 45;
            this.iconHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconHelp.Location = new System.Drawing.Point(3, 478);
            this.iconHelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconHelp.Name = "iconHelp";
            this.iconHelp.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.iconHelp.Size = new System.Drawing.Size(292, 109);
            this.iconHelp.TabIndex = 11;
            this.iconHelp.Text = "   Help";
            this.iconHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconHelp.UseVisualStyleBackColor = true;
            this.iconHelp.Click += new System.EventHandler(this.iconHelp_Click);
            // 
            // panelSet
            // 
            this.panelSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(70)))));
            this.panelSet.Controls.Add(this.ptbUser);
            this.panelSet.Controls.Add(this.lbMenu);
            this.panelSet.Controls.Add(this.ptbIconMenu);
            this.panelSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSet.Location = new System.Drawing.Point(301, 40);
            this.panelSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSet.Name = "panelSet";
            this.panelSet.Size = new System.Drawing.Size(1199, 89);
            this.panelSet.TabIndex = 18;
            // 
            // ptbUser
            // 
            this.ptbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbUser.Image = ((System.Drawing.Image)(resources.GetObject("ptbUser.Image")));
            this.ptbUser.ImageRotate = 0F;
            this.ptbUser.Location = new System.Drawing.Point(1118, 10);
            this.ptbUser.Name = "ptbUser";
            this.ptbUser.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ptbUser.Size = new System.Drawing.Size(69, 62);
            this.ptbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbUser.TabIndex = 2;
            this.ptbUser.TabStop = false;
            this.ptbUser.Click += new System.EventHandler(this.ptbUser_Click);
            // 
            // lbMenu
            // 
            this.lbMenu.AutoSize = true;
            this.lbMenu.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMenu.ForeColor = System.Drawing.Color.Turquoise;
            this.lbMenu.Location = new System.Drawing.Point(105, 13);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(90, 37);
            this.lbMenu.TabIndex = 1;
            this.lbMenu.Text = "Menu";
            // 
            // ptbIconMenu
            // 
            this.ptbIconMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(70)))));
            this.ptbIconMenu.ForeColor = System.Drawing.Color.Turquoise;
            this.ptbIconMenu.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.ptbIconMenu.IconColor = System.Drawing.Color.Turquoise;
            this.ptbIconMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ptbIconMenu.IconSize = 60;
            this.ptbIconMenu.Location = new System.Drawing.Point(30, 10);
            this.ptbIconMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptbIconMenu.Name = "ptbIconMenu";
            this.ptbIconMenu.Size = new System.Drawing.Size(60, 62);
            this.ptbIconMenu.TabIndex = 0;
            this.ptbIconMenu.TabStop = false;
            this.ptbIconMenu.Click += new System.EventHandler(this.ptbIconHome_Click);
            // 
            // panelContraint
            // 
            this.panelContraint.BackColor = System.Drawing.Color.Transparent;
            this.panelContraint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelContraint.BackgroundImage")));
            this.panelContraint.Controls.Add(this.panelSetting);
            this.panelContraint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContraint.Location = new System.Drawing.Point(301, 129);
            this.panelContraint.Name = "panelContraint";
            this.panelContraint.Size = new System.Drawing.Size(1199, 821);
            this.panelContraint.TabIndex = 19;
            // 
            // panelSetting
            // 
            this.panelSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSetting.BackColor = System.Drawing.Color.Transparent;
            this.panelSetting.BorderRadius = 20;
            this.panelSetting.Controls.Add(this.btnDoiMatKhau);
            this.panelSetting.Controls.Add(this.btnDangXuat);
            this.panelSetting.Controls.Add(this.btnThongTinCaNhan);
            this.panelSetting.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(70)))));
            this.panelSetting.Location = new System.Drawing.Point(989, 3);
            this.panelSetting.MaximumSize = new System.Drawing.Size(207, 228);
            this.panelSetting.MinimumSize = new System.Drawing.Size(207, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(207, 0);
            this.panelSetting.TabIndex = 2;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(70)))));
            this.btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.Turquoise;
            this.btnDoiMatKhau.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDoiMatKhau.IconColor = System.Drawing.Color.Turquoise;
            this.btnDoiMatKhau.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoiMatKhau.IconSize = 45;
            this.btnDoiMatKhau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(3, 81);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(201, 56);
            this.btnDoiMatKhau.TabIndex = 13;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.UseVisualStyleBackColor = false;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau1_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDangXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(70)))));
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.Turquoise;
            this.btnDangXuat.Location = new System.Drawing.Point(1, 146);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(202, 56);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThongTinCaNhan
            // 
            this.btnThongTinCaNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(70)))));
            this.btnThongTinCaNhan.FlatAppearance.BorderSize = 0;
            this.btnThongTinCaNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongTinCaNhan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnThongTinCaNhan.ForeColor = System.Drawing.Color.Turquoise;
            this.btnThongTinCaNhan.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThongTinCaNhan.IconColor = System.Drawing.Color.Turquoise;
            this.btnThongTinCaNhan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongTinCaNhan.IconSize = 2;
            this.btnThongTinCaNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongTinCaNhan.Location = new System.Drawing.Point(3, 19);
            this.btnThongTinCaNhan.Name = "btnThongTinCaNhan";
            this.btnThongTinCaNhan.Size = new System.Drawing.Size(201, 56);
            this.btnThongTinCaNhan.TabIndex = 12;
            this.btnThongTinCaNhan.Text = "Thông tin cá nhân";
            this.btnThongTinCaNhan.UseVisualStyleBackColor = false;
            this.btnThongTinCaNhan.Click += new System.EventHandler(this.btnThongTinCaNhan_Click);
            // 
            // timeResetForm
            // 
            this.timeResetForm.Tick += new System.EventHandler(this.timeResetForm_Tick);
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            this.guna2MessageDialog1.Caption = null;
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Dark;
            this.guna2MessageDialog1.Text = null;
            // 
            // FormMain_QuanLy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1500, 950);
            this.Controls.Add(this.panelContraint);
            this.Controls.Add(this.panelSet);
            this.Controls.Add(this.PanelMenu);
            this.Controls.Add(this.PanelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormMain_QuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý";
            this.MdiChildActivate += new System.EventHandler(this.FormMain_MdiChildActivate);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.PanelHeader.ResumeLayout(false);
            this.PanelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.panelChilden.ResumeLayout(false);
            this.panelSet.ResumeLayout(false);
            this.panelSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIconMenu)).EndInit();
            this.panelContraint.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TimeMenu;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbLogo;
        private Guna.UI2.WinForms.Guna2Panel PanelHeader;
        private FontAwesome.Sharp.IconButton iconAn;
        private FontAwesome.Sharp.IconButton iconClose;
        private FontAwesome.Sharp.IconButton iconMaxMin;
        private System.Windows.Forms.Timer timeChilden;
        private System.Windows.Forms.Timer timeForm;
        private System.Windows.Forms.Timer timeSetting;
        private System.Windows.Forms.FlowLayoutPanel PanelMenu;
        private FontAwesome.Sharp.IconButton iconSetting;
        private System.Windows.Forms.Panel panelLogo;
        private Guna.UI2.WinForms.Guna2CirclePictureBox ptbLogo;
        private FontAwesome.Sharp.IconButton iconAbout;
        private FontAwesome.Sharp.IconButton iconHome;
        private FontAwesome.Sharp.IconButton iconHelp;
        private FontAwesome.Sharp.IconButton btnQuanLySanPham;
        private FontAwesome.Sharp.IconButton btnThongKeDoanhThu;
        private FontAwesome.Sharp.IconButton btnQuanLyNhanVien;
        private FontAwesome.Sharp.IconButton btnQuanLyNhaCungCap;
        private FontAwesome.Sharp.IconButton btnQuanLyKhachHang;
        private System.Windows.Forms.Panel panelSet;
        private Guna.UI2.WinForms.Guna2CirclePictureBox ptbUser;
        private System.Windows.Forms.Label lbMenu;
        private FontAwesome.Sharp.IconPictureBox ptbIconMenu;
        private Guna.UI2.WinForms.Guna2Panel panelContraint;
        private System.Windows.Forms.FlowLayoutPanel panelChilden;
        private FontAwesome.Sharp.IconButton btnQuanLyVocher;
        private System.Windows.Forms.Timer timeResetForm;
        private FontAwesome.Sharp.IconButton btnQuanLyChatLieu;
        private FontAwesome.Sharp.IconButton btnQuanLyTheLoai;
        private Guna.UI2.WinForms.Guna2Panel panelSetting;
        private Guna.UI2.WinForms.Guna2Button btnDangXuat;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        private FontAwesome.Sharp.IconButton btnThongTinCaNhan;
        private FontAwesome.Sharp.IconButton btnDoiMatKhau;
    }
}