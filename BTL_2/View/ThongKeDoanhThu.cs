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
using Xuat_Exel;

namespace DuyThien_BTL.Childen
{
    public partial class ThongKeDoanhThu : Form
    {
        AccessData access = new AccessData();
        public DataTable dt_thien = new DataTable();
        XuatExel xuatexcel;
        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            btnThang.Enabled = false;
            //Lưu ngày hiện tại
            string ngayhientai = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString();
            //Mảng dữ liệu kiểu DateTime để lấy DateTime.Now - đi từ 1 đến 6
            //Phục vụ mục đích: lấy ra 6 ngày trước ngày hôm nay
            DateTime[] ngay = new DateTime[7];
            //Mảng dữ liệu kiểu string để lưu ngày / tháng của 6 ngày trước đó
            string[] hienthingay = new string[7];
            for(int i = 1; i <= 6; i++)
            {
                ngay[i] = DateTime.Now.AddDays(-i);
                hienthingay[i] = ngay[i].Day.ToString() + "/" + ngay[i].Month.ToString();
            }

            //Lấy số hóa đơn xuất theo 7 ngày
            int[] soluonghoadon = new int[7];
            double[] doanhthu = new double[7]; 
            for (int i = 1; i <= 6; i++)
            {
                string sql = "Select count(MaHDB) as SoLuong, sum(TongTienHDB) as TongTien from HoaDonBan where day(NgayBan) = '" + ngay[i].Day.ToString() + "' AND month(NgayBan) = '" + ngay[i].Month.ToString() + "'";
                soluonghoadon[i] = int.Parse(access.ReadData(sql).Rows[0]["SoLuong"].ToString());
                if(access.ReadData(sql).Rows[0]["TongTien"].ToString() != "")
                {
                    doanhthu[i] = double.Parse(access.ReadData(sql).Rows[0]["TongTien"].ToString());
                }
                else
                {
                    doanhthu[i] = 0;
                }
            }
            int soluonghientai = int.Parse(access.ReadData("Select count(MaHDB) as SoLuong from HoaDonBan where day(NgayBan) = '" + DateTime.Now.Day.ToString() + "' AND month(NgayBan) = '"+DateTime.Now.Month.ToString()+"'").Rows[0]["SoLuong"].ToString());
            double tongtienhientai = 0;
            if(access.ReadData("Select sum(TongTienHDB) as TongTien from HoaDonBan where day(NgayBan) = '" + DateTime.Now.Day.ToString() + "' AND month(NgayBan) = '" + DateTime.Now.Month.ToString() + "'").Rows[0]["TongTien"].ToString() != "")
            {
                tongtienhientai = double.Parse(access.ReadData("Select sum(TongTienHDB) as TongTien from HoaDonBan where day(NgayBan) = '" + DateTime.Now.Day.ToString() + "' AND month(NgayBan) = '" + DateTime.Now.Month.ToString() + "'").Rows[0]["TongTien"].ToString());
            }
            else
            {
                tongtienhientai = 0;
            }
            
            //Gán Số hóa đơn xuất tương ứng với 7 ngày gần nhất
            chart7Ngay.Series["Số hóa đơn xuất"].Points.AddXY(hienthingay[6], soluonghoadon[6]);
            chart7Ngay.Series["Số hóa đơn xuất"].Points.AddXY(hienthingay[5], soluonghoadon[5]);
            chart7Ngay.Series["Số hóa đơn xuất"].Points.AddXY(hienthingay[4], soluonghoadon[4]);
            chart7Ngay.Series["Số hóa đơn xuất"].Points.AddXY(hienthingay[3], soluonghoadon[3]);
            chart7Ngay.Series["Số hóa đơn xuất"].Points.AddXY(hienthingay[2], soluonghoadon[2]);
            chart7Ngay.Series["Số hóa đơn xuất"].Points.AddXY(hienthingay[1], soluonghoadon[1]);
            chart7Ngay.Series["Số hóa đơn xuất"].Points.AddXY(ngayhientai, soluonghientai);

