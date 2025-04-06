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
        BUS_SanPham sanpham;
        public frmThucdon()
        {
            InitializeComponent();
        }

        //Tải danh sách sản phẩm
        public void LoadSp()
        {
            sanpham = new BUS_SanPham("", "", "", new byte[10], 0, "");
            gridThucDon.DataSource = sanpham.TaiSp();
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại chọn tệp
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Chỉ cho phép chọn ảnh (JPG, PNG, BMP, GIF)
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
            btnTimkiem.Enabled = false;
            txtTimkiem.Enabled = false;
            btnThemmon.Enabled = true;

            LoadSp();
            gridThucDon.Columns["btnUpdate"].DisplayIndex = gridThucDon.Columns.Count - 1; //đưa button về cuối
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



        //chuyển hình ảnh sang byte[];
        public byte[] ImageToByteArray(Image img)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        //chuyển byte[] sang hình ảnh;
        public Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }



        //Tải tên loại lên combobox Tên loại
        public void TaiTenLoai()
        {
            sanpham = new BUS_SanPham("", "", "", new byte[10], 0, "");
            cboTenloai.DataSource = sanpham.TaiTenloai();
            cboTenloai.DisplayMember = "TenLoai";
        }

        //Khi nhấn vào picture sẽ hiện form thêm loại
        private void picThemLoai_Click(object sender, EventArgs e)
        {
            frmThemLoaiSanPham themloai = new frmThemLoaiSanPham();
            themloai.ShowDialog();

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

            DataGridViewRow hangduocchon = gridThucDon.SelectedRows[0];
            txtMasanpham.Text = hangduocchon.Cells["Mã món"].Value.ToString();
            cboTenloai.Text = hangduocchon.Cells["Tên loại"].Value.ToString();
            txtTensanpham.Text = hangduocchon.Cells["Tên món"].Value.ToString();
            picAnhsanpham.Image = ByteArrayToImage((byte[])hangduocchon.Cells["Hình ảnh"].Value);
            numGiaban.Value = Convert.ToDecimal(hangduocchon.Cells["Giá bán"].Value);
            cboTrangthai.Text = hangduocchon.Cells["Trạng thái"].Value.ToString();

            gbThongtinsanpham.Enabled = true;
            txtMasanpham.Enabled = false;
            //cboTenloai.Enabled = false;


            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThemmon.Enabled = false;
        }


        //Nút lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMasanpham.Enabled == false) //nếu không cho sửa mã thì trường hợp update
            {
                sanpham = new BUS_SanPham("", "", "", new byte[10], 0, "");
                sanpham.SuaSp(txtMasanpham.Text, cboTenloai.Text, txtTensanpham.Text, ImageToByteArray(picAnhsanpham.Image), (int)numGiaban.Value, cboTrangthai.Text);
                LoadSp();
            }
            else
            {
                sanpham = new BUS_SanPham("", "", "", new byte[10], 0, "");
                sanpham.ThemSp(txtMasanpham.Text, cboTenloai.Text, txtTensanpham.Text, ImageToByteArray(picAnhsanpham.Image), (int)numGiaban.Value, cboTrangthai.Text);
                LoadSp();
            }
            frmThucdon_Load(sender, e);

        }



        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmThucdon_Load(sender, e);
        }

        private void btnDinhluong_Click(object sender, EventArgs e)
        {
            frmDinhLuong dinhluong = new frmDinhLuong();
            dinhluong.ShowDialog();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {

        }
    }
}
