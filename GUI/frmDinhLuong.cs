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
        BUS_DinhLuong dinhluong = new BUS_DinhLuong("", "", 0);
        string Masp;
        public frmDinhLuong(string masp, string tensp)   //truyền mã sản phẩm và tên sản phẩm vào form định lượng
        {
            InitializeComponent();
            txtTenSp.Text = tensp;
            txtTenSp.ReadOnly = true;
            Masp = masp;

            LoadRecipe(); //load danh sách định lượng theo tên sản phẩm
        }

        //Tải tên nguyên liệu lên combobox
        public void LoadRecipe_name()
        {
            cboTenNguyenLieu.DataSource = dinhluong.LoadRecipe_name();
            cboTenNguyenLieu.DisplayMember = "TenNL";
            cboTenNguyenLieu.ValueMember = "MaNL";
            cboTenNguyenLieu.SelectedIndex = -1;
        }

        //Load lại danh sách định lượng theo tên sản phẩm trên griview
        public void LoadRecipe()
        {
            gridDsDinhluong.RowTemplate.Height = 35;
            gridDsDinhluong.DataSource = dinhluong.LoadRecipe(txtTenSp.Text);
            gridDsDinhluong.Columns["btnUpdate"].DisplayIndex = gridDsDinhluong.Columns.Count - 2; //đưa button về cuối
            gridDsDinhluong.Columns["btnXoadinhluong"].DisplayIndex = gridDsDinhluong.Columns.Count - 1; //đưa button về cuối

        }

        //Khi load form định lượng
        private void frmDinhLuong_Load(object sender, EventArgs e)
        {
            LoadRecipe();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            LoadRecipe_name();

        }

        private bool IsIngredientDuplicated(string tennl) //Kiểm tra trùng nguyên liệu
        {
            foreach (DataGridViewRow row in gridDsDinhluong.Rows)
            {
                if (row.Cells["Tên nguyên liệu"].Value != null &&
                    row.Cells["Tên nguyên liệu"].Value.ToString() == tennl)
                {
                    return true;
                }
            }
            return false;
        }
        //Nút thêm để thêm định lượng vào database
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy số lượng nguyên liệu từ numSoluongNL
            Decimal soLuong = Convert.ToDecimal(txtSoluong.Text);

            // Kiểm tra xem số lượng có bằng 0 không
            if (soLuong == 0)
            {
                General.ShowWarning("Vui lòng nhập số lượng nguyên liệu", this);
                return;
            }

            string tennl = cboTenNguyenLieu.Text;

            // Kiểm tra trùng nguyên liệu
            if (IsIngredientDuplicated(tennl))
            {
                General.ShowWarning("Nguyên liệu này đã có trong định lượng", this);
                return;
            }

            // Thêm định lượng vào database
            dinhluong.AddRecipe(Masp, tennl, soLuong);

            // Reset lại giá trị của NumericUpDown
            txtSoluong.Text = "0";
            LoadRecipe(); // Load lại danh sách định lượng
        }

        //Nhấn nút xong khi đã thêm đủ danh sách định lượng
        private void btnXong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void gridDsDinhluong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // không làm gì khi click vào header hoặc các cột khác ngoài cột btnUpdate
            //if (e.RowIndex < 0 || e.ColumnIndex != gridDsDinhluong.Columns["btnUpdate"].Index)
            //{
            //    return;
            //}
            if (e.ColumnIndex == gridDsDinhluong.Columns["btnUpdate"].Index)
            {
                DataGridViewRow hangduocchon = gridDsDinhluong.SelectedRows[0];
                cboTenNguyenLieu.Text = hangduocchon.Cells["Tên nguyên liệu"].Value.ToString();
                txtSoluong.Text = (hangduocchon.Cells["Số lượng"].Value).ToString();

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                cboTenNguyenLieu.Enabled = false; //Không cho sửa tên nguyên liệu
            }
            if (e.ColumnIndex == gridDsDinhluong.Columns["btnXoadinhluong"].Index)  //Xóa định lượng
            {
                DataGridViewRow hangduocchon = gridDsDinhluong.SelectedRows[0];
                cboTenNguyenLieu.Text = hangduocchon.Cells["Tên nguyên liệu"].Value.ToString();
                txtSoluong.Text = (hangduocchon.Cells["Số lượng"].Value).ToString();
                DialogResult result = General.ShowConfirm("Bạn có chắc chắn muốn xóa nguyên liệu này khỏi định lượng không?", this);
                if (result == DialogResult.Yes)
                {
                    dinhluong.DeleteRecipe(txtTenSp.Text, cboTenNguyenLieu.Text);
                    General.ShowInformation("Đã xóa nguyên liệu khỏi định lượng", this);
                }

                frmDinhLuong_Load(sender, e);

            }

        }

        //Sửa đinh lượng
        private void btnSua_Click(object sender, EventArgs e)
        {

            // Cập nhật định lượng
            dinhluong.UpdateRecipe(txtTenSp.Text, cboTenNguyenLieu.Text, Convert.ToDecimal(txtSoluong.Text));
            General.ShowInformation("Cập nhật định lượng thành công", this);

            // Đổi trạng thái button và load lại danh sách
            cboTenNguyenLieu.Enabled = true;
            LoadRecipe();
            frmDinhLuong_Load(sender, e);
        }



        private void cboTenNguyenLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenNguyenLieu.SelectedValue != null)
            {
                string maNL = cboTenNguyenLieu.SelectedValue.ToString();
                string donvi = new BUS_NguyenLieu().LayDonvi(maNL);
                lblDonvi.Text = donvi;
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }

            // Kiểm tra giá trị sau khi người dùng nhập một ký tự mới
            string currentText = txtSoluong.Text + e.KeyChar;
            if (long.TryParse(currentText, out long result))
            {
                if (result > 100000000) // Giới hạn giá trị 
                {
                    e.Handled = true; // Không cho phép nhập khi vượt quá giới hạn
                    General.ShowError("Số tiền vượt quá giới hạn. Vui lòng nhập lại!", this);
                }
            }
        }

        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoluong.Text.Trim(), out int soTien) && txtSoluong.Text != "")
            {
                General.ShowError("Số lượng không hợp lệ. Vui lòng nhập lại.", this);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
        }
    }
}
