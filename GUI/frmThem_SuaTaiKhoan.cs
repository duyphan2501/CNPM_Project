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
        public frmThem_SuaTaiKhoan(string tenDangNhap = null, string trangThai = null, string vaiTro = null, string hoTen = null, string email = null)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(tenDangNhap)) // Nếu có dữ liệu, chế độ Update
            {
                isUpdateMode = true;
                txtTendangnhap.Text = tenDangNhap;
                if (trangThai == true.ToString())
                {
                    btnToggleSwitchTrangThai.Checked = true;
                }
                else
                {
                    btnToggleSwitchTrangThai.Checked = false;
                }
                cboVaitro.Text = vaiTro;
                txtHoten.Text = hoTen;
                txtEmail.Text = email;
                txtTendangnhap.ReadOnly = true; // Không cho sửa tên đăng nhập khi cập nhật
                txtMatkhau.Enabled = false; // Không cho sửa tài khoản khi cập nhật
            }
            else
            {
                isUpdateMode = false;
            }
        }



        //Biến cập nhật giá trị trạng thái
        string trangthai = "0";

        //Nếu công tắc bậc thì trạng thái là 1
        private void btnToggleSwitchTrangThai_CheckedChanged(object sender, EventArgs e)
        {
            if (btnToggleSwitchTrangThai.Checked == true)
            {
                trangthai = "1";
            }
            else
            {
                trangthai = "0";
            }
        }


        //Kiểm tra định dạng email
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

        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool datontai = false;
            string tenDN = txtTendangnhap.Text;  //Tên đăng nhập đăng nhập vào
            DataTable dt = taikhoanbus.LoadAccount();
            foreach (DataRow row in dt.Rows)  
            {
                string tendangnhap = row["Tên đăng nhập"].ToString();  // duyệt qua các tên đăng nhập đăng có
                if(tendangnhap == tenDN && txtTendangnhap.ReadOnly == false)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    datontai = true;
                }
            }
            if (datontai == false)
            {
                if (string.IsNullOrEmpty(txtHoten.Text) ||  //check thông tin nhập vào không được bỏ trống
                    string.IsNullOrEmpty(cboVaitro.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Thông tin không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!IsValidEmail(txtEmail.Text))  //check định dạng email
                {
                    MessageBox.Show("Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((string.IsNullOrEmpty(txtTendangnhap.Text) || string.IsNullOrEmpty(txtMatkhau.Text)) && isUpdateMode == false) //Trường hợp  thêm tài khoản thì check thêm tên đăng nhập và mật khẩu
                {
                    MessageBox.Show("Thông tin không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (isUpdateMode == false)  //Thêm tài khoản
                {
                    taikhoanbus.AddAccount(txtTendangnhap.Text, txtMatkhau.Text, trangthai, cboVaitro.Text, txtHoten.Text, txtEmail.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else   //Cập nhật tài khoản
                {
                    taikhoanbus.UpdateAccount(txtTendangnhap.Text, trangthai, cboVaitro.Text, txtHoten.Text, txtEmail.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
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
