using DuyThien_BTL.KetNoi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuyThien_BTL
{
    public partial class Form_Login : Form
    {
        AccessData dataAccess = new AccessData();
        public static string username = "";
        public Form_Login()
        {
            InitializeComponent();
        }
        //Lấy ra mã nhân viên (Tên tài khoản hiện tại)
        public string get_user()
        {
            return username;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = $"select * from tblUser where TenDangNhap='{txtUsername.Text}' and MatKhau='{txtPassword.Text}'";
            DataTable dt = dataAccess.ReadData(sql);
            if (dt.Rows.Count > 0)
            {
                if (tgwRemember.Checked == true)
                {
                    Properties.Settings.Default.username = txtUsername.Text;
                    Properties.Settings.Default.password = txtPassword.Text;
                    Properties.Settings.Default.Save();
                }
                if (tgwRemember.Checked == false)
                {
                    Properties.Settings.Default.username = "";
                    Properties.Settings.Default.password = "";
                    Properties.Settings.Default.Save();
                }
                lbThongBao.ForeColor = Color.LimeGreen;
                lbThongBao.Text = "Đăng nhập thành công";
                username = txtUsername.Text;
                //Vào trong Form Main
                string get_chucvu = $"select * from tblUser inner join NhanVien on tblUser.MaNV = NhanVien.MaNV " +
                    $"where TenDangNhap = '{txtUsername.Text}'";
                DataTable dtchucvu = dataAccess.ReadData(get_chucvu);
                string MaNV = dtchucvu.Rows[0]["MaNV"].ToString();
                string chucvu = dtchucvu.Rows[0]["MaChucVu"].ToString();
                if (chucvu == "CV01")
                {
                    FormMain_QuanLy formquanly = new FormMain_QuanLy(MaNV);
                    formquanly.Visible = true;
                    
                    this.Visible = false;
                    
                }
                else if (chucvu == "CV02")
                {
                    FormMain_NhanVienBanHang formnhanvienbanhang = new FormMain_NhanVienBanHang(MaNV);
                    formnhanvienbanhang.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    FormMain_NhanVienKho formnhanvienkho = new FormMain_NhanVienKho(MaNV);
                    formnhanvienkho.Visible = true;
                    this.Visible = false;
                }

            }
            else
            {

                lbThongBao.Text = "Tên đăng nhập hoặc mật khẩu sai";
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            lbThongBao.Text = "";
            txtUsername.Text = Properties.Settings.Default.username;
            txtPassword.Text = Properties.Settings.Default.password;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowPass_Click(object sender, EventArgs e)
        {
            if(txtPassword.PasswordChar == '●')
            {
                HidePass.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void HidePass_Click(object sender, EventArgs e)
        {
            if(txtPassword.PasswordChar == '\0')
            {
                ShowPass.BringToFront();
                txtPassword.PasswordChar = '●';
            }
        }
    }
}
