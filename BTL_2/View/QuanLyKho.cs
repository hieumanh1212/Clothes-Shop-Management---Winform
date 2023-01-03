using DuyThien_BTL.KetNoi;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xuat_Exel;

namespace DuyThien_BTL.Childen
{
    public partial class QuanLyKho : System.Windows.Forms.Form
    {
        AccessData accessData = new AccessData();
        XuatExel xuatexcel;
        CommondFunction commondFunction = new CommondFunction();
        public QuanLyKho()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grbThongTinMatHang_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyKho_Load(object sender, EventArgs e)
        {
            // fill combobox SanPham
            commondFunction.FillCombobox(cboMaSP, accessData.ReadData("select * from SanPham"), "MaSP", "MaSP");
            cboMaSP.SelectedIndex=-1;
            // Thong tin in ra datagridview
            string sql = "select MaSP,MaChiTietSP,MauSac,Size,SoLuong from ChiTietSanPham";
            dgvThongTinMatHang.DataSource = accessData.ReadData(sql);

            btnHuy.Enabled = false;
        }

        private void cboMaCTSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // neu combobox ko rong thi tim kiem
            if (cboMaSP.SelectedIndex != -1)
                TimKiem();
            btnHuy.Enabled = true;
        }
        void TimKiem()
        {
            // tim kiem SanPham
            string sqlTimKiem = "";
            if (cboMaSP.Text != "")
            {
                sqlTimKiem = $"select MaSP,MaChiTietSP,MauSac,Size,SoLuong from ChiTietSanPham where MaSP = '{cboMaSP.Text}'";
            }
           
            dgvThongTinMatHang.DataSource = accessData.ReadData(sqlTimKiem);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // fill lai combobox SanPham
            commondFunction.FillCombobox(cboMaSP, accessData.ReadData("select * from SanPham"), "MaSP", "MaSP");
            cboMaSP.SelectedIndex = -1;
            // in thong tin ra dgv
            string sql = "select MaSP,MaChiTietSP,MauSac,Size,SoLuong from ChiTietSanPham";
            dgvThongTinMatHang.DataSource = accessData.ReadData(sql);
            btnHuy.Enabled = false;
            
        }

        private void btnInThongTinSP_Click(object sender, EventArgs e)
        {
            if(dgvThongTinMatHang.RowCount ==0)
            {
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn không thể xuất khi dữ liệu trống!";
                MessageGuna.Caption = "Thông báo!";
                MessageGuna.Show();
                return;
            }    
            xuatexcel = new XuatExel(dgvThongTinMatHang, "Thông tin kho", 0);

        }
    }
}
