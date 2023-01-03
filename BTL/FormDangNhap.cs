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
    public partial class FormDangNhap : Form
    {
        AccessData dataAccess = new AccessData();
        public static string username = "";
        public FormDangNhap()
        {
            InitializeComponent();
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
                string get_chucvu = $"select MaChucVu, NhanVien.MaNV from tblUser inner join NhanVien on tblUser.MaNV = NhanVien.MaNV " +
                    $"where TenDangNhap = '{txtUsername.Text}'";
                DataTable dtchucvu = dataAccess.ReadData(get_chucvu);
                string chucvu = dtchucvu.Rows[0]["MaChucVu"].ToString();
                string manhanvien = dtchucvu.Rows[0]["MaNV"].ToString();
                //Đăng nhập theo chức vụ
                if (chucvu == "CV01")
                {
                    FormMain_QuanLy formquanly = new FormMain_QuanLy(manhanvien);
                    formquanly.Visible = true;
                    this.Visible = false;
                }
                else if (chucvu == "CV02")
                {
                    FormMain_NhanVienBanHang formnhanvienbanhang = new FormMain_NhanVienBanHang();
                    formnhanvienbanhang.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    FormMain_NhanVienKho formnhanvienkho = new FormMain_NhanVienKho();
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

        private void FormDangNhap_Load(object sender, EventArgs e)
        {
            lbThongBao.Text = "";
            txtUsername.Text = Properties.Settings.Default.username;
            txtPassword.Text = Properties.Settings.Default.password;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0';
                guna2CircleButton2.BringToFront();
            }
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '●';
                guna2CircleButton1.BringToFront();
            }
        }
    }
}
