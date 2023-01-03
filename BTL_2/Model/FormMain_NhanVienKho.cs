using DuyThien_BTL.Childen;
using DuyThien_BTL.KetNoi;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuyThien_BTL
{
    public partial class FormMain_NhanVienKho : Form
    {
        private IconButton curren;
        private Panel leftborderbtn;
        AccessData accessData = new AccessData();

        Color colorCheck = Color.Turquoise;
        IconButton buttonCheck = null;
        Form checkForm = null;
        int checkWidth = 0;

        HoaDonNhap HDN = new HoaDonNhap();
        QuanLyKho QLK = new QuanLyKho();

        string manhanvien = "";
        public void Them_anhNV(string manhanvien)
        {
            string sql = "Select * from NhanVien where NhanVien.MaNV = '" + manhanvien + "'";
            DataTable dtThongTin = accessData.ReadData(sql);
            string fileAnh = dtThongTin.Rows[0]["Anh"].ToString();
            if (fileAnh != "")
                ptbUser.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + fileAnh);
            else
                ptbUser.Image = null;
        }
        public FormMain_NhanVienKho(string manhanvien)
        {
            InitializeComponent();
            leftborderbtn = new Panel();
            leftborderbtn.Size = new Size(5, 40);
            //panelChilden.Controls.Add(leftborderbtn);

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            if (panelSetting.Height == panelSetting.MaximumSize.Height)
                timeSetting.Start();
            this.manhanvien = manhanvien;
            Them_anhNV(manhanvien);
        }
        // Màu của button và text
        private struct RGBColors
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(172, 126, 241);
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(249, 118, 176);
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(253, 138, 114);
            public static System.Drawing.Color color4 = System.Drawing.Color.FromArgb(95, 77, 221);
            public static System.Drawing.Color color5 = System.Drawing.Color.FromArgb(249, 88, 155);
            public static System.Drawing.Color color6 = System.Drawing.Color.FromArgb(24, 161, 251);
            public static System.Drawing.Color color7 = System.Drawing.Color.FromArgb(130, 161, 251);
            public static System.Drawing.Color color8 = System.Drawing.Color.FromArgb(50, 70, 251);
            public static System.Drawing.Color color9 = System.Drawing.Color.FromArgb(99, 89, 45);
        }
        int checkChilden;
        //Sự kiện khi ấn vào buttun: đổi màu và hoán đổi vị trí của icon và text
        private void ActivateButton(object senderBtn, System.Drawing.Color color, int checkChilden)
        {
            //if (senderBtn != null)
            //{


            //Button

            DisableButton();
            this.checkChilden = checkChilden;
            if (senderBtn != null)
            {
                curren = (IconButton)senderBtn;
                buttonCheck = curren;
                colorCheck = color;
                iconHome.ForeColor = iconHome.IconColor = colorCheck;

                if (checkChilden == 1)
                {
                    //Đổi màu cho left boder button
                    curren.Controls.Add(leftborderbtn);
                    leftborderbtn.BackColor = color;
                    leftborderbtn.Location = new Point(curren.Left);
                    //leftborderbtn.Location = new Point(3, curren.Location.Y);
                    leftborderbtn.Visible = true;
                    leftborderbtn.BringToFront();
                    if (PanelMenu.Width == PanelMenu.MaximumSize.Width)
                    {
                        curren.TextAlign = ContentAlignment.MiddleCenter;
                        curren.TextImageRelation = TextImageRelation.TextBeforeImage;
                        curren.ImageAlign = ContentAlignment.MiddleRight;
                    }
                }

                //curren.BackColor = System.Drawing.Color.FromArgb(37, 36, 81);
                curren.ForeColor = color;
                curren.IconColor = color;

                if (checkChilden == 0 || checkChilden == 1)
                {
                    //Current Child Form Icon
                    ptbIconMenu.IconChar = curren.IconChar;
                    ptbIconMenu.IconColor = color;
                    lbMenu.Text = curren.Text.Trim();
                    lbMenu.ForeColor = color;
                }
                else
                {
                    ptbIconMenu.IconChar = IconChar.Navicon;
                    ptbIconMenu.IconColor = color;
                    lbMenu.ForeColor = color;
                    lbMenu.Text = checkChilden == 2 ? "Thông Tin Cá Nhân" : "Đổi Mật Khẩu";
                }
            }

        }


        private void DisableButton()
        {
            if (curren != null)
            {

                if (checkChilden == 1)
                {
                    curren.ForeColor = curren.IconColor = System.Drawing.Color.AliceBlue;
                    leftborderbtn.Visible = false;
                    curren.TextAlign = ContentAlignment.MiddleLeft;
                    curren.TextImageRelation = TextImageRelation.ImageBeforeText;
                    curren.ImageAlign = ContentAlignment.MiddleLeft;
                }
                else
                    curren.ForeColor = curren.IconColor = System.Drawing.Color.Turquoise;

            }
        }

        private void kt_AddForm(Form f, object sender, System.Drawing.Color color, int checkChilden = 1)
        {
            //if (curren == (IconButton)(sender))
            //    return;
            //panelContraint.Controls.Remove(panelSetting);
            //if (CheckExitsFrom(f.Name) == false)
            //{
            timeResetForm.Start();
            panelContraint.Controls.Clear();
            if (panelSetting.Height == panelSetting.MaximumSize.Height)
                timeSetting.Start();


            ActivateButton(sender, color, checkChilden);

            //resetWH_From();

            checkForm = f;

            //cut_Form(checkForm);

            checkForm.MdiParent = this;
            checkWidth = panelContraint.Width;
            checkForm.Width = 0;
            panelContraint.Controls.Add(checkForm);

            if (checkChilden == 1 || checkChilden == 0)
                checkForm.Dock = DockStyle.Left;
            else
                checkForm.Dock = DockStyle.Right;
            checkForm.BringToFront();

            //

            checkForm.Show();
            timeForm.Start();
            //}
            //else
            //ActiveChildForm(checkForm.Name);


        }
        // ấn hiện menu 
        bool checkMenu = true;


        private void TimeMenu_Tick(object sender, EventArgs e)
        {
            if (checkMenu)
            {
                //iconHome.Text = iconHelp.Text = iconSetting.Text = iconAbout.Text = "";
                PanelMenu.Width -= 10;
                ptbLogo.Width -= 10;
                if (PanelMenu.Width <= PanelMenu.MinimumSize.Width)
                {
                    this.Width -= (PanelMenu.MaximumSize.Width - PanelMenu.MinimumSize.Width);
                    checkMenu = false;
                    TimeMenu.Stop();


                    ActivateButton(buttonCheck, colorCheck, checkChilden);
                }
            }
            else
            {

                PanelMenu.Width += 10;
                ptbLogo.Width += 10;
                if (PanelMenu.Width >= PanelMenu.MaximumSize.Width)
                {

                    checkMenu = true;
                    TimeMenu.Stop();
                    this.Width += (PanelMenu.MaximumSize.Width - PanelMenu.MinimumSize.Width);

                    ActivateButton(buttonCheck, colorCheck, checkChilden);
                    //iconHome.Text = "      Home";
                    //iconHelp.Text = "      Help";
                    //iconSetting.Text = "      Setting";
                    //iconAbout.Text = "      About";
                }
            }
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void PanelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();

            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        // Kiểm tra xem form con đã tồn tại chưa
        private bool CheckExitsFrom(string nameform)
        {
            bool check = false;

            //foreach (Control ct in panelContraint.Controls)
            //{
            //    if(ct is Form)
            //    {
            //        foreach (Control f in panelContraint.Controls)
            //        {
            //            if (f.Name == nameform)
            //            {
            //                check = true;
            //                break;
            //            }   
            //        }    

            //    }    

            //}
            foreach (Form f in panelContraint.Controls)
            {
                if (f.Name == nameform)
                {
                    check = true;
                    break;
                }


            }
            return check;
        }


        private void ActiveChildForm(string nameform)
        {

            foreach (Form f in panelContraint.Controls)
            {
                if (f.Name == nameform)
                {
                    f.Activate();
                    break;
                }
            }

        }


        private void timeForm_Tick(object sender, EventArgs e)
        {
            checkForm.Width += 50;
            if (checkForm.Width >= checkWidth)
            {
                //checkForm.Width = checkWidth;
                timeForm.Stop();
                //checkForm.Dock = DockStyle.Fill;
            }
        }




        private void btnTaoHoaDonNhap_Click(object sender, EventArgs e)
        {
            if (HDN.IsDisposed) // IsDisposed:  khởi tạo rồi nhưng đã bị đóng lại.
                HDN = new HoaDonNhap();
            //kt_AddForm(new HoaDonNhap(), sender, RGBColors.color3);           
            kt_AddForm(HDN, sender, RGBColors.color3);
        }
        private void btnKho_Click(object sender, EventArgs e)
        {
            if (QLK.IsDisposed) // IsDisposed:  khởi tạo rồi nhưng đã bị đóng lại.
                QLK = new QuanLyKho();
            //kt_AddForm(new HoaDonNhap(), sender, RGBColors.color3);           
            kt_AddForm(QLK, sender, RGBColors.color4);
        }
        private void iconSetting_Click(object sender, EventArgs e)
        {
            kt_AddForm(new Author(), sender, System.Drawing.Color.Turquoise, 0);
        }


        private void iconAbout_Click(object sender, EventArgs e)
        {
            kt_AddForm(new Author(), sender, System.Drawing.Color.Turquoise, 0);
        }

        private void iconHelp_Click(object sender, EventArgs e)
        {
            kt_AddForm(new Author(), sender, System.Drawing.Color.Turquoise, 0);
        }


        private void resetPanalSetting()
        {


            panelContraint.Controls.Add(panelSetting);
            panelSetting.BringToFront();

        }


        private void ptbUser_Click(object sender, EventArgs e)
        {
            resetPanalSetting();
            timeSetting.Start();
        }

        private void FormMain_NhanVienKho_SizeChanged(object sender, EventArgs e)
        {
            if (checkForm != null)
                checkForm.Dock = DockStyle.Fill;
            panelSetting.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }

        // ấn hiện Panelsetting
        bool checkSetting = false;
        private void timeSetting_Tick(object sender, EventArgs e)
        {
            if (checkSetting)
            {
                panelSetting.Height -= 10;
                if (panelSetting.Height == panelSetting.MinimumSize.Height)
                {
                    checkSetting = false;
                    timeSetting.Stop();
                }
            }
            else
            {
                panelSetting.Height += 10;
                if (panelSetting.Height == panelSetting.MaximumSize.Height)
                {
                    checkSetting = true;
                    timeSetting.Stop();
                }
            }
        }

        private void timeChilden_Tick(object sender, EventArgs e)
        {
            if (checkContrain)
            {
                panelChilden.Height -= 40;
                if (panelChilden.Height == panelChilden.MinimumSize.Height)
                {
                    checkContrain = false;
                    timeChilden.Stop();
                }
            }
            else
            {
                panelChilden.Height += 40;
                if (panelChilden.Height == panelChilden.MaximumSize.Height)
                {
                    checkContrain = true;
                    timeChilden.Stop();
                }
            }
        }

        private void iconHome_Click(object sender, EventArgs e)
        {
            timeChilden.Start();
        }


        //Đóng Form
        private void iconClose_Click(object sender, EventArgs e)
        {
            guna2MessageDialog1.Text = "Bạn có muốn thoát không ?";
            guna2MessageDialog1.Caption = "Thông báo";
            if (guna2MessageDialog1.Show() == DialogResult.Yes)
                Application.Exit();
        }

        private void iconMaxMin_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }

            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void iconAn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ptbLogo_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void ptbIconMenu_Click(object sender, EventArgs e)
        {
            TimeMenu.Start();
        }

        private void panelChilden_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timeResetForm_Tick(object sender, EventArgs e)
        {
            bool check = false;
            foreach (Control ct in panelContraint.Controls)
            {
                if (ct is Form)
                    check = true;
            }
            if (!check)
            {
                resetForm();
                timeResetForm.Stop();
            }
        }

        // reset về trang chủ 
        public void resetForm()
        {
            DisableButton();
            //leftborderbtn.Visible = false;
            //this.Width = fwidth; this.Height = fheight;

            //resetWH_From();
            colorCheck = System.Drawing.Color.Turquoise;
            buttonCheck = null;
            curren = null;
            ptbIconMenu.IconChar = IconChar.Navicon;
            ptbIconMenu.IconColor = colorCheck;
            lbMenu.Text = "Menu";
            lbMenu.ForeColor = colorCheck;
            iconHome.IconColor = colorCheck;
            iconHome.ForeColor = colorCheck;
            if (panelSetting.Height == panelSetting.MaximumSize.Height)
                timeSetting.Start();
            //if (panelChilden.Height == panelChilden.MaximumSize.Height)
            //    timeChilden.Start();
            panelContraint.Controls.Clear();
            //panelContraint.BackgroundImage = Image.FromFile("E:\\ảnh\\shop.png");

        }

        // ấn hiện panelchilden 
        bool checkContrain;

        private void panelSet_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            kt_AddForm(new Form_ThongTinCaNhan(manhanvien), sender, System.Drawing.Color.Turquoise, 2);

        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            kt_AddForm(new DoiMatKhau(this.manhanvien), sender, System.Drawing.Color.Turquoise, 3);

        }


        Form_Login dangnhap = new Form_Login();
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            int w = dangnhap.Width, h = dangnhap.Height;
            this.Visible = false;
            dangnhap.Visible = true;
            dangnhap.Width = w;
            dangnhap.Height = h;
        }

        private void PanelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
