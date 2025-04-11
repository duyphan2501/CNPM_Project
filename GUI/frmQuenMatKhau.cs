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

            // tạo mã 6 chũ số
            Random rand = new Random();
            resetCode = (rand.Next(999999)).ToString();

            // set up gửi mail
            String from, to, pass, messageBody;
            MailMessage message = new MailMessage();
            from = "duyphan2501@gmail.com";
            to = (email).Trim().ToString();
            pass = "fhwmkqpzuysppsfm";
            messageBody = "Mã xác thực là: " + resetCode;
            message.From = new MailAddress(from);
            message.To.Add(to);
            message.Body = messageBody;
            message.Subject = "Lấy lại mật khẩu";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            // gửi mail
            try
            {
                smtp.Send(message);
                MessageBox.Show("Mã xác thực đã được gửi đến email của bạn");
                grpStep2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show("Mã xác thực không đúng");
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
                messageDialog.Text = "Đặt lại mật khẩu thành công.";
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Show();
                // update lại trong db
                taikhoan.updatePassword(txtUsername.Text, password);
                // trở về login
                this.Close();
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
            }

        }

        private void picReturn_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin frmLogin = new frmLogin(); 
            frmLogin.Show();
        }
    }
}
