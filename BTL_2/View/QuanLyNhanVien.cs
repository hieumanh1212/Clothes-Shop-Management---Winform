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
using Guna.UI2.WinForms;
using System.Text.RegularExpressions;
using Xuat_Exel;

namespace DuyThien_BTL.Childen
{
    public partial class QuanLyNhanVien : Form
    {
        AccessData access = new AccessData();
        CommondFunction common = new CommondFunction();
        XuatExel xuatexel;
        public bool checkLuu = false;

        //fileAnh dùng để lưu tên của Ảnh
        string fileAnh = "";
        public QuanLyNhanVien()
        {
            InitializeComponent();
            //panelGian.Visible = false;
        }
        //Button Đóng
        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        //Chỉ cho số điện thoại điền số
        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        //Show Table
        void ShowTable()
        {
            common.FillCombobox(cbbMaNhanVienTK, access.ReadData("Select * from NhanVien"), "MaNV", "MaNV");
            cbbMaNhanVienTK.SelectedValue = "";
            cbbMaNhanVienTK.Items.IndexOf(-1);

            string sql = "Select NhanVien.MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, DienThoai, TenChucVu, Anh, TenDangNhap, MatKhau " +
                " from NhanVien inner join tblUser on NhanVien.MaNV = tblUser.MaNV inner join ChucVu on NhanVien.MaChuCVu = ChucVu.MaChucVu";
            dgvThongTinNhanVien.DataSource = access.ReadData(sql);


        }


        //Gán EnableTrue
        void EnableTrue(bool check)
        {
            foreach (Control ctrl in guna2GroupBox1.Controls)
                ctrl.Enabled = check;
            tbUsername.Enabled = tbMaNhanVien.Enabled = false;
        }
        //Form Load
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {

            //Fill ChucVu
            DataTable dtChucVu = access.ReadData("Select * from ChucVu");
            common.FillCombobox(cbbChucVu, dtChucVu, "TenChucVu", "MaChucVu");

            cbbChucVu.SelectedValue = "";


            //Fill Tìm kiếm
            //common.FillCombobox(cbbMaNhanVienTK, access.ReadData("Select * from NhanVien"), "MaNV", "MaNV");
            //cbbMaNhanVienTK.SelectedValue = "";
            //cbbMaNhanVienTK.Items.IndexOf(-1);

            //Hiển thị ra datagridview
            ShowTable();
            btnInDS.Enabled = true;
            //HIển thị tiêu đề Cột
            dgvThongTinNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvThongTinNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvThongTinNhanVien.Columns[2].HeaderText = "Giới Tính";
            dgvThongTinNhanVien.Columns[3].HeaderText = "Ngày Sinh";
            dgvThongTinNhanVien.Columns[4].HeaderText = "Địa Chỉ";
            dgvThongTinNhanVien.Columns[5].HeaderText = "Điện Thoại";
            dgvThongTinNhanVien.Columns[6].HeaderText = "Chức Vụ";
            dgvThongTinNhanVien.Columns[7].HeaderText = "Ảnh";
            dgvThongTinNhanVien.Columns[8].HeaderText = "Tên đăng nhập";
            dgvThongTinNhanVien.Columns[9].HeaderText = "Mật Khẩu";


        }

        //Button Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            tbUsername.Text = tbMaNhanVien.Text = common.AutoCode("NhanVien", "MaNV", "NV");
            btnThem.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;

            //Gán lại các text có enable = true
            EnableTrue(true);

            //Nếu đang ở chức năng Thêm thì checkLuu = true
            checkLuu = true;

            //Không được chọn datagridview
            dgvThongTinNhanVien.Enabled = false;

            //Tắt chức năng In danh sách
            btnInDS.Enabled = false;

