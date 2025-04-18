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
        BUS_NguyenLieu nguyenlieubus = new BUS_NguyenLieu("", "", "", "", 0, 0, 0);
        public frmKho()
        {
            InitializeComponent();

        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            pnlThongtinNL.Visible = false;
            LoadNguyenLieu();
            TaiTenLoai();
            pnlThongtinNL.Enabled = false;
            btnThemNguyenlieu.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;

        }

        public void LoadNguyenLieu()
        {
            gridDsNguyenlieu.RowTemplate.Height = 50;
            gridDsNguyenlieu.DataSource = nguyenlieubus.LoadIngredients();
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
            General.ShowDialogWithBlur(loainguyenlieu);

            TaiTenLoai();
        }

        private void btnThemNguyenlieu_Click(object sender, EventArgs e)
        {
            pnlThongtinNL.Visible = true;
            pnlThongtinNL.Enabled = true;
            txtMaNguyenLieu.Enabled = true;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            txtTenNguyenLieu.Clear();
            txtDonvitinh.Clear();

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
            DataTable dt = nguyenlieubus.LoadIngredients_name(); //tải danh sách tên nguyên liêu
            bool tontai = false;
            foreach (DataRow row in dt.Rows)
            {
                if (row["TenNL"].ToString() == txtTenNguyenLieu.Text && txtMaNguyenLieu.Enabled == true)
                {
                    tontai = true;
                }
            }
            if (tontai == true)
            {
                MessageBox.Show("Đã tồn tại tên nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtMaNguyenLieu.Enabled == true)
                {
                    nguyenlieubus.AddIngredients(txtMaNguyenLieu.Text, cboTenloai.Text, txtTenNguyenLieu.Text, txtDonvitinh.Text, Convert.ToInt32(numMuctoithieu.Value), Convert.ToInt32(numMucondinh.Value));
                    LoadNguyenLieu();

                }
                else
                {
                    nguyenlieubus.UpdateIngredients(txtMaNguyenLieu.Text, cboTenloai.Text, txtTenNguyenLieu.Text, txtDonvitinh.Text, Convert.ToInt32(numMuctoithieu.Value), Convert.ToInt32(numMucondinh.Value));
                    LoadNguyenLieu();
                }
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
            txtDonvitinh.Text = hangduocchon.Cells["Đơn vị tính"].Value.ToString();
            numMuctoithieu.Value = Convert.ToDecimal(hangduocchon.Cells["Mức tối thiểu"].Value);
            numMucondinh.Value = Convert.ToDecimal(hangduocchon.Cells["Mức ổn định"].Value);

            pnlThongtinNL.Enabled = true;
            txtMaNguyenLieu.Enabled = false;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            btnThemNguyenlieu.Enabled = false;
            pnlThongtinNL.Visible = true;
        }

        private void gridDsNguyenlieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlThongtinNL.Visible = false;
            btnThemNguyenlieu.Enabled = true;
        }
    }
}
