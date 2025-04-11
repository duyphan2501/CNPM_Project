using BUS;
using cnpm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (!File.Exists("config.txt"))
            {
                this.Hide();
                frmConfig f = new frmConfig();
                f.ShowDialog();
            }
            txtUsername.Focus();
        }

        private void btnLogin_Enter(object sender, EventArgs e)
        {
            // hiện viền button khi được tab đến
            btnLogin.BorderThickness = 2;
        }

        private void btnLogin_Leave(object sender, EventArgs e)
        {
            // xoá viền button không được tab đến
            btnLogin.BorderThickness = 0;
        }

        private void picShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            // xoá passworChar khi giữ chuột
            txtPassword.PasswordChar = '\0';
        }

        private void picShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            // đặt lại passwordchar khi thả chuột
            txtPassword.PasswordChar = '•';
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        BUS_TaiKhoan taikhoan;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            string userName = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra đầu vào
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                messageDialog.Caption = "Thiếu thông tin";
                messageDialog.Text = "Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!";
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Show();

                txtUsername.Focus();
                return;
            }

            // Khởi tạo BUS và gọi kiểm tra đăng nhập
            taikhoan = new BUS_TaiKhoan(userName, password);
            Program.account = taikhoan.ValidateLoginAccount(password);

            // Kiểm tra kết quả
            if (Program.account != null)
            {
                string vaitro = Program.account.Rows[0]["VaiTro"].ToString();

                // Điều hướng theo vai trò
                if (vaitro.ToLower() == "thu ngân")
                {
                    frmBanHang frmBanHang = new frmBanHang();
                    frmBanHang.Show();
                }
                else
                {
                    frmAdmin frmAdmin = new frmAdmin();
                    frmAdmin.Show();
                }

                this.Hide(); // Ẩn form login
            }
            else
            {
                messageDialog.Caption = "Đăng nhập thất bại";
                messageDialog.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Show();

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }


        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void lblForgotpassword_Click(object sender, EventArgs e)
        {

        }
    }
}
