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
        private BUS_DonHang donhangBUS;
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
            CheckShiftOpening();
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
        private void CheckShiftOpening()
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
            var allCategory = new ProductCategory("Tất cả", null);
            allCategory.SetActive(true);
            allCategory.LoaiSPClicked += ProductCategory_Clicked;
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
                byte[] hinhAnh = dr["HinhAnh"] as byte[];
                string tenSp = dr["TenSp"].ToString();
                int giaBan = Convert.ToInt32(dr["GiaBan"]);
                string maLoai = dr["MaLoai"].ToString();
                string maSp = dr["MaSp"].ToString();

                Widget widget = new Widget(hinhAnh, tenSp, giaBan, maLoai, maSp);
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
            string maSanPham = widget.MaSanPham;
            // Kiểm tra sản phẩm đã có trong hóa đơn chưa
            foreach (Control ctrl in pnlInvoiceItem.Controls)
            {
                if (ctrl is InvoiceItem existingItem && existingItem.TenMon == tenmon)
                {
                    // Nếu có, tăng số lượng sản phẩm
                    existingItem.IncreaseQuantity();
                    // Cập nhật lại tổng tiền khi số lượng thay đổi
                    UpdateTotalAmount();
                    return;
                }
            }

            // Nếu không có, thêm item mới vào hóa đơn
            InvoiceItem newItem = new InvoiceItem(tenmon, dongia, 1, maSanPham);
            newItem.XoaItemClicked += InvoiceItem_XoaItemClicked;
            newItem.SoLuongChanged += InvoiceItem_SoLuongChanged;  // Đăng ký sự kiện khi số lượng thay đổi
            pnlInvoiceItem.Controls.Add(newItem);

            // Cập nhật lại tổng tiền khi thêm sản phẩm mới
            UpdateTotalAmount();
        }

        private void InvoiceItem_SoLuongChanged(object sender, EventArgs e)
        {
            // Cập nhật lại tổng tiền khi số lượng thay đổi
            UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            int total = 0;

            // Lặp qua tất cả các InvoiceItem trong pnlInvoiceItem
            foreach (var control in pnlInvoiceItem.Controls)
            {
                if (control is InvoiceItem invoiceItem)
                {
                    total += invoiceItem.ThanhTien();  // Tính tổng tiền từ tất cả các InvoiceItem
                }
            }

            // Cập nhật lblTongtien
            lblTongtien.Text = General.FormatMoney(total);  // Định dạng số theo kiểu tiền tệ
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
            // Thiết lập văn hóa Việt Nam để ngày trong tuần hiển thị tiếng Việt
            var culture = new System.Globalization.CultureInfo("vi-VN");
            DateTime now = DateTime.Now;

            // Cập nhật thời gian dạng
            lblThoiGian.Text = now.ToString("dddd, dd/MM/yyyy - HH:mm", culture);
        }

        private string ghiChu = "", maThe = "";

        private void btnChonSoCho_Click(object sender, EventArgs e)
        {
            frmTheRung frmTheRung = new frmTheRung();
            General.ShowDialogWithBlur(frmTheRung);
            // lấy kết quả từ form dialog
            if (frmTheRung.DialogResult == DialogResult.OK && frmTheRung.SelectedTheRung != null)
            {
                var theDuocChon = frmTheRung.SelectedTheRung;
                lblSoCho.Text = theDuocChon.SoThe;
                maThe = theDuocChon.MaThe;
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            // phát sinh mã đơn hàng
            donhangBUS = new BUS_DonHang();
            lblMaDonHang.Text = donhangBUS.PhatSinhMaDonHang();
            lblSoCho.Text = "";
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (maThe != "" && lblMaDonHang.Text != "" && pnlInvoiceItem.Controls.Count > 0)
            {
                // lấy list từ pnlInvoice Item để tuyền vào frmThanhToan
                List<InvoiceItem> danhSachItem = pnlInvoiceItem.Controls
                .OfType<InvoiceItem>()
                .ToList();
                // tạo đối tượng frmThanhToán
                frmThanhToan frmThanhToan = new frmThanhToan(lblTongtien.Text, lblMaDonHang.Text, maThe, danhSachItem, ghiChu);
                // reset UI, giỏ hàng, panel sản phẩm... nếu thanh toán thành công
                frmThanhToan.ThanhToanThanhCong += (s, ev) =>
                {
                    ClearFormBanHang();
                };
                // hiện frm
                General.ShowDialogWithBlur(frmThanhToan);
            }
        }
        public void ClearFormBanHang()
        {
            pnlInvoiceItem.Controls.Clear();
            lblTongtien.Text = "";
            lblSoCho.Text = "";
            lblMaDonHang.Text = "";
            ghiChu = "";
        }

        private void btnGhiChu_Click(object sender, EventArgs e)
        {
            frmGhiChu frmGhiChu = new frmGhiChu(ghiChu); // Truyền ghi chú hiện tại vào

            DialogResult result = General.ShowDialogWithBlur(frmGhiChu);

            if (result == DialogResult.OK)
            {
                ghiChu = frmGhiChu.GhiChu; // Lấy ghi chú từ frmGhiChu 
            }
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            ClearFormBanHang();
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            frmOrderList frmDonHang = new frmOrderList();
            General.ShowDialogWithBlur(frmDonHang);
        }
    }
}
