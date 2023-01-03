using DuyThien_BTL.KetNoi;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xuat_Exel;
using Exel = Microsoft.Office.Interop.Excel;

namespace DuyThien_BTL.Childen
{
    public partial class QuanLyKhachHang : Form
    {
        AccessData accessData = new AccessData();
        CommondFunction commond = new CommondFunction();
        XuatExel XuatExel;
        bool checkLuu = false;
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Phương thức show bảng khách hàng
        void showTable()
        {
            dgvThongTinKhachHang.DataSource = accessData.ReadData("select * from KhachHang");
        }
        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
        bool checkValid()
        {
            if (txtTenKH.Text.Trim() == "")
            {
                Message.Text = "Không được để tên khách hàng trống";
                Message.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                Message.Caption = "Thông báo";
                Message.Show();
                return false;
            }
            else if (radioNam.Checked == false && radioNu.Checked == false)
            {
                Message.Text = "Bạn phải chọn giới tính của nhân viên";
                Message.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                Message.Caption = "Thông báo";
                Message.Show();
                return false;
            }
            else if (tbSdt.Text.Trim() == "")
            {
                Message.Text = "Không được để số điện thoại trống";
                Message.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                Message.Caption = "Thông báo";
                Message.Show();
                return false;
            }
            else if (tbDiaChi.Text.Trim() == "")
            {
                Message.Text = "Không được để địa chỉ khách hàng trống";
                Message.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                Message.Caption = "Thông báo";
                Message.Show();
                return false;
            }
            else if (txtTenKH.Text.Trim() != "")
            {
                Regex reg = new Regex("^([a-vxyỳọáầảấờễàạằệếýộậốũứĩõúữịỗìềểẩớặòùồợãụủíỹắẫựỉỏừỷởóéửỵẳẹèẽổẵẻỡơôưăêâđ]+)((\\s{1}[a-vxyỳọáầảấờễàạằệếýộậốũứĩõúữịỗìềểẩớặòùồợãụủíỹắẫựỉỏừỷởóéửỵẳẹèẽổẵẻỡơôưăêâđ]+){1,})$");
                if (reg.IsMatch(txtTenKH.Text.ToLower()) == false)
                {
                    Message.Text = "Bạn phải nhập đúng định dạng Tên nhân viên";
                    txtTenKH.Focus();
                    Message.Show();
                    return false;
                }
            }
            if (tbSdt.Text.Trim() != "")
            {
                Regex reg = new Regex("(((\\+|)84)|0)(3|5|7|8|9)+([0-9]{8})\\b");
                if (reg.IsMatch(tbSdt.Text) == false)
                {
                    Message.Text = "Bạn phải nhập đúng định dạng số điện thoại";
                    tbSdt.Focus();
                    Message.Show();
                    return false;
                }
            }
            return true;
        }
        void button(bool res1,bool res2)
        {
            btnThem.Enabled = res1;
            btnLuu.Enabled = btnHuy.Enabled = res2;
        }
        void enableControl(bool check)
        {
            foreach (Control control in this.grbIn4KH.Controls)
                control.Enabled = check;
            tbMaKH.Enabled = false;
        }
        void resetValue()
        {
            foreach (Control control in this.grbIn4KH.Controls)
            {
                if (control is Guna2TextBox)
                    ((Guna2TextBox)control).Text = "";
            }
            radioNam.Checked = false;
            radioNu.Checked = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            checkLuu = true;

            //Tắt chức năng tìm kiếm
            SoDienThoai_TK.Enabled = false;
            btnTimKiem.Enabled = false;

            button(false,true);
            tbMaKH.Text =  commond.AutoCode("KhachHang", "MaKH", "KH");
            enableControl(true);
            dgvThongTinKhachHang.Enabled = false ;

            //Tắt chức năng in danh sách
            btnInKH.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sex = "";
            if (radioNam.Checked == true)
                sex = "Nam";
            if (radioNu.Checked == true)
                sex = "Nữ";
            if (checkLuu == true && checkValid()==true)
            {
                string sqlCheckSdt = $"select * from KhachHang where DienThoai = '{tbSdt.Text}'";
                DataTable dataTableSdt = accessData.ReadData(sqlCheckSdt);
                if (dataTableSdt.Rows.Count > 0)
                {
                    Message.Buttons = MessageDialogButtons.OK;
                    Message.Caption = "Thông báo";
                    Message.Icon = MessageDialogIcon.None;
                    Message.Text = "Số điện thoại đã tồn tại";
                    Message.Show();
                    tbSdt.Focus();
                }
                
                else
                {
                    string sql = $"insert into KhachHang " +
                        $"values('{tbMaKH.Text}',N'{txtTenKH.Text}',N'{sex}','{String.Format("{0:MM/dd/yyyy}", dtNgaySinh.Value.ToString())}',N'{tbDiaChi.Text}','{tbSdt.Text}')";
                    accessData.UpdateData(sql);

                    Message.Buttons = MessageDialogButtons.OK;
                    Message.Icon = MessageDialogIcon.Information;
                    Message.Text = "Thêm thành công !";
                    Message.Show();
                    resetValue();
                    showTable();
                    enableControl(false);
                    button(true, false);
                    dgvThongTinKhachHang.Enabled = true;
                    SoDienThoai_TK.Enabled = btnTimKiem.Enabled = true;
                }
            }
            if(checkLuu==false&&checkValid()==true)
            {
                accessData.UpdateData("Select * into BangMoiSdt from KhachHang");
                accessData.UpdateData("Delete from BangMoiSdt where MaKH = N'" + tbMaKH.Text + "'");

                int check = 0; // ktra so dien thoai trong csdl chua
                DataTable dt = accessData.ReadData("Select * from BangMoiSdt");
                foreach (DataRow dr in dt.Rows)
                {
                    if (tbSdt.Text == dr["DienThoai"].ToString())
                    {
                        Message.Buttons = MessageDialogButtons.OK;
                        Message.Icon = MessageDialogIcon.Warning;
                        Message.Text = "Đã tồn tại Số điện thoại này";
                        check = 1;
                        Message.Show();
                        try
                        {
                            accessData.UpdateData("Drop table BangMoiSdt");
                        }
                        catch { }
                        return;
                    }
                }
                if (check == 0)
                {
                    string sql = $"Update KhachHang set " +
                    $"TenKH=N'{txtTenKH.Text}', " +
                    $"NgaySinh='{String.Format("{0:MM/dd/yyyy}", dtNgaySinh.Value.ToString())}', " +
                    $"DiaChi=N'{tbDiaChi.Text}', " +
                    $"DienThoai='{tbSdt.Text}', " +
                    $"GioiTinh=N'{sex}' " +
                    $"where MaKH='{tbMaKH.Text}'";
                    accessData.UpdateData(sql);
                    Message.Buttons = MessageDialogButtons.OK;
                    Message.Icon = MessageDialogIcon.Information;
                    Message.Text = "Sửa thành công !";
                    Message.Show();
                    showTable();
                    resetValue();
                    button(true, false);
                    enableControl(false);
                    dgvThongTinKhachHang.Enabled = true;
                    SoDienThoai_TK.Enabled = true;
                    try
                    {
                        accessData.UpdateData("Drop table BangMoiSdt");
                    }
                    catch { }
                }

            }
            
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            
            showTable();
            enableControl(false);
            dgvThongTinKhachHang.Enabled = true;
            tbMaKH.Enabled = false;
            button(true, false);
        }

