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
        BUS_TaiKhoan taikhoanbus;
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadTK();
            cboTrangthai.Text = "Hoạt Động";
            gridDsTaikhoan.Columns["btnUpdate"].DisplayIndex = gridDsTaikhoan.Columns.Count - 1; //đưa button về cuối
        }


        //Load tài khoản có hiệu lực
        public void LoadTK()
        {
            taikhoanbus = new BUS_TaiKhoan("", "", "", "", "", "");
            gridDsTaikhoan.DataSource = taikhoanbus.TaiTK();
            cboTrangthai.SelectedItem = "Hoạt Động";
        }

        //Load tài khoản vô hiệu hóa
        public void LoadTK1()
        {
            taikhoanbus = new BUS_TaiKhoan("", "", "", "", "", "");
            gridDsTaikhoan.DataSource = taikhoanbus.TaiTK1();
            cboTrangthai.SelectedItem = "Vô Hiệu";
        }

        //Khi clik tạo tài khoản thì chuyển form
        private void btnTaotaikhoan_Click(object sender, EventArgs e)
        {
            frmThem_SuaTaiKhoan themtk = new frmThem_SuaTaiKhoan();
            themtk.ShowDialog();
            LoadTK();
        }

        

       
        //Hiển thị danh sách tài khoản theo trạng thái
        private void cboTrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTrangthai.Text == "Hoạt Động")
            {
                LoadTK();
            }
            else
            {
                LoadTK1();
            }

        }

        

        //private void gridDsTaikhoan_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    taikhoanbus = new BUS_TaiKhoan("", "", "", "", "", "");
        //    DataGridViewRow hangduocchon = gridDsTaikhoan.SelectedRows[0];
        //    frmThemTaiKhoan capnhattk = new frmThemTaiKhoan(hangduocchon.Cells[1].Value.ToString(), hangduocchon.Cells[2].Value.ToString(), hangduocchon.Cells[3].Value.ToString(), hangduocchon.Cells[0].Value.ToString(), hangduocchon.Cells[4].Value.ToString());
        //    capnhattk.ShowDialog();
        //    LoadTK();
        //}

        private void gridDsTaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            taikhoanbus = new BUS_TaiKhoan("", "", "", "", "", "");
            DataGridViewRow hangduocchon = gridDsTaikhoan.SelectedRows[0];
            frmThem_SuaTaiKhoan capnhattk = new frmThem_SuaTaiKhoan(hangduocchon.Cells["Tên đăng nhập"].Value.ToString(), hangduocchon.Cells["Trạng thái"].Value.ToString(), hangduocchon.Cells["Vai trò"].Value.ToString(), hangduocchon.Cells["Họ tên"].Value.ToString(), hangduocchon.Cells["Email"].Value.ToString());
            capnhattk.ShowDialog();
            LoadTK();
        }
    }
}
