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
using System.Windows.Media;
using FontAwesome.Sharp;


namespace BTL.FormCon
{
    public partial class FormCon : Form
    {

        private IconButton curren;
        private Panel leftborderbtn;
        public FormCon()
        {
            InitializeComponent();
            leftborderbtn = new Panel();
            leftborderbtn.Size = new Size(7, 50);
            panelMenu.Controls.Add(leftborderbtn);
            //form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private struct RGBColors
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(172, 126, 241);
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(249, 118, 176);
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(253, 138, 114);
            public static System.Drawing.Color color4 = System.Drawing.Color.FromArgb(95, 77, 221);
            public static System.Drawing.Color color5 = System.Drawing.Color.FromArgb(249, 88, 155);
            public static System.Drawing.Color color6 = System.Drawing.Color.FromArgb(24, 161, 251);
        }
        private void ActivateButton(object senderBtn, System.Drawing.Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                curren = (IconButton)senderBtn;
                curren.BackColor = System.Drawing.Color.FromArgb(37, 36, 81);
                curren.ForeColor = color;
                curren.TextAlign = ContentAlignment.MiddleCenter;
                curren.IconColor = color;
                curren.TextImageRelation = TextImageRelation.TextBeforeImage;
                curren.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftborderbtn.BackColor = color;
                leftborderbtn.Location = new Point(0, curren.Location.Y);
                leftborderbtn.Visible = true;
                leftborderbtn.BringToFront();
                //Current Child Form Icon
                iconCurrenForm.IconChar = curren.IconChar;
                iconCurrenForm.IconColor = color;
                labelCurrenForm.Text = curren.Text;
                
            }
        }
        private void DisableButton()
        {
            if (curren != null)
            {
                curren.BackColor = System.Drawing.Color.FromArgb(31, 30, 68);
                curren.ForeColor = System.Drawing.Color.Gainsboro;
                curren.TextAlign = ContentAlignment.MiddleLeft;
                curren.IconColor = System.Drawing.Color.Gainsboro;
                curren.TextImageRelation = TextImageRelation.ImageBeforeText;
                curren.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1); 
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            DisableButton();
            leftborderbtn.Visible = false;
            iconCurrenForm.IconChar = IconChar.Home;
            iconCurrenForm.IconColor = System.Drawing.Color.MediumOrchid;
            labelCurrenForm.Text = "Home";
        }

        private void FormCon_Load(object sender, EventArgs e)
        {

        }
    }
}
