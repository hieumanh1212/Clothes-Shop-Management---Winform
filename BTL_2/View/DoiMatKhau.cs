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

namespace DuyThien_BTL.Childen
{
    public partial class DoiMatKhau : Form
    {
        AccessData dataAccess = new AccessData();
        string manhanvien = "";
        public DoiMatKhau(String manhanvien)
        {
            InitializeComponent();
            this.manhanvien = manhanvien;
        }
        
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string sql = $"select * from tblUser where MaNV='{this.manhanvien}'";
            DataTable dataTable = dataAccess.ReadData(sql);
            if (txtOldPass.Text != (string)dataTable.Rows[0]["MatKhau"])
            {
                Message.Icon = MessageDialogIcon.Information;
                Message.Buttons = MessageDialogButtons.OK;
                Message.Text = "Mật khẩu cũ không chính xác";
                Message.Show();

                txtOldPass.Focus();
            }
            else
            {
                if(txtPassword.Text.Trim() == "" && txtConfirmPass.Text.Trim() == "")
                {
                    Message.Icon = MessageDialogIcon.Information;
                    Message.Buttons = MessageDialogButtons.OK;
                    Message.Text = "Không được bỏ trống";
                    Message.Show();
                }
                else
                {
                    if (txtPassword.Text==txtConfirmPass.Text && txtConfirmPass.Text== (string)dataTable.Rows[0]["MatKhau"])
                    {
                        Message.Icon = MessageDialogIcon.Information;
                        Message.Buttons = MessageDialogButtons.OK;
                        Message.Text = "Mật khẩu mới không được giống mật khẩu cũ";
                        Message.Show();
                    }
                    if (txtPassword.Text != txtConfirmPass.Text)
                    {
                        Message.Icon = MessageDialogIcon.Information;
                        Message.Buttons = MessageDialogButtons.OK;
                        Message.Text = "Xác nhận mật khẩu chưa chính xác";
                        Message.Show();
                    }
                    if (txtPassword.Text == txtConfirmPass.Text && txtConfirmPass.Text != (string)dataTable.Rows[0]["MatKhau"])
                    {
                        Message.Buttons = MessageDialogButtons.YesNo;
                        Message.Icon = MessageDialogIcon.Question;
                        Message.Text = $"Bạn đồng ý đổi mật khẩu không ?";
                        if (Message.Show()==DialogResult.Yes)
                        {
                            //MessageBox.Show("1");
                            sql = "update tblUser " +
                                $"set MatKhau='{txtPassword.Text}'" +
                                $"where MaNV='{this.manhanvien}'";
                            dataAccess.UpdateData(sql);

                            Message.Icon = MessageDialogIcon.Information;
                            Message.Buttons = MessageDialogButtons.OK;
                            Message.Text = "Đổi mật khẩu thành công";
                            Message.Show();

                            txtPassword.Text = "";
                            txtPassword.Text = "";
                            txtConfirmPass.Text = "";

                        }
                    }
                }
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtOldPass.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }
        //OldPass
        private void ShowPassOld_Click(object sender, EventArgs e)
        {
            if (txtOldPass.PasswordChar == '●')
            {
                HidePassOld.BringToFront();
                txtOldPass.PasswordChar = '\0';
            }
        }

        private void HidePassOld_Click(object sender, EventArgs e)
        {
            if (txtOldPass.PasswordChar == '\0')
            {
                ShowPassOld.BringToFront();
                txtOldPass.PasswordChar = '●';
            }
        }
        //New Pass
        private void ShowPassNew_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
            {
                HidePassNew.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void HidePassNew_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                ShowPassNew.BringToFront();
                txtPassword.PasswordChar = '●';
            }
        }

        //Confirm Pass
        private void ShowConfirm_Click(object sender, EventArgs e)
        {
            if (txtConfirmPass.PasswordChar == '●')
            {
                HideConfirm.BringToFront();
                txtConfirmPass.PasswordChar = '\0';
            }
        }

        private void HideConfirm_Click(object sender, EventArgs e)
        {
            if (txtConfirmPass.PasswordChar == '\0')
            {
                ShowConfirm.BringToFront();
                txtConfirmPass.PasswordChar = '●';
            }
        }
    }
}
