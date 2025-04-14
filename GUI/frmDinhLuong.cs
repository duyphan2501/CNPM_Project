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
        }

        //Tải tên nguyên liệu lên combobox
        public void TaitenNL()
        {
            cboTenNguyenLieu.DataSource = dinhluong.TaiTenNL();
            cboTenNguyenLieu.DisplayMember = "TenNL";
        }

        //Load lại danh sách định lượng theo tên sản phẩm trên griview
        public void loadDsDinhluong()
        {
            gridDsDinhluong.RowTemplate.Height = 50;
            gridDsDinhluong.DataSource = dinhluong.TaiDsDinhluong(txtTenSp.Text);
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

        //Nút thêm để thêm định lượng vào database
        private void btnThem_Click(object sender, EventArgs e)
        {

            // Kiểm tra xem nguyên liệu được định lượng chưa
            bool daTonTai = false;
            foreach (DataGridViewRow row in gridDsDinhluong.Rows)
            {
                if (row.Cells["Tên nguyên liệu"].Value != null && row.Cells["Tên nguyên liệu"].Value.ToString() == cboTenNguyenLieu.Text)
                {
                    // Hiển thị thông báo nếu nguyên liệu đã tồn tại
                    MessageBox.Show("Đã có nguyên liệu này rồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    daTonTai = true;
                    break;
                }
            }

            // Thêm mới nếu chưa tồn tại
            if (!daTonTai)
            {
                dinhluong.ThemDinhluong(Masp, cboTenNguyenLieu.Text, Convert.ToInt32(numSoluongNL.Value));

                numSoluongNL.Value = 0;
                loadDsDinhluong();
            }
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
            cboTenNguyenLieu.Enabled = false; //Không cho sưa tên nguyên liệu
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            dinhluong.SuaDinhluong(txtTenSp.Text, cboTenNguyenLieu.Text, Convert.ToInt32(numSoluongNL.Value));
            cboTenNguyenLieu.Enabled = true;
            loadDsDinhluong();
            frmDinhLuong_Load(sender, e);

        }

        private void gridDsDinhluong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dinhluong.XoaDinhLuong(txtTenSp.Text, cboTenNguyenLieu.Text);
            loadDsDinhluong();
            frmDinhLuong_Load(sender, e);
        }
    }
}
