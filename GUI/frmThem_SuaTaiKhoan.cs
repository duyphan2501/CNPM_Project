using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class frmThem_SuaTaiKhoan : Form
    {
        BUS_TaiKhoan taikhoanbus = new BUS_TaiKhoan("", "", "", "", "", "");
        private bool isUpdateMode;

        //Truyền các tham số từ form TaiKhoan vào form Them_SuaTaiKhoan để có thể Update tài khoản
        public frmThem_SuaTaiKhoan(string tenDangNhap = null, string trangThai = null, string vaiTro = null, string hoTen = null, string email = null)
        {
            InitializeComponent();

            isUpdateMode = !string.IsNullOrEmpty(tenDangNhap); //Biến cờ trạng thái để xác định xem có phải là chế độ cập nhật hay không

            if (isUpdateMode) 
            {
                txtTendangnhap.Text = tenDangNhap;
                btnToggleSwitchTrangThai.Checked = trangThai == true.ToString();
                cboVaitro.Text = vaiTro;
                txtHoten.Text = hoTen;
                txtEmail.Text = email;

                txtTendangnhap.ReadOnly = true;
                txtMatkhau.Enabled = false;
            }
        }



        //Biến cập nhật giá trị trạng thái
        string trangThai = "0";

        //Nếu công tắc bậc thì trạng thái là 1
        private void btnToggleSwitchTrangThai_CheckedChanged(object sender, EventArgs e)
        {
            trangThai = btnToggleSwitchTrangThai.Checked ? "1" : "0";
        }


        //Hàm kiểm tra định dạng email
        bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //Hàm kiểm tra xem tài khoan đã tồn tại hay chưa
        private bool IsUsernameExists(string tenDN)
        {
            foreach (DataRow row in taikhoanbus.LoadAccount().Rows) //Tải tài khoản từ database
            {
                if (row["Tên đăng nhập"].ToString() == tenDN)
                    return true;
            }
            return false;
        }


        //Hàm kiểm tra các lỗi nhập liêu
        private bool ValidateInput()
        {
            if (!isUpdateMode && IsUsernameExists(txtTendangnhap.Text))
            {
                General.ShowWarning("Tên đăng nhập đã tồn tại.",this);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoten.Text))
            {
                General.ShowWarning("Vui lòng nhập họ tên.",this);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTendangnhap.Text))
            {
                General.ShowWarning("Vui lòng nhập tên đăng nhập.",this);
                return false;
            }

            if (txtMatkhau.Enabled && string.IsNullOrWhiteSpace(txtMatkhau.Text))
            {
                General.ShowWarning("Vui lòng nhập mật khẩu.",this);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                General.ShowWarning("Vui lòng nhập email.",this);
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                General.ShowWarning("Email không hợp lệ.",this);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboVaitro.Text))
            {
                
                General.ShowWarning("Vui lòng chọn vai trò.",this);
                return false;
            }
            return true;
        }

        //Khi nhấn nút lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;  //Lỗi nhập liệu thì không thực hiện gì cả

            if (isUpdateMode) //Nếu trạng thái cập nhật khoản
            {
                taikhoanbus.UpdateAccount(txtTendangnhap.Text, trangThai, cboVaitro.Text, txtHoten.Text, txtEmail.Text);
                General.ShowInformation("Cập nhật tài khoản thành công", this);

            }
            else  //Nếu trạng thái thêm tài khoản
            {
                taikhoanbus.AddAccount(txtTendangnhap.Text, txtMatkhau.Text, trangThai, cboVaitro.Text, txtHoten.Text, txtEmail.Text);
                General.ShowInformation("Tạo tài khoản thành công", this);

            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Nút hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmThemTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        //gợi ý nhập email
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string input = txtEmail.Text;

            // Kiểm tra xem chuỗi hiện tại có chứa "@gmail.com" hay không
            if (!input.Contains("@") && input.Length > 0)
            {
                txtEmail.Text = input + "@gmail.com"; // Thêm "@gmail.com"
                txtEmail.SelectionStart = input.Length; // Đặt con trỏ sau phần vừa nhập
            }
        }
    }
}