            //Tắt chức năng tìm kiếm
            cbbMaNhanVienTK.Enabled = false;
        }
        //Hàm kiểm tra thông tin đầu vào xem chuẩn không
        bool CheckNhap()
        {
            if(tbPassword.Text.Trim() == "")
            {
                MessageOK.Text = "Bạn phải nhập Mật Khẩu của nhân viên";
                MessageOK.Show();
                tbPassword.Focus();
                return false;
            }
            else if(rdbNam.Checked == false && rdbNu.Checked == false)
            {
                MessageOK.Text = "Bạn phải chọn giới tính của nhân viên";
                MessageOK.Show();
                return false;
            }
            else if(tbDiaChi.Text.Trim() == "")
            {
                MessageOK.Text = "Bạn phải nhập địa chỉ của nhân viên";
                tbDiaChi.Focus();
                MessageOK.Show();
                return false;
            }
            
            else if(cbbChucVu.Text == "")
            {
                MessageOK.Text = "Bạn phải chọn chức vụ của nhân viên";
                MessageOK.Show();
                return false;
            }
            
            else if(ptbAnhNhanVien.Image == null)
            {
                MessageOK.Text = "Bạn phải chọn ảnh của nhân viên";
                MessageOK.Show();
                return false;
            }
            if (tbTenNV.Text.Trim() == "" || tbTenNV.Text.Trim() != "")
            {
                Regex reg1 = new Regex("^([a-vxyỳọáầảấờễàạằệếýộậốũứĩõúữịỗìềểẩớặòùồợãụủíỹắẫựỉỏừỷởóéửỵẳẹèẽổẵẻỡơôưăêâđ]+)((\\s{1}[a-vxyỳọáầảấờễàạằệếýộậốũứĩõúữịỗìềểẩớặòùồợãụủíỹắẫựỉỏừỷởóéửỵẳẹèẽổẵẻỡơôưăêâđ]+){1,})$");
                if (reg1.IsMatch(tbTenNV.Text.ToLower()) == false)
                {
                    MessageOK.Text = "Bạn phải nhập đúng định dạng Tên nhân viên";
                    tbTenNV.Focus();
                    MessageOK.Show();
                    return false;
                }
            }

            if (txtSdt.Text.Trim() == "" || txtSdt.Text.Trim() != "")
            {
                Regex reg2 = new Regex("(((\\+|)84)|0)(3|5|7|8|9)+([0-9]{8})\\b");
                if (reg2.IsMatch(txtSdt.Text) == false)
                {
                    MessageOK.Text = "Bạn phải nhập đúng định dạng số điện thoại";
                    txtSdt.Focus();
                    MessageOK.Show();
                    return false;
                }
            }

            return true;
        }
        //Button Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(checkLuu)    //Đang ở chức năng Thêm nhân viên
            {
                access.UpdateData("Select * into BangMoiNV_Insert from NhanVien");
                access.UpdateData("Delete from BangMoiNV_Insert where MaNV = N'" + tbMaNhanVien.Text + "'");

                int check = 0; // ktra so dien thoai trong csdl chua
                DataTable dt = access.ReadData("Select * from BangMoiNV_Insert");
                foreach (DataRow dr in dt.Rows)
                {
                    if (txtSdt.Text == dr["DienThoai"].ToString())
                    {
                        MessageOK.Buttons = MessageDialogButtons.OK;
                        MessageOK.Icon = MessageDialogIcon.Warning;
                        MessageOK.Text = "Đã tồn tại Số điện thoại này";
                        check = 1;
                        MessageOK.Show();
                        try
                        {
                            access.UpdateData("Drop table BangMoiNV_Insert");
                        }
                        catch { }
                        return;
                    }
                }
                if (check == 0)
                {
                    if (!CheckNhap())
                    {
                        try
                        {
                            access.UpdateData("Drop table BangMoiNV_Insert");
                        }
                        catch { }
                    }
                    else
                    {
                        //Sex để lấy giới tính của nhân viên
                        string sex = "";
                        if (rdbNam.Checked == true)
                            sex = "Nam";
                        if (rdbNu.Checked == true)
                            sex = "Nữ";
                        //Thêm vào bảng Nhân Viên
                        string sqlNhanVien = $"insert into NhanVien " +
                            $"values('{tbMaNhanVien.Text}', N'{tbTenNV.Text}'," +
                            $"N'{sex}', '{String.Format("{0:MM/dd/yyyy}", dtpNgaysinh.Value.ToString())}', N'{tbDiaChi.Text}'," +
                            $"'{txtSdt.Text}', N'{cbbChucVu.SelectedValue}', N'{fileAnh}')";
                        access.UpdateData(sqlNhanVien);

                        //Thêm vào bảng tblUser
                        String sqlUser = $"insert into tblUser " +
                            $"values('{tbMaNhanVien.Text}','{tbUsername.Text}','{tbPassword.Text}')";

                        access.UpdateData(sqlUser);

                        //Hiển thị lên datagridview
                        ShowTable();

                        //Cho phép chọn datagridview
                        dgvThongTinNhanVien.Enabled = true;

                        //Sau khi thêm thành công thì reset value
                        ResetValue();
                        MessageOK.Buttons = MessageDialogButtons.OK;
                        MessageOK.Icon = MessageDialogIcon.Information;
                        MessageOK.Text = "Thêm thành công !";
                        MessageOK.Show();

                        //Mở chức năng Tìm kiếm
                        cbbMaNhanVienTK.Enabled = true;

                        //Mở chức năng In danh sách
                        btnInDS.Enabled = true;

                        EnableTrue(false);
                        common.FillCombobox(cbbChucVu, access.ReadData("Select * from ChucVu"), "TenChucVu", "MaChucVu");
                        cbbChucVu.SelectedValue = "";
                        cbbChucVu.Items.IndexOf(-1);

                        try
                        {
                            access.UpdateData("Drop table BangMoiNV_Insert");
                        }
                        catch { }
                    }
                }
            }
            else            // Đang ở chức năng Sửa
            {
                if (!CheckNhap()) 
                { 
                }
                else
                {
                    try
                    {
                        access.UpdateData("Drop table BangMoiNV");
                    }
                    catch { }

                    access.UpdateData("Select * into BangMoiNV from NhanVien");
                    access.UpdateData("Delete from BangMoiNV where MaNV = N'" + tbMaNhanVien.Text + "'");

                    int check = 0; // ktra so dien thoai trong csdl chua
                    DataTable dt = access.ReadData("Select * from BangMoiNV");
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (txtSdt.Text == dr["DienThoai"].ToString())
                        {
                            MessageOK.Buttons = MessageDialogButtons.OK;
                            MessageOK.Icon = MessageDialogIcon.Warning;
                            MessageOK.Text = "Đã tồn tại Số điện thoại này";
                            check = 1;
                            MessageOK.Show();
                            try
                            {
                                access.UpdateData("Drop table BangMoiNV");
                            }
                            catch { }
                            return;
                        }
                    }
                    if (check == 0)
                    {
                        //Sex để lấy giới tính của nhân viên
                        string sex = "";
                        if (rdbNam.Checked == true)
                            sex = "Nam";
                        if (rdbNu.Checked == true)
                            sex = "Nữ";
                        //Sửa thông tin nhân viên
                        string sql = $"update NhanVien set " +
                            $"TenNV = N'{tbTenNV.Text}' , GioiTinh = N'{sex}', " +
                            $"NgaySinh = '{String.Format("{0:MM/dd/yyyy}", dtpNgaysinh.Value.ToString())}', DiaChi = N'{tbDiaChi.Text}', " +
                            $"DienThoai = '{txtSdt.Text}', MaChucVu = N'{cbbChucVu.SelectedValue}', " +
                            $"Anh = N'{fileAnh}' " +
                            $"from NhanVien,tblUser " +
                            $"where NhanVien.MaNV = '{tbUsername.Text}' and NhanVien.MaNV = tblUser.MaNV";
                        access.UpdateData(sql);
                        sql = $"update tblUser set " +
                            $"MatKhau = '{tbPassword.Text}' " +
                            $"from NhanVien,tblUser " +
                            $"where tblUser.MaNV = N'{tbMaNhanVien.Text}' and NhanVien.MaNV = tblUser.MaNV";
                        access.UpdateData(sql);

                        //Hiển thị lên datagridview
                        ShowTable();

                        //Sau khi hoàn tất Lưu thì quay trở lại ban đầu
                        btnThem.Enabled = true;
                        btnLuu.Enabled = btnHuy.Enabled = false;
                        ResetValue();

                        MessageOK.Buttons = MessageDialogButtons.OK;
                        MessageOK.Icon = MessageDialogIcon.Information;
                        MessageOK.Text = "Sửa thành công !";
                        MessageOK.Show();

                        EnableTrue(false);
                        common.FillCombobox(cbbChucVu, access.ReadData("Select * from ChucVu"), "TenChucVu", "MaChucVu");
                        cbbChucVu.SelectedValue = "";
                        cbbChucVu.Items.IndexOf(-1);

                        //Mở chưc năng In danh sách
                        btnInDS.Enabled = true;

                        //Mở chức năng tìm kiếm
                        cbbMaNhanVienTK.Enabled = true;
                        try
                        {
                            access.UpdateData("Drop table BangMoiNV");
                        }
                        catch { }
                    }
                }
                  
            }

        }
        //Button Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            EnableTrue(false);
            btnThem.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;
            rdbNam.Checked = rdbNu.Checked = false;

            cbbChucVu.SelectedValue = "";

            ////Cho phép chọn datagridview
            dgvThongTinNhanVien.Enabled = true;

            //Reset các giá trị của text về null
            ResetValue();

            //Mở chức năng tìm kiếm
            cbbMaNhanVienTK.Enabled = true;

            ShowTable();
            //Mở chức năng In danh sách
            btnInDS.Enabled = true;
            common.FillCombobox(cbbChucVu, access.ReadData("Select * from ChucVu"), "TenChucVu", "MaChucVu");
            cbbChucVu.SelectedValue = "";
            cbbChucVu.Items.IndexOf(-1);
        }
        //Button Ảnh
        private void btnAnh_Click(object sender, EventArgs e)
        {
            string[] image;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPEG Images|*.jpg|PNG Images|*.png|All files|*.*";
            openFile.FilterIndex = 1;
            openFile.InitialDirectory = Application.StartupPath + "\\Images\\";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ptbAnhNhanVien.Image = Image.FromFile(openFile.FileName);
                image = openFile.FileName.ToString().Split('\\');
                fileAnh = image[image.Length - 1];

            }
        }

        //Cellclick - Khi ấn vào dòng của Datagridview thì sẽ hiển thị thông tin lên phía trên
        private void dgvThongTinNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            checkLuu = false;
            tbMaNhanVien.Text = dgvThongTinNhanVien.CurrentRow.Cells[0].Value.ToString();
            tbUsername.Text = tbMaNhanVien.Text;
            tbTenNV.Text = dgvThongTinNhanVien.CurrentRow.Cells[1].Value.ToString();
            if (dgvThongTinNhanVien.CurrentRow.Cells[2].Value.ToString() == "Nam")
                rdbNam.Checked = true;
            else
                rdbNu.Checked = true;

            dtpNgaysinh.Value = (DateTime)dgvThongTinNhanVien.CurrentRow.Cells[3].Value;
            tbDiaChi.Text = dgvThongTinNhanVien.CurrentRow.Cells[4].Value.ToString();
            txtSdt.Text = dgvThongTinNhanVien.CurrentRow.Cells[5].Value.ToString();
            cbbChucVu.Text = dgvThongTinNhanVien.CurrentRow.Cells[6].Value.ToString();
            if (dgvThongTinNhanVien.CurrentRow.Cells[7].Value.ToString() != "")
                ptbAnhNhanVien.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + dgvThongTinNhanVien.CurrentRow.Cells[7].Value.ToString());
            else
                ptbAnhNhanVien.Image = null;
            tbPassword.Text = dgvThongTinNhanVien.CurrentRow.Cells[9].Value.ToString();

            EnableTrue(true);

            btnThem.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;

            //Tắt chức năng In danh sách
            //btnInDS.Enabled = false;

            //Tắt chức năng tìm kiếm
            cbbMaNhanVienTK.Enabled = false;

        }

        //Reset các text về null
        void ResetValue()
        {
            foreach (Control control in this.guna2GroupBox1.Controls)
            {
                if (control is Guna2TextBox)
                    ((Guna2TextBox)control).Text = "";
            }
            cbbChucVu.Text = "";
            ptbAnhNhanVien.Image = null;
            rdbNam.Checked = false;
            rdbNu.Checked = false;
        }

        //Xóa Nhân viên bằng cách nhấn đúp vào hàng
        private void dgvThongTinNhanVien_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int check = 0;
                MessageOK.Buttons = MessageDialogButtons.YesNo;
                MessageOK.Icon = MessageDialogIcon.Question;
                MessageOK.Text = $"Bạn muốn xóa nhân viên này không ?";
                if (MessageOK.Show() == DialogResult.Yes)
                {
                    string sqlTonTaiHDB = $"select * from HoaDonBan where MaNV = '{tbMaNhanVien.Text}'";
                    if (access.ReadData(sqlTonTaiHDB).Rows.Count > 0)
                    {
                        check = 1;

                    }
                    string sqlTonTaiHDN = $"select * from HoaDonNhap where MaNV = '{tbMaNhanVien.Text}'";
                    if (access.ReadData(sqlTonTaiHDB).Rows.Count > 0)
                    {
                        check = 1;
                    }
                    if(check == 1)
                    {
                        MessageOK.Buttons = MessageDialogButtons.OK;
                        MessageOK.Icon = MessageDialogIcon.Warning;
                        MessageOK.Text = "Nhân viên vẫn còn trong hóa đơn\n Bạn không thể xóa nhân viên này !";
                        MessageOK.Show();
                    }
                    if (check == 0)
                    {
                        string sql = $"delete tblUser " +
                                 $"from NhanVien, tblUser " +
                                 $"where NhanVien.MaNV = '{tbMaNhanVien.Text}' and NhanVien.MaNV = tblUser.MaNV";
                        access.UpdateData(sql);
                        sql = $"delete NhanVien " +
                              $"from NhanVien " +
                              $"where NhanVien.MaNV = '{tbMaNhanVien.Text}'";
                        access.UpdateData(sql);


                        EnableTrue(false);
                        common.FillCombobox(cbbChucVu, access.ReadData("Select * from ChucVu"), "TenChucVu", "MaChucVu");
                        cbbChucVu.SelectedValue = "";
                        cbbChucVu.Items.IndexOf(-1);

                        MessageOK.Buttons = MessageDialogButtons.OK;
                        MessageOK.Icon = MessageDialogIcon.Information;
                        MessageOK.Text = "Xóa thành công !";
                        MessageOK.Show();


                        common.FillCombobox(cbbMaNhanVienTK, access.ReadData("Select * from NhanVien"), "MaNV", "MaNV");
                        cbbMaNhanVienTK.SelectedValue = "";
                        cbbMaNhanVienTK.Items.IndexOf(-1);
                        cbbMaNhanVienTK.Enabled = true;
                        ShowTable();
                    }
                }
                else
                {
                    btnHuy_Click(null, null);
                }
            }
            catch
            {
                MessageOK.Buttons = MessageDialogButtons.OK;
                MessageOK.Icon = MessageDialogIcon.Warning;
                MessageOK.Text = "Nhân viên vẫn còn trong hóa đơn\n Bạn không thể xóa nhân viên này !";
                MessageOK.Show();
            }
        }

        //Tìm Kiếm
        private void cbbMaNhanVienTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Tắt chức năng in danh sách
                //btnInDS.Enabled = false;

                if(cbbMaNhanVienTK.SelectedIndex == -1)
                {
                    btnThem.Enabled = true;
                    btnLuu.Enabled = btnHuy.Enabled = false;
                }
                else
                {
                    btnThem.Enabled = btnLuu.Enabled = false;
                    btnHuy.Enabled = true;
                    string sql = $"Select NhanVien.MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, DienThoai, TenChucVu, Anh, TenDangNhap, MatKhau " +
                    " from NhanVien inner join tblUser on NhanVien.MaNV = tblUser.MaNV inner join ChucVu on NhanVien.MaChuCVu = ChucVu.MaChucVu " +
                    $" where NhanVien.MaNV = '{cbbMaNhanVienTK.Text}'";
                    DataTable dt = access.ReadData(sql);
                    dgvThongTinNhanVien.DataSource = dt;
                    ResetValue();
                }
                
            }
            catch { }
        }

        //Tên nhân viên không được có số
        private void tbTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {

            if (dgvThongTinNhanVien.RowCount <= 0)
            {
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn không thể xuất khi Không có dòng dữ liệu nào !";
                MessageGuna.Show();
                return;
            }


            dgvThongTinNhanVien.Columns.RemoveAt(dgvThongTinNhanVien.ColumnCount - 1);
            dgvThongTinNhanVien.Columns.RemoveAt(dgvThongTinNhanVien.ColumnCount - 1);
            dgvThongTinNhanVien.Columns.RemoveAt(dgvThongTinNhanVien.ColumnCount - 1);
            xuatexel = new XuatExel(dgvThongTinNhanVien, "Danh Sánh Nhân Viên", 0);

            ShowTable();
            dgvThongTinNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvThongTinNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvThongTinNhanVien.Columns[2].HeaderText = "Giới Tính";
            dgvThongTinNhanVien.Columns[3].HeaderText = "Ngày Sinh";
            dgvThongTinNhanVien.Columns[4].HeaderText = "Địa Chỉ";
            dgvThongTinNhanVien.Columns[5].HeaderText = "Điện Thoại";
            dgvThongTinNhanVien.Columns[6].HeaderText = "Chức Vụ";
            dgvThongTinNhanVien.Columns[7].HeaderText = "Ảnh";
            dgvThongTinNhanVien.Columns[8].HeaderText = "Tên đăng nhập";
            dgvThongTinNhanVien.Columns[9].HeaderText = "Mật Khẩu";
        }
    }
}
