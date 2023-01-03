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
using System.Windows.Markup;

namespace DuyThien_BTL.Childen
{
    public partial class QuanLyVocher : Form
    {
        AccessData access = new AccessData();
        CommondFunction common = new CommondFunction();
        bool CheckLuu = false;
        public QuanLyVocher()
        {
            InitializeComponent();
        }

        private void QuanLyVocher_Load(object sender, EventArgs e)
        {

            ShowTable();
            //Gán tiêu đề Cột trong datagridview
            dgvThongTinVoucher.Columns[0].HeaderText = "Mã Voucher";
            dgvThongTinVoucher.Columns[1].HeaderText = "Tên Voucher";
            dgvThongTinVoucher.Columns[2].HeaderText = "Phần Trăm";
            dgvThongTinVoucher.Columns[3].HeaderText = "Số Lượng";
            btnLuu.Enabled = btnHuy.Enabled = false;
            tbMaVoucher.Enabled = false;

            EnableTrue(false);
        }

        //Hàm ShowTable
        void ShowTable()
        {
            common.FillCombobox(cbbMaVoucherTK, access.ReadData("Select * from Voucher"), "TenVoucher", "MaVoucher");
            cbbMaVoucherTK.SelectedValue = "";
            cbbMaVoucherTK.Items.IndexOf(-1);
            dgvThongTinVoucher.DataSource = access.ReadData("Select * from Voucher");
        }
        //Hàm Enable
        void EnableTrue(bool check)
        {
            tbTenVoucher.Enabled = tbPhanTram.Enabled = tbSoLuong.Enabled = check;
        }
        //Kiểm tra đầu vào
        bool CheckNhap()
        {
            if(tbTenVoucher.Text.Trim() == "")
            {
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn chưa nhập Tên voucher";
                MessageGuna.Show();
                tbTenVoucher.Focus();
                return false;
            }
            else if(tbPhanTram.Text.Trim() == "")
            {
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn chưa nhập Phần Trăm giảm";
                MessageGuna.Show();
                tbPhanTram.Focus();
                return false;
            }
            else if (tbSoLuong.Text.Trim() == "")
            {
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                MessageGuna.Text = "Bạn chưa nhập Số Lượng Voucher";
                MessageGuna.Show();
                tbSoLuong.Focus();
                return false;
            }
            else if(int.Parse(tbPhanTram.Text) > 100)
            {
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                MessageGuna.Text = "Phần trăm không thể lớn hơn 100";
                MessageGuna.Show();
                tbPhanTram.Focus();
                return false;
            }
            

            if (dtNgayBatDau.Value > dtNgayKetThuc.Value)
            {
                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                MessageGuna.Text = "Ngày bắt đầu Voucher phải nhỏ hơn ngày kết thúc !";
                dtNgayBatDau.Focus();
                MessageGuna.Show();
                return false;
            }
            DataTable dtVoucher = access.ReadData("Select * from Voucher where TenVoucher = N'"+tbTenVoucher.Text+"'");
            if(dtVoucher.Rows.Count>0)
            {
                tbTenVoucher.Text = tbTenVoucher.Text.Trim();
                if (CheckLuu)
                {
                    for(int i=0;i<dtVoucher.Rows.Count;i++)
                    {
                        if (dtVoucher.Rows[i]["TenVoucher"].ToString().ToLower().Trim() == tbTenVoucher.Text.ToLower().Trim())
                        {
                            MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                            MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                            MessageGuna.Text = "Tên Voucher bạn nhập đã bị trùng !";
                            tbTenVoucher.Focus();
                            MessageGuna.Show();
                            tbTenVoucher.Text = "";
                            return false;
                        }    
                    }   
                }
                else
                {
                    DataTable CheckSua_Voucher1 = access.ReadData("Select TenVouCher from Voucher where MaVoucher = N'" + tbMaVoucher.Text + "'");
                    if (CheckSua_Voucher1.Rows[0]["TenVoucher"].ToString() != tbTenVoucher.Text)
                    {
                        DataTable CheckSua_Voucher2 = access.ReadData("Select TenVouCher from Voucher where TenVouCher = N'" + tbTenVoucher.Text + "'");
                        if (CheckSua_Voucher2.Rows.Count > 0)
                        {
                            MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                            MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                            MessageGuna.Text = "Tên Voucher bạn nhập đã bị trùng !";
                            MessageGuna.Caption = "Thông báo!";
                            MessageGuna.Show();
                            tbTenVoucher.Text = quaylai;
                            return false;
                        }
                    }
                }   
            }
            return true;
        }
        //Button Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = true;
            EnableTrue(true);
            cbbMaVoucherTK.Enabled = false;
            dgvThongTinVoucher.Enabled = false;

            //Tự sinh ra mã voucher
            tbMaVoucher.Text = common.AutoCode("Voucher", "MaVoucher", "VC");

            CheckLuu = true;

