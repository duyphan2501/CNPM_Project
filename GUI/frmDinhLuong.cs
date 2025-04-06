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

        //Tải tên sản phẩm lên combobox
        //public void TaitenSp()
        //{
        //    dinhluong = new BUS_DinhLuong("", "", 0);
        //    cboTenSp.DataSource = dinhluong.TaiTenSp();
        //    cboTenSp.DisplayMember = "TenSp";
        //}

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
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
