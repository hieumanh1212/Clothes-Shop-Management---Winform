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
    public partial class HoaDonNhap : System.Windows.Forms.Form
    {
        Form_Login login = new Form_Login();
        AccessData access = new AccessData();
        XuatExel xuatexel;
        CommondFunction common = new CommondFunction();
        bool CheckLuuChiTiet = false;       //Nếu = false thì lưu, = true thì sửa
        bool CheckHuy = false;              //Nếu = false thì hủy chức năng thêm, = true là hủy chức năng tìm kiếm
        public string user = "";
        public HoaDonNhap()
        {
            InitializeComponent();
            user = login.get_user();
        }

        //Button Đóng
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Hàm Load
        private void HoaDonNhap_Load(object sender, EventArgs e)
        {

            //Fill combobox Tìm kiếm
            common.FillCombobox(cbbTimKiem, access.ReadData("Select * from HoaDonNhap"), "MaHDN", "MaHDN");
            cbbTimKiem.SelectedIndex = -1;

            //Fill combobox NhaCungCap
            common.FillCombobox(cbbMaNCC, access.ReadData("Select * from NhaCungCap"), "MaNhaCungCap", "MaNhaCungCap");
            cbbMaNCC.SelectedIndex = -1;
            //Button ThemChiTiet
            btnThemChiTiet.Enabled = false;

            //Fill combobox Mã chi tiết
            common.FillCombobox(cbbMaChiTiet, access.ReadData("Select * from ChiTietSanPham"), "MaChiTietSP", "MaChiTietSP");
            cbbMaChiTiet.SelectedIndex = -1;

            //Thông tin chung
            tbMaHD.Text = tbTenNCC.Text = "";
            //Tự nhập điền mã nhân viên + tên nhân viên
            tbMaNV.Text = user;
            string sql = "select TenNV from NhanVien where MaNV = N'" + user + "'";
            tbTenNV.Text = access.ReadData(sql).Rows[0]["TenNV"].ToString();
            //Ngày nhập là ngày hôm nay (Hiện tại)
            dtNgayNhap.Value = DateTime.Now;


            //Thông tin chi tiết
            tbTenHang.Text = tbChatLieu.Text = tbTheLoai.Text = tbSize.Text = tbMauSac.Text = tbDonGia.Text = "";
            pictureAnh.Image = null;

            //Numberic
            nbrSoLuongNhap.Enabled = false;

            //Enable button
            EnableButton(true, false);

            //Clear DatagridView
            dgvThongTin.DataSource = null;

            //Tổng tiền
            tbTongTien.Text = "";

        }
        //Hàm show table
        public void ShowTable(string str)
        {
            string sql = "select ChiTietSanPham.MaChiTietSP, TenSP, TenChatLieu, TenTheLoai, Size, MauSac, SLNhap, DonGiaNhap, ThanhTienHDN " +
                " from ChiTietHDN, ChiTietSanPham, SanPham, TheLoai, ChatLieu " +
                " where ChiTietHDN.MaChiTietSP = ChiTietSanPham.MaChiTietSP AND ChiTietSanPham.MaSP = SanPham.MaSP " +
                " AND SanPham.MaTheLoai = TheLoai.MaTheLoai and SanPham.MaChatLieu = ChatLieu.MaChatLieu " +
                " AND MaHDN = N'"+str+"'";
            dgvThongTin.DataSource = access.ReadData(sql);

            dgvThongTin.Columns[0].HeaderText = "Mã Chi Tiết SP";
            dgvThongTin.Columns[1].HeaderText = "Tên SP";
            dgvThongTin.Columns[2].HeaderText = "Chất Liệu";
            dgvThongTin.Columns[3].HeaderText = "Thể Loại";
            dgvThongTin.Columns[4].HeaderText = "Size";
            dgvThongTin.Columns[5].HeaderText = "Màu sắc";
            dgvThongTin.Columns[6].HeaderText = "Số lượng";
            dgvThongTin.Columns[7].HeaderText = "Giá nhập";
            dgvThongTin.Columns[8].HeaderText = "Thành Tiền";
        }
        //Enable Button
        public void EnableButton(bool check1, bool check2)
        {
            btnThem.Enabled = check1;
            btnLuu.Enabled = btnHuy.Enabled = btnIn.Enabled = check2;
        }

        //Khi chọn mã nhà cung cấp thì Tên nhà cung cấp phải tự động cập nhật
        private void cbbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "Select TenNhaCungCap from NhaCungCap where MaNhaCungCap = N'" + cbbMaNCC.Text + "'";
                tbTenNCC.Text = access.ReadData(sql).Rows[0]["TenNhaCungCap"].ToString();

                btnThemChiTiet.Enabled = true;
            }
            catch
            { }



            
        }

        //Thêm Hóa Đơn Nhập
        private void btnThem_Click(object sender, EventArgs e)
        {
            CheckHuy = false;

            EnableButton(false, true);
            btnLuu.Enabled = false;
            btnIn.Enabled = false;

            //Tự sinh ra mã Hóa đơn nhập
            tbMaHD.Text = common.AutoCode("HoaDonNhap", "MaHDN", "HDN");

            //Mở mã nhà cung cấp
            cbbMaNCC.Enabled = true;

            //Đổi màu
            grbThongTin.CustomBorderColor = Color.FromArgb(31, 30, 68);
            grbThongTin.ForeColor = Color.White;

            //Tắt chức năng tìm kiếm
            cbbTimKiem.Enabled = false;
        }

        //Thêm chi tiết
        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            CheckLuuChiTiet = false;

            //Đóng mã nhà cung cấp
            cbbMaNCC.Enabled = false;
            btnThemChiTiet.Enabled = false;

            //Mở chi tiết
            cbbMaChiTiet.Enabled = true;
            nbrSoLuongNhap.Enabled = false;

            //Đổi màu thông tin 
            grbThongTin.CustomBorderColor = Color.FromArgb(213, 218, 223);
            grbThongTin.ForeColor = Color.FromArgb(31, 30, 68);
            //Đổi màu Chi Tiết
            grbThongTinChiTiet.CustomBorderColor = Color.FromArgb(31, 30, 68);
            grbThongTinChiTiet.ForeColor = Color.White;
            lbThongBao.ForeColor = lbTongTien.ForeColor = Color.FromArgb(31, 30, 68);


            //Inser bảng Hóa Đơn Nhập
            string sql = "Insert HoaDonNhap values (N'"+tbMaHD.Text+"', N'"+cbbMaNCC.Text+"', N'"+tbMaNV.Text+"', " +
                "'"+ String.Format("{0:MM/dd/yyyy}", dtNgayNhap.Value.ToString()) + "', 0)";
            access.UpdateData(sql);

        }

        //Sự kiện cho cbbMaChiTiet
        private void cbbMaChiTiet_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select * from ChiTietSanPham, SanPham, TheLoai, ChatLieu " +
                " where ChiTietSanPham.MaSP = SanPham.MaSP " +
                " AND SanPham.MaTheLoai = TheLoai.MaTheLoai " +
                " AND SanPham.MaChatLieu = ChatLieu.MaChatLieu " +
                " AND ChiTietSanPham.MaChiTietSP = N'"+cbbMaChiTiet.Text+"'";
            DataTable dt = access.ReadData(sql);
            if(cbbMaChiTiet.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                try
                {
                    tbTenHang.Text = dt.Rows[0]["TenSP"].ToString();
                    tbChatLieu.Text = dt.Rows[0]["TenChatLieu"].ToString();
                    tbTheLoai.Text = dt.Rows[0]["TenTheLoai"].ToString();
                    tbSize.Text = dt.Rows[0]["Size"].ToString();
                    tbMauSac.Text = dt.Rows[0]["MauSac"].ToString();
                    tbDonGia.Text = dt.Rows[0]["DonGiaNhap"].ToString();
                    if (dt.Rows[0]["Anh"].ToString() != "")
                        pictureAnh.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + dt.Rows[0]["Anh"].ToString());
                    else
                        pictureAnh.Image = null;

                    //Sau khi chọn mã chi tiết thì mới được phép chọn số lượng nhập
                    nbrSoLuongNhap.Enabled = true;

                    //Mỗi khi chọn mới Chi Tiết thì số lượng về 0
                    nbrSoLuongNhap.Value = 0;

                }
                catch { }
            }
        }

        private void tbDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        //Số lượng của Chi Tiết Sản Phẩm
        private void nbrSoLuongNhap_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbThanhTien.Text = (double.Parse(tbDonGia.Text) * int.Parse(nbrSoLuongNhap.Value.ToString())).ToString();

                //Sau khỉ chọn số lượng thì mới được phép lưu chi tiết
                btnLuuChiTiet.Enabled = int.Parse(nbrSoLuongNhap.Value.ToString()) > 0 ? true : false;


            }
            catch { }
            

        }

        //Button Lưu chi tiết
        private void btnLuuChiTiet_Click(object sender, EventArgs e)
        {
            if(CheckLuuChiTiet == false)        //Thêm chi tiết
            {
                //Nếu đã tồn tại một chi tiết nào đó, thì khi thêm lần 2 sẽ chỉ cập nhật lại số lượng
                string tontai = "Select * from ChiTietHDN where MaChiTietSP = N'" + cbbMaChiTiet.Text +
                    "' AND MaHDN = N'" + tbMaHD.Text + "'";
                DataTable dt_tontai = access.ReadData(tontai);
                
                if (dt_tontai.Rows.Count > 0)
                {
                    int soluongcu = int.Parse(dt_tontai.Rows[0]["SLNhap"].ToString());
                    int soluongmoi = soluongcu + int.Parse(nbrSoLuongNhap.Value.ToString());
                    string updatesoluong = "Update ChiTietHDN set SLNhap = " + soluongmoi.ToString() + 
                        " where MaChiTietSP = N'"+cbbMaChiTiet.Text+"' AND MaHDN = N'"+tbMaHD.Text+"'";
                    access.UpdateData(updatesoluong);

                    ShowTable(tbMaHD.Text);

                    //Hiển thị MessageGuna
                    MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MessageGuna.Text = "Thêm thành công";
                    MessageGuna.Show();

                }
                else
                {
                    string sql = "Insert ChiTietHDN values (N'" + cbbMaChiTiet.Text + "', N'" + tbMaHD.Text + "', " + nbrSoLuongNhap.Value.ToString() + " , " + tbThanhTien.Text + ")";
                    access.UpdateData(sql);

                    ShowTable(tbMaHD.Text);

                    //Hiển thị MessageGuna
                    MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MessageGuna.Text = "Thêm thành công";
                    MessageGuna.Show();

                }

                //Gán các text về null
                ChiTietText();

                btnLuuChiTiet.Enabled = false;

                //Tổng tiền HĐN
                TongTienHDN(tbMaHD.Text);

                //Button Lưu
                btnLuu.Enabled = true;

                

            }    
            else                                //Sửa chi tiết
            {
                string update = "Update ChiTietHDN set SLNhap = "+nbrSoLuongNhap.Value.ToString()+" " +
                    " where MaChiTietSP = N'"+cbbMaChiTiet.Text+"' AND MaHDN = N'"+tbMaHD.Text+"'";
                access.UpdateData(update);

                
                //Hiển thị MessageGuna
                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                MessageGuna.Text = "Sửa thành công";
                MessageGuna.Show();

                btnHuyChiTiet_Click(sender, e);

                ShowTable(tbMaHD.Text);
                TongTienHDN(tbMaHD.Text);
                
            }
        }

        //Hàm lấy tổng tiền của Hóa đơn nhập
        public void TongTienHDN(string str)
        {
            string tongtien = "Select * from HoaDonNhap where MaHDN = N'" + str + "'";
            tbTongTien.Text = access.ReadData(tongtien).Rows[0]["TongTienHDN"].ToString();

        }
        //Hàm gán các text của Chi Tiết về null
        public void ChiTietText()
        {
            common.FillCombobox(cbbMaChiTiet, access.ReadData("Select * from ChiTietSanPham"), "MaChiTietSP", "MaChiTietSP");
            cbbMaChiTiet.SelectedIndex = -1;

            tbChatLieu.Text = tbSize.Text = tbDonGia.Text = tbTenHang.Text = tbTheLoai.Text = tbMauSac.Text = "";
            tbThanhTien.Text = "";


            nbrSoLuongNhap.Value = 0;
            pictureAnh.Image = null;
            nbrSoLuongNhap.Enabled = false;

            cbbMaChiTiet.Enabled = false;
            cbbMaChiTiet.Enabled = true;
        }

        //Sự kiện cellclick cho chi tiết sản phẩm
        private void dgvThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            cbbMaChiTiet.Text = dgvThongTin.CurrentRow.Cells[0].Value.ToString();
            nbrSoLuongNhap.Value = int.Parse(dgvThongTin.CurrentRow.Cells[6].Value.ToString());

            if (CheckHuy == false)              //Khi đang ở trong chức năng Thêm
            {
                //Hiển thị button Hủy Chi Tiết
                btnLuuChiTiet.Enabled = btnHuyChiTiet.Enabled = true;
                CheckLuuChiTiet = true;

                cbbMaChiTiet.Enabled = false;
                cbbMaChiTiet.Enabled = true;
                cbbMaChiTiet.Enabled = false;
            }
            else                               //Khi đang ở trong chức năng Tìm kiếm
            {
                //Hiển thị button Hủy Chi Tiết
                btnLuuChiTiet.Enabled = btnHuyChiTiet.Enabled = false;
                CheckLuuChiTiet = true;
                nbrSoLuongNhap.Enabled = false;

                cbbMaChiTiet.Enabled = false;
                cbbMaChiTiet.Enabled = true;
                cbbMaChiTiet.Enabled = false;
            }

        }

        //Button Hủy Chi Tiết
        private void btnHuyChiTiet_Click(object sender, EventArgs e)
        {
            CheckLuuChiTiet = false;
            //Cho Text bằng rỗng
            ChiTietText();

            nbrSoLuongNhap.Value = 0;

            btnHuyChiTiet.Enabled = false;
        }

        //Xóa chi tiết sản phẩm
        private void dgvThongTin_DoubleClick(object sender, EventArgs e)
        {
            if(cbbTimKiem.Text == "")
            {
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                MessageGuna.Text = "Bạn có muốn xóa không ?";
                if (MessageGuna.Show() == DialogResult.Yes)
                {
                    string sql = "Delete from ChiTietHDN " +
                        " where MaChiTietSP = N'" + cbbMaChiTiet.Text + "' AND MaHDN = N'" + tbMaHD.Text + "'";
                    access.UpdateData(sql);

                    //Hiển thị MessageGuna
                    MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MessageGuna.Text = "Xóa thành công";
                    MessageGuna.Show();

                    btnHuyChiTiet_Click(sender, e);

                    ShowTable(tbMaHD.Text);
                    TongTienHDN(tbMaHD.Text);

                    if (dgvThongTin.Rows.Count == 0)
                    {
                        btnLuu.Enabled = false;
                    }
                }
            }

           
        }

        //Button Lưu chung -- Sau khi thêm một hóa đơn nhập mới. Ấn nút lưu kết thúc quá trình Thêm.
        //Tất cả về ban đầu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Fill combobox Tìm kiếm
            common.FillCombobox(cbbTimKiem, access.ReadData("Select * from HoaDonNhap"), "MaHDN", "MaHDN");
            cbbTimKiem.SelectedIndex = -1;
            //Thông tin chung
            tbMaHD.Text = "";
            common.FillCombobox(cbbMaNCC, access.ReadData("Select * from NhaCungCap"), "MaNhaCungCap", "MaNhaCungCap");
            cbbMaNCC.SelectedIndex = -1;
            btnThemChiTiet.Enabled = false;
            tbTenNCC.Text = "";
            cbbMaNCC.Enabled = false;
            //Thông tin chi tiết
            ChiTietText();
            cbbMaChiTiet.Enabled = nbrSoLuongNhap.Enabled = false;
            //Datagridview Clear
            dgvThongTin.DataSource = null;

            //Enable Button
            EnableButton(true, false);

            //Tổng tiền
            tbTongTien.Text = "";

            //Bật tìm kiếm
            cbbTimKiem.Enabled = true;

            //Đổi màu thông tin 
            grbThongTin.CustomBorderColor = Color.FromArgb(213, 218, 223);
            grbThongTin.ForeColor = Color.FromArgb(31, 30, 68);
            //Đổi màu Chi Tiết
            grbThongTinChiTiet.CustomBorderColor = Color.FromArgb(213, 218, 223);
            grbThongTinChiTiet.ForeColor = Color.FromArgb(31, 30, 68);
        }

        //Button Hủy -- Nếu như đang trong quá trình tạo hóa đơn mà không muốn tạo nữa thì sẽ xóa hết dữ liệu
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(CheckHuy == false)       //Hủy hóa đơn khi đang trong chức năng Tạo hóa đơn
            {
                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                MessageGuna.Text = "Bạn có muốn hủy hóa đơn này không ?";
                if (MessageGuna.Show() == DialogResult.Yes)
                {
                    //Xóa HoaDonNhap
                    string sql = "Delete from HoaDonNhap where MaHDN = N'" + tbMaHD.Text + "'";
                    access.UpdateData(sql);

                    //Thông tin chung
                    tbMaHD.Text = "";
                    common.FillCombobox(cbbMaNCC, access.ReadData("Select * from NhaCungCap"), "MaNhaCungCap", "MaNhaCungCap");
                    cbbMaNCC.SelectedIndex = -1;
                    btnThemChiTiet.Enabled = false;
                    tbTenNCC.Text = "";
                    cbbMaNCC.Enabled = false;
                    //Thông tin chi tiết
                    ChiTietText();
                    cbbMaChiTiet.Enabled = nbrSoLuongNhap.Enabled = false;
                    //Datagridview Clear
                    dgvThongTin.DataSource = null;

                    //Enable Button
                    EnableButton(true, false);

                    //Tổng tiền
                    tbTongTien.Text = "";

                    //Bật tìm kiếm
                    cbbTimKiem.Enabled = true;

                    CheckHuy = false;

                    //Đổi màu thông tin 
                    grbThongTin.CustomBorderColor = Color.FromArgb(213, 218, 223);
                    grbThongTin.ForeColor = Color.FromArgb(31, 30, 68);
                    //Đổi màu Chi Tiết
                    grbThongTinChiTiet.CustomBorderColor = Color.FromArgb(213, 218, 223);
                    grbThongTinChiTiet.ForeColor = Color.FromArgb(31, 30, 68);
                }
            }
            else                 //Nếu đang tìm kiếm mà bấm HỦY thì kết thúc chức năng HỦY
            {
                HoaDonNhap_Load(sender, e);
            }

        }

        //Chức năng tìm kiếm
        private void cbbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckHuy = true;
            try
            {
                string ThongTinChung = "select HoaDonNhap.MaHDN, NhanVien.MaNV, TenNV, NhaCungCap.MaNhaCungCap, TenNhaCungCap, NgayNhap " +
                " from NhanVien, HoaDonNhap, NhaCungCap" +
                " where NhanVien.MaNV = HoaDonNhap.MaNV AND HoaDonNhap.MaNhaCungCap = NhaCungCap.MaNhaCungCap " +
                " AND HoaDonNHap.MaHDN = N'" + cbbTimKiem.Text + "'";
                DataTable dtChung = access.ReadData(ThongTinChung);
                //Điền thông tin lên Thông Tin Chung
                tbMaHD.Text = dtChung.Rows[0]["MaHDN"].ToString();
                cbbMaNCC.Text = dtChung.Rows[0]["MaNhaCungCap"].ToString();
                tbTenNCC.Text = dtChung.Rows[0]["TenNhaCungCap"].ToString();
                dtNgayNhap.Text = dtChung.Rows[0]["NgayNhap"].ToString();

                //Chỉnh sửa button trong Thông Tin Chung
                btnThemChiTiet.Enabled = false;
                cbbMaNCC.Enabled = true;
                cbbMaNCC.Enabled = false;

                //Chỉnh sửa Button tổng thể
                btnThem.Enabled = false;
                btnHuy.Enabled = btnIn.Enabled =  true;

                //Button Hủy chi tiết
                btnHuyChiTiet.Enabled = false;

                //Điền thông tin Chi Tiết
                ShowTable(tbMaHD.Text);

                //Tổng tiền của hóa đơn đang tìm
                string TongTien = "select * from HoaDonNhap where MaHDN = N'"+tbMaHD.Text+"'";
                DataTable dtTien = access.ReadData(TongTien);
                tbTongTien.Text = dtTien.Rows[0]["TongTienHDN"].ToString();
            }
            catch
            { }



        }

        //Xóa hóa đơn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            MessageGuna.Text = "Bạn có muốn xóa hóa đơn này không ?";
            if(MessageGuna.Show() == DialogResult.Yes)
            {
                string Xoa = "Delete from HoaDonNhap where MaHDN = N'" + cbbTimKiem.Text + "'";
                access.UpdateData(Xoa);

                //Hiển thị MessageGuna
                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                MessageGuna.Text = "Xóa thành công";
                MessageGuna.Show();

                HoaDonNhap_Load(sender, e);
            }
            
        }

        private void grbThongTinChiTiet_Click(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (dgvThongTin.RowCount <= 0)
            {
                MessageGuna.Text = "Bạn không thể xuất khi Không có dòng dữ liệu nào !";
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Caption = "Thông báo";
                MessageGuna.Show();
                return;
            }
            
            xuatexel = new XuatExel(dgvThongTin, "Hóa đơn nhập", tbMaHD.Text, tbTenNCC.Text, tbTenNV.Text, tbTongTien.Text, dtNgayNhap.Value.ToString("dd/MM/yyyy"));
        }
    }
}