            dtNgayBatDau.Enabled = dtNgayKetThuc.Enabled = true;
        }
        //Button Lưu
        string quaylai = "";
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(CheckLuu)    //Thêm
            {
                if(!CheckNhap()) { }
                else
                {                  
                        
                    string sql = "Insert Voucher values (N'" + tbMaVoucher.Text + "', N'" + tbTenVoucher.Text + "'," + tbPhanTram.Text + " , " + tbSoLuong.Text + 
                        ", '"+ dtNgayBatDau.Value.ToString("MM/dd/yyyy") + "', '"+ dtNgayKetThuc.Value.ToString("MM/dd/yyyy") + "')";
                    access.UpdateData(sql);

                    MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MessageGuna.Text = "Thêm thành công";
                    MessageGuna.Show();
                    ShowTable();

                    btnHuy_Click(null, null);
                }
            }
            else            //Sửa
            {
                
                if (!CheckNhap()) { }
                else
                {
                    string sqlSua = "Update Voucher set " +
                        " TenVoucher = N'" + tbTenVoucher.Text + "' ,  PhanTram = " + tbPhanTram.Text + "  ,  SoLuong = " + tbSoLuong.Text + "  " +
                        " , NgayBatDau = '" + String.Format("{0:MM/dd/yyyy}", dtNgayBatDau.Value.ToString()) +"', NgayKetThuc = '"+ String.Format("{0:MM/dd/yyyy}", dtNgayKetThuc.Value.ToString()) + "'" +
                        " where MaVoucher = N'"+tbMaVoucher.Text+"'";

                    MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    MessageGuna.Text = "Sửa thành công";
                    MessageGuna.Show();
                    access.UpdateData(sqlSua);
                    ShowTable();
                    btnHuy_Click(null, null);
                }
                
            }
        }
        //String.Format("{0:MM/dd/yyyy}", dtNgayBatDau.Value.ToString())
        //Button Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            EnableTrue(false);
            btnThem.Enabled = true;
            btnLuu.Enabled = btnHuy.Enabled = false;
            dgvThongTinVoucher.Enabled = true;
            cbbMaVoucherTK.Enabled = true;

            tbMaVoucher.Text = tbTenVoucher.Text = tbPhanTram.Text = tbSoLuong.Text = "";

            ShowTable();

            dtNgayBatDau.Enabled = dtNgayKetThuc.Enabled = false;
        }

        //Phần trăm phải là số
        private void tbPhanTram_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //Button Đóng
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Sự kiện Cellclick
        private void dgvThongTinVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckLuu = false;
            tbMaVoucher.Text = dgvThongTinVoucher.CurrentRow.Cells[0].Value.ToString();
            tbTenVoucher.Text = dgvThongTinVoucher.CurrentRow.Cells[1].Value.ToString();
            tbPhanTram.Text = dgvThongTinVoucher.CurrentRow.Cells[2].Value.ToString();
            tbSoLuong.Text = dgvThongTinVoucher.CurrentRow.Cells[3].Value.ToString();
            dtNgayBatDau.Value = (DateTime) dgvThongTinVoucher.CurrentRow.Cells[4].Value;
            dtNgayKetThuc.Value = (DateTime) dgvThongTinVoucher.CurrentRow.Cells[5].Value;

            EnableTrue(true);
            btnThem.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = dtNgayBatDau.Enabled = dtNgayKetThuc.Enabled = true;
            cbbMaVoucherTK.Enabled = false;
            quaylai = tbTenVoucher.Text;
        }

        //Xóa voucher
        private void dgvThongTinVoucher_DoubleClick(object sender, EventArgs e)
        {
            MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            MessageGuna.Text = "Bạn có muốn xóa không ?";
            MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            if (MessageGuna.Show() == DialogResult.Yes)
            {
                string sqlXoa = "Delete from Voucher where MaVoucher = N'" + tbMaVoucher.Text + "'";
                access.UpdateData(sqlXoa);

                MessageGuna.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                MessageGuna.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                MessageGuna.Text = "Xóa thành công";
                MessageGuna.Show();
                ShowTable();

                btnHuy_Click(null, null);
            }


        }

        private void ibtnReset_Click(object sender, EventArgs e)
        {
            ShowTable();
        }


        private void cbbMaVoucherTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbMaVoucherTK.SelectedIndex == -1)
                {
                    btnThem.Enabled = true;
                    btnLuu.Enabled = btnHuy.Enabled = false;
                }
                else
                {
                    btnThem.Enabled = btnLuu.Enabled = false;
                    btnHuy.Enabled = true;
                    DataTable dtVoucher_TK = access.ReadData("Select * from Voucher where TenVoucher = N'" + cbbMaVoucherTK.Text + "'");
                    dgvThongTinVoucher.DataSource = dtVoucher_TK;

                }

            }
            catch
            {

            }
        }
    }
}
