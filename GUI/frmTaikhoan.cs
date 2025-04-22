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
    public partial class frmTaiKhoan : Form
    {
        BUS_TaiKhoan taiKhoanBus = new BUS_TaiKhoan("", "", "", "", "", "");
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadAccountsByStatus("Hoạt Động"); //mở form thì load danh sách tài khoản còn hoạt động
            //cboTrangthai.Text = "Hoạt Động";
            gridDsTaikhoan.Columns["btnUpdate"].DisplayIndex = gridDsTaikhoan.Columns.Count - 1; //đưa button kí hiệu sửa về cuối
        }

        //Hàm tài danh sách tài khoản theo trạng thái
        private void LoadAccountsByStatus(string status)
        {
            if (status == "Hoạt Động")
                gridDsTaikhoan.DataSource = taiKhoanBus.LoadAccount();
            else
                gridDsTaikhoan.DataSource = taiKhoanBus.LoadDisabledAccounts();

            gridDsTaikhoan.RowTemplate.Height = 50;
            cboTrangthai.SelectedItem = status;
        }

        //Khi click tạo tài khoản thì chuyển sang form Them_SuaTaiKhoan
        private void btnTaotaikhoan_Click(object sender, EventArgs e)
        {
            frmThem_SuaTaiKhoan themtk = new frmThem_SuaTaiKhoan();
            General.ShowDialogWithBlur(themtk);
            LoadAccountsByStatus("Hoạt Động");
        }


        //Hiển thị danh sách tài khoản theo trạng thái
        private void cboTrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccountsByStatus(cboTrangthai.Text);
        }

        //Khi click vào button sửa tài khoản thì chuyển sang form Them_SuaTaiKhoan và đưa thông tin tài khoản được chọn vào form
        private void gridDsTaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // không làm gì khi click vào header hoặc các cột khác ngoài cột btnUpdate
            if (e.RowIndex < 0 || e.ColumnIndex != gridDsTaikhoan.Columns["btnUpdate"].Index)
            {
                return;
            }
            DataGridViewRow hangduocchon = gridDsTaikhoan.SelectedRows[0];
            string tendangnhap = hangduocchon.Cells["Tên đăng nhập"].Value.ToString();
            string trangthai = hangduocchon.Cells["Trạng thái"].Value.ToString();
            string vaitro = hangduocchon.Cells["Vai trò"].Value.ToString();
            string hoten = hangduocchon.Cells["Họ tên"].Value.ToString();
            string email = hangduocchon.Cells["Email"].Value.ToString();

            frmThem_SuaTaiKhoan capnhattk = new frmThem_SuaTaiKhoan(tendangnhap, trangthai , vaitro, hoten, email);
            capnhattk.ShowDialog();
            LoadAccountsByStatus(cboTrangthai.Text);
        }
    }
}
