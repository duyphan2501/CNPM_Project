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
        }

        //Load lại danh sách định lượng theo tên sản phẩm trên griview
        public void LoadRecipe()
        {
            gridDsDinhluong.RowTemplate.Height = 35;
            gridDsDinhluong.DataSource = dinhluong.LoadRecipe(txtTenSp.Text);
            gridDsDinhluong.Columns["btnUpdate"].DisplayIndex = gridDsDinhluong.Columns.Count - 1; //đưa button về cuối

        }

        //Khi load form định lượng
        private void frmDinhLuong_Load(object sender, EventArgs e)
        {
            LoadRecipe();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
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
            int soLuong = Convert.ToInt32(numSoluongNL.Value);
            if (soLuong == 0)
            {
                General.ShowWarning("Vui lòng nhập số lượng nguyên liệu", this);
                return;
            }
            string tennl = cboTenNguyenLieu.Text;

            if (IsIngredientDuplicated(tennl))
            {
                MessageBox.Show("Nguyên liệu này đã có trong định lượng.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dinhluong.AddRecipe(Masp, tennl, soLuong);
            numSoluongNL.Value = 0;
            LoadRecipe();
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
            if (e.RowIndex < 0 || e.ColumnIndex != gridDsDinhluong.Columns["btnUpdate"].Index)
            {
                return;
            }
            DataGridViewRow hangduocchon = gridDsDinhluong.SelectedRows[0];
            cboTenNguyenLieu.Text = hangduocchon.Cells["Tên nguyên liệu"].Value.ToString();
            numSoluongNL.Value = (int)hangduocchon.Cells["Số lượng"].Value;

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            cboTenNguyenLieu.Enabled = false; //Không cho sửa tên nguyên liệu
        }

        //Sửa đinh lượng
        private void btnSua_Click(object sender, EventArgs e)
        {
            dinhluong.UpdateRecipe(txtTenSp.Text, cboTenNguyenLieu.Text, Convert.ToInt32(numSoluongNL.Value));
            MessageBox.Show("Cập nhật thông tin thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cboTenNguyenLieu.Enabled = true;
            LoadRecipe();
            frmDinhLuong_Load(sender, e);
        }

        //Khi xóa định lượng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(   //Thông báo xuất quá mức tối thiểu
                                "Bạn có chắc chắn xóa định lượng không?",
                                "Xác nhận xóa",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                dinhluong.DeleteRecipe(txtTenSp.Text, cboTenNguyenLieu.Text);
                MessageBox.Show("Đã xóa nguyên liệu khỏi định lượng", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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
    }
}
