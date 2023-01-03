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
    public partial class NhaCungCap : Form
    {
        AccessData Data = new AccessData();
        CommondFunction comm = new CommondFunction();
        bool checkDeLuu;
        string sql = "Select * from NhaCungCap";

        private void reset()
        {
            tbTenNhaCungCap.Text = tbMaNhaCC.Text = "";
            tbTenNhaCungCap.Enabled = tbMaNhaCC.Enabled = btnLuu.Enabled = btnHuy.Enabled = false;
            btnThem.Enabled = true;
        }
        void load_Data(string sql)
        {
            comm.FillCombobox(cbbMaNCCTK, Data.ReadData("Select * from NhaCungCap"), "TenNhaCungCap", "MaNhaCungCap");
            cbbMaNCCTK.SelectedValue = "";
            cbbMaNCCTK.Items.IndexOf(-1);
            dgvThongTinNCC.DataSource = Data.ReadData(sql);
            cbbMaNCCTK.Enabled = dgvThongTinNCC.Enabled = true;

        }
        public NhaCungCap()
        {
            InitializeComponent();
        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            load_Data(sql);
            reset();

            dgvThongTinNCC.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
            dgvThongTinNCC.Columns[1].HeaderText = "Tên Nhà Cung cấp";
        }
        

        private void dgvThongTinNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = tbMaNhaCC.Enabled = cbbMaNCCTK.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            tbMaNhaCC.Text = dgvThongTinNCC.CurrentRow.Cells[0].Value.ToString();
            tbTenNhaCungCap.Text = dgvThongTinNCC.CurrentRow.Cells[1].Value.ToString();
            checkDeLuu = tbTenNhaCungCap.Enabled = true;
            quaylai = tbTenNhaCungCap.Text.Trim();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            load_Data(sql);
            reset();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            tbTenNhaCungCap.Enabled = true;
            tbMaNhaCC.Text = comm.AutoCode("NhaCungCap", "MaNhaCungCap", "NCC");

            btnThem.Enabled = checkDeLuu = cbbMaNCCTK.Enabled = dgvThongTinNCC.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
        }
        // Quay lại chuỗi trước khi sửa nếu mà chùng tên nhà cung cấp
        string quaylai = "";
        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            
            tbTenNhaCungCap.Text = tbTenNhaCungCap.Text.Trim();
            if (!checkDeLuu)
            {
                if (tbTenNhaCungCap.Text.Trim() == "")
                {
                    MessageBox.Text = "Tên Nhà Cung Cấp Rỗng!";
                    MessageBox.Caption = "Thông Báo!";
                    MessageBox.Show();
                    return;
                }
                else
                {
                    if (Data.ReadData("Select TenNhaCungCap from NhaCungCap Where TenNhaCungCap = N'" + tbTenNhaCungCap.Text.Trim() + "'").Rows.Count > 0)
                    {
                        MessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                        MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        MessageBox.Text = "Tên nhà cung cấp đã tồn tại!";
                        MessageBox.Caption = "Thông báo!";
                        MessageBox.Show();
                        tbTenNhaCungCap.Text = "";
                        tbTenNhaCungCap.Focus();
                        return;
                    }
                    Data.UpdateData("insert NhaCungCap values('" + tbMaNhaCC.Text + "',N'" + tbTenNhaCungCap.Text.Trim() + "')");
                    MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageBox.Text = "Thêm nhà cung cấp thành công!";
                    MessageBox.Caption = "Thông báo!";
                    MessageBox.Show();
                }
            }
            else
            {

                DataTable CheckNhaCungCap = Data.ReadData("Select TenNhaCungCap from NhaCungCap where MaNhaCungCap = N'" + tbMaNhaCC.Text + "'");
                if (CheckNhaCungCap.Rows[0][0].ToString() == tbTenNhaCungCap.Text.Trim())
                {
                    load_Data(sql);
                    reset();
                    tbTenNhaCungCap.Focus();
                    return;
                }

                DataTable NhaCungCap = Data.ReadData("Select * from NhaCungCap where TenNhaCungCap = N'" + tbTenNhaCungCap.Text + "'");
                if (NhaCungCap.Rows.Count > 0)
                {
                    MessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                    MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageBox.Text = "Tên Nhà Cung Cấp đã tồn tại!";
                    MessageBox.Caption = "Thông báo!";
                    tbTenNhaCungCap.Text = quaylai;
                    tbTenNhaCungCap.Focus();
                    MessageBox.Show();
                    return;
                }
                else
                {
                    MessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MessageBox.Text = "Sửa nhà cung cấp thành công!";
                    MessageBox.Caption = "Thông báo!";
                    MessageBox.Show();
                    string sql = "";
                    sql = "Update NhaCungCap SET ";
                    sql += "TenNhaCungCap = N'" + tbTenNhaCungCap.Text + "' ";
                    sql += "Where MaNhaCungCap = N'" + tbMaNhaCC.Text + "'";
                    Data.UpdateData(sql);
                }

            }
            load_Data(sql);
            reset();
            
        }

        private void cbbMaNCCTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnThem.Enabled = false;
                DataTable DataSearch = new DataTable();
                DataSearch = Data.ReadData("Select * from NhaCungCap where TenNhaCungCap = N'" + cbbMaNCCTK.Text + "' ");
                dgvThongTinNCC.DataSource = DataSearch;
                tbMaNhaCC.Text = DataSearch.Rows[0]["MaNhaCungCap"].ToString();
                tbTenNhaCungCap.Text = DataSearch.Rows[0]["TenNhaCungCap"].ToString();
                tbTenNhaCungCap.Enabled = checkDeLuu = btnHuy.Enabled = btnLuu.Enabled = true;
                quaylai = tbTenNhaCungCap.Text;
            }
            catch
            {

            }
        }

        private void dgvThongTinNCC_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                MessageBox.Text = $"Bạn muốn xóa nhà cung cấp có mã là: {tbMaNhaCC.Text} Không!";
                MessageBox.Caption = "Thông báo!";
                if (MessageBox.Show() == DialogResult.Yes)
                {
                    Data.UpdateData("Delete from NhaCungCap Where MaNhaCungCap = N'" + tbMaNhaCC.Text + "'");
                }
            }
            catch 
            {
                MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MessageBox.Text = "Vẫn còn hóa đơn nhập từ nhà cung cấp: " + tbTenNhaCungCap.Text + ". \nBạn không thể xóa nhà cung cấp này!";
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
