using DuyThien_BTL.KetNoi;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xuat_Exel;
using static System.Net.WebRequestMethods;

namespace DuyThien_BTL.Childen
{
    public partial class HoaDonBan : System.Windows.Forms.Form
    {
        AccessData access = new AccessData();
        CommondFunction common = new CommondFunction();
        Form_Login login = new Form_Login();
        XuatExel xuatexel;
        //Lưu username (tên đăng nhập) của người hiện tại
        string username = "";

        //Lưu tổng tiền của cả hóa đơn
        double tongtien;
        //Bắt cho nút Lưu Chi Tiết. Nếu = false thì sẽ được hiểu là Thêm. = true là đang chức năng sửa
        bool CheckLuuChiTiet = false;       //Nếu = false thì Thêm, = true thì Sửa
        //Nếu = false thì đang ở chức năng Thêm, sẽ Hủy hóa đơn đang tạo. Nếu = true thì đang ở chức năng tìm kiếm, chỉ thoát khỏi chức năng tìm kiếm
        bool CheckHuy = false;              //Nếu = false thì đang ở chức năng thêm, = true thì đang ở chức năng tìm kiếm

        //Check Voucher
        //Nếu đang ở trong chức năng Thêm thì CheckVoucher = false, nếu bấm Hủy thì CheckVoucher = true
        //Phục vụ cho mục đích: Bấm Hủy thì CheckVoucher = true để nó không vào trong sự kiện selectedindexchanged của cbbVoucher
        bool CheckVoucher = false;

        //CheckCellClick
        //Nếu CheckCellClick = false thì đang ở chức năng Thêm. Nếu CheckCellClick = true thì đang ở chức năng Tìm kiếm
        //Phục vụ cho mục đích: Nếu bấm vào CellClick trong chức năng Tìm kiếm thì sẽ không bắt sự kiện valuechanged của nbrSoLuongBan
        bool CheckCellClick = false;
        public HoaDonBan()
        {

            InitializeComponent();
        }

        //Hàm Load
        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            //Fill Tim Kiem
            common.FillCombobox(cbbTimKiem, access.ReadData("Select * from HoaDoNBan"), "MaHDB", "MaHDB");
            cbbTimKiem.SelectedIndex = -1;

            tbTienBanDau.Text = tbTienVoucher.Text = "";

            //Fill combobox Voucher
            common.FillCombobox(cbbVoucher, access.ReadData("Select * from Voucher"), "TenVoucher", "MaVoucher");
            cbbVoucher.SelectedIndex = -1;

            //Fill combobox Mã Chi Tiết Sản Phẩm
            common.FillCombobox(cbbMaChiTiet, access.ReadData("Select * from ChiTietSanPham"), "MaChiTietSP", "MaChiTietSP");
            cbbMaChiTiet.SelectedIndex = -1;

            //Text Chi Tiết Sản Phẩm về rỗng
            tbTenHang.Text = tbChatLieu.Text = tbSize.Text = tbMauSac.Text = tbTheLoai.Text = tbDonGia.Text = "";
            pictureAnh.Image = null;

            //Fill combobox Mã Khách Hàng
            common.FillCombobox(cbbMaKH, access.ReadData("Select * from KhachHang"), "MaKH", "MaKH");
            cbbMaKH.SelectedIndex = -1;

            //Text Khách Hàng về rỗng
            tbTenKH.Text = tbDienThoai.Text = tbDiaChi.Text = "";
            btnThemChiTiet.Enabled = false;

            //Bắt đầu vào thì các button là False
            btnLuu.Enabled = btnHuy.Enabled = btnIn.Enabled = false;
            nbrSoLuongBan.Enabled = false;

            //Gán Mã Nhân Viên, Tên Nhân Viên, Ngày Bán (Ngày hôm nay)
            username = login.get_user();
            tbMaNV.Text = username;
            String layten = "Select * from NhanVien where MaNV = N'"+username+"'";
            tbTenNV.Text = access.ReadData(layten).Rows[0]["TenNV"].ToString();

            dtNgayBan.Value = DateTime.Now;
            tbMaHD.Text = "";
            btnThem.Enabled = true;
            tbTongTien.Text = "";

