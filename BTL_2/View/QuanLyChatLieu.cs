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
    public partial class QuanLyChatLieu : Form
    {
        AccessData Data = new AccessData();
        CommondFunction comm = new CommondFunction();
        bool checkDeLuu;
        
        string sql = "Select * from ChatLieu";
        public QuanLyChatLieu()
        {

            InitializeComponent();
        }
        private void reset()
        {
            tbTenChatLieu.Text = tbMaChatLieu.Text = "";
            tbTenChatLieu.Enabled = tbMaChatLieu.Enabled = btnLuu.Enabled = btnHuy.Enabled = false;
            btnThem.Enabled = true;
        }

        void load_Data(string sql)
        {
            comm.FillCombobox(cbbTenChatLieuTK, Data.ReadData("Select * from ChatLieu"), "TenChatLieu", "MaChatLieu");
            cbbTenChatLieuTK.SelectedValue = "";
            cbbTenChatLieuTK.Items.IndexOf(-1);
            dgvThongTinChatLieu.DataSource = Data.ReadData(sql);
            dgvThongTinChatLieu.Enabled = cbbTenChatLieuTK.Enabled = true;

        }


        

        
        private void QuanLyChatLieu_Load(object sender, EventArgs e)
        {
            
            load_Data(sql);
            reset();
            
            dgvThongTinChatLieu.Columns[0].HeaderText = "Mã Chất Liệu";
            dgvThongTinChatLieu.Columns[1].HeaderText = "Tên Chất Liệu";
        }

        private void dgvThongTinChatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = tbMaChatLieu.Enabled= cbbTenChatLieuTK.Enabled = false; ;
            btnLuu.Enabled = btnHuy.Enabled = true;
            tbMaChatLieu.Text = dgvThongTinChatLieu.CurrentRow.Cells[0].Value.ToString();
            tbTenChatLieu.Text = dgvThongTinChatLieu.CurrentRow.Cells[1].Value.ToString();
            checkDeLuu = tbTenChatLieu.Enabled = true;
            quaylai = tbTenChatLieu.Text;
        }
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            
            load_Data(sql);
            reset();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            tbTenChatLieu.Enabled = true;
            tbMaChatLieu.Text = comm.AutoCode("ChatLieu", "MaChatLieu", "CL");

            btnThem.Enabled = checkDeLuu = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            dgvThongTinChatLieu.Enabled = cbbTenChatLieuTK.Enabled =  false;
        }


        // Quay lại chuỗi trước khi sửa nếu mà chùng tên chất liệu
        string quaylai = "";
        private void btnLuu_Click(object sender, EventArgs e)
        {
            tbTenChatLieu.Text = tbTenChatLieu.Text.Trim();
            if (!checkDeLuu)
            {
                if(tbTenChatLieu.Text.Trim() == "")
                {
                    MessageBox.Text = "Tên chất Liệu Rỗng!";
                    MessageBox.Caption = "Thông Báo!";
                    MessageBox.Show();
                    return;
                }
                else
                {
                    if(Data.ReadData("Select TenChatLieu from ChatLieu Where TenChatLieu = N'"+ tbTenChatLieu.Text.Trim() + "'").Rows.Count>0)
                    {
                        MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        MessageBox.Text = "Tên chất liệu đã tồn tại!";
                        MessageBox.Caption = "Thông báo!";
                        MessageBox.Show();
                        tbTenChatLieu.Text = "";
                        tbTenChatLieu.Focus();
                        return;
                    }
                    Data.UpdateData("insert ChatLieu values('" + tbMaChatLieu.Text + "',N'" + tbTenChatLieu.Text.Trim() + "')");
                    MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageBox.Text = "Thêm chất liệu thành công!";
                    MessageBox.Caption = "Thông báo!";
                    MessageBox.Show();
                }
            }
            else
            {
                DataTable CheckChatLieu = Data.ReadData("Select TenChatLieu from ChatLieu where MaChatLieu = N'"+ tbMaChatLieu.Text +"'");
                if (CheckChatLieu.Rows[0][0].ToString() == tbTenChatLieu.Text.Trim())
                {
                    load_Data(sql);
                    reset();
                    return;
                }    
                    
                DataTable ChatLieu = Data.ReadData("Select * from ChatLieu where TenChatLieu = N'" + tbTenChatLieu.Text.Trim() + "'");
                if (ChatLieu.Rows.Count > 0)
                {
                    MessageBox.Text = "Tên Chất liệu đã tồn tại!";
                    MessageBox.Caption = "Thông báo!";
                    MessageBox.Show();
                    tbTenChatLieu.Text = quaylai;
                    tbTenChatLieu.Focus();
                    return;
                }
                else
                {
                    MessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MessageBox.Text = "Sửa chất liệu công!";
                    MessageBox.Caption = "Thông báo!";
                    MessageBox.Show();
                    string sql = "";
                    sql = "Update ChatLieu SET ";
                    sql += "TenChatLieu = N'" + tbTenChatLieu.Text.Trim() + "' ";
                    sql += "Where MaChatLieu = N'" + tbMaChatLieu.Text + "'";
                    Data.UpdateData(sql);
                }    
                
            }
            
            load_Data(sql);
            reset();


        }


        
        private void cbbMaChatLieuTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnThem.Enabled = false;
                DataTable DataSearch = new DataTable();
                DataSearch = Data.ReadData("Select * from ChatLieu where TenChatLieu = N'" + cbbTenChatLieuTK.Text + "' ");
                dgvThongTinChatLieu.DataSource = DataSearch;
                tbMaChatLieu.Text = DataSearch.Rows[0]["MaChatLieu"].ToString();
                tbTenChatLieu.Text = DataSearch.Rows[0]["TenChatLieu"].ToString();
                tbTenChatLieu.Enabled = checkDeLuu = btnHuy.Enabled = btnLuu.Enabled =  true;
                quaylai = tbTenChatLieu.Text;
            }
            catch
            {

            }


        }

        private void dgvThongTinChatLieu_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                MessageBox.Text = $"Bạn muốn xóa chất liệu có mã là: {tbMaChatLieu.Text} Không!";
                MessageBox.Caption = "Thông báo!";
                if(MessageBox.Show() == DialogResult.Yes)
                {
                    Data.UpdateData("Delete from ChatLieu Where MaChatLieu = '" + tbMaChatLieu.Text + "'");
                }
            
                
            }
            catch
            {
                MessageBox.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                MessageBox.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MessageBox.Text = "Vẫn còn sản phẩm có chất liệu: "+tbTenChatLieu.Text + ". Bạn không thể xóa chất liệu này !";
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

        private void tbMaChatLieu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