        private void dgvThongTinKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            checkLuu = false;
            tbMaKH.Text = dgvThongTinKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dgvThongTinKhachHang.CurrentRow.Cells[1].Value.ToString();
            dtNgaySinh.Value = (DateTime)dgvThongTinKhachHang.CurrentRow.Cells[3].Value;
            tbDiaChi.Text = dgvThongTinKhachHang.CurrentRow.Cells[4].Value.ToString();
            tbSdt.Text = dgvThongTinKhachHang.CurrentRow.Cells[5].Value.ToString();
            if (dgvThongTinKhachHang.CurrentRow.Cells[2].Value.ToString() == "Nam")
                radioNam.Checked = true;
            else
                radioNu.Checked = true;
            button(false, true);
            enableControl(true);
            dgvThongTinKhachHang.Enabled = true;

            //Tắt chức năng tìm kiếm
            SoDienThoai_TK.Enabled = btnTimKiem.Enabled= btnInKH.Enabled = false;
        }

        private void dgvThongTinKhachHang_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int check = 0;

                Message.Buttons = MessageDialogButtons.YesNo;
                Message.Caption = "Thông báo!";
                Message.Text = $"Bạn muốn xóa khách hàng có mã là: {tbMaKH.Text} Không!";


                if (Message.Show() == DialogResult.Yes)
                {
                    string sqlTonTaiHDB = $"select * from HoaDonBan where MaKH = '{tbMaKH.Text}'";
                    if (accessData.ReadData(sqlTonTaiHDB).Rows.Count > 0)
                    {
                        check = 1;

                    }
                    if (check == 1)
                    {
                        Message.Buttons = MessageDialogButtons.OK;
                        Message.Icon = MessageDialogIcon.Warning;
                        Message.Text = "Khách Hàng vẫn còn trong hóa đơn\n Bạn không thể xóa khách hàng này !";
                        Message.Show();
                    }
                    if (check == 0)
                    {
                        string sql = $"delete from KhachHang where MaKH = '{tbMaKH.Text}'";
                        accessData.UpdateData(sql);
                        Message.Buttons = MessageDialogButtons.OK;
                        Message.Caption = "Thông báo";
                        Message.Icon = MessageDialogIcon.None;
                        Message.Text = "Xóa thành công";
                        Message.Show();
                        resetValue();
                    }

                }
                resetValue();
                button(true, false);
                showTable();

