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

            loadDsDinhluong(); //load danh sách định lượng theo tên sản phẩm
        }

        //Tải tên nguyên liệu lên combobox
        public void TaitenNL()
        {
            cboTenNguyenLieu.DataSource = dinhluong.LoadRecipe_name();
            cboTenNguyenLieu.DisplayMember = "TenNL";
        }

        //Load lại danh sách định lượng theo tên sản phẩm trên griview
        public void loadDsDinhluong()
        {
            gridDsDinhluong.RowTemplate.Height = 50;
            gridDsDinhluong.DataSource = dinhluong.LoadRecipe(txtTenSp.Text);
            gridDsDinhluong.Columns["btnUpdate"].DisplayIndex = gridDsDinhluong.Columns.Count - 1; //đưa button về cuối

        }

        //Khi load form định lượng
        private void frmDinhLuong_Load(object sender, EventArgs e)
        {
            loadDsDinhluong();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            TaitenNL();
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

            string tennl = cboTenNguyenLieu.Text;

            if (IsIngredientDuplicated(tennl))
            {
                MessageBox.Show("This ingredient already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dinhluong.AddRecipe(Masp, tennl, Convert.ToInt32(numSoluongNL.Value));
            numSoluongNL.Value = 0;
            loadDsDinhluong();
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
            cboTenNguyenLieu.Enabled = true;
            loadDsDinhluong();
            frmDinhLuong_Load(sender, e);

        }

        //Khi xóa định lượng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            dinhluong.DeleteRecipe(txtTenSp.Text, cboTenNguyenLieu.Text);
            loadDsDinhluong();
            frmDinhLuong_Load(sender, e);
        }
    }
}
