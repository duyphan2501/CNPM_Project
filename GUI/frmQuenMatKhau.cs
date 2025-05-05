using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
namespace GUI
{
    public partial class frmQuenMatKhau : Form
    {
        public frmQuenMatKhau()
        {
            InitializeComponent();
        }

        string resetCode;
        BUS_TaiKhoan taikhoan;

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            // Lấy email của tài khoản
            taikhoan = new BUS_TaiKhoan(txtUsername.Text);
            string email = taikhoan.SelectOneAccount().Rows[0]["email"].ToString();

            // Tạo mã 6 chữ số
            Random rand = new Random();
            resetCode = (rand.Next(100000, 999999)).ToString(); // Đảm bảo đủ 6 chữ số

            // Set up gửi mail
            string from = "duyphan2501@gmail.com";
            string to = email.Trim();
            string pass = "fhwmkqpzuysppsfm";
            string messageBody = "Mã xác thực là: " + resetCode;

            MailMessage message = new MailMessage(from, to, "Lấy lại mật khẩu", messageBody);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(from, pass)
            };

            try
            {
                smtp.Send(message);

                messageDialog.Caption = "Thành công";
                messageDialog.Text = "Mã xác thực đã được gửi đến email của bạn.";
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Show();

                grpStep2.Enabled = true;
            }
            catch (Exception ex)
            {
                messageDialog.Caption = "Lỗi";
                messageDialog.Text = ex.Message;
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Show();
            }
        }


        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            if (txtResetCode.Text == resetCode)
            {
                grpStep3.Enabled = true;
            }
            else
            {
                messageDialog.Caption = "Sai mã xác thực";
                messageDialog.Text = "Mã xác thực không đúng. Vui lòng kiểm tra lại.";
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Show();
            }
        }


        private void frmQuenMatKhau_Load(object sender, EventArgs e)
        {
            grpStep2.Enabled = false;
            grpStep3.Enabled = false;
        }

        private void btnClearPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtConfirmPass.Text = "";
            txtPassword.Focus();
        }

        private void btnComfirmPass_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPass.Text.Trim();

            // kiểm tra đầu vào
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                messageDialog.Caption = "Thiếu thông tin";
                messageDialog.Text = "Vui lòng nhập đầy đủ mật khẩu và xác nhận mật khẩu.";
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Show();
                return;
            }
            // kiểm tra mật khẩu xác nhận
            if (password != confirmPassword)
            {
                messageDialog.Caption = "Không khớp";
                messageDialog.Text = "Mật khẩu và xác nhận mật khẩu không trùng khớp!";
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Show();
                txtConfirmPass.Clear();
                txtConfirmPass.Focus();
            }
            else
            {
                // thành công
                messageDialog.Caption = "Thành công";
                messageDialog.Text = "Đặt lại mật khẩu thành công. Vui lòng đăng nhập lại!";
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Show();
                // update lại trong db
                taikhoan.UpdatePassword(txtUsername.Text, password);
                // trở về login
                Application.Restart();
            }

        }

        private void picReturn_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                this.Close();
            }
            else 
            { 
                this.Close();
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
            }
        }
    }
}
