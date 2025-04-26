using BUS;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace GUI
{
    public partial class frmMoCaLam : Form
    {
        public frmMoCaLam()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtTienDauCa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép số và phím điều khiển (như backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void btnMoCaLam_Click(object sender, EventArgs e)
        {
            // Lấy giá trị số tiền từ TextBox và chuyển thành kiểu int (có thể dùng decimal nếu cần)
            if (int.TryParse(txtTienDauCa.Text, out int soTien))
            {
                // Định dạng số tiền theo kiểu tiền tệ (hàng nghìn)
                string formattedMoney = soTien.ToString("#,##0");

                // Hiển thị GunaMessageBox với số tiền đã được định dạng và yêu cầu xác nhận
                messageDialog.Text = "Số tiền bạn muốn mở ca là: " + formattedMoney + " VND.\nBạn có chắc chắn muốn mở ca?";
                messageDialog.Caption = "Xác nhận mở ca";
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;  // Các nút Yes/No
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question; // Biểu tượng câu hỏi

                // Hiển thị Guna2MessageDialog và nhận kết quả
                DialogResult result = messageDialog.Show();

                if (result == DialogResult.Yes)
                {
                    string tenDangNhap = Program.account.Rows[0]["TenDangNhap"].ToString();
                    BUS_CaLamViec calamBUS = new BUS_CaLamViec(
                        DateTime.Now,            // TgBatDau
                        null,                    // TgKetThuc = null
                        "",                      // GhiChu
                        soTien,               // TienDauCa
                        0,                       // TienCuoiCa
                        tenDangNhap
                    );

                    calamBUS.InsertCaLamViec();
                    Program.shift = calamBUS.SelectOpenShift(tenDangNhap);
                    this.Close();
                }
            }
            else
            {
                // Hộp thoại lỗi khi nhập không hợp lệ
                Guna.UI2.WinForms.Guna2MessageDialog errorDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
                errorDialog.Caption = "Lỗi";
                errorDialog.Text = "Số tiền không hợp lệ. Vui lòng nhập lại.";
                errorDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                errorDialog.Show();
            }
        }
        private void frmMoCaLam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Nếu người dùng cố bấm Alt+F4 hoặc bấm X để tắt
                DialogResult result = MessageBox.Show(
                    "Bạn phải mở ca để tiếp tục sử dụng phần mềm.\nBạn có muốn thoát phần mềm không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Không cho đóng
                }
                else
                {
                    Application.Exit(); // Đóng luôn cả phần mềm
                }
            }
        }

    }
}
