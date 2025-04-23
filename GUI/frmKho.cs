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

            if (this.Modal)   //nếu mở từ xuất nhập
            {
                pnlThongtinNL.Visible = false;
                btnThemNguyenlieu.Visible = false;
                btnTrolai.Visible = true;
                LoadNguyenLieu();
            }
            else  //nếu chạy trực tiếp
            {
                btnTrolai.Visible = false;
                pnlThongtinNL.Visible = false;
                LoadNguyenLieu();
                TaiTenLoai();
                pnlThongtinNL.Enabled = false;
                btnThemNguyenlieu.Enabled = true;
                btnThemNguyenlieu.Visible = true;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                txtMaNguyenLieu.Enabled = true;
            }
        }

        public void LoadNguyenLieu()
        {
            gridDsNguyenlieu.RowTemplate.Height = 50;
            gridDsNguyenlieu.DataSource = nguyenlieubus.LoadIngredients();
            gridDsNguyenlieu.Columns["btnUpdate"].DisplayIndex = gridDsNguyenlieu.Columns.Count - 1;

        }

        public void TaiTenLoai()
        {
            cboTenloai.DataSource = nguyenlieubus.LoadIngredients_type();
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

            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThemNguyenlieu.Enabled = false;

            
            txtMaNguyenLieu.Focus();
            txtTenNguyenLieu.Clear();
            txtDonvitinh.Clear();
            numMuctoithieu.Value = 0;
            numMucondinh.Value = 0;

            txtMaNguyenLieu.Text = nguyenlieubus.PhatSinhMaNL();
            txtMaNguyenLieu.ReadOnly = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmKho_Load(sender, e);
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string manl = txtMaNguyenLieu.Text;
            string tenloai = cboTenloai.Text;
            string tennl = txtTenNguyenLieu.Text;
            string donvi = txtDonvitinh.Text;
            int muctoithieu = (int)numMuctoithieu.Value;
            int mucondinh = (int)numMucondinh.Value;

            //// Kiểm tra tên nguyên liệu có trùng không
            if (IsDuplicateIngredient(tennl, manl))
            {
                MessageBox.Show("Đã tồn tại tên nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra các thông tin nhập vào
            if (!ValidateInput(tenloai, tennl, donvi, muctoithieu, mucondinh)) return;

            

            if (txtMaNguyenLieu.Enabled == true)
                nguyenlieubus.AddIngredients(manl, tenloai, tennl, donvi, muctoithieu, mucondinh);
            else
                nguyenlieubus.UpdateIngredients(manl, tenloai, tennl, donvi, muctoithieu, mucondinh);

            LoadNguyenLieu();
            frmKho_Load(sender, e);

        }

        private bool ValidateInput(string tenloai, string tennl, string donvi, int muctoithieu, int mucondinh)
        {
            if (string.IsNullOrEmpty(tenloai))
            {
                General.ShowWarning("Vui lòng chọn tên loại");
                return false;
            }

            if (string.IsNullOrEmpty(tennl))
            {
                General.ShowWarning("Vui lòng nhập tên nguyên liệu");
                return false;
            }

            if (string.IsNullOrEmpty(donvi))
            {
                General.ShowWarning("Vui lòng nhập đơn vị tính");
                return false;
            }

            if (muctoithieu == 0)
            {
                General.ShowWarning("Vui lòng nhập mức tối thiểu");
                return false;
            }

            if (mucondinh == 0)
            {
                General.ShowWarning("Vui lòng nhập mức ổn định");
                return false;
            }

            return true;
        }

        private bool IsDuplicateIngredient(string tennl, string currentMaNL)
        {
            DataTable dt = nguyenlieubus.LoadIngredients_name();
            foreach (DataRow row in dt.Rows)
            {
                string existingName = row["TenNL"].ToString().ToLower();  // Chuyển tất cả thành chữ thường
                string existingMaNL = row["MaNL"].ToString();

                if (existingName == tennl.ToLower() && existingMaNL != currentMaNL)  // So sánh không phân biệt hoa/thường
                    return true;
            }
            return false;
        }


        private void gridDsNguyenlieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlThongtinNL.Visible = true;
            if (this.Modal) //nếu mở từ form khác thì không cho sửa
                return;
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
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlThongtinNL.Visible = false;
            btnThemNguyenlieu.Enabled = true;
        }

        private void btnTrolai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
