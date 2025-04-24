using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using Microsoft.Identity.Client;

namespace GUI
{
    public partial class frmThucdon : Form
    {
        BUS_SanPham sanpham = new BUS_SanPham("", "", "", new byte[10], 0, "");
        public frmThucdon()
        {
            InitializeComponent();
        }

        //Tải danh sách sản phẩm
        public void LoadProduct()
        {
            gridThucDon.RowTemplate.Height = 150; //Chiều cao các hàng trong gridview
            gridThucDon.DataSource = sanpham.LoadProduct();
            gridThucDon.Columns["btnUpdate"].DisplayIndex = gridThucDon.Columns.Count - 1; //đưa button về cuối
            ((DataGridViewImageColumn)gridThucDon.Columns["Hình Ảnh"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại chọn tệp
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Chỉ cho phép chọn ảnh (JPG, PNG)
            openFileDialog.Filter = "Hình ảnh|*.jpg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK) // Nếu người dùng chọn ảnh
            {
                // Hiển thị ảnh trong PictureBox
                picAnhsanpham.Image = Image.FromFile(openFileDialog.FileName);

                // Đảm bảo ảnh hiển thị vừa với PictureBox
                picAnhsanpham.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void frmThucdon_Load(object sender, EventArgs e)
        {
            pnlThongtinSP.Visible = false;  //Khi load form thì ẩn panel thông tin sản phẩm
            pnlThongtinSP.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = btnDinhluong.Enabled = false;
            btnThemmon.Enabled = true;
            txtMasanpham.Enabled = true;
            TaiTenLoai();
            LoadProduct();
        }


        //Xóa dữ liệu trong các textbox cần xóa
        private void ResetTextbox()
        {
            txtMasanpham.Clear();
            txtTensanpham.Clear();
            numGiaban.Value = 0;
            picAnhsanpham.Image = null;
            txtTimkiem.Clear();
            btnLuu.Enabled = true;
        }

        //Tải tên loại lên combobox Tên loại
        public void TaiTenLoai()
        {
            cboTenloai.DataSource = sanpham.TaiLoaiSP();
            cboTenloai.DisplayMember = "TenLoai";
            cboTenloai.ValueMember = "MaLoai";
        }

        //Khi nhấn vào picture sẽ hiện form thêm loại
        private void picThemLoai_Click(object sender, EventArgs e)
        {
            frmThemLoaiSanPham themloai = new frmThemLoaiSanPham();
            General.ShowDialogWithBlur(themloai);

            TaiTenLoai();
        }


        //Khi click nút Thêm món
        private void btnThemmon_Click(object sender, EventArgs e)
        {
            pnlThongtinSP.Visible = true;
            pnlThongtinSP.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnTimkiem.Enabled = true;
            txtTimkiem.Enabled = true;
            ResetTextbox();

            TaiTenLoai();
            txtMasanpham.Text = sanpham.PhatSinhMaSp(); //Phát sinh mã sản phẩm
            txtMasanpham.ReadOnly = true;
        }

        string tensp;
        //Khi chọn dòng trong gridview
        private void gridThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào đúng cột btnUpdate và không phải header
            if (e.RowIndex < 0 || e.ColumnIndex != gridThucDon.Columns["btnUpdate"].Index)
            {
                return;
            }

            // Lấy dữ liệu từ dòng được chọn
            DataGridViewRow hangduocchon = gridThucDon.SelectedRows[0];

            // Cập nhật thông tin vào các điều khiển
            txtMasanpham.Text = hangduocchon.Cells["Mã món"].Value?.ToString();
            cboTenloai.Text = hangduocchon.Cells["Tên loại"].Value?.ToString();
            txtTensanpham.Text = hangduocchon.Cells["Tên món"].Value?.ToString();
            numGiaban.Value = Convert.ToDecimal(hangduocchon.Cells["Giá bán"].Value);
            cboTrangthai.Text = hangduocchon.Cells["Trạng thái"].Value?.ToString();

            tensp = txtTensanpham.Text;

            // Xử lý ảnh, nếu null thì gán ảnh mặc định hoặc để null
            var hinhAnh = hangduocchon.Cells["Hình ảnh"].Value as byte[];
            picAnhsanpham.Image = hinhAnh != null ? General.ByteArrayToImage(hinhAnh) : null;

            // Cập nhật giao diện
            EnableProductFields();
            pnlThongtinSP.Visible = true;

            
        }

        private void EnableProductFields()
        {
            pnlThongtinSP.Enabled = true;
            txtMasanpham.Enabled = false;
            //cboTenloai.Enabled = false; // Nếu cần thì có thể bật lại

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnDinhluong.Enabled = true;
            btnThemmon.Enabled = false;
        }



        //Nút lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maSanPham = txtMasanpham.Text;
            string maLoai = cboTenloai.SelectedValue.ToString();
            string tenSanPham = txtTensanpham.Text;
            int giaBan = Convert.ToInt32(numGiaban.Value);
            string trangThai = cboTrangthai.Text;
            byte[] anhSanPham = picAnhsanpham.Image != null ? General.ImageToByteArray(picAnhsanpham.Image) : null;

            
            if (!IsDuplicateProduct(maSanPham, tenSanPham)) //kiểm tra trùng tên sản phẩm
            {
                if (ValidateInputs(tenSanPham, giaBan, trangThai, anhSanPham))  //kiểm tra dữ liệu nhập vào
                {
                    if (!txtMasanpham.Enabled) // Đang ở chế độ cập nhật
                    {
                        sanpham.UpdateProduct(maSanPham, maLoai, tenSanPham, anhSanPham, giaBan, trangThai);
                        MessageBox.Show("Cập nhật thông tin món thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        sanpham.AddProduct(maSanPham, maLoai, tenSanPham, anhSanPham, giaBan, trangThai);
                        MessageBox.Show("Thêm món thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    LoadProduct();
                    frmThucdon_Load(sender, e);
                }
            }
            txtMasanpham.Enabled = true;
        }

        private bool IsDuplicateProduct(string maSP, string tenSP) //kiểm tra trùng tên sản phẩm mà khác chính nó
        {
            DataTable dt = sanpham.LoadProduct();
            foreach (DataRow row in dt.Rows)
            {
                string tenMon = row["Tên món"].ToString().ToLower();
                string maMon = row["Mã món"].ToString();

                if (tenMon == tenSP.ToLower() && maMon != maSP) //so sánh ko phân biệt hoa thường
                {
                    MessageBox.Show("Đã có sản phẩm này rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        private bool ValidateInputs(string tenSanPham, int giaBan, string trangThai, byte[] anhSanPham)
        {
            if (string.IsNullOrEmpty(tenSanPham))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (giaBan == 0)
            {
                MessageBox.Show("Vui lòng nhập giá bán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(trangThai))
            {
                MessageBox.Show("Vui lòng chọn trạng thái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (anhSanPham == null)
            {
                MessageBox.Show("Vui lòng thêm ảnh sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmThucdon_Load(sender, e);
        }

        private void btnDinhluong_Click(object sender, EventArgs e)
        {
            frmDinhLuong dinhluong = new frmDinhLuong(txtMasanpham.Text, txtTensanpham.Text);  //truyền mã sản phẩm và tên sản phẩm vào form định lượng để thêm định lượng
            General.ShowDialogWithBlur(dinhluong);
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {

        }

        private void cboLoctrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProduct();
            if (cboLoctrangthai.Text != "Tất cả")
            {
                string filter = cboLoctrangthai.Text == "Còn bán" ? "Còn bán" : "Ngưng bán";
                DataView dv = ((DataTable)gridThucDon.DataSource).DefaultView;
                dv.RowFilter = $"[Trạng thái] LIKE '%{filter}%'";
                gridThucDon.DataSource = dv;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlThongtinSP.Visible = false;
            btnThemmon.Enabled = true;
            frmThucdon_Load(sender, e);
        }
    }
}
