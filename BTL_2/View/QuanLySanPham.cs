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
    public partial class QuanLySanPham : Form
    {
        AccessData access = new AccessData();
        CommondFunction common = new CommondFunction();
        XuatExel xuatexel;
        bool CheckLuuSP = false;   //Nếu = false thì là Thêm, = true thì là sửa
        bool CheckLuuChiTiet = false; //Nếu = false thì là Thêm, = true thì là sửa
        //Nếu CheckReset = false thì load lại datagridview Sản Phẩm. Nếu = true thì load cả Sản phẩm và chi tiết sản phẩm
        bool CheckReset = false;
        string fileAnh = "";    // Để lưu tên của ảnh
        string MaSP = "";
        public QuanLySanPham()
        {
            InitializeComponent();

        }
        //Enabel Text của SanPham
        public void EnableTextSanPham(bool check)
        {
            txtTenSP.Enabled = cbbTheLoai.Enabled = cbbChatLieu.Enabled  = btnAnh.Enabled = check;
        }
        //EnableButton của SanPham
        public void EnableButtonSanPham(bool check1, bool check2)
        {
            btnThemSP.Enabled = check1;
            btnLuuSP.Enabled = btnHuySP.Enabled = check2;
        }
        //Load
        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            
            //Tắt ChiTietSanPham
            panelChiTiet.Enabled = false;

            //Tắt Các Text của Sản phẩm
            EnableTextSanPham(false);

            //Ảnh là rỗng
            pictureAnh.Image = null;

            //Fill combobox TheLoai
            common.FillCombobox(cbbTheLoai, access.ReadData("Select * from TheLoai"), "TenTheLoai", "MaTheLoai");
            cbbTheLoai.SelectedIndex = -1;

            //Fill combobox ChatLieu
            common.FillCombobox(cbbChatLieu, access.ReadData("Select * from ChatLieu"), "TenChatLieu", "MaChatLieu");
            cbbChatLieu.SelectedIndex = -1;


            //Fill combobox Tìm Kiếm cho sản phẩm
            common.FillCombobox(cbbTimKiemMaSP, access.ReadData("Select * from SanPham"), "MaSP", "MaSP");
            cbbTimKiemMaSP.SelectedIndex = -1;

            //Hiển thị Thêm SP, tắt Lưu và Hủy
            EnableButtonSanPham(true, false);

            //Show Table
            ShowTable();


            //Sửa tiêu đề cột cho dgvSanPham
            dgvSanPham.Columns[0].HeaderText = "Mã SP";
            dgvSanPham.Columns[1].HeaderText = "Tên SP";
            dgvSanPham.Columns[2].HeaderText = "Chất Liệu";
            dgvSanPham.Columns[3].HeaderText = "Thể Loại";
            dgvSanPham.Columns[4].HeaderText = "Ảnh";

        }
        //Show Table
        public void ShowTable()
        {
            string sql = "select * from SanPham";
            dgvSanPham.DataSource = access.ReadData(sql);
        }

        //Button Thêm Sản phẩm
        private void btnThemSP_Click_1(object sender, EventArgs e)
        {
            CheckLuuSP = false;

            //Đổi Enable Button
            EnableButtonSanPham(false, true);

            //Tắt chức năng tìm kiếm
            cbbTimKiemMaSP.Enabled = false;

            //Hiển thị Text
            EnableTextSanPham(true);

            //Tắt datagridview
            dgvSanPham.Enabled = false;

            //Tự sinh ra Mã sản phẩm
            txtMaSP.Text = common.AutoCode("SanPham", "MaSP", "SP");
        }

        //Button Hủy sản phẩm
        private void btnHuySP_Click_1(object sender, EventArgs e)
        {
            //Mở lại chức năng tìm kiếm
            cbbTimKiemMaSP.Enabled = true;
            CheckReset = false;

            //Tắt text
            EnableTextSanPham(false);

            //Reset Text
            ResetText();

            //Mở datagridview
            dgvSanPham.Enabled = true;

            //Đóng ChiTietSanPham
            panelChiTiet.Enabled = false;

            //Tắt dgv ChiTiet
            dgvChiTiet.DataSource = null;

            //Tắt text bên chi tiết
            btnHuyChiTiet_Click_1(sender, e);

            //Fill combobox Tìm Kiếm cho sản phẩm
            common.FillCombobox(cbbTimKiemMaSP, access.ReadData("Select * from SanPham"), "MaSP", "MaSP");
            cbbTimKiemMaSP.SelectedIndex = -1;

            //Đổi Enable Button
            EnableButtonSanPham(true, false);

            //Show Table
            ShowTable();
            //Sửa tiêu đề cột cho dgvSanPham
            dgvSanPham.Columns[0].HeaderText = "Mã SP";
            dgvSanPham.Columns[1].HeaderText = "Tên SP";
            dgvSanPham.Columns[2].HeaderText = "Chất Liệu";
            dgvSanPham.Columns[3].HeaderText = "Thể Loại";
            dgvSanPham.Columns[4].HeaderText = "Ảnh";

            //Dgv ChiTietSanPham
            dgvChiTiet.DataSource = null;
        }

        public void ResetText()
        {
            txtMaSP.Text = txtTenSP.Text = "";
            //Fill lại combobox
            //Fill combobox TheLoai
            common.FillCombobox(cbbTheLoai, access.ReadData("Select * from TheLoai"), "TenTheLoai", "MaTheLoai");
            cbbTheLoai.SelectedIndex = -1;

            //Fill combobox ChatLieu
            common.FillCombobox(cbbChatLieu, access.ReadData("Select * from ChatLieu"), "TenChatLieu", "MaChatLieu");
            cbbChatLieu.SelectedIndex = -1;

            //Ảnh
            pictureAnh.Image = null;
        }

        //Đóng Form
        private void btnDong_Click_1(object sender, EventArgs e)
        {
            MessageGuna.Icon = MessageDialogIcon.Question;
            MessageGuna.Buttons = MessageDialogButtons.YesNo;
            MessageGuna.Text = "Bạn có muốn thoát không ?";
            if(MessageGuna.Show() == DialogResult.Yes)
            {
                this.Close();
            }
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
                pictureAnh.Image = Image.FromFile(openFile.FileName);
                image = openFile.FileName.ToString().Split('\\');
                fileAnh = image[image.Length - 1];

            }
        }

        //Lưu sản phẩm
        private void btnLuuSP_Click_1(object sender, EventArgs e)
        {
            if(CheckLuuSP == false)     //Lưu
            {
                if(!CheckNhap()) { }
                else
                {
                    string sql = "Insert SanPham values (N'"+txtMaSP.Text+"', N'"+txtTenSP.Text+"', N'"+cbbChatLieu.SelectedValue+"', N'"+cbbTheLoai.SelectedValue+"', N'"+fileAnh+"')";
                    access.UpdateData(sql);
                    MessageGuna.Buttons = MessageDialogButtons.OK;
                    MessageGuna.Icon = MessageDialogIcon.Information;
                    MessageGuna.Text = "Thêm thành công";
                    MessageGuna.Show();

                    btnHuySP_Click_1(sender, e);

                    ShowTable();
                }
            }
            else      //Sửa
            {
                if (!CheckNhap()) { }
                else
                {
                    string sql = "Update SanPham set TenSP = N'"+txtTenSP.Text+"', MaChatLieu = N'"+cbbChatLieu.SelectedValue+"', MaTheLoai = N'"+cbbTheLoai.SelectedValue+"', Anh = N'"+fileAnh+"' " +
                        " where MaSP = N'"+txtMaSP.Text+"'";
                    access.UpdateData(sql);
                    MessageGuna.Buttons = MessageDialogButtons.OK;
                    MessageGuna.Icon = MessageDialogIcon.Information;
                    MessageGuna.Text = "Sửa thành công";
                    MessageGuna.Show();

                    btnHuySP_Click_1(sender, e);

                    ShowTable();
                }
            }
        }
        //Check Nhập
        bool CheckNhap()
        {
            if(txtTenSP.Text.Trim() == "")
            {
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn phải nhập tên sản phẩm";
                MessageGuna.Show();
                txtTenSP.Focus();
                return false;
            }
            else if(cbbTheLoai.Text == "")
            {
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn phải chọn thể loại";
                MessageGuna.Show();
                return false;
            }
            else if(cbbChatLieu.Text == "")
            {
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn phải chọn chất liệu";
                MessageGuna.Show();
                return false;
            }
            else if(pictureAnh.Image == null)
            {
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn phải chọn ảnh của sản phẩm";
                MessageGuna.Show();
                return false;
            }
            return true;
        }
        //Sự kiện CellClick
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Vào chức năng sửa
            
            CheckLuuSP = true;
            CheckReset = true;

            txtMaSP.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
            txtTenSP.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
            cbbChatLieu.SelectedValue = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
            cbbTheLoai.SelectedValue = dgvSanPham.CurrentRow.Cells[3].Value.ToString();
            if (dgvSanPham.CurrentRow.Cells[4].Value.ToString() != "")
                pictureAnh.Image = Image.FromFile(Application.StartupPath + "\\Images\\" + dgvSanPham.CurrentRow.Cells[4].Value.ToString());
            else
                pictureAnh.Image = null;

            EnableButtonSanPham(false, true);
            EnableTextSanPham(true);
            cbbTimKiemMaSP.Enabled = false;
            cbbChatLieu.Enabled = cbbTheLoai.Enabled = false;
            cbbChatLieu.Enabled = cbbTheLoai.Enabled = true;

            //Chi Tiết sản phẩm
            MaSP = txtMaSP.Text;
            panelChiTiet.Enabled = true;

            //EnableButton
            EnableButtonChiTiet(true, false);

            //EnableText
            EnableTextChiTiet(false);

            //Show Table ChiTiet
            ShowTableChiTiet();
            //Sửa tiêu đề cột cho dgvSanPham
            dgvChiTiet.Columns[0].HeaderText = "Mã Chi Tiết";
            dgvChiTiet.Columns[1].HeaderText = "Size";
            dgvChiTiet.Columns[2].HeaderText = "Giá Nhập";
            dgvChiTiet.Columns[3].HeaderText = "Giá bán";
            dgvChiTiet.Columns[4].HeaderText = "Màu sắc";
            dgvChiTiet.Columns[5].HeaderText = "Số lượng";

        }

        //Enable Button ChiTiet
        public void EnableButtonChiTiet(bool check1, bool check2)
        {
            btnThemChiTiet.Enabled = check1;
            btnLuuChiTiet.Enabled = btnHuyChiTiet.Enabled = check2;
        }
        //Enable Text ChiTiet
        public void EnableTextChiTiet(bool check)
        {
            txtGiaNhap.Enabled = txtGiaBan.Enabled = check;
            cbbSize.Enabled = cbbMauSac.Enabled = check;
        }
        //Xóa sản phẩm
        private void dgvSanPham_DoubleClick(object sender, EventArgs e)
        {
            MessageGuna.Buttons = MessageDialogButtons.YesNo;
            MessageGuna.Icon = MessageDialogIcon.Question;
            MessageGuna.Text = "Bạn có muốn xóa sản phẩm này không ?";
            if(MessageGuna.Show() == DialogResult.Yes)
            {
                string sql = "Delete from ChiTietSanPham where MaSP = N'"+txtMaSP.Text+"' " +
                    "  Delete from SanPham where MaSP = N'"+txtMaSP.Text+"'";
                access.UpdateData(sql);

                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Information;
                MessageGuna.Text = "Xóa thành công";
                MessageGuna.Show();
            }

            btnHuySP_Click_1(sender, e);

            ShowTable();
        }

        //Chỉ cho giá nhập là số
        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Thêm chi tiết sản phẩm
        private void btnThemChiTiet_Click_1(object sender, EventArgs e)
        {
            CheckLuuChiTiet = false;
            //Tự sinh ra Mã Chi Tiết Sản Phẩm
            txtMaChiTietSP.Text = common.AutoCodeABC("ChiTietSanPham", "MaChiTietSP", MaSP);

            //Enable Button
            EnableButtonChiTiet(false, true);

            //Enable Text
            EnableTextChiTiet(true);

            //Tắt chức năng tìm kiếm
            cbbTimKiemSize.Enabled = cbbTimKiemMau.Enabled = false;

            //Tắt datagridview
            dgvChiTiet.Enabled = false;

            //Khi đang thêm chi tiết thì phía Sản phẩm phải tắt
            panelSanPham.Enabled = false;
        }
        //Hủy chi tiết
        private void btnHuyChiTiet_Click_1(object sender, EventArgs e)
        {
            //Bật datagridview
            dgvChiTiet.Enabled = true;

            //Enable text
            EnableTextChiTiet(false);

            //Bật tìm kiếm
            cbbTimKiemSize.Enabled = cbbTimKiemMau.Enabled = true;

            //Reset Text
            ResetTextChiTiet();
            cbbMauSac.Enabled = cbbSize.Enabled = false;

            //Show Table ChiTiet
            ShowTableChiTiet();
            //Sửa tiêu đề cột cho dgvSanPham
            dgvChiTiet.Columns[0].HeaderText = "Mã Chi Tiết";
            dgvChiTiet.Columns[1].HeaderText = "Size";
            dgvChiTiet.Columns[2].HeaderText = "Giá Nhập";
            dgvChiTiet.Columns[3].HeaderText = "Giá bán";
            dgvChiTiet.Columns[4].HeaderText = "Màu sắc";
            dgvChiTiet.Columns[5].HeaderText = "Số lượng";

            //Enable Button
            EnableButtonChiTiet(true, false);

            //Fix kiểu Hiếu Mạnh
            cbbTimKiemSize.Enabled = cbbTimKiemMau.Enabled = false;
            cbbTimKiemSize.Enabled = cbbTimKiemMau.Enabled = true;

            //Nếu Hủy thì hiển thị lại panelSanPham
            panelSanPham.Enabled = true;
        }
        //Reset Text Chi Tiết
        public void ResetTextChiTiet()
        {
            txtMaChiTietSP.Text = txtGiaNhap.Text = txtGiaBan.Text = "";

            cbbMauSac.SelectedIndex = cbbSize.SelectedIndex = -1;
            cbbMauSac.Enabled = cbbSize.Enabled = true;
            cbbTimKiemSize.SelectedIndex = cbbTimKiemMau.SelectedIndex = -1;
        }

        //Button Lưu chi tiết

        //ShowTableChiTiet
        public void ShowTableChiTiet()
        {
            dgvChiTiet.DataSource = access.ReadData("Select MaChiTietSP, Size, DonGiaNhap, DonGiaBan, MauSac, SoLuong from ChiTietSanPham where MaSP = '" + MaSP + "'");
        }
        //CheckNhapChiTiet
        bool CheckNhapChiTiet()
        {
            if(cbbSize.Text == "")
            {
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn phải chọn Size";
                MessageGuna.Show();
                return false;
            }
            else if(txtGiaNhap.Text == "")
            {
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn phải nhập giá nhập";
                MessageGuna.Show();
                return false;
            }
            else if(txtGiaBan.Text == "")
            {
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn phải nhập giá bán";
                MessageGuna.Show();
                return false;
            }
            else if(cbbMauSac.Text == "")
            {
                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn phải chọn màu sắc";
                MessageGuna.Show();
                return false;
            }

            return true;
        }

        //Button Lưu chi tiết
        private void btnLuuChiTiet_Click(object sender, EventArgs e)
        {
            if(CheckLuuChiTiet == false)    //Thêm
            {
                if(!CheckNhapChiTiet()) { }
                else
                {
                    //Kiểm tra đã tồn tại Size và màu
                    DataTable dt = access.ReadData("Select * from ChiTietSanPham where MaSP = N'"+txtMaSP.Text+"' AND Size = N'" + cbbSize.Text + "' and MauSac = N'"+cbbMauSac.Text+"'");
                    if(dt.Rows.Count > 0)
                    {
                        MessageGuna.Buttons = MessageDialogButtons.OK;
                        MessageGuna.Icon = MessageDialogIcon.Warning;
                        MessageGuna.Text = "Đã tồn tại Chi tiết này";
                        MessageGuna.Show();
                        return;
                    }


                    //Nếu không trùng
                    if(int.Parse(txtGiaBan.Text) < int.Parse(txtGiaNhap.Text))
                    {
                        MessageGuna.Buttons = MessageDialogButtons.YesNo;
                        MessageGuna.Icon = MessageDialogIcon.Question;
                        MessageGuna.Text = "Bạn muốn để giá bán nhỏ hơn giá nhập ?";
                        if(MessageGuna.Show() == DialogResult.Yes)
                        {
                            string sql = "Insert ChiTietSanPham values (N'" + txtMaChiTietSP.Text + "', N'" + txtMaSP.Text + "', N'" + cbbSize.Text + "', " + txtGiaNhap.Text + " , " + txtGiaBan.Text + " , 0, N'" + cbbMauSac.Text + "')";
                            access.UpdateData(sql);

                            MessageGuna.Buttons = MessageDialogButtons.OK;
                            MessageGuna.Icon = MessageDialogIcon.Information;
                            MessageGuna.Text = "Thêm thành công";
                            MessageGuna.Show();

                            btnHuyChiTiet_Click_1(sender, e);

                            ShowTableChiTiet();
                        }
                        else
                        {
                            txtGiaBan.Focus();
                        }
                    }
                    else
                    {
                        string sql = "Insert ChiTietSanPham values (N'" + txtMaChiTietSP.Text + "', N'" + txtMaSP.Text + "', N'" + cbbSize.Text + "', " + txtGiaNhap.Text + " , " + txtGiaBan.Text + " , 0, N'" + cbbMauSac.Text + "')";
                        access.UpdateData(sql);

                        MessageGuna.Buttons = MessageDialogButtons.OK;
                        MessageGuna.Icon = MessageDialogIcon.Information;
                        MessageGuna.Text = "Thêm thành công";
                        MessageGuna.Show();

                        btnHuyChiTiet_Click_1(sender, e);

                        ShowTableChiTiet();
                    }
                }
            }
            else      //Sửa
            {
                if(!CheckNhapChiTiet()) { }
                else
                {
                    //Kiểm tra trùng
                    access.UpdateData("Select * into BangMoi from ChiTietSanPham where MaSP = N'"+txtMaSP.Text+"'");
                    access.UpdateData("Delete from BangMoi where MaChiTietSP = N'"+txtMaChiTietSP.Text+"'");


                    DataTable dt = access.ReadData("Select * from BangMoi");
                    foreach(DataRow dr in dt.Rows)
                    {
                        if (cbbSize.Text == dr["Size"].ToString() && cbbMauSac.Text == dr["MauSac"].ToString())
                        {
                            MessageGuna.Buttons = MessageDialogButtons.OK;
                            MessageGuna.Icon = MessageDialogIcon.Warning;
                            MessageGuna.Text = "Đã tồn tại Chi tiết này";
                            MessageGuna.Show();
                            try
                            {
                                access.UpdateData("Drop table BangMoi");
                            }
                            catch { }
                            return;
                        }
                    }


                    //Sửa
                    if (double.Parse(txtGiaBan.Text) < double.Parse(txtGiaNhap.Text))
                    {
                        MessageGuna.Buttons = MessageDialogButtons.YesNo;
                        MessageGuna.Icon = MessageDialogIcon.Question;
                        MessageGuna.Text = "Bạn muốn để giá bán nhỏ hơn giá nhập ?";
                        if (MessageGuna.Show() == DialogResult.Yes)
                        {
                            string sql = "Update ChiTietSanPham set Size = N'" + cbbSize.Text + "', DonGiaNhap = " + txtGiaNhap.Text + ", DonGiaBan = " + txtGiaBan.Text + ", MauSac = N'" + cbbMauSac.Text + "'  " +
                            "where MaChiTietSP = N'" + txtMaChiTietSP.Text + "'";
                            access.UpdateData(sql);



                            MessageGuna.Buttons = MessageDialogButtons.OK;
                            MessageGuna.Icon = MessageDialogIcon.Information;
                            MessageGuna.Text = "Sửa thành công";
                            MessageGuna.Show();

                            btnHuyChiTiet_Click_1(sender, e);

                            ShowTableChiTiet();

                            //drop
                            try
                            {
                                access.UpdateData("Drop table BangMoi");
                            }
                            catch { }
                        }
                        else
                        {
                            txtGiaBan.Focus();
                            //drop
                            try
                            {
                                access.UpdateData("Drop table BangMoi");
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        string sql = "Update ChiTietSanPham set Size = N'" + cbbSize.Text + "', DonGiaNhap = " + txtGiaNhap.Text + ", DonGiaBan = " + txtGiaBan.Text + ", MauSac = N'" + cbbMauSac.Text + "'  " +
                            "where MaChiTietSP = N'" + txtMaChiTietSP.Text + "'";
                        access.UpdateData(sql);



                        MessageGuna.Buttons = MessageDialogButtons.OK;
                        MessageGuna.Icon = MessageDialogIcon.Information;
                        MessageGuna.Text = "Sửa thành công";
                        MessageGuna.Show();

                        btnHuyChiTiet_Click_1(sender, e);

                        ShowTableChiTiet();

                        //drop
                        try
                        {
                            access.UpdateData("Drop table BangMoi");
                        }
                        catch { }
                    }

                }
            }
        }

        //Xóa Chi Tiết
        private void dgvChiTiet_DoubleClick(object sender, EventArgs e)
        {
            MessageGuna.Buttons = MessageDialogButtons.YesNo;
            MessageGuna.Icon = MessageDialogIcon.Question;
            MessageGuna.Text = "Bạn muốn xóa chi tiết này không ?";
            if(MessageGuna.Show() == DialogResult.Yes)
            {
                string sql = "Delete from ChiTietSanPham where MaChiTietSP = N'"+txtMaChiTietSP.Text+"'";
                access.UpdateData(sql);

                MessageGuna.Buttons = MessageDialogButtons.OK;
                MessageGuna.Icon = MessageDialogIcon.Information;
                MessageGuna.Text = "Xóa thành công";
                MessageGuna.Show();

                btnHuyChiTiet_Click_1(sender, e);

                ShowTableChiTiet();

                btnHuyChiTiet_Click_1(sender, e);

                ShowTableChiTiet();
            }
        }

        //Cell Click của ChiTiet
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckLuuChiTiet = true;
            //Hiển thị thông tin lên phía trên
            txtMaChiTietSP.Text = dgvChiTiet.CurrentRow.Cells[0].Value.ToString();
            cbbSize.Text = dgvChiTiet.CurrentRow.Cells[1].Value.ToString();
            txtGiaNhap.Text = dgvChiTiet.CurrentRow.Cells[2].Value.ToString();
            txtGiaBan.Text = dgvChiTiet.CurrentRow.Cells[3].Value.ToString();
            cbbMauSac.Text = dgvChiTiet.CurrentRow.Cells[4].Value.ToString();

            //Điều chỉnh Button
            EnableButtonChiTiet(false, true);
            EnableTextChiTiet(true);
            cbbSize.Enabled = cbbMauSac.Enabled = false;
            cbbSize.Enabled = cbbMauSac.Enabled = true;

            //Tắt chức năng tìm kiếm
            cbbTimKiemMau.Enabled = cbbTimKiemSize.Enabled = false;

            //Không cho phép sửa Size và Màu Sắc
            cbbSize.Enabled = cbbMauSac.Enabled = false;

            //PanelSanPham
            panelSanPham.Enabled = false;
        }

        //Tìm kiếm của Sản Phẩm
        private void cbbTimKiemMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //Tắt chức năng thêm
            EnableButtonSanPham(false, true);
            btnLuuSP.Enabled = false;

            //Tìm kiếm
            DataTable dt = access.ReadData("Select * from SanPham where MaSP = N'"+cbbTimKiemMaSP.Text+"'");
            dgvSanPham.DataSource = dt;

        }

        //Tìm kiếm theo Size
        private void cbbTimKiemSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnThemChiTiet.Enabled = btnLuuChiTiet.Enabled = false;
            btnHuyChiTiet.Enabled = true;
            TimKiemChiTiet();
        }

        //Tìm kiếm theo Màu sắc
        private void cbbTimKiemMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnThemChiTiet.Enabled = btnLuuChiTiet.Enabled = false;
            btnHuyChiTiet.Enabled = true;
            TimKiemChiTiet();
        }

        public void TimKiemChiTiet()
        {
            if(cbbTimKiemSize.SelectedIndex != -1 && cbbTimKiemMau.SelectedIndex == -1)
            {
                string size = "Select MaChiTietSP, Size, DonGiaNhap, DonGiaBan, MauSac from ChiTietSanPham " +
                    " where Size = N'" + cbbTimKiemSize.Text + "'";
                dgvChiTiet.DataSource = access.ReadData(size);


            }
            if(cbbTimKiemSize.SelectedIndex == -1 && cbbTimKiemMau.SelectedIndex != -1)
            {
                string mau = "Select MaChiTietSP, Size, DonGiaNhap, DonGiaBan, MauSac from ChiTietSanPham " +
                    " where MauSac = N'" + cbbTimKiemMau.Text + "'";
                dgvChiTiet.DataSource = access.ReadData(mau);
            }
            if(cbbTimKiemSize.SelectedIndex != -1 && cbbTimKiemMau.SelectedIndex != -1)
            {
                string cahai = "Select MaChiTietSP, Size, DonGiaNhap, DonGiaBan, MauSac from ChiTietSanPham " +
                    " where Size = N'"+cbbTimKiemSize.Text+"' and MauSac = N'"+cbbTimKiemMau.Text+"'";
                dgvChiTiet.DataSource = access.ReadData(cahai);
            }
        }
        private void ibtnReset_Click(object sender, EventArgs e)
        {
            ShowTable();
            if (CheckReset)
                ShowTableChiTiet();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if(cbbTimKiemMaSP.SelectedIndex != -1)
            {
                if(dgvChiTiet.RowCount == 0)
                {
                    dgvChiTiet.DataSource = access.ReadData("Select * from ChiTietSanPham Where MaSP = N'" + cbbTimKiemMaSP.Text + "'");
                    dgvChiTiet.Columns[0].HeaderText = "Mã Chi Tiết";
                    dgvChiTiet.Columns[1].HeaderText = "Mã Sản Phẩm";
                    dgvChiTiet.Columns[2].HeaderText = "Size";
                    dgvChiTiet.Columns[3].HeaderText = "Đơn Giá Nhập";
                    dgvChiTiet.Columns[4].HeaderText = "Đơn Giá Bán";
                    dgvChiTiet.Columns[5].HeaderText = "Số Lượng";
                    dgvChiTiet.Columns[6].HeaderText = "Màu Sắc";
                    if(dgvChiTiet.RowCount <=0)
                    {
                        MessageGuna.Buttons = MessageDialogButtons.OK;
                        MessageGuna.Icon = MessageDialogIcon.Warning;
                        MessageGuna.Text = "Bạn không thể xuất khi Không có dòng dữ liệu nào !";
                        MessageGuna.Show();
                        dgvChiTiet.DataSource = null;
                        return;
                    }   
                    xuatexel = new XuatExel(dgvChiTiet, "Danh Sách Sản Phẩm", 0);
                    dgvChiTiet.DataSource = null;
                    
                }  
                else
                {
                    if (dgvChiTiet.RowCount <= 0)
                    {
                        MessageGuna.Buttons = MessageDialogButtons.OK;
                        MessageGuna.Icon = MessageDialogIcon.Warning;
                        MessageGuna.Text = "Bạn không thể xuất khi Không có dòng dữ liệu nào !";
                        MessageGuna.Show();
                        return;
                    }
                    xuatexel = new XuatExel(dgvChiTiet, "Danh Sách Sản Phẩm", 0);
                }    
                
            }
            else
            {
                if (txtMaSP.Text != "")
                {
                    if (dgvChiTiet.RowCount <= 0)
                    {
                        MessageGuna.Buttons = MessageDialogButtons.OK;
                        MessageGuna.Icon = MessageDialogIcon.Warning;
                        MessageGuna.Text = "Bạn không thể xuất khi Không có dòng dữ liệu nào !";
                        MessageGuna.Show();
                        return;
                    }
                    xuatexel = new XuatExel(dgvChiTiet, "Danh Sách Sản Phẩm", 0);
                    
                }   
                else
                {
                    dgvChiTiet.DataSource = access.ReadData("Select * from ChiTietSanPham");
                    dgvChiTiet.Columns[0].HeaderText = "Mã Chi Tiết";
                    dgvChiTiet.Columns[1].HeaderText = "Mã Sản Phẩm";
                    dgvChiTiet.Columns[2].HeaderText = "Size";
                    dgvChiTiet.Columns[3].HeaderText = "Đơn Giá Nhập";
                    dgvChiTiet.Columns[4].HeaderText = "Đơn Giá Bán";
                    dgvChiTiet.Columns[5].HeaderText = "Số Lượng";
                    dgvChiTiet.Columns[6].HeaderText = "Màu Sắc";
                    if (dgvChiTiet.RowCount <= 0)
                    {
                        MessageGuna.Buttons = MessageDialogButtons.OK;
                        MessageGuna.Icon = MessageDialogIcon.Warning;
                        MessageGuna.Text = "Bạn không thể xuất khi Không có dòng dữ liệu nào !";
                        MessageGuna.Show();
                        return;
                    }
                    xuatexel = new XuatExel(dgvChiTiet, "Danh Sách Sản Phẩm", 0);
                    dgvChiTiet.DataSource = null;
                }
            }
            
            
        }
    }
}
