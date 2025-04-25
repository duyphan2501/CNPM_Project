using BUS;
using DAL;
using GUI.components;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmOrderList : Form
    {
        BUS_DonHang donhang;
        BUS_ChiTietDonHang ctDonHang;
        BUS_TaiKhoan taikhoan;
        BUS_TheRung theRung;

        bool isEditing = false;
        DataGridViewRow viewDetailRow;
        string mode = "";

        int pageSize;
        int currentPage = 1;
        int totalPages;


        public frmOrderList(string mode)
        {
            InitializeComponent();
            donhang = new BUS_DonHang();
            ctDonHang = new BUS_ChiTietDonHang();
            taikhoan = new BUS_TaiKhoan();
            this.mode = mode;
        }

        private void frmOrderList_Load(object sender, EventArgs e)
        {
            // Load danh sách đơn hàng
            string maCaLam = Program.shift.Rows[0]["MaCaLam"].ToString();
            if (mode == "cashier")
            {
                LoadOrderList(donhang.SelectOrderForCashier(maCaLam));
                btnChinhSua.Visible = false;
                btnLuu.Visible = false;
            }
            else
            {
                pageSize = GetPageSizeFromGridView();
                totalPages = (int)Math.Ceiling((double)new BUS_DonHang().GetToTalNumberDonHang() / pageSize);
                LoadDonHangPage(currentPage);
            }

            // không cho chỉnh sửa 
            gridOrderDetail.Columns["MaSP"].ReadOnly = true;
            gridOrderDetail.Columns["TenSp"].ReadOnly = true;
            gridOrderDetail.Columns["DonGia"].ReadOnly = true;

            // Ẩn panel chi tiết đơn hàng
            pnlOrderDetail.Visible = false;
            EnableEditing(false);
            DefaultControlButton();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            // ẩn chi tiết đơn hàng
            pnlOrderDetail.Visible = false;
        }

        private void DefaultControlButton()
        {
            btnViewDetail.Enabled = false;
            btnThanhToan.Enabled = false;
            btnHoanThanh.Enabled = false;
        }

        private void LoadOrderList(DataTable orderList)
        {
            gridOrderList.Rows.Clear();
            BUS_CaLamViec caLamViec = new BUS_CaLamViec();

            // đổ dữ liệu vào gridOrderlist 
            foreach (DataRow row in orderList.Rows)
            {
                BUS_TheRung theRung = new BUS_TheRung();
                string maDon = row["MaDonHang"].ToString();
                string soThe = theRung.LaySoThe(row["MaThe"].ToString());
                string NVLap = caLamViec.GetUserNameOfShift(row["MaCaLap"].ToString());
                string giamGia = row["GiamGia"].ToString();
                string tongTien = General.FormatMoney((int)row["TongTien"]);
                string NVThanhToan = "";
                string thanhToanStr = "";
                // kiểm tra đơn hàng thanh toán chưa
                if (row["LoaiThanhToan"] != DBNull.Value && !string.IsNullOrEmpty(row["LoaiThanhToan"].ToString()))
                {
                    thanhToanStr = ConvertLoaiThanhToan(Convert.ToInt32(row["LoaiThanhToan"]));
                    NVThanhToan = caLamViec.GetUserNameOfShift(row["MaCaThanhToan"].ToString());
                }
                string trangThaiStr = ConvertTrangThai(Convert.ToInt32(row["TrangThai"]));
                string ngayLap = Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy HH:mm:ss");

                // thêm hàng vào gridOrderList
                gridOrderList.Rows.Add(maDon, soThe, NVLap, NVThanhToan, giamGia, tongTien, thanhToanStr, trangThaiStr, ngayLap);
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (gridOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng.");
                return;
            }
            // Lấy mã đơn hàng từ dòng được chọn
            viewDetailRow = gridOrderList.SelectedRows[0];
            LoadOrderDetail();
        }

        private void LoadOrderDetail()
        {
            // Lấy thông tin chi tiết đơn hàng
            string viewDetailMaDonHang = viewDetailRow.Cells["MaDonHang"].Value.ToString();
            DataTable ctList = ctDonHang.SelectChiTietByMaDon(viewDetailMaDonHang);
            gridOrderDetail.Rows.Clear();

            // Tính số tiền góc để tính toán lại tổng tiền khi có thay đổi về số lượng sản phẩm hoặc giảm giá
            int tongTienGoc = 0;
            foreach (DataRow row in ctList.Rows)
            {
                // Load dữ liệu lên gridOrderDetail 
                string maSP = row["MaSp"].ToString();
                string tenSP = row["TenSp"].ToString();
                string donGia = General.FormatMoney((int)row["DonGia"]);
                int soLuong = (int)row["SoLuong"];

                gridOrderDetail.Rows.Add(Properties.Resources.recyclebin, maSP, tenSP, donGia, soLuong);
                tongTienGoc += (int)row["DonGia"] * soLuong;
            }

            // Cập nhật thông tin đơn hàng
            txtGhiChu.Text = donhang.LayGhiChu(viewDetailMaDonHang);
            pnlOrderDetail.Visible = true;
            CapNhatTongTienVaGiamGia(); // Hiển thị tổng tiền
        }

        private void CapNhatTongTienVaGiamGia()
        {
            // tính tiền góc
            int tongTienGoc = 0;
            foreach (DataGridViewRow row in gridOrderDetail.Rows)
            {
                if (row.IsNewRow) continue;

                int donGia = General.FormatMoneyToInt(row.Cells["DonGia"].Value.ToString());
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                tongTienGoc += donGia * soLuong;
            }

            // tính tiền sau giảm giá
            int percent = (int)numGiamGia.Value;
            int tienGiam = (tongTienGoc * percent / 100) / 1000 * 1000; // Làm tròn xuống 1000
            int tongTienSauGiam = tongTienGoc - tienGiam;

            // cập nhật lại tổng tiền
            lblTongTien.Text = General.FormatMoney(tongTienSauGiam);
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            isEditing = !isEditing;
            EnableEditing(isEditing);
            // nếu là huỷ thì load lại grid
            if (!isEditing) LoadOrderDetail();
        }

        private void EnableEditing(bool enable)
        {
            // mở chỉnh sửa giảm giá và ghi chú
            numGiamGia.Enabled = enable;
            txtGhiChu.Enabled = enable;

            // cho phép chỉnh sửa số lượng nếu isEditing == true
            gridOrderDetail.Columns["SoLuong"].ReadOnly = !enable;

            // thay đổi nút tuỳ thuộc vào trạng thái chỉnh sửa
            btnChinhSua.Text = enable ? "Huỷ" : "Chỉnh sửa";
        }

        private void gridOrderDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 4) return; // chỉ cho phép chỉnh sửa cột số lượng

            var cell = gridOrderDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (!int.TryParse(cell.Value?.ToString(), out int soLuong) || soLuong < 1)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương.");
                cell.Value = 1;
            }

            // cập nhật lại tổng tiền
            CapNhatTongTienVaGiamGia();
        }

        private void gridOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // nếu không phải là chế độ chỉnh sửa thì không cho phép xoá
            if (!isEditing || e.RowIndex < 0 || e.ColumnIndex != 0) return;

            if (MessageBox.Show("Bạn có chắc muốn xoá sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // xoá sản phẩm trong grid và cập nhật tổng tiền
                gridOrderDetail.Rows.RemoveAt(e.RowIndex);
                CapNhatTongTienVaGiamGia();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string viewDetailMaDonHang = viewDetailRow.Cells["MaDonHang"].Value.ToString();
            // xoá tất cả chi tiết đơn hàng hiện tại
            ctDonHang.DeleteAllCTDonHang(viewDetailMaDonHang);

            // thêm chi tiết đơn hàng trong gridview
            foreach (DataGridViewRow row in gridOrderDetail.Rows)
            {
                if (row.IsNewRow) continue;

                // lấy thông tin để thêm ctđh
                string maSP = row.Cells["MaSP"].Value?.ToString();
                int donGia = General.FormatMoneyToInt(row.Cells["DonGia"].Value.ToString());
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                // thêm chi tiết đơn hàng
                ctDonHang = new BUS_ChiTietDonHang(viewDetailMaDonHang, maSP, donGia, soLuong);
                if (ctDonHang.InsertOrderDetail() == 0)
                {
                    MessageBox.Show($"Lỗi khi thêm sản phẩm {maSP} vào đơn hàng");
                    return;
                }
            }

            // cập nhật đơn hàng
            int giamGia = (int)numGiamGia.Value;
            string ghiChu = txtGhiChu.Text.Trim();
            int tongTien = General.FormatMoneyToInt(lblTongTien.Text);
            donhang.UpdateDonHang(viewDetailMaDonHang, giamGia, tongTien, ghiChu);

            // cập nhật lại cả 2 gridview 
            MessageBox.Show("Lưu đơn hàng thành công!");
            LoadOrderDetail();
            UpdateviewDetailRow();
        }

        private void UpdateviewDetailRow()
        {
            // cập nhật phần liên quan đơn hàng
            viewDetailRow.Cells["GiamGia"].Value = numGiamGia.Value;
            viewDetailRow.Cells["TongTien"].Value = lblTongTien.Text;
        }
        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTienVaGiamGia();
        }

        private string ConvertLoaiThanhToan(int loai) =>
            loai switch
            {
                0 => "Tiền mặt",
                1 => "Chuyển khoản",
                _ => "Chưa thanh toán"
            };

        private string ConvertTrangThai(int trangThai) =>
            trangThai switch
            {
                0 => "Đang chế biến",
                1 => "Hoàn thành",
                _ => "Không xác định"
            };
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = gridOrderList.SelectedRows[0];

            theRung = new BUS_TheRung();
            string tongTien = selectedRow.Cells["TongTien"].Value.ToString();
            string maDonHang = selectedRow.Cells["MaDonHang"].Value.ToString();
            string soThe = selectedRow.Cells["SoThe"].Value.ToString();
            string maThe = theRung.LayMaThe(soThe);
            string ghiChu = new BUS_DonHang().LayGhiChu(maDonHang);

            // tạo List<InvoiceItem> để truyền vào frmThanhToan 
            List<InvoiceItem> invoiceItem = new List<InvoiceItem>();

            DataTable ctList = ctDonHang.SelectChiTietByMaDon(maDonHang);

            foreach (DataRow row in ctList.Rows)
            {
                string tenSP = row["TenSp"].ToString();
                int donGia = (int)row["DonGia"];
                int soLuong = (int)row["SoLuong"];
                string maSP = row["MaSp"].ToString();
                invoiceItem.Add(new InvoiceItem(tenSP, donGia, soLuong, maSP));
            }

            frmThanhToan frmThanhToan = new frmThanhToan(tongTien, maDonHang, maThe, invoiceItem, ghiChu);

            // cập nhật trạng thái đơn hàng khi thanh toán thành công
            frmThanhToan.ThanhToanThanhCong += (s, ev) =>
            {
                selectedRow.Cells["LoaiThanhToan"].Value = ConvertLoaiThanhToan(donhang.LayLoaiThanhToan(maDonHang));
                selectedRow.Cells["NVThanhToan"].Value = Program.account.Rows[0]["TenDangNhap"].ToString();
            };

            General.ShowDialogWithBlur(frmThanhToan);
        }

        private void gridOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnViewDetail.Enabled = true;

            DataGridViewRow selectedRow = gridOrderList.Rows[e.RowIndex];
            var nvThanhToan = selectedRow.Cells["NVThanhToan"].Value;

            // Nếu chưa thanh toán thì hiển thị nút Thanh Toán
            if (nvThanhToan == null || string.IsNullOrEmpty(nvThanhToan.ToString()))
            {
                btnThanhToan.Enabled = true;
            }
            else
            {
                btnThanhToan.Enabled = false;
            }

            // Nếu đơn chưa hoàn thành thì hiển thị nút hoàn thành món
            string trangThai = selectedRow.Cells["TrangThai"].Value.ToString();
            if (trangThai == "Đang chế biến")
            {
                btnHoanThanh.Enabled = true;
            }
            else
            {
                btnHoanThanh.Enabled = false;
            }
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = gridOrderList.SelectedRows[0];
            theRung = new BUS_TheRung();
            donhang = new BUS_DonHang();

            // Lấy mã đơn hàng từ dòng được chọn
            string maDonHang = selectedRow.Cells["MaDonHang"].Value.ToString();
            string soThe = selectedRow.Cells["SoThe"].Value.ToString();
            string maThe = theRung.LayMaThe(soThe);

            // cập nhật trạng thái đơn hàng
            donhang.UpdateStateDonHang(maDonHang, 1);

            // cập nhật trạng thái đơn hàng trong grid
            selectedRow.Cells["TrangThai"].Value = "Hoàn thành";

            // cập nhật trạng thái thẻ rung
            theRung.UpdateStateTheRung(0, maThe);
        }

        private void GeneratePaginationButtons()
        {
            pnlPagination.Controls.Clear();

            int maxPageButtons = 5;
            int startPage = Math.Max(1, currentPage - 2);
            int endPage = Math.Min(totalPages, startPage + maxPageButtons - 1);

            // Giữ đúng số nút nếu gần cuối danh sách
            if (endPage - startPage + 1 < maxPageButtons)
            {
                startPage = Math.Max(1, endPage - maxPageButtons + 1);
            }

            // Nút "Đầu Trang"
            if (currentPage > 1)
            {
                pnlPagination.Controls.Add(CreateGunaButton("<<", (s, e) =>
                {
                    currentPage = 1;
                    LoadDonHangPage(currentPage);
                }));
            }

            // Nút "Trang trước"
            if (currentPage > 1)
            {
                pnlPagination.Controls.Add(CreateGunaButton("<", (s, e) =>
                {
                    currentPage--;
                    LoadDonHangPage(currentPage);
                }));
            }

            // Các nút số trang
            for (int i = startPage; i <= endPage; i++)
            {
                int selectedPage = i;
                pnlPagination.Controls.Add(CreateGunaButton(i.ToString(), (s, e) =>
                {
                    currentPage = selectedPage;
                    LoadDonHangPage(currentPage);
                }, i == currentPage));
            }

            // Nút "Trang sau"
            if (currentPage < totalPages)
            {
                pnlPagination.Controls.Add(CreateGunaButton(">", (s, e) =>
                {
                    currentPage++;
                    LoadDonHangPage(currentPage);
                }));
            }

            // Nút "Cuối Trang"
            if (currentPage < totalPages)
            {
                pnlPagination.Controls.Add(CreateGunaButton(">>", (s, e) =>
                {
                    currentPage = totalPages;
                    LoadDonHangPage(currentPage);
                }));
            }
        }

        private Guna2Button CreateGunaButton(string text, EventHandler onClick, bool isActive = false)
        {
            int width = 45;

            // Nếu là >> hoặc << thì tăng chiều rộng
            if (text == ">>" || text == "<<") width = 60;

            var btn = new Guna2Button
            {
                Text = text,
                Width = width,
                Height = 32,
                BorderRadius = 6,
                FillColor = isActive ? Color.DodgerBlue : Color.Gainsboro,
                ForeColor = isActive ? Color.White : Color.Black,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Margin = new Padding(4),
                Cursor = Cursors.Hand,
                TextAlign = HorizontalAlignment.Center,
                Padding = new Padding(0)
            };
            btn.Click += onClick;

            return btn;
        }


        private void LoadDonHangPage(int page)
        {
            DataTable dt = new BUS_DonHang().SelectDonHangOnPage(page, pageSize);
            LoadOrderList(dt);
            GeneratePaginationButtons();
        }

        int GetPageSizeFromGridView()
        {
            // Trừ đi độ cao của header để lấy vùng hiển thị cho dòng dữ liệu
            int gridHeight = gridOrderList.ClientSize.Height - gridOrderList.ColumnHeadersHeight;
            int rowHeight = gridOrderList.RowTemplate.Height;

            return Math.Max(1, gridHeight / rowHeight); // Đảm bảo tối thiểu 1 dòng
        }
    }
}