                txtTenKH.Enabled = dtNgaySinh.Enabled = tbSdt.Enabled = tbDiaChi.Enabled = false;
                 
            }
            catch { }
            
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetValue();
            
            
            dgvThongTinKhachHang.Enabled = true;
            showTable();
            enableControl(false);
            button(true, false);

            //Mở tìm kiếm
            SoDienThoai_TK.Enabled = btnTimKiem.Enabled = true;

            //Mở chức năng in danh sách
            btnInKH.Enabled = true;
        }

       

        private void tbSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cbbKhachHangVienTK_Click(object sender, EventArgs e)
        {
        }

        private void btnInNV_Click(object sender, EventArgs e)
        {
            if (dgvThongTinKhachHang.RowCount <= 0)
            {
                Message.Text = "Bạn không thể xuất khi Không có dòng dữ liệu nào !";
                Message.Buttons = MessageDialogButtons.OK;
                Message.Icon = MessageDialogIcon.Warning;
                Message.Caption = "Thông báo";
                Message.Show();
            }
            else
            {
                //// workbook = file exel, application = exel
                //Exel.Application exel =  new Exel.Application();
                //Exel.Workbook exBook = exel.Workbooks.Add(Exel.XlWBATemplate.xlWBATWorksheet);
                //Exel.Worksheet exSheet = (Exel.Worksheet)exBook.Worksheets[1];

                ////Tieude exel
                //Exel.Range exRange = (Exel.Range)exSheet.Cells[1,1];
                //exRange.Range["A1:C1"].MergeCells = true;
                //exRange.Font.Size = 10;
                //exRange.Font.Bold = true;
                //exRange.Font.Color = Color.Black;
                //exRange.Value = "CỬA HÀNG BÁN QUẦN ÁO LUONVUITUOI NHÓM 07";

                //Exel.Range Address = (Exel.Range)exSheet.Cells[2, 1];
                //Address.Range["A2:C2"].MergeCells = true;
                //Address.Font.Size = 10;
                //Address.Font.Bold = true;
                //Address.Font.Color = Color.Black;
                //Address.Value = "SỐ 3 CẦU GIẤY - HÀ NỘI";

                //exRange.Range["C6:E6"].MergeCells= true;
                //exRange.Range["C6:E6"].Value = "           DANH SÁCH NHÂN VIÊN";
                //exRange.Range["C6:E6"].Font.Size = 15;
                //exSheet.Range["C6:E6"].Font.Bold = true;
                //exSheet.Range["B8:C8"].ColumnWidth = 17;

                //exSheet.Range["E8"].ColumnWidth = 16;
                //exSheet.Range["F8"].ColumnWidth = 12;
                //exSheet.Range["G8"].ColumnWidth = 12;

                //exSheet.Range["B8:G8"].Interior.Color = Color.Yellow;

                //exSheet.Range["B8:G8"].Font.Size = 12;
                //exSheet.Range["B8"].Value = "Mã khách hàng";
                //exSheet.Range["C8"].Value = "Tên khách hàng";
                //exSheet.Range["D8"].Value = "Giới tính";
                //exSheet.Range["E8"].Value = "Ngày sinh";
                //exSheet.Range["F8"].Value = "Số điện thoại";
                //exSheet.Range["G8"].Value = "Địa chỉ";
                //exSheet.Range[$"B8:G{8+dgvThongTinKhachHang.Rows.Count}"].Borders.Color = Color.Black;

                //int dong = 9;
                //for(int i = 0; i < dgvThongTinKhachHang.Rows.Count; i++)
                //{
                //    exSheet.Range["B" + (dong + i).ToString()].Value = dgvThongTinKhachHang.Rows[i].Cells[0].Value.ToString();
                //    exSheet.Range["C" + (dong + i).ToString()].Value = dgvThongTinKhachHang.Rows[i].Cells[1].Value.ToString();
                //    exSheet.Range["D" + (dong + i).ToString()].Value = dgvThongTinKhachHang.Rows[i].Cells[2].Value.ToString();
                //    exSheet.Range["E" + (dong + i).ToString()].Value = dgvThongTinKhachHang.Rows[i].Cells[3].Value;
                //    exSheet.Range["F" + (dong + i).ToString()].Value = "0"+dgvThongTinKhachHang.Rows[i].Cells[5].Value.ToString();
                //    exSheet.Range["G" + (dong + i).ToString()].Value = dgvThongTinKhachHang.Rows[i].Cells[4].Value.ToString();
                //}
                //exBook.Activate();
                //SaveFileDialog save = new SaveFileDialog();
                //save.Filter = "Exel 97-2002 Workbook|*.xls|Excel Workbook|*.xlsx|All Files|*.*";
                //save.FilterIndex = 2;
                //if (save.ShowDialog() == DialogResult.OK)
                //{
                //    exBook.SaveAs(save.FileName.ToLower());
                //}
                //exel.Quit();
                XuatExel = new XuatExel(dgvThongTinKhachHang, "Danh Sách Khách Hàng", 0);
            }
        }

        //Tìm kiếm khách hàng theo số điện thoại
        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            Regex reg = new Regex("(((\\+|)84)|0)(3|5|7|8|9)+([0-9]{8})\\b");
            if (reg.IsMatch(SoDienThoai_TK.Text) == false)
            {
                Message.Buttons = MessageDialogButtons.OK;
                Message.Icon = MessageDialogIcon.Warning;
                Message.Text = "Bạn phải nhập đúng định dạng số điện thoại";
                SoDienThoai_TK.Focus();
                Message.Show();
            }
            else
            {
                string sqlTimKiem = $"select * from KhachHang where DienThoai = '{SoDienThoai_TK.Text}'";
                DataTable dataTableTK = accessData.ReadData(sqlTimKiem);
                if (dataTableTK.Rows.Count > 0)
                    dgvThongTinKhachHang.DataSource = dataTableTK;
                else
                {
                    Message.Buttons = MessageDialogButtons.OK;
                    Message.Icon = MessageDialogIcon.Warning;
                    Message.Text = "Không tồn tại khách hàng này";
                    Message.Show(); 
                }
               
            } 
            SoDienThoai_TK.Text = "";
            btnHuy.Enabled = true;
        }

        private void dgvThongTinKhachHang_DockChanged(object sender, EventArgs e)
        {

        }
    }
}