            //Clear datagridview
            dgvThongTin.DataSource = null;


        }

        //Thêm Hóa Đơn
        private void btnThem_Click(object sender, EventArgs e)
        {
            //Nếu bấm Thêm thì CheckCellClick = true
            CheckCellClick = true;
            //Nếu bấm Thêm thì CheckLuuChiTiet = false
            CheckLuuChiTiet = false;

            btnHuy.Enabled = true;
            btnThem.Enabled = btnLuu.Enabled = false;

            //Tự sinh ra Mã Hóa Đơn
            tbMaHD.Text = common.AutoCode("HoaDonBan", "MaHDB", "HDB");

            //Combobox MaKH
            cbbMaKH.Enabled = true;

            //Đổi màu
            grbThongTin.CustomBorderColor = Color.FromArgb(31, 30, 68);
            grbThongTin.ForeColor = Color.White;

            //Tắt chức năng tìm kiếm
            cbbTimKiem.Enabled = false;

            //CheckHuy
            CheckHuy = false;

            //CheckVoucher
            CheckVoucher = false;
        }

        //Khi chọn Mã KH từ Combobox, tự động điền các giá trị liên quan
        private void cbbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = "Select * from KhachHang where MaKH = N'" + cbbMaKH.Text + "'";
                DataTable dt = access.ReadData(sql);
                tbTenKH.Text = dt.Rows[0]["TenKH"].ToString();
                tbDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();
                tbDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();

