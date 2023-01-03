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
    public partial class QuanLyTheLoai : Form
    {

        AccessData Data = new AccessData();
        CommondFunction comm = new CommondFunction();
        bool checkDeLuu;
        string sql = "Select * from TheLoai";



        public QuanLyTheLoai()
        {
            InitializeComponent();
        }
        
        private void reset()
        {
            tbTenTheLoai.Text = tbMaTheLoai.Text = "";
            tbTenTheLoai.Enabled = tbMaTheLoai.Enabled = btnLuu.Enabled = btnHuy.Enabled = false;
            btnThem.Enabled = true;
        }

        void load_Data(string sql)
        {
            comm.FillCombobox(cbbTenTheLoaiTK, Data.ReadData("Select * from TheLoai"), "TenTheLoai", "MaTheLoai");
            cbbTenTheLoaiTK.SelectedValue = "";
            cbbTenTheLoaiTK.Items.IndexOf(-1);
            dgvThongTinTheLoai.DataSource = Data.ReadData(sql);
            cbbTenTheLoaiTK.Enabled = dgvThongTinTheLoai.Enabled = true;
        }

        private void QuanLyTheLoai_Load(object sender, EventArgs e)
        {
            load_Data(sql);
            reset();

            dgvThongTinTheLoai.Columns[0].HeaderText = "Mã Thể Loại";
            dgvThongTinTheLoai.Columns[1].HeaderText = "Tên Thể Loại";
        }

        

        

        private void dgvThongTinTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = tbMaTheLoai.Enabled = cbbTenTheLoaiTK.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            tbMaTheLoai.Text = dgvThongTinTheLoai.CurrentRow.Cells[0].Value.ToString();
            tbTenTheLoai.Text = dgvThongTinTheLoai.CurrentRow.Cells[1].Value.ToString();
            checkDeLuu = tbTenTheLoai.Enabled = true;
            quaylai = tbTenTheLoai.Text;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            load_Data(sql);

            reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            tbTenTheLoai.Enabled = true;
            tbMaTheLoai.Text = comm.AutoCode("TheLoai", "MaTheLoai", "TL");
            
            btnThem.Enabled = checkDeLuu = cbbTenTheLoaiTK.Enabled = dgvThongTinTheLoai.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
        }

        // Quay lại chuỗi trước khi sửa nếu mà chùng tên thể loại
        string quaylai = "";
        private void btnLuu_Click(object sender, EventArgs e)
        {
            tbTenTheLoai.Text = tbTenTheLoai.Text.Trim();
            if (!checkDeLuu)
            {
                if (tbTenTheLoai.Text.Trim() == "")
                {
                    MessageBox.Text = "Tên Thể Loại Rỗng!";
                    MessageBox.Caption = "Thông Báo!";
                    MessageBox.Show();
                    return;
                }
                else
                {
                    if (Data.ReadData("Select TenTheLoai from TheLoai Where TenTheLoai = N'" + tbTenTheLoai.Text.Trim() + "'").Rows.Count > 0)
                    {
                        MessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                        MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        MessageBox.Text = "Tên thể loại đã tồn tại!";
                        MessageBox.Caption = "Thông báo!";
                        MessageBox.Show();
                        tbTenTheLoai.Text = "";
                        tbTenTheLoai.Focus();
                        return;
                    }
                    Data.UpdateData("insert TheLoai values('" + tbMaTheLoai.Text + "',N'" + tbTenTheLoai.Text + "')");
                    MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageBox.Text = "Thêm thể loại thành công!";
                    MessageBox.Caption = "Thông báo!";
                    MessageBox.Show();
                }
            }
            else
            {
                DataTable CheckChatLieu = Data.ReadData("Select TenTheLoai from TheLoai where MaTheLoai = N'" + tbMaTheLoai.Text + "'");
                if (CheckChatLieu.Rows[0][0].ToString() == tbTenTheLoai.Text)
                {
                    load_Data(sql);
                    reset();
                    return;
                }

                DataTable ChatLieu = Data.ReadData("Select * from TheLoai where TenTheLoai = N'" + tbTenTheLoai.Text + "'");
                if (ChatLieu.Rows.Count > 0)
                {
                    MessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                    MessageBox.Text = "Tên thể loại đã tồn tại!";
                    MessageBox.Caption = "Thông báo!";
                    MessageBox.Show();
                    tbTenTheLoai.Text = quaylai;
                    return;
                }
                else
                {
                    MessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MessageBox.Text = "Sửa thể loại thành công!";
                    MessageBox.Caption = "Thông báo!";
                    MessageBox.Show();
                    string sql = "";
                    sql = "Update TheLoai SET ";
                    sql += "TenTheLoai = N'" + tbTenTheLoai.Text + "' ";
                    sql += "Where MaTheLoai = N'" + tbMaTheLoai.Text + "'";
                    Data.UpdateData(sql);
                }

            }
            load_Data(sql);
            reset();
        }

        private void cbbTenTheLoaiTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnThem.Enabled = false;
                DataTable DataSearch = new DataTable();
                DataSearch = Data.ReadData("Select * from TheLoai where TenTheLoai = N'" + cbbTenTheLoaiTK.Text + "' ");
                dgvThongTinTheLoai.DataSource = DataSearch;
                tbMaTheLoai.Text = DataSearch.Rows[0]["MaTheLoai"].ToString();
                tbTenTheLoai.Text = DataSearch.Rows[0]["TenTheLoai"].ToString();
                tbTenTheLoai.Enabled = checkDeLuu = btnHuy.Enabled = btnLuu.Enabled = true;
                quaylai = tbTenTheLoai.Text;
            }
            catch
            {

            }
        }

        private void dgvThongTinTheLoai_DoubleClick(object sender, EventArgs e)
        {

            try 
            {
                MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                MessageBox.Text = $"Bạn muốn xóa Thể Loại có mã là: {tbMaTheLoai.Text} Không!";
                MessageBox.Caption = "Thông báo!";
                if (MessageBox.Show() == DialogResult.Yes)
                {
                    Data.UpdateData("Delete from TheLoai Where MaTheLoai = '" + tbMaTheLoai.Text + "'");
                }
            }
            catch
            {
                MessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MessageBox.Text = "Vẫn còn sản phẩm có thể loại: " + tbTenTheLoai.Text + ". Bạn không thể xóa thể loại này !";
                MessageBox.Caption = "Thông báo!";
                MessageBox.Show();
            }

            load_Data(sql);
            reset();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
