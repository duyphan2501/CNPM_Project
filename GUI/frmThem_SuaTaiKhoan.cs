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
        BUS_TaiKhoan taikhoanbus;
        private bool isUpdateMode;
        public frmThem_SuaTaiKhoan(string tenDangNhap = null, string trangThai = null, string vaiTro = null, string hoTen = null, string email = null)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(tenDangNhap)) // Nếu có dữ liệu, chế độ Update
            {
                isUpdateMode = true;
                txtTendangnhap.Text = tenDangNhap;
                if(trangThai == "1")
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
                txtTendangnhap.Enabled = false; // Không cho sửa tên đăng nhập khi cập nhật
                txtMatkhau.Enabled = false; // Không cho sửa tài khoản khi cập nhật
            }
            else
            {
                isUpdateMode = false;
            }
        }

       

        //Biến cập nhật giá trị trạng thái
        string trangthai;

        //Nếu công tắc bậc thì trạng thái là 1
        private void btnToggleSwitchTrangThai_CheckedChanged(object sender, EventArgs e)
        {
            if (btnToggleSwitchTrangThai.Checked == true) {
                trangthai = "1";
            }
            else
            {
                trangthai = "0";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            taikhoanbus = new BUS_TaiKhoan("", "", "", "", "", "");
            if (isUpdateMode == false)  //Thêm tài khoản
            {
                taikhoanbus.ThemTaiKhoan(txtTendangnhap.Text, txtMatkhau.Text, trangthai, cboVaitro.Text, txtHoten.Text, txtEmail.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else   //Cập nhật tài khoản
            {
                taikhoanbus.SuaTaiKhoan(txtTendangnhap.Text,trangthai,cboVaitro.Text,txtHoten.Text,txtEmail.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
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
    }
}