            //Gán Doanh thu tương ứng với 7 ngày gần nhất
            chart7Ngay2.Series["Doanh thu"].Points.AddXY(hienthingay[6], doanhthu[6]);
            chart7Ngay2.Series["Doanh thu"].Points.AddXY(hienthingay[5], doanhthu[5]);
            chart7Ngay2.Series["Doanh thu"].Points.AddXY(hienthingay[4], doanhthu[4]);
            chart7Ngay2.Series["Doanh thu"].Points.AddXY(hienthingay[3], doanhthu[3]);
            chart7Ngay2.Series["Doanh thu"].Points.AddXY(hienthingay[2], doanhthu[2]);
            chart7Ngay2.Series["Doanh thu"].Points.AddXY(hienthingay[1], doanhthu[1]);
            chart7Ngay2.Series["Doanh thu"].Points.AddXY(ngayhientai, tongtienhientai);

            //Tính tổng số lượng hóa đơn và tổng doanh thu trong 7 ngày gần nhất
            int tonghoadon = soluonghientai;
            double tongdoanhthu = tongtienhientai;
            for(int i = 1; i <= 6; i++)
            {
                tonghoadon += int.Parse(soluonghoadon[i].ToString());
                tongdoanhthu += double.Parse(doanhthu[i].ToString());
            }
            tbTongHD.Text = tonghoadon.ToString();
            tbTongDT.Text = tongdoanhthu.ToString();


            //Thu và chi theo năm _ 3 năm gần nhất

            //Fill 3 năm gần nhất vào combobox
            int namhientai = DateTime.Now.Year;
            int namtruoc = namhientai - 1;
            int namkia = namhientai - 2;

            cbb3namgannhat.Items.Add(namhientai);
            cbb3namgannhat.Items.Add(namtruoc);
            cbb3namgannhat.Items.Add(namkia);

            cbbNam.Items.Add(namhientai);
            cbbNam.Items.Add(namtruoc);
            cbbNam.Items.Add(namkia);

            panelNam.Visible = false;


            //Vừa vào thì hiển thị thống kê của Tháng hiện tại
            cbbNam.Text = namhientai.ToString();
            int thanghientai = DateTime.Now.Month;
            cbbThang.Text = thanghientai.ToString();

        }


        //Thống kê theo Năm
        
        private void btnNam_Click(object sender, EventArgs e)
        {
            btnThang.Enabled = true;
            btnNam.Enabled = false;
            panelNam.Visible = true;
            panelThang.Visible = false;
            cbb3namgannhat.SelectedIndex = 0;
        }

        //Combobox 3 năm gần nhất
        double thu = 0, chi = 0, thuve = 0;
        private void cbb3namgannhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bắt đầu vào Clear hết dữ liệu cũ
            chartNam.Series.Clear();
            //Thêm lại
            chartNam.Series.Add("Tổng Thu");
            chartNam.Series.Add("Tổng Chi");

            chartNam.Series["Tổng Thu"].Name = "Tổng Thu";
            chartNam.Series["Tổng Chi"].Name = "Tổng Chi";

