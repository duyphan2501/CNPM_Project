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
        BUS_TaiKhoan taikhoanbus = new BUS_TaiKhoan("", "", "", "", "", "");
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadAccount();
            //cboTrangthai.Text = "Hoạt Động";
            gridDsTaikhoan.Columns["btnUpdate"].DisplayIndex = gridDsTaikhoan.Columns.Count - 1; //đưa button về cuối
        }


        //Load tài khoản có hiệu lực
        public void LoadAccount()
        {
            
            gridDsTaikhoan.DataSource = taikhoanbus.LoadAccount();
            gridDsTaikhoan.RowTemplate.Height = 50;   //Chiều cao các hàng trong gridview
            cboTrangthai.SelectedItem = "Hoạt Động";
        }

        //Load tài khoản vô hiệu hóa
        public void LoadDisabledAccounts()
        {
            gridDsTaikhoan.DataSource = taikhoanbus.LoadDisabledAccounts();
            gridDsTaikhoan.RowTemplate.Height = 50;
            cboTrangthai.SelectedItem = "Vô Hiệu";
        }

        //Khi click tạo tài khoản thì chuyển form
        private void btnTaotaikhoan_Click(object sender, EventArgs e)
        {
            frmThem_SuaTaiKhoan themtk = new frmThem_SuaTaiKhoan();
            General.ShowDialogWithBlur(themtk);
            LoadAccount();

        }




        //Hiển thị danh sách tài khoản theo trạng thái
        private void cboTrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTrangthai.Text == "Hoạt Động")
            {
                LoadAccount();
            }
            else
            {
                LoadDisabledAccounts();
            }

        }



        //private void gridDsTaikhoan_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    taikhoanbus = new BUS_TaiKhoan("", "", "", "", "", "");
        //    DataGridViewRow hangduocchon = gridDsTaikhoan.SelectedRows[0];
        //    frmThemTaiKhoan capnhattk = new frmThemTaiKhoan(hangduocchon.Cells[1].Value.ToString(), hangduocchon.Cells[2].Value.ToString(), hangduocchon.Cells[3].Value.ToString(), hangduocchon.Cells[0].Value.ToString(), hangduocchon.Cells[4].Value.ToString());
        //    capnhattk.ShowDialog();
        //    LoadAccount();
        //}

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
            LoadAccount();
        }

        private void gridDsTaikhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
