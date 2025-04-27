using BUS;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMoCaLam : Form
    {
        private bool isForceClose = false; // Cờ cho phép đóng form

        public frmMoCaLam()
        {
            InitializeComponent();
        }

        private void frmMoCaLam_Load(object sender, EventArgs e)
        {
            txtTienDauCa.Focus();
        }

        private void btnMoCaLam_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTienDauCa.Text.Trim(), out int soTien))
            {
                General.ShowError("Số tiền không hợp lệ. Vui lòng nhập lại.", this);
                txtTienDauCa.Focus();
                return;
            }

            string formattedMoney = soTien.ToString("#,##0") + " VND";

            if (General.ShowConfirm($"Bạn xác nhận mở ca với số tiền: {formattedMoney}?", this) == DialogResult.Yes)
            {
                try
                {
                    string tenDangNhap = Program.account.Rows[0]["TenDangNhap"].ToString();
                    var calamBUS = new BUS_CaLamViec(
                        DateTime.Now, null, "", soTien, 0, tenDangNhap
                    );

                    calamBUS.InsertCaLamViec();
                    Program.shift = calamBUS.SelectOpenShift(tenDangNhap);

                    isForceClose = true; // Cho phép đóng form
                    this.Close();
                }
                catch (Exception ex)
                {
                    General.ShowError("Đã xảy ra lỗi khi mở ca: " + ex.Message, this);
                }
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Program.account.Clear();

            // Đóng tất cả các form ngoài frmLogin
            foreach (Form frm in Application.OpenForms.Cast<Form>().ToList())
            {
                if (!(frm is frmLogin)) // Chỉ giữ lại frmLogin
                    frm.Close();
            }

            // Tạo và hiển thị lại frmLogin
            frmLogin loginForm = new frmLogin();
            loginForm.Show(); // Mở lại frmLogin
            loginForm.BringToFront(); // Đưa frmLogin lên phía trước

            // Đóng form hiện tại (có thể là frmBanHang, frmAdmin,...)
            this.Close();
        }


        private void frmMoCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isForceClose && e.CloseReason == CloseReason.UserClosing)
            {
                if (General.ShowConfirm("Bạn phải mở ca để tiếp tục sử dụng phần mềm.\nBạn có muốn thoát phần mềm không?", this) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void txtTienDauCa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }

            // Kiểm tra giá trị sau khi người dùng nhập một ký tự mới
            string currentText = txtTienDauCa.Text + e.KeyChar;
            if (long.TryParse(currentText, out long result))
            {
                if (result > 100000000) // Giới hạn giá trị 
                {
                    e.Handled = true; // Không cho phép nhập khi vượt quá giới hạn
                    General.ShowError("Số tiền vượt quá giới hạn. Vui lòng nhập lại!", this);
                }
            }
        }

    }
}