            chartNam.Series["Tổng Thu"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chartNam.Series["Tổng Chi"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chartNam.Series["Tổng Thu"].Color = Color.Lime;
            chartNam.Series["Tổng Thu"].BorderWidth = 3;

            chartNam.Series["Tổng Chi"].Color = Color.Red;
            chartNam.Series["Tổng Chi"].BorderWidth = 3;

            double[] tongthu = new double[13];
            double[] tongchi = new double[13];
            for (int i = 1; i <= 12; i++)
            {
                //Tổng thu _ Hóa đơn bán
                if (access.ReadData("select sum(TongTienHDB) as TongTien from HoaDonBan where month(NgayBan) = " + i + " AND year(NgayBan) = " + cbb3namgannhat.Text).Rows[0]["TongTien"].ToString() != "")
                    tongthu[i] = double.Parse(access.ReadData("select sum(TongTienHDB) as TongTien from HoaDonBan where month(NgayBan) = " + i + " AND year(NgayBan) = " + cbb3namgannhat.Text).Rows[0]["TongTien"].ToString());
                else
                    tongthu[i] = 0;

                //Tổng chi _ Hóa đơn nhập
                if (access.ReadData("select sum(TongTienHDN) as TongTien from HoaDonNhap where month(NgayNhap) = " + i + " AND year(NgayNhap) = " + cbb3namgannhat.Text).Rows[0]["TongTien"].ToString() != "")
                    tongchi[i] = double.Parse(access.ReadData("select sum(TongTienHDN) as TongTien from HoaDonNhap where month(NgayNhap) = " + i + " AND year(NgayNhap) = " + cbb3namgannhat.Text).Rows[0]["TongTien"].ToString());
                else
                    tongchi[i] = 0;
            }

            //dgvThien.Columns.Clear();
            //dgvThien.Rows.Clear();

            //dgvThien.Columns.Add("Column1", "Tháng");
            //dgvThien.Columns.Add("Column2", "Tổng Thu");
            //dgvThien.Columns.Add("Column3", "Tổng Chi");
            //dgvThien.Columns.Add("Column4", "Tiền thu về");

            DataTable data = new DataTable();
            data.Columns.Add("Tháng");
            data.Columns.Add("Tổng Thu");
            data.Columns.Add("Tổng Chi");
            //Cho ra datagridview để in excel 12 tháng
            for (int i = 1; i <= 12; i++)
            {
                //this.dgvThien.Rows.Add(i.ToString(), tongthu[i].ToString(), tongchi[i].ToString(), (tongthu[i] - tongchi[i]).ToString());
                data.Rows.Add(i.ToString(), tongthu[i].ToString(), tongchi[i].ToString());
                thu += tongthu[i];
                chi += tongchi[i];

            }
            dgvThien.DataSource = data;



            //Gán tổng thu và tổng chi vào biểu đồ tương ứng theo 12 tháng của năm

            for (int i = 1; i <= 12; i++)
            {
                chartNam.Series["Tổng Thu"].Points.AddXY("Tháng " + i, tongthu[i]);
                chartNam.Series["Tổng Chi"].Points.AddXY("Tháng " + i, tongchi[i]);
            }
            

            //Tổng tiền đã thu và Tổng tiền đã chi và Tiền Thực tế

            int thangthunhieunhat = 0, thangchinhieunhat = 0;
            double tienthunhieunhat = 0, tienchinhieunhat = 0;
            double tiendathu = 0, tiendachi = 0, tienthucte;
            for(int i = 1; i <= 12; i++)
            {
                tiendathu += tongthu[i];
                tiendachi += tongchi[i];
                //Lấy ra thông tin về Tháng thu nhiều nhất
                if (tienthunhieunhat < tongthu[i])
                {
                    tienthunhieunhat = tongthu[i];
                    thangthunhieunhat = i;
                }
                //Lấy ra thông tin về Tháng chi nhiều nhất
                if(tienchinhieunhat < tongchi[i])
                {
                    tienchinhieunhat = tongchi[i];
                    thangchinhieunhat = i;
                }
            }

            tbThangThuNhieuNhat.Text = thangthunhieunhat + " thu về " + tienthunhieunhat;
            tbThangChiNhieuNhat.Text = thangchinhieunhat + " chi ra " + tienchinhieunhat;

            tienthucte = tiendathu - tiendachi;

            tbTienDaThu.Text = tiendathu.ToString();
            tbTienDaChi.Text = tiendachi.ToString();


            



            //Tỷ lệ sản phẩm bán ra
            chartTyLeSPNam.Series.Clear();
            chartTyLeSPNam.Series.Add("Series1");
            chartTyLeSPNam.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;

            string sql = "select SanPham.MaSP, sum(SLBan) as SoLuong " +
                " from HoaDonBan, ChiTietHDB, ChiTietSanPham, SanPham " +
                " where HoaDonBan.MaHDB = ChiTietHDB.MaHDB " +
                " and ChiTietHDB.MaChiTietSP = ChiTietSanPham.MaChiTietSP " +
                " and ChiTietSanPham.MaSP = SanPham.MaSP " +
                " and year(NgayBan) = "+cbb3namgannhat.Text+" " +
                " group by SanPham.MaSP";
            DataTable dt = access.ReadData(sql);
            int soluong = dt.Rows.Count;

            chartTyLeSPNam.DataSource = dt;
            chartTyLeSPNam.Series["Series1"].XValueMember = "MaSP";
            chartTyLeSPNam.Series["Series1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartTyLeSPNam.Series["Series1"].YValueMembers = "SoLuong";
            chartTyLeSPNam.Series["Series1"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

            

        }
        //Thống kê theo Tháng
        private void btnThang_Click(object sender, EventArgs e)
        {
            btnThang.Enabled = false;
            btnNam.Enabled = true;
          
            panelNam.Visible = false;
            panelThang.Visible = true;

        }

        //Chọn Năm của Thống kê theo tháng
        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Chọn năm thì mới cho phép chọn tháng
            cbbThang.Enabled = true;
        }

        //Sau khi chọn tháng thì hiển thị thông tin phía dưới
        private void cbbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartSPGiamDan.Series.Clear();
            chartSPGiamDan.Series.Add("Series1");
            chartSPGiamDan.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            chartSPGiamDan.Series["Series1"].Color = Color.Lime;
            chartSPGiamDan.Series["Series1"].Name = "Số Lượng";
            chartSPGiamDan.Series["Số Lượng"].IsValueShownAsLabel = true;
            string sql = "select Top 3 with ties SanPham.MaSP, sum(SLBan) as SoLuong " +
                " from HoaDonBan, ChiTietHDB, ChiTietSanPham, SanPham " +
                " where HoaDonBan.MaHDB = ChiTietHDB.MaHDB " +
                " and ChiTietHDB.MaChiTietSP = ChiTietSanPham.MaChiTietSP " +
                " and ChiTietSanPham.MaSP = SanPham.MaSP" +
                " and year(NgayBan) = " + cbbNam.Text + "" +
                " and month(NgayBan) = " + cbbThang.Text + "" +
                " group by SanPham.MaSP " +
                " order by SoLuong";
            DataTable dt = access.ReadData(sql);
            //Nếu tồn tại doanh thu thì hiển thị lên Biểu đồ
            if(dt.Rows.Count > 0)
            {
                chartSPGiamDan.DataSource = dt;
                chartSPGiamDan.Series["Số Lượng"].XValueMember = "MaSP";
                chartSPGiamDan.Series["Số Lượng"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                chartSPGiamDan.Series["Số Lượng"].YValueMembers = "SoLuong";
                chartSPGiamDan.Series["Số Lượng"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;

                //Thống kê tổng tiền đã thu
                string tien = "Select count(MaHDB) as SoLuongHD, sum(TongTienHDB) as TongTien from HoaDonBan where year(NgayBan) = " + cbbNam.Text + " and month(NgayBan) = " + cbbThang.Text + "";
                DataTable dt_tien = access.ReadData(tien);

                tbHoaDonDaXuat.Text = dt_tien.Rows[0]["SoLuongHD"].ToString();
                tbTongTienDaThu.Text = dt_tien.Rows[0]["TongTien"].ToString();

                //Thống kê tổng tiền đã chi
                string tienchi = "Select sum(TongTienHDN) as TongTienChi from HoaDonNhap where year(NgayNhap) = " + cbbNam.Text + " and month(NgayNhap) = " + cbbThang.Text + "";
                DataTable dt_tienchi = access.ReadData(tienchi);

                tbTongTienDaChi.Text = dt_tienchi.Rows[0]["TongTienChi"].ToString();
               

            }
            //Nếu tháng đó không có doanh thu (cửa hàng nghỉ)
            else
            {
                
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MessageGuna.Text = "Tháng này không có doanh thu";
                MessageGuna.Show();
                tbHoaDonDaXuat.Text = tbTongTienDaThu.Text = tbTongTienDaChi.Text =  "";
               
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if(btnThang.Enabled == false)
            {
                if(tbHoaDonDaXuat.Text == "")
                {
                    MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                    MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageGuna.Text = "Bạn không in được khi không có doanh thu!";
                    MessageGuna.Show();
                    return;
                }    
                xuatexcel = new XuatExel(3,"Thống kê doanh thu tháng "+ cbbThang.Text + " năm " + cbbNam.Text, tbHoaDonDaXuat.Text, tbTongTienDaThu.Text, tbTongTienDaChi.Text);  

            }    
            else
            {
                if (tbTienDaThu.Text == "0" &&  tbTienDaChi.Text == "0")
                {
                    MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                    MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageGuna.Text = "Bạn không in được khi không có doanh thu!";
                    MessageGuna.Show();
                    return;
                }
                xuatexcel = new XuatExel(dgvThien, "Thống kê doanh thu năm " + cbb3namgannhat.Text, thu.ToString(), chi.ToString());
            }
        }

    }
}
