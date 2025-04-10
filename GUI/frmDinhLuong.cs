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
    public partial class frmDinhLuong : Form
    {
        BUS_DinhLuong dinhluong;
        string Masp;
        public frmDinhLuong(string masp, string tensp)   //truyền mã sản phẩm và tên sản phẩm vào form định lượng
        {
            InitializeComponent();
            txtTenSp.Text = tensp;
            txtTenSp.ReadOnly = true;
            Masp = masp;
        }

        //Tải tên nguyên liệu lên combobox
        public void TaitenNL()
        {
            dinhluong = new BUS_DinhLuong("", "", 0);
            cboTenNguyenLieu.DataSource = dinhluong.TaiTenNL();
            cboTenNguyenLieu.DisplayMember = "TenNL";
        }

        //Load lại danh sách định lượng theo tên sản phẩm trên griview
        public void loadDsDinhluong()
        {
            dinhluong = new BUS_DinhLuong("", "", 0);
            gridDsDinhluong.DataSource = dinhluong.TaiDsDinhluong(txtTenSp.Text);

        }

        //Khi load form định lượng
        private void frmDinhLuong_Load(object sender, EventArgs e)
        {
            loadDsDinhluong();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            TaitenNL();
        }

        //Nút thêm để thêm định lượng vào database
        private void btnThem_Click(object sender, EventArgs e)
        {
            dinhluong = new BUS_DinhLuong("", "", 0);
            dinhluong.ThemDinhluong(Masp, cboTenNguyenLieu.Text, (int)numSoluongNL.Value);

            numSoluongNL.Value = 0;
            loadDsDinhluong();

        }

        //Nhấn nút xong khi đã thêm đủ danh sách định lượng
        private void btnXong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Nút Hủy
        //private void btnHuy_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.Cancel;
        //    this.Close();

        //}

        private void gridDsDinhluong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dinhluong = new BUS_DinhLuong("", "", 0);
            DataGridViewRow hangduocchon = gridDsDinhluong.SelectedRows[0];
            cboTenNguyenLieu.Text = hangduocchon.Cells["Tên nguyên liệu"].Value.ToString();
            numSoluongNL.Value = (int)hangduocchon.Cells["Số lượng"].Value;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dinhluong = new BUS_DinhLuong("", "", 0);
            dinhluong.SuaDinhluong(txtTenSp.Text, cboTenNguyenLieu.Text, (int)numSoluongNL.Value);
            loadDsDinhluong();
            frmDinhLuong_Load(sender, e);
        }

        private void gridDsDinhluong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
