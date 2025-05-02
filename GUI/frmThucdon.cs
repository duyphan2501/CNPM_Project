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
            gridThucDon.RowTemplate.Height = 100; //Chiều cao các hàng trong gridview
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
            txtMasanpham.Enabled = false; //không cho phép sửa mã sản phẩm 
        }

        private void frmThucdon_Load(object sender, EventArgs e)
        {
            pnlThongtinSP.Visible = false;  //Khi load form thì ẩn panel thông tin sản phẩm
            pnlThongtinSP.Enabled = false;
            btnLuu.Enabled = btnHuy.Enabled = btnDinhluong.Enabled = false;
            btnThemmon.Enabled = true;
            txtMasanpham.Enabled = true;

            cboLoctrangthai.Text = "Tất cả";
            LoadProduct_type();
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
        public void LoadProduct_type()
        {
            cboTenloai.DataSource = sanpham.LoadProduct_type();
            cboTenloai.DisplayMember = "TenLoai";
            cboTenloai.ValueMember = "MaLoai";
        }

        //Khi nhấn vào picture sẽ hiện form thêm loại
        private void picThemLoai_Click(object sender, EventArgs e)
        {
            frmThemLoaiSanPham themloai = new frmThemLoaiSanPham();
            General.ShowDialogWithBlur(themloai);

            LoadProduct_type();
        }


        //Khi click nút Thêm món
        private void btnThemmon_Click(object sender, EventArgs e)
        {
            pnlThongtinSP.Visible = true;
            pnlThongtinSP.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtTimkiem.Enabled = true;
            ResetTextbox();

            LoadProduct_type();
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
                        General.ShowInformation("Cập nhật món thành công", this);
                    }
                    else
                    {
                        sanpham.AddProduct(maSanPham, maLoai, tenSanPham, anhSanPham, giaBan, trangThai);
                        General.ShowInformation("Thêm món thành công", this);
                    }

                    LoadProduct();
                    frmThucdon_Load(sender, e);
                }
                txtMasanpham.Enabled = true;
            }
            
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
                    General.ShowWarning("Tên sản phẩm đã tồn tại", this);
                    return true;
                }
            }
            return false;
        }

        private bool ValidateInputs(string tenSanPham, int giaBan, string trangThai, byte[] anhSanPham)
        {
            if (string.IsNullOrEmpty(tenSanPham))
            {
                General.ShowWarning("Vui lòng nhập tên sản phẩm",this);
                return false;
            }
            if (giaBan == 0)
            {
                General.ShowWarning("Vui lòng nhập giá bán", this);
                return false;
            }
            if (string.IsNullOrEmpty(trangThai))
            {
                General.ShowWarning("Vui lòng chọn trạng thái", this);
                return false;
            }
            if (anhSanPham == null)
            {
                General.ShowWarning("Vui lòng thêm ảnh sản phẩm", this);
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

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            // Lọc sản phẩm trong DataGridView theo từ khóa tìm kiếm
            string keyword = txtTimkiem.Text.Trim().ToLower();

            // Tạm thời bỏ qua việc chọn dòng hiện tại
            gridThucDon.CurrentCell = null;

            // Lặp qua tất cả các hàng trong DataGridView
            foreach (DataGridViewRow row in gridThucDon.Rows)
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
    }
}
