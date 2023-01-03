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

namespace DuyThien_BTL.Childen
{
    public partial class Form_ThongTinCaNhan : Form
    {
        AccessData accessData = new AccessData();
        string manv = "";
        public Form_ThongTinCaNhan(string manv)
        {
            InitializeComponent();
            this.manv = manv;
        }

        private void Form_ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            string sql = "Select * from NhanVien inner join ChucVu on NhanVien.MaChucVu = ChucVu.MaChucVu where NhanVien.MaNV = '" + manv + "'";
            DataTable dtThongTin = accessData.ReadData(sql);
            lblMaNV.Text += dtThongTin.Rows[0]["MaNV"].ToString();
            lblTenNV.Text += dtThongTin.Rows[0]["TenNV"].ToString();
            lblGioiTinh.Text += dtThongTin.Rows[0]["GioiTinh"].ToString();
            DateTime ngay = ((DateTime)(dtThongTin.Rows[0]["NgaySinh"]));
            lblNgaySinh.Text += ngay.Day.ToString() + "/" + ngay.Month.ToString() + "/" + ngay.Year.ToString();
            lblDiaChi.Text += dtThongTin.Rows[0]["DiaChi"].ToString();
            lblSDT.Text += dtThongTin.Rows[0]["DienThoai"].ToString();
            lblChucVu.Text += dtThongTin.Rows[0]["TenChucVu"].ToString();
            string fileAnh = dtThongTin.Rows[0]["Anh"].ToString();

            if (fileAnh != "")
                pictureBox.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + fileAnh);
            else
                pictureBox.Image = null;

        }
    }
}
