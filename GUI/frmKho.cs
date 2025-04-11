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
    public partial class frmKho : Form
    {
        BUS_NguyenLieu nguyenlieubus = new BUS_NguyenLieu("", "", "", "", 0);
        public frmKho()
        {
            InitializeComponent();
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            LoadNguyenLieu();
            TaiTenLoai();
            gbThongtinnguyenlieu.Enabled = false;
            btnThemNguyenlieu.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
        }

        public void LoadNguyenLieu()
        {
            gridDsNguyenlieu.RowTemplate.Height = 50;
            gridDsNguyenlieu.DataSource = nguyenlieubus.TaiNguyenlieu();
            gridDsNguyenlieu.Columns["btnUpdate"].DisplayIndex = gridDsNguyenlieu.Columns.Count - 1; //đưa button về cuối

        }

        public void TaiTenLoai()
        {
            cboTenloai.DataSource = nguyenlieubus.TaiLoaiNguyenLieu();
            cboTenloai.DisplayMember = "TenLoai";
        }

        private void picThemLoai_Click(object sender, EventArgs e)
        {
            frmThemLoaiNguyenLieu loainguyenlieu = new frmThemLoaiNguyenLieu();
            loainguyenlieu.ShowDialog();

            TaiTenLoai();
        }

        private void btnThemNguyenlieu_Click(object sender, EventArgs e)
        {
            gbThongtinnguyenlieu.Enabled = true;
            txtMaNguyenLieu.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            txtTenNguyenLieu.Clear();
            txtDonvitinh.Clear();
            numSoluong.Value = 0;

            txtMaNguyenLieu.Text = nguyenlieubus.PhatSinhMaNL();
            txtMaNguyenLieu.ReadOnly = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmKho_Load(sender, e);
            btnThemNguyenlieu.Enabled = true;   
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNguyenLieu.Enabled == true)
            {
                nguyenlieubus.ThemNguyenLieu(txtMaNguyenLieu.Text, cboTenloai.Text, txtTenNguyenLieu.Text, txtDonvitinh.Text, (int)numSoluong.Value);
                LoadNguyenLieu();
            }
            else
            {
                nguyenlieubus.SuathongtinNL(txtMaNguyenLieu.Text, cboTenloai.Text, txtTenNguyenLieu.Text, txtDonvitinh.Text, (int)numSoluong.Value);
                LoadNguyenLieu();
            }
            frmKho_Load(sender, e);

        }

        private void gridDsNguyenlieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // không làm gì khi click vào header hoặc các cột khác ngoài cột btnUpdate
            if (e.RowIndex < 0 || e.ColumnIndex != gridDsNguyenlieu.Columns["btnUpdate"].Index)
            {
                return;
            }
            DataGridViewRow hangduocchon = gridDsNguyenlieu.SelectedRows[0];
            txtMaNguyenLieu.Text = hangduocchon.Cells["Mã nguyên liệu"].Value.ToString();
            cboTenloai.Text = hangduocchon.Cells["Tên loại"].Value.ToString();
            txtTenNguyenLieu.Text = hangduocchon.Cells["Tên nguyên liệu"].Value.ToString();
            numSoluong.Value = Convert.ToDecimal(hangduocchon.Cells["Số lượng"].Value);
            txtDonvitinh.Text = hangduocchon.Cells["Đơn vị tính"].Value.ToString();

            gbThongtinnguyenlieu.Enabled = true;
            txtMaNguyenLieu.Enabled = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThemNguyenlieu.Enabled = false;
        }
    }
}
