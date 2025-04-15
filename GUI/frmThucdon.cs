using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

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
            DataGridViewImageColumn imgCol = (DataGridViewImageColumn)gridThucDon.Columns["Hình Ảnh"];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;  //tùy chỉnh ảnh về zoom

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
            gbThongtinsanpham.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnDinhluong.Enabled = false;
            btnTimkiem.Enabled = false;
            txtTimkiem.Enabled = false;
            btnThemmon.Enabled = true;
            TaiTenLoai();
            LoadProduct();
        }


        //Xóa dữ liệu trong các textbox cần xóa
        private void ResetTextbox()
        {
            txtMasanpham.Clear();
            //cboTenloai.Items.Clear();
            txtTensanpham.Clear();
            numGiaban.Value = 0;
            //cboTrangthai.Items.Clear();
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
            gbThongtinsanpham.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnTimkiem.Enabled = true;
            txtTimkiem.Enabled = true;
            ResetTextbox();

            TaiTenLoai();
            txtMasanpham.Text = sanpham.PhatSinhMaSp();
            txtMasanpham.ReadOnly = true;
        }

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

            // Xử lý ảnh, nếu null thì gán ảnh mặc định hoặc để null
            var hinhAnh = hangduocchon.Cells["Hình ảnh"].Value as byte[];
            picAnhsanpham.Image = hinhAnh != null ? General.ByteArrayToImage(hinhAnh) : null;

            // Cập nhật giao diện
            EnableProductFields();
        }

        private void EnableProductFields()
        {
            gbThongtinsanpham.Enabled = true;
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
            // Lấy thông tin từ form
            string maSanPham = txtMasanpham.Text;
            string maLoai = cboTenloai.SelectedValue.ToString();
            string tenSanPham = txtTensanpham.Text;
            int giaBan = (int)numGiaban.Value;
            string trangThai = cboTrangthai.Text;

            // Kiểm tra xem có ảnh không
            byte[] anhSanPham = null;
            if (picAnhsanpham.Image != null)
            {
                anhSanPham = General.ImageToByteArray(picAnhsanpham.Image);
            }

            // Kiểm tra nếu không cho sửa mã sản phẩm (trường hợp cập nhật)
            if (txtMasanpham.Enabled == false)  // Cập nhật sản phẩm
            {
                sanpham.UpdateProduct(maSanPham, maLoai, tenSanPham, anhSanPham, giaBan, trangThai);
            }
            else  // Thêm sản phẩm mới
            {
                sanpham.AddProduct(maSanPham, maLoai, tenSanPham, anhSanPham, giaBan, trangThai);
            }

            // Tải lại dữ liệu sau khi thêm/sửa
            LoadProduct();
            frmThucdon_Load(sender, e);
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmThucdon_Load(sender, e);
        }

        private void btnDinhluong_Click(object sender, EventArgs e)
        {
            frmDinhLuong dinhluong = new frmDinhLuong(txtMasanpham.Text, txtTensanpham.Text);  //truyền mã sản phẩm và tên sản phẩm vào form định lượng để thêm định lượng
            dinhluong.ShowDialog();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {

        }

        private void cboLoctrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoctrangthai.Text == "Tất cả")
            {
                LoadProduct();
            }
            else if (cboLoctrangthai.Text == "Còn bán")
            {
                LoadProduct();
                DataView dv = ((DataTable)gridThucDon.DataSource).DefaultView;
                dv.RowFilter = $"[Trạng thái] LIKE '%Còn bán%'";
                gridThucDon.DataSource = dv;
            }
            else
            {
                LoadProduct();
                DataView dv = ((DataTable)gridThucDon.DataSource).DefaultView;
                dv.RowFilter = $"[Trạng thái] LIKE '%Ngưng bán%'";
                gridThucDon.DataSource = dv;
            }
        }
    }
}