                //Sau khi chọn xong Khách Hàng thì sẽ cho Nhập chi tiết hóa đơn
                btnThemChiTiet.Enabled = true;
            }
            catch { }

        }

        //Button Thêm Chi Tiết cho hóa đơn
        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            cbbMaKH.Enabled = false;
            btnThemChiTiet.Enabled = false;
            btnThemChiTiet.Enabled = false;
            btnLuuChiTiet.Enabled = btnHuyChiTiet.Enabled = false;
            //Đổi màu
            grbThongTin.CustomBorderColor = Color.FromArgb(213, 218, 223);
            grbThongTin.ForeColor = Color.FromArgb(31, 30, 68);
            //Đổi màu chi tiết
            grbThongTinChiTiet.CustomBorderColor = Color.FromArgb(31, 30, 68);
            grbThongTinChiTiet.ForeColor = Color.White;
            //Đổi màu các label để nó được hiển thị
            lbVoucher.ForeColor = lbTongTien.ForeColor = lblTienBanDau.ForeColor = lblTienVoucher.ForeColor = Color.FromArgb(31, 30, 68);

            //Mở chi tiết
            cbbMaChiTiet.Enabled = true;

            //Thêm bản ghi vào HoaDonBan
            string sql = "Insert HoaDonBan values (N'"+tbMaHD.Text+"', N'"+tbMaNV.Text+"', N'"+cbbMaKH.Text+
                "', N'', '"+ String.Format("{0:MM/dd/yyyy}", dtNgayBan.Value.ToString()) + "', 0)";
            access.UpdateData(sql);

            //Mở Voucher
            cbbVoucher.Enabled = true;
        }

        //Chọn combobox Mã Chi Tiết SP
        private void cbbMaChiTiet_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Select * from ChiTietSanPham, SanPham, TheLoai, ChatLieu " +
                " where ChiTietSanPham.MaSP = SanPham.MaSP " +
                " AND SanPham.MaTheLoai = TheLoai.MaTheLoai " +
                " AND SanPham.MaChatLieu = ChatLieu.MaChatLieu " +
                " AND ChiTietSanPham.MaChiTietSP = N'" + cbbMaChiTiet.Text + "'";
            DataTable dt = access.ReadData(sql);
            if (cbbMaChiTiet.SelectedIndex == -1)
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
                    tbDonGia.Text = dt.Rows[0]["DonGiaBan"].ToString();
                    if (dt.Rows[0]["Anh"].ToString() != "")
                        pictureAnh.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + dt.Rows[0]["Anh"].ToString());
                    else
                        pictureAnh.Image = null;

                    //Sau khi chọn mã chi tiết thì mới được phép chọn số lượng nhập
                    nbrSoLuongBan.Enabled = true;

                    //Mỗi khi chọn mới Chi Tiết thì số lượng về 0
                    nbrSoLuongBan.Value = 0;

                }
                catch { }
            }
        }

        //Chọn số lượng Khách Hàng muốn mua
        private void nbrSoLuongBan_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(CheckCellClick == true)  //Đang chức năng Thêm
                {
                    //Kiểm tra xem số lượng sản phẩm còn đáp ứng đủ hay không
                    string sql = "Select * from ChiTietSanPham where MaChiTietSP = N'" + cbbMaChiTiet.Text + "'";
                    int soluongcon = int.Parse(access.ReadData(sql).Rows[0]["SoLuong"].ToString());
                    //Nếu như số lượng khách mua > số lượng còn lại thì hiển thị thông báo
                    if (int.Parse(nbrSoLuongBan.Value.ToString()) > soluongcon)
                    {
                        MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                        MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        MessageGuna.Text = "Sản phẩm này chỉ còn: " + soluongcon;
                        MessageGuna.Show();

                        //Xóa bỏ text
                        nbrSoLuongBan.Value = 0;
                        nbrSoLuongBan.Focus();
                    }
                    //Nếu như số lượng khách mua < số lượng còn lại thì cho phép tạo hóa đơn bán
                    else
                    {
                        tbThanhTien.Text = (double.Parse(tbDonGia.Text) * int.Parse(nbrSoLuongBan.Value.ToString())).ToString();

                        //Sau khỉ chọn số lượng thì mới được phép lưu chi tiết
                        btnLuuChiTiet.Enabled = int.Parse(nbrSoLuongBan.Value.ToString()) > 0 ? true : false;
                    }
                }
                else
                {

                }
                
            }
            catch { }
        }

        //Button Lưu Chi Tiết
        private void btnLuuChiTiet_Click(object sender, EventArgs e)
        {
            if(CheckLuuChiTiet == false)        //Thêm chi tiết sản phẩm
            {
                //Nếu đã tồn tại một chi tiết nào đó, thì khi thêm lần 2 sẽ chỉ cập nhật lại số lượng
                string tontai = "Select * from ChiTietHDB where MaChiTietSP = N'" + cbbMaChiTiet.Text +
                    "' AND MaHDB = N'" + tbMaHD.Text + "'";
                DataTable dt_tontai = access.ReadData(tontai);

                if (dt_tontai.Rows.Count > 0)
                {
                    int soluongcu = int.Parse(dt_tontai.Rows[0]["SLBan"].ToString());
                    int soluongmoi = soluongcu + int.Parse(nbrSoLuongBan.Value.ToString());
                    string updatesoluong = "Update ChiTietHDB set SLBan = " + soluongmoi.ToString() +
                        " where MaChiTietSP = N'" + cbbMaChiTiet.Text + "' AND MaHDB = N'" + tbMaHD.Text + "'";
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
                    string sql = "Insert ChiTietHDB values (N'" + cbbMaChiTiet.Text + "', N'" + tbMaHD.Text + "', " + nbrSoLuongBan.Value.ToString() + " , " + tbThanhTien.Text + ")";
                    access.UpdateData(sql);

                    ShowTable(tbMaHD.Text);

                    //Hiển thị MessageGuna
                    MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MessageGuna.Text = "Thêm thành công";
                    MessageGuna.Show();
                }

                //Gán các text trong Chi Tiết = null
                ChiTietText();
                //Sau khi lưu chi tiết thì tắt button lưu chi tiết
                btnLuuChiTiet.Enabled = false;

                //Tổng tiền HĐB
                TongTienHDB(tbMaHD.Text);

                tbTienBanDau.Text = tbTongTien.Text;
                tbTienVoucher.Text = "-0";

                //Button Lưu
                btnLuu.Enabled = true;

            }
            else                                //Sửa chi tiết sản phẩm
            {

                string update = "Update ChiTietHDB set SLBan = " + nbrSoLuongBan.Value.ToString() + " " +
                    " where MaChiTietSP = N'" + cbbMaChiTiet.Text + "' AND MaHDB = N'" + tbMaHD.Text + "'";
                access.UpdateData(update);


                //Hiển thị MessageGuna
                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                MessageGuna.Text = "Sửa thành công";
                MessageGuna.Show();

                btnHuyChiTiet_Click(sender, e);

                ShowTable(tbMaHD.Text);

                //Tổng tiền HĐB
                TongTienHDB(tbMaHD.Text);

                tbTienBanDau.Text = tbTongTien.Text;
                tbTienVoucher.Text = "-0";
            }
            //Lưu tổng tiền của cả hóa đơn
            tongtien = double.Parse(tbTongTien.Text);
        }
        public void TongTienHDB(string str)
        {
            string sql = "Select * from HoaDonBan where MaHDB = N'"+str+"'";
            tbTongTien.Text = access.ReadData(sql).Rows[0]["TongTienHDB"].ToString();
        }
        //Hàm Show Table
        void ShowTable(string str)
        {
            string sql = "select ChiTietSanPham.MaChiTietSP, TenSP, TenChatLieu, TenTheLoai, Size, MauSac, SLBan, DonGiaBan, ThanhTienHDB " +
                " from ChiTietHDB, ChiTietSanPham, SanPham, TheLoai, ChatLieu " +
                " where ChiTietHDB.MaChiTietSP = ChiTietSanPham.MaChiTietSP AND ChiTietSanPham.MaSP = SanPham.MaSP " +
                " AND SanPham.MaTheLoai = TheLoai.MaTheLoai and SanPham.MaChatLieu = ChatLieu.MaChatLieu " +
                " AND MaHDB = N'" + str + "'";
            dgvThongTin.DataSource = access.ReadData(sql);

            dgvThongTin.Columns[0].HeaderText = "Mã Chi Tiết SP";
            dgvThongTin.Columns[1].HeaderText = "Tên SP";
            dgvThongTin.Columns[2].HeaderText = "Chất Liệu";
            dgvThongTin.Columns[3].HeaderText = "Thể Loại";
            dgvThongTin.Columns[4].HeaderText = "Size";
            dgvThongTin.Columns[5].HeaderText = "Màu sắc";
            dgvThongTin.Columns[6].HeaderText = "Số lượng";
            dgvThongTin.Columns[7].HeaderText = "Giá bán";
            dgvThongTin.Columns[8].HeaderText = "Thành Tiền";
        }
        //Hàm ChiTietText để gán các text trong Thông tin chi tiết về rỗng
        public void ChiTietText()
        {
            common.FillCombobox(cbbMaChiTiet, access.ReadData("Select * from ChiTietSanPham"), "MaChiTietSP", "MaChiTietSP");
            cbbMaChiTiet.SelectedIndex = -1;

            tbChatLieu.Text = tbSize.Text = tbDonGia.Text = tbTenHang.Text = tbTheLoai.Text = tbMauSac.Text = "";
            tbThanhTien.Text = "";


            nbrSoLuongBan.Value = 0;
            pictureAnh.Image = null;
            nbrSoLuongBan.Enabled = false;

            cbbMaChiTiet.Enabled = false;
            cbbMaChiTiet.Enabled = true;
        }
        //Button Đóng
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Sự kiện CellClick cho datagridview để đưa thông tin từ datagridview lên thông tin chi tiết
        private void dgvThongTin_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (CheckHuy == false && CheckCellClick == true)              //Khi đang ở trong chức năng Thêm
            {
                //Hiển thị button Hủy Chi Tiết
                cbbMaChiTiet.Text = dgvThongTin.CurrentRow.Cells[0].Value.ToString();
                nbrSoLuongBan.Value = int.Parse(dgvThongTin.CurrentRow.Cells[6].Value.ToString());

                btnLuuChiTiet.Enabled = btnHuyChiTiet.Enabled = true;
                CheckLuuChiTiet = true;

                cbbMaChiTiet.Enabled = false;
                cbbMaChiTiet.Enabled = true;
                cbbMaChiTiet.Enabled = false;

            }
            else                          //Khi đang ở trong chức năng Tìm kiếm
            {
                //Hiển thị button Hủy Chi Tiết
                cbbMaChiTiet.Text = dgvThongTin.CurrentRow.Cells[0].Value.ToString();
                nbrSoLuongBan.Value = int.Parse(dgvThongTin.CurrentRow.Cells[6].Value.ToString());

                btnLuuChiTiet.Enabled = btnHuyChiTiet.Enabled = false;
                CheckLuuChiTiet = true;
                nbrSoLuongBan.Enabled = false;

                cbbMaChiTiet.Enabled = false;
                cbbMaChiTiet.Enabled = true;
                cbbMaChiTiet.Enabled = false;

            }
        }

        //Button Hủy Chi Tiết
        private void btnHuyChiTiet_Click(object sender, EventArgs e)
        {
            //Đang ở chức năng sửa, đổi CheckLuuChiTiet = false để quay lại chức năng Thêm
            CheckLuuChiTiet = false;
            //Cho Text bằng rỗng
            ChiTietText();

            nbrSoLuongBan.Value = 0;

            btnHuyChiTiet.Enabled = false;
        }
        //Double Click - Xóa chi tiết sản phẩm
        private void dgvThongTin_DoubleClick(object sender, EventArgs e)
        {
            if (cbbTimKiem.Text == "")
            {
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                MessageGuna.Text = "Bạn có muốn xóa không ?";
                if (MessageGuna.Show() == DialogResult.Yes)
                {
                    string sql = "Delete from ChiTietHDB " +
                        " where MaChiTietSP = N'" + cbbMaChiTiet.Text + "' AND MaHDB = N'" + tbMaHD.Text + "'";
                    access.UpdateData(sql);

                    //Hiển thị MessageGuna
                    MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MessageGuna.Text = "Xóa thành công";
                    MessageGuna.Show();

                    btnHuyChiTiet_Click(sender, e);

                    ShowTable(tbMaHD.Text);

                    if (dgvThongTin.Rows.Count == 0)
                    {
                        btnLuu.Enabled = false;
                    }

                    TongTienHDB(tbMaHD.Text);
                }
            }
        }

        //Button Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            CheckVoucher = true;
            CheckCellClick = true;
            if (CheckHuy == false)       //Hủy hóa đơn khi đang trong chức năng Tạo hóa đơn
            {
                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                MessageGuna.Text = "Bạn có muốn hủy hóa đơn này không ?";
                if (MessageGuna.Show() == DialogResult.Yes)
                {
                    //Xóa HoaDonNhap
                    string sql = "Delete from HoaDonBan where MaHDB = N'" + tbMaHD.Text + "'";
                    access.UpdateData(sql);

                    //Fill combobox Voucher
                    common.FillCombobox(cbbVoucher, access.ReadData("Select * from Voucher"), "TenVoucher", "MaVoucher");
                    cbbVoucher.SelectedIndex = -1;


                    //Thông tin chung
                    tbMaHD.Text = "";
                    common.FillCombobox(cbbMaKH, access.ReadData("Select * from KhachHang"), "MaKH", "MaKH");
                    cbbMaKH.SelectedIndex = -1;

                    tbDiaChi.Text = tbDienThoai.Text = "";
                    //Đưa về Thêm chi tiết
                    btnThemChiTiet.Enabled = false;
                    tbTenKH.Text = "";
                    cbbMaKH.Enabled = false;
                    //Thông tin chi tiết
                    ChiTietText();
                    cbbMaChiTiet.Enabled = nbrSoLuongBan.Enabled = false;
                    //Datagridview Clear
                    dgvThongTin.DataSource = null;

                    //Chỉnh lại button tổng
                    btnThem.Enabled = true;
                    btnLuu.Enabled = btnHuy.Enabled = false;

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
            }
            else                 //Nếu đang tìm kiếm mà bấm HỦY thì kết thúc chức năng HỦY
            {
                HoaDonBan_Load(sender, e);
            }
            //Lưu xong tắt Voucher
            cbbVoucher.Enabled = false;

            //Reset text của Tiền
            tbTienBanDau.Text = tbTienVoucher.Text = tbTongTien.Text = "";
        }

        //Button Lưu Hóa đơn
        //Lưu lại thông tin của hóa đơn đang tạo
        private void btnLuu_Click(object sender, EventArgs e)
        {
            CheckVoucher = true;
            HoaDonBan_Load(sender, e);
            btnThem.Enabled = true;
            tbMaHD.Text = "";
            cbbMaChiTiet.Enabled = false;
            dgvThongTin.DataSource = null;
            
            //Bật tìm kiếm
            cbbTimKiem.Enabled = true;

            //Reset text của Tiền
            tbTienBanDau.Text = tbTienVoucher.Text = tbTongTien.Text = "";

        }

        //Combobox Voucher để áp dụng Voucher vào Tổng tiền của hóa đơn bán
        private void cbbVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cbbVoucher.SelectedIndex != -1 && CheckVoucher == false)
                {
                    string sql = "Select * from Voucher where MaVoucher = N'" + cbbVoucher.SelectedValue + "'";
                    DataTable dt_voucher = access.ReadData(sql);
                    int soluongvoucher = int.Parse(dt_voucher.Rows[0]["SoLuong"].ToString());
                    DateTime dt_ngaybatdau, dt_ngayketthuc, ngayhientai;
                    DateTime.TryParse(String.Format("{0:dd/MM/yyyy}", dt_voucher.Rows[0]["NgayBatDau"].ToString()), out dt_ngaybatdau);
                    DateTime.TryParse(String.Format("{0:dd/MM/yyyy}", dt_voucher.Rows[0]["NgayKetThuc"].ToString()), out dt_ngayketthuc);
                    ngayhientai = DateTime.Now;
                    //Kiểm tra xem Voucher có còn hay không (Số lượng)
                    if (soluongvoucher == 0)
                    {
                        MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                        MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        MessageGuna.Text = "Voucher này đã hết lượt sử dụng";
                        MessageGuna.Show();

                        tbTongTien.Text = tongtien.ToString();
                        tbTienBanDau.Text = tongtien.ToString();
                        tbTienVoucher.Text = "-0";
                    }
                    //Kiểm tra xem Voucher có còn hạn sử dụng không (Ngày bắt đầu - ngày kết thúc)
                    //Nếu ngày hiện tại < ngày bắt đầu tức là voucher chưa đến ngày được áp dụng
                    else if (ngayhientai < dt_ngaybatdau)
                    {
                        MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                        MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        MessageGuna.Text = "Voucher này chưa đến ngày áp dụng\nChỉ được áp dụng từ ngày " + dt_ngaybatdau.Day + "/" + dt_ngaybatdau.Month + "/" + dt_ngaybatdau.Year;
                        MessageGuna.Show();

                        tbTongTien.Text = tongtien.ToString();
                        tbTienBanDau.Text = tongtien.ToString();
                        tbTienVoucher.Text = "-0";
                    }
                    //Nếu ngày hiện tại > ngày kết thúc tức là voucher đã hết hạn
                    else if (ngayhientai > dt_ngayketthuc)
                    {
                        MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                        MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        MessageGuna.Text = "Voucher này đã hết hạn\nChỉ được áp dụng đến ngày " + dt_ngayketthuc.Day + "/" + dt_ngayketthuc.Month + "/" + dt_ngayketthuc.Year;
                        MessageGuna.Show();

                        tbTongTien.Text = tongtien.ToString();
                        tbTienBanDau.Text = tongtien.ToString();
                        tbTienVoucher.Text = "-0";
                    }
                    else
                    {
                        string update = "Update HoaDonBan set MaVoucher = N'" + cbbVoucher.SelectedValue + "' where MaHDB = N'" + tbMaHD.Text + "'";
                        access.UpdateData(update);
                        int phantram = 0;
                        if (dt_voucher.Rows.Count > 0)
                        {
                            phantram = int.Parse(dt_voucher.Rows[0]["PhanTram"].ToString());
                        }

                        //Hiển thị tiền ở góc phải
                        tbTongTien.Text = (tongtien - (tongtien * phantram / 100)).ToString();
                        tbTienBanDau.Text = tongtien.ToString();
                        tbTienVoucher.Text = "-" + (tongtien * phantram / 100).ToString();

                        //Thông báo áp dụng thành công
                        MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        MessageGuna.Text = "Voucher này đã được áp dụng";
                        MessageGuna.Show();

                        //Update TongTienHDB
                        string updateTien = "Update HoaDonBan set TongTienHDB = '"+double.Parse(tbTongTien.Text)+ "' where MaHDB = N'" + tbMaHD.Text + "'";
                        access.UpdateData(updateTien);

                    }

                }

                
            }
            catch { }

            

        }

        //Tìm Kiếm
        private void cbbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CheckHuy = true;
                CheckCellClick = false;

                string ThongTinChung = "select HoaDonBan.MaHDB, NhanVien.MaNV, TenNV, NgayBan, KhachHang.MaKH, TenKH, KhachHang.DienThoai, KhachHang.DiaChi  " +
                " from NhanVien, HoaDonBan, KhachHang" +
                " where NhanVien.MaNV = HoaDonBan.MaNV AND HoaDonBan.MaKH = KhachHang.MaKH " +
                " AND HoaDonBan.MaHDB = N'" + cbbTimKiem.Text + "'";
                DataTable dtChung = access.ReadData(ThongTinChung);
                //Điền thông tin lên Thông Tin Chung
                tbMaHD.Text = dtChung.Rows[0]["MaHDB"].ToString();
                cbbMaKH.Text = dtChung.Rows[0]["MaKH"].ToString();
                tbTenKH.Text = dtChung.Rows[0]["TenKH"].ToString();
                dtNgayBan.Text = dtChung.Rows[0]["NgayBan"].ToString();

                //Chỉnh sửa button trong Thông Tin Chung
                btnThemChiTiet.Enabled = false;
                cbbMaKH.Enabled = true;
                cbbMaKH.Enabled = false;

                //Chỉnh sửa Button tổng thể
                btnThem.Enabled = false;
                btnHuy.Enabled = btnIn.Enabled = true;

                //Button Hủy chi tiết
                btnHuyChiTiet.Enabled = false;

                //Điền thông tin Chi Tiết
                ShowTable(tbMaHD.Text);

                //Tổng tiền của hóa đơn đang tìm
                string TongTien = "select * from HoaDonBan where MaHDB = N'" + tbMaHD.Text + "'";
                DataTable dtTien = access.ReadData(TongTien);
                double tongtien = double.Parse(dtTien.Rows[0]["TongTienHDB"].ToString());

                //Tính Tiền
                tbTongTien.Text = dtTien.Rows[0]["TongTienHDB"].ToString();
                //Lấy mã voucher để truy xuất ra Phần Trăm
                string mavoucher = dtTien.Rows[0]["MaVoucher"].ToString();
                string layphantram = "Select * from Voucher where MaVoucher = N'"+mavoucher+"'";
                DataTable dt_layphantram = access.ReadData(layphantram);
                int phantram;
                if(dt_layphantram.Rows.Count > 0)
                {
                    phantram = int.Parse(dt_layphantram.Rows[0]["PhanTram"].ToString());
                }
                else
                {
                    phantram = 0;
                }

                TinhTien(tongtien, phantram);

                //Voucher đã được áp dụng
                cbbVoucher.Enabled = false;
                

            }
            catch { }
        }

        //Xóa hóa đơn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            MessageGuna.Text = "Bạn có muốn xóa hóa đơn này không ?";
            if (MessageGuna.Show() == DialogResult.Yes)
            {
                string Xoa = "Delete from HoaDonBan where MaHDB = N'" + cbbTimKiem.Text + "'";
                access.UpdateData(Xoa);

                //Hiển thị MessageGuna
                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                MessageGuna.Text = "Xóa thành công";
                MessageGuna.Show();

                HoaDonBan_Load(sender, e);
            }
        }

        public void TinhTien(double phaitra, int phantram)
        {
            if(phantram > 0)
            {
                double tongtien = phaitra / (1 - (phantram * 1.0 / 100.0));
                double giamvoucher = tongtien * phantram * 1.0 / 100.0;
                tbTienBanDau.Text = tongtien.ToString();
                tbTienVoucher.Text = "-" + giamvoucher.ToString();
            }
            else
            {
                tbTienBanDau.Text = phaitra.ToString();
                tbTienVoucher.Text = "-0";
            }

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
            xuatexel = new XuatExel(dgvThongTin, "Hóa Đơn Bán", tbMaHD.Text, tbTenNV.Text, tbTenKH.Text, tbTienVoucher.Text, tbTienBanDau.Text, tbTongTien.Text, dtNgayBan.Value.ToString("dd/MM/yyyy"));
        }
    }
}
