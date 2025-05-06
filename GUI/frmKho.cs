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
            LoadCboLocNL();
            pnlThongtinNL.Visible = false;
            LoadIngredients();
            LoadIngredients_type();
            pnlThongtinNL.Enabled = false;
            btnThemNguyenlieu.Enabled = true;
            btnThemNguyenlieu.Visible = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNguyenLieu.Enabled = true;
        }

        public void LoadCboLocNL()
        {
            // Xóa các mục cũ (nếu có)
            cboLocNL.Items.Clear();

            // Thêm mục "Tất cả" đầu tiên
            cboLocNL.Items.Add("Tất cả");

            // Thêm các nguyên liệu trực tiếp 
            cboLocNL.Items.Add("Ổn định");
            cboLocNL.Items.Add("Cần nhập");

            // Chọn mặc định là "Tất cả"
            cboLocNL.SelectedIndex = 0;
        }

        public void LoadIngredients()
        {
            gridDsNguyenlieu.DataSource = nguyenlieubus.LoadIngredients();
            gridDsNguyenlieu.Columns["btnUpdate"].DisplayIndex = gridDsNguyenlieu.Columns.Count - 1;

        }

        public void LoadIngredients_type()
        {
            cboTenloai.DataSource = nguyenlieubus.LoadIngredients_type();
            cboTenloai.DisplayMember = "TenLoai";
        }

        private void picThemLoai_Click(object sender, EventArgs e)
        {
            frmThemLoaiNguyenLieu loainguyenlieu = new frmThemLoaiNguyenLieu();
            General.ShowDialogWithBlur(loainguyenlieu);

            LoadIngredients_type();
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
                General.ShowWarning("Tên nguyên liệu đã tồn tại!", this);
                return;
            }
            // Kiểm tra các thông tin nhập vào
            if (!ValidateInput(tenloai, tennl, donvi, muctoithieu, mucondinh)) return;



            if (txtMaNguyenLieu.Enabled == true)
                nguyenlieubus.AddIngredients(manl, tenloai, tennl, donvi, muctoithieu, mucondinh);
            else
                nguyenlieubus.UpdateIngredients(manl, tenloai, tennl, donvi, muctoithieu, mucondinh);

            LoadIngredients();
            frmKho_Load(sender, e);

        }

        private bool ValidateInput(string tenloai, string tennl, string donvi, int muctoithieu, int mucondinh)
        {
            if (string.IsNullOrEmpty(tenloai))
            {
                General.ShowWarning("Vui lòng chọn tên loại",this);
                return false;
            }

            if (string.IsNullOrEmpty(tennl))
            {
                General.ShowWarning("Vui lòng nhập tên nguyên liệu",this);
                return false;
            }

            if (string.IsNullOrEmpty(donvi))
            {
                General.ShowWarning("Vui lòng nhập đơn vị tính",this);
                return false;
            }

            if (muctoithieu == 0)
            {
                General.ShowWarning("Vui lòng nhập mức tối thiểu",this);
                return false;
            }

            if (mucondinh == 0)
            {
                General.ShowWarning("Vui lòng nhập mức ổn định",this);
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
            pnlThongtinNL.Visible = true;

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

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            // Lọc sản phẩm trong DataGridView theo từ khóa tìm kiếm
            string keyword = txtTimkiem.Text.Trim().ToLower();

            // Tạm thời bỏ qua việc chọn dòng hiện tại
            gridDsNguyenlieu.CurrentCell = null;

            // Lặp qua tất cả các hàng trong DataGridView
            foreach (DataGridViewRow row in gridDsNguyenlieu.Rows)
            {
                bool isMatchFound = false;

                // Lặp qua tất cả các cột trong mỗi hàng
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Kiểm tra nếu giá trị trong cell chứa từ khóa tìm kiếm
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(keyword))
                    {
                        isMatchFound = true;
                        break;  // Nếu tìm thấy kết quả, không cần kiểm tra các cột còn lại
                    }
                }

                // Ẩn hoặc hiện hàng tùy thuộc vào việc tìm thấy kết quả hay không
                row.Visible = isMatchFound;
            }
        }

        private void cboLocNL_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadIngredients();
            DataView dv = ((DataTable)gridDsNguyenlieu.DataSource).DefaultView;


            // Lọc dữ liệu theo loại phiếu
            if (cboLocNL.Text == "Tất cả")
            {
                dv.RowFilter = "";  // Không áp dụng bộ lọc nếu chọn "Tất cả"
            }
            else if (cboLocNL.Text == "Ổn định")
            {
                dv.RowFilter = "[Số lượng tồn] >= [Mức ổn định]";
            }
            else
            {
                dv.RowFilter = "[Số lượng tồn] < [Mức tối thiểu]";
            }

            // Cập nhật lại DataSource với bộ lọc
            gridDsNguyenlieu.DataSource = dv.ToTable();  // Dùng ToTable để chuyển DataView thành DataTable
        }

        private void btnXuatNhapKho_Click(object sender, EventArgs e)
        {
            frmXuatNhapKho frm = new frmXuatNhapKho();
            frm.DataChanged += FormCon_DataChanged; 
            General.ShowDialogWithBlur(frm);
        }

        // Xử lý sự kiện khi dữ liệu thay đổi
        private void FormCon_DataChanged(object sender, EventArgs e)
        {
            // Cập nhật lại GridView hoặc DataGridView
            LoadIngredients();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            frmLichSuXuatNhap frm = new frmLichSuXuatNhap();
            General.ShowDialogWithBlur(frm);
        }
    }
}
