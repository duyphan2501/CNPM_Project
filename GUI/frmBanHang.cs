using BUS;
using cnpm;
using GUI.components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBanHang : Form
    {
        private BUS_LoaiSanPham loaiSanphamBUS;
        private BUS_SanPham sanPhamBUS;
        private BUS_CaLamViec calam;
        public frmBanHang()
        {
            InitializeComponent();
            loaiSanphamBUS = new BUS_LoaiSanPham();  
            sanPhamBUS = new BUS_SanPham();  
            calam = new BUS_CaLamViec();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            SetFullScreen();  
            EnableDoubleBuffering();
            KiemTraMoCa();  
            LoadProductCateGory(); 
            LoadProducts(); 
            SetUserDetails(); 
        }

        private void SetFullScreen()
        {
            // Đặt form toàn màn hình
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        private void EnableDoubleBuffering()
        {
            // Kích hoạt double buffering để giảm lag khi thêm nhiều item vào Panel
            foreach (Panel panel in new[] { pnlInvoiceItem, pnlThucDon })
            {
                typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel, new object[] { true });
            }
        }

        // Kiểm tra xem đã mở ca làm việc chưa, nếu chưa thì yêu cầu mở ca
        private void KiemTraMoCa()
        {
            var calam = new BUS_CaLamViec();
            string tenDangNhap = Program.account.Rows[0]["TenDangNhap"].ToString();
            Program.shift = calam.SelectOpenShift(tenDangNhap);
            // ko có ca nào
            if (Program.shift.Rows.Count == 0)
            {
                frmMoCaLam frmMoCaLam = new frmMoCaLam();
                General.ShowDialogWithBlur(frmMoCaLam);
            }
        }

        private void SetUserDetails()
        {
            // Cập nhật các thông tin ca làm việc, họ tên và vai trò người dùng
            lblMaCaLam.Text = Program.shift.Rows[0]["MaCaLam"].ToString();
            lblHoTen.Text = Program.account.Rows[0]["HoTen"].ToString();
            lblVaiTro.Text = Program.account.Rows[0]["VaiTro"].ToString();
        }

        private void LoadProductCateGory()
        {
            // Tạo nút "Tất cả" để chọn tất cả sản phẩm
            var allCategory = new ProductCategory
            {
                Text = "Tất cả",
                MaLoai = null
            };
            allCategory.SetActive(true);
            allCategory.Click += ProductCategory_Clicked;
            pnlProductCategory.Controls.Add(allCategory);

            // Tải các loại sản phẩm và hiển thị lên panel
            foreach (DataRow category in loaiSanphamBUS.SelectAllCategoryProduct().Rows)
            {
                ProductCategory proCategory = new ProductCategory(category["TenLoai"].ToString(), category["MaLoai"].ToString());
                proCategory.LoaiSPClicked += ProductCategory_Clicked;
                pnlProductCategory.Controls.Add(proCategory);
            }
        }

        private void LoadProducts()
        {
            // Lấy sản phẩm và hiển thị lên giao diện
            foreach (DataRow dr in sanPhamBUS.SelectOnSaleProduct().Rows)
            {
                Widget widget = new Widget(dr["HinhAnh"] as byte[], dr["TenSp"].ToString(), Convert.ToInt32(dr["GiaBan"]), dr["MaLoai"].ToString());
                widget.ThemSanPhamClicked += Widget_ThemSanPhamClicked;
                pnlThucDon.Controls.Add(widget);
            }
        }

        private void ProductCategory_Clicked(object sender, EventArgs e)
        {
            // Xử lý sự kiện click chọn loại sản phẩm, thay đổi trạng thái nút 
            var selectedCategory = sender as ProductCategory;
            foreach (ProductCategory category in pnlProductCategory.Controls.OfType<ProductCategory>())
            {
                category.SetActive(category == selectedCategory);
            }
            // hiển thị sản phẩm cùng mã loại
            foreach (Widget widget in pnlThucDon.Controls.OfType<Widget>())
            {
                widget.Visible = selectedCategory.MaLoai == null || widget.MaLoai == selectedCategory.MaLoai;
            }
        }

        private void Widget_ThemSanPhamClicked(object sender, EventArgs e)
        {
            // Xử lý thêm sản phẩm vào hóa đơn khi người dùng nhấn nút thêm
            Widget widget = sender as Widget;
            string tenmon = widget.TenSanPham;
            int dongia = widget.GiaSanPham;
            // kiểm tra có hay ko
            foreach (Control ctrl in pnlInvoiceItem.Controls)
            {
                if (ctrl is InvoiceItem existingItem && existingItem.TenMon == tenmon)
                {
                    // có thì tăng số lượng
                    existingItem.IncreaseQuantity();
                    return;
                }
            }
            // ko có thì thêm item mới
            InvoiceItem newItem = new InvoiceItem(tenmon, dongia, 1);
            newItem.XoaItemClicked += InvoiceItem_XoaItemClicked;
            pnlInvoiceItem.Controls.Add(newItem);
        }

        private void InvoiceItem_XoaItemClicked(object sender, EventArgs e)
        {
            // Xử lý xóa item khỏi hóa đơn
            pnlInvoiceItem.Controls.Remove(sender as InvoiceItem);
        }

        private void txtTimMon_TextChanged(object sender, EventArgs e)
        {
            // Lọc sản phẩm theo từ khóa tìm kiếm
            string keyword = txtTimMon.Text.Trim().ToLower();
            foreach (Control ctrl in pnlThucDon.Controls)
            {
                if (ctrl is Widget widget)
                {
                    // chứa từ khoá thì hiện ra
                    widget.Visible = widget.TenSanPham.ToLower().Contains(keyword);
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Cập nhật thời gian hiện tại mỗi khi tick
            DateTime now = DateTime.Now;
            lblThoiGian.Text = $"{now:dddd}, {now:dd/MM/yyyy - HH:mm}";
        }
    }
}
