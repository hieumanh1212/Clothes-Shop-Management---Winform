namespace DuyThien_BTL.Childen
{
    partial class Author
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
            this.lbThien = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbThịnh = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lbHieu = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnThoat = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lbThien
            // 
            this.lbThien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbThien.BackColor = System.Drawing.Color.Transparent;
            this.lbThien.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.lbThien.Location = new System.Drawing.Point(189, 303);
            this.lbThien.Name = "lbThien";
            this.lbThien.Size = new System.Drawing.Size(656, 83);
            this.lbThien.TabIndex = 0;
            this.lbThien.Text = "Hoàng Minh Duy Thiện";
            // 
            // lbThịnh
            // 
            this.lbThịnh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbThịnh.BackColor = System.Drawing.Color.Transparent;
            this.lbThịnh.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThịnh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.lbThịnh.Location = new System.Drawing.Point(189, 433);
            this.lbThịnh.Name = "lbThịnh";
            this.lbThịnh.Size = new System.Drawing.Size(571, 83);
            this.lbThịnh.TabIndex = 1;
            this.lbThịnh.Text = "Nguyễn Đông Thịnh";
            // 
            // lbHieu
            // 
            this.lbHieu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbHieu.BackColor = System.Drawing.Color.Transparent;
            this.lbHieu.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHieu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.lbHieu.Location = new System.Drawing.Point(189, 175);
            this.lbHieu.Name = "lbHieu";
            this.lbHieu.Size = new System.Drawing.Size(478, 83);
            this.lbHieu.TabIndex = 2;
            this.lbHieu.Text = "Đặng Mạnh Hiếu";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThoat.BorderRadius = 20;
            this.btnThoat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThoat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThoat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThoat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(189, 631);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(656, 59);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Đóng";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Author
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1035, 850);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lbHieu);
            this.Controls.Add(this.lbThịnh);
            this.Controls.Add(this.lbThien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Author";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Author_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lbThien;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbThịnh;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbHieu;
        private Guna.UI2.WinForms.Guna2Button btnThoat;
    }
}