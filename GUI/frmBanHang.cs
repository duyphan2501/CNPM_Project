using BUS;
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

            // Nếu không có ca nào, mở form mở ca
            if (Program.shift.Rows.Count == 0)
            {
                frmMoCaLam frmMoCaLam = new frmMoCaLam();
                General.ShowDialogWithBlur(frmMoCaLam);  // Hiển thị form mở ca và đợi người dùng mở ca

                // Sau khi người dùng mở ca, gọi SetUserDetails()
                SetUserDetails();
            }
            else
            {
                // Nếu ca đã mở, chỉ cần gọi SetUserDetails() ngay lập tức
                SetUserDetails();
            }
        }

        private void SetUserDetails()
        {
            if (Program.shift.Rows.Count > 0)
            {
                // Nếu có ca làm việc đang mở, lấy thông tin từ DataTable
                lblMaCaLam.Text = Program.shift.Rows[0]["MaCaLam"].ToString();
            }
            else
            {
                lblMaCaLam.Text = "Chưa mở ca";
            }
            if (Program.account.Rows.Count > 0)
            {
                lblHoTen.Text = Program.account.Rows[0]["HoTen"].ToString();
                lblVaiTro.Text = Program.account.Rows[0]["VaiTro"].ToString();
            }
            else
            {
                // Nếu không có thông tin người dùng, đặt các label về trống
                lblHoTen.Text = "";
                lblVaiTro.Text = "";
            }
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
                // Tạo đối tượng mới và thêm vào panel sản phẩm
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
                // lấy dữ liệu
                byte[] hinhAnh = dr["HinhAnh"] as byte[];
                string tenSp = dr["TenSp"].ToString();
                int giaBan = Convert.ToInt32(dr["GiaBan"]);
                string maLoai = dr["MaLoai"].ToString();
                string maSp = dr["MaSp"].ToString();

                //Tạo một đối tượng Widget mới và thêm vào panel sản phẩm
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
        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            if (IsValidDonHang())
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
            frmOrderList frmDonHang = new frmOrderList("cashier");
            General.ShowDialogWithBlur(frmDonHang);
        }

        private void btnTamLuu_Click(object sender, EventArgs e)
        {
            // xác nhận tạm lưu
            if (General.ShowConfirm("Xác nhận tạm lưu", this) == DialogResult.No)
            {
                return;
            }

            // Kiểm tra trạng thái đơn hàng trước khi lưu
            if (!IsValidDonHang())
            {
                return;
            }
            // Lấy thông tin cần thiết để tạo đơn hàng
            string maDonHang = lblMaDonHang.Text;
            string tenDangNhap = Program.account.Rows[0]["TenDangNhap"].ToString();
            string maCaLam = Program.shift.Rows[0]["MaCaLam"].ToString();
            int tongTien = General.FormatMoneyToInt(lblTongtien.Text);

            // Tạo đối tượng đơn hàng với trạng thái tạm lưu (ThanhToan = 0)
            donhangBUS = new BUS_DonHang(maDonHang, maCaLam, 0, maThe, 0, tongTien, ghiChu);
            int insertedRows = donhangBUS.InsertNewOrder();

            if (insertedRows > 0)
            {
                // Duyệt qua các món trong hóa đơn để thêm chi tiết đơn hàng
                foreach (var item in pnlInvoiceItem.Controls.OfType<InvoiceItem>())
                {
                    // Tạo đối tượng chi tiết đơn hàng
                    BUS_ChiTietDonHang chiTietDonHang = new BUS_ChiTietDonHang(maDonHang, item.MaSanPham, item.DonGia, item.SoLuong);

                    // Lưu chi tiết vào CSDL
                    int isDetailAdded = chiTietDonHang.InsertOrderDetail();
                    if (isDetailAdded == 0)
                    {
                        General.ShowError("Lỗi khi thêm chi tiết đơn hàng", this);
                        return;
                    }
                }

                // Cập nhật trạng thái thẻ rung sang 'đang dùng' 
                BUS_TheRung therung = new BUS_TheRung();
                therung.UpdateStateTheRung(1, maThe);
                ClearFormBanHang();
            }
            else
            {
                // Thông báo lỗi nếu thêm đơn hàng thất bại
                General.ShowError("Lỗi khi thêm đơn hàng", this);
                return;
            }
        }

        private bool IsValidDonHang()
        {
            // Kiểm tra trạng thái đơn hàng
            if (lblMaDonHang.Text.Trim() == "" || lblSoCho.Text.Trim() == "")
            {
                General.ShowWarning("Vui lòng chọn số chờ và mã đơn hàng trước khi thanh toán.", this);
                return false;
            }

            if (pnlInvoiceItem.Controls.Count == 0)
            {
                General.ShowWarning("Giỏ hàng trống. Vui lòng thêm sản phẩm trước khi thanh toán.", this);
                return false;
            }

            return true;
        }

        private void btnTongKetCa_Click(object sender, EventArgs e)
        {
            frmTongKetCa frmTongKetCa = new frmTongKetCa();
            frmTongKetCa.ShiftClosed += (s, ev) => {
                CheckShiftOpening(); // Gọi lại kiểm tra mở ca khi frmTongKetCa báo đã chốt xong
            };
            General.ShowDialogWithBlur(frmTongKetCa);
        }
    }
}
