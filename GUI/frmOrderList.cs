using BUS;
using DAL;
using GUI.components;
using GUI.ReportPrint;
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
            this.mode = mode;
        }

        private void frmOrderList_Load(object sender, EventArgs e)
        {
            if (mode == "cashier")
            {
                string maCaLam = Program.shift.Rows[0]["MaCaLam"].ToString();
                LoadOrderList(donhang.SelectOrderForCashier(maCaLam));
                btnChinhSua.Visible = false;
                btnLuu.Visible = false;
            }
            else
            {
                ctrlboxExit.Visible = false;
                pageSize = GetPageSizeFromGridView();
                totalPages = (int)Math.Ceiling((double)new BUS_DonHang().GetToTalNumberDonHang() / pageSize);
                LoadDonHangPage(currentPage);
                btnHoanThanh.Visible = false;
                btnThanhToan.Visible = false;
                btnDoiThe.Visible = false;
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
            frmOrderList_Load(sender, e);
        }

        private void DefaultControlButton()
        {
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
                General.ShowInformation("Vui lòng chọn một đơn hàng.", this);
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
            numGiamGia.Value = Convert.ToInt32(viewDetailRow.Cells["GiamGia"].Value);
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
            btnLuu.Enabled = enable;
        }

        private void gridOrderDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 4) return; // chỉ cho phép chỉnh sửa cột số lượng

            var cell = gridOrderDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (!int.TryParse(cell.Value?.ToString(), out int soLuong) || soLuong < 1)
            {
                General.ShowInformation("Số lượng phải là số nguyên dương.", this);
                cell.Value = 1;
            }

            // cập nhật lại tổng tiền
            CapNhatTongTienVaGiamGia();
        }

        // click vào icon xoá
        private void gridOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // nếu không phải là chế độ chỉnh sửa thì không cho phép xoá
            if (!isEditing || e.RowIndex < 0 || e.ColumnIndex != 0) return;

            if (General.ShowConfirm("Bạn có chắc muốn xoá sản phẩm này?", this) == DialogResult.Yes)
            {
                // xoá sản phẩm trong grid và cập nhật tổng tiền
                gridOrderDetail.Rows.RemoveAt(e.RowIndex);
                CapNhatTongTienVaGiamGia();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string viewDetailMaDonHang = viewDetailRow.Cells["MaDonHang"].Value.ToString();

            // Xoá toàn bộ chi tiết đơn hàng cũ
            ctDonHang.DeleteAllCTDonHang(viewDetailMaDonHang);

            // Thêm lại chi tiết đơn hàng mới từ grid
            foreach (DataGridViewRow row in gridOrderDetail.Rows)
            {
                if (row.IsNewRow) continue;

                string maSP = row.Cells["MaSP"].Value?.ToString();
                int donGia = General.FormatMoneyToInt(row.Cells["DonGia"].Value.ToString());
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                ctDonHang = new BUS_ChiTietDonHang(viewDetailMaDonHang, maSP, donGia, soLuong);
                if (ctDonHang.InsertOrderDetail() == 0)
                {
                    General.ShowError($"Lỗi khi thêm sản phẩm {maSP} vào đơn hàng", this);
                    return;
                }
            }

            // Cập nhật thông tin đơn hàng
            int giamGia = (int)numGiamGia.Value;
            string ghiChu = txtGhiChu.Text.Trim();
            int tongTien = General.FormatMoneyToInt(lblTongTien.Text);
            donhang.UpdateDonHang(viewDetailMaDonHang, giamGia, tongTien, ghiChu);

            // Tính lại nguyên liệu đã xuất (cũ)
            Dictionary<string, decimal> oldRecipe = new BUS_PhieuXuatKho().GetRecipeFromPhieuXuat(viewDetailMaDonHang);

            // Tính nguyên liệu cần xuất mới theo sản phẩm trong đơn
            Dictionary<string, decimal> newRecipe = new Dictionary<string, decimal>();
            foreach (DataGridViewRow row in gridOrderDetail.Rows)
            {
                if (row.IsNewRow) continue;

                string maSP = row.Cells["MaSP"].Value.ToString();
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                // Lấy định lượng của sản phẩm
                DataTable recipe = new BUS_DinhLuong().SelectRecipeOfProduct(maSP);
                foreach (DataRow r in recipe.Rows)
                {
                    string maNL = r["MaNL"].ToString();
                    decimal soLuongCan = Convert.ToDecimal(r["SoLuong"]);
                    decimal tongSoLuong = soLuongCan * soLuong;

                    if (newRecipe.ContainsKey(maNL))
                        newRecipe[maNL] += tongSoLuong;
                    else
                        newRecipe.Add(maNL, tongSoLuong);
                }
            }

            // So sánh nguyên liệu mới và cũ
            List<(string maNL, decimal soLuong)> listXuatThem = new List<(string, decimal)>();
            List<(string maNL, decimal soLuong)> listNhapLai = new List<(string, decimal)>();

            foreach (var kvp in newRecipe)
            {
                string maNL = kvp.Key;
                decimal soLuongMoi = kvp.Value;

                decimal soLuongCu = oldRecipe.ContainsKey(maNL) ? oldRecipe[maNL] : 0;
                decimal chenhlech = soLuongMoi - soLuongCu;

                if (chenhlech > 0)
                    listXuatThem.Add((maNL, chenhlech));
                else if (chenhlech < 0)
                    listNhapLai.Add((maNL, -chenhlech));
            }

            // Xử lý xuất thêm nếu có
            if (listXuatThem.Count > 0)
            {
                BUS_PhieuXuatKho phieuXuat = new BUS_PhieuXuatKho();
                string maPhieuXuatMoi = phieuXuat.GenerateID();

                phieuXuat.AddDeliveryReceip(maPhieuXuatMoi, Program.account.Rows[0]["TenDangNhap"].ToString(), DateTime.Now, "Điều chỉnh đơn hàng " + viewDetailMaDonHang);

                BUS_ChiTietXuatKho chiTietXuat = new BUS_ChiTietXuatKho();
                foreach (var item in listXuatThem)
                {
                    chiTietXuat.AddExportDetail(maPhieuXuatMoi, item.maNL, item.soLuong);
                }
            }

            // Xử lý nhập lại nếu có
            if (listNhapLai.Count > 0)
            {
                BUS_PhieuNhapKho phieuNhap = new BUS_PhieuNhapKho();
                string maPhieuNhapMoi = phieuNhap.GenerateID();

                phieuNhap.AddGoodsReceipt(maPhieuNhapMoi, Program.account.Rows[0]["TenDangNhap"].ToString(), DateTime.Now, "Điều chỉnh đơn hàng " + viewDetailMaDonHang);

                BUS_ChiTietNhapKho chiTietNhap = new BUS_ChiTietNhapKho();
                foreach (var item in listNhapLai)
                {
                    int giaNhap = new BUS_NguyenLieu().GetGiaNhap(item.maNL);
                    chiTietNhap.AddEntryDetail(maPhieuNhapMoi, item.maNL, giaNhap, item.soLuong);
                }
            }

            // cập nhật lại cả 2 gridview 
            General.ShowInformation("Cập nhật đơn hàng thành công!", this);
            EnableEditing(false);
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

        private void LoadDonHangPage(int page)
        {
            DataTable dt = new BUS_DonHang().SelectDonHangOnPage(page, pageSize);
            LoadOrderList(dt);
            // gọi hàm phân trang
            PaginationHelper.GeneratePaginationButtons(
            pnlPagination,
            currentPage,
            totalPages,
            (page) =>
            {
                currentPage = page;
                LoadDonHangPage(currentPage);
            });
        }

        int GetPageSizeFromGridView()
        {
            // Trừ đi độ cao của header để lấy vùng hiển thị cho dòng dữ liệu
            int gridHeight = gridOrderList.ClientSize.Height - gridOrderList.ColumnHeadersHeight;
            int rowHeight = gridOrderList.RowTemplate.Height;

            return Math.Max(1, gridHeight / rowHeight); // Đảm bảo tối thiểu 1 dòng
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (gridOrderList.SelectedRows.Count == 0)
            {
                General.ShowInformation("Vui lòng chọn một đơn hàng.", this);
                return;
            }
            DataGridViewRow selectedRow = gridOrderList.SelectedRows[0];
            string maHoaDon = selectedRow.Cells["MaDonHang"].Value.ToString();

            // Gọi hàm từ tầng DAL để lấy dữ liệu
            DataTable dt = new BUS_DonHang().SelectHoaDon(maHoaDon);

            ReportHelper.PreviewReport("Invoice.rdlc", dt);
        }

        private void btnInPhieuBep_Click(object sender, EventArgs e)
        {
            if (gridOrderList.SelectedRows.Count == 0)
            {
                General.ShowInformation("Vui lòng chọn một đơn hàng.", this);
                return;
            }
            DataGridViewRow selectedRow = gridOrderList.SelectedRows[0];
            string maHoaDon = selectedRow.Cells["MaDonHang"].Value.ToString();

            // Gọi hàm từ tầng DAL để lấy dữ liệu
            DataTable dt = new BUS_DonHang().SelectHoaDon(maHoaDon);

            ReportHelper.PreviewReport("PhieuBep.rdlc", dt);

        }

        private void btnDoiThe_Click(object sender, EventArgs e)
        {
            if (gridOrderList.SelectedRows.Count == 0)
            {
                General.ShowInformation("Vui lòng chọn một đơn hàng.", this);
                return;
            }

            DataGridViewRow selectedRow = gridOrderList.SelectedRows[0];
            string maDonHang = selectedRow.Cells["MaDonHang"].Value.ToString();
            frmTheRung frmTheRung = new frmTheRung();
            General.ShowDialogWithBlur(frmTheRung);

            // lấy mã thẻ hiện tại
            theRung = new BUS_TheRung();
            string sotheHienTai = selectedRow.Cells["SoThe"].Value.ToString();
            string matheHienTai = theRung.LayMaThe(sotheHienTai);

            // lấy kết quả từ form dialog
            if (frmTheRung.DialogResult == DialogResult.OK && frmTheRung.SelectedTheRung != null)
            {
                var theDuocChon = frmTheRung.SelectedTheRung;
                // cập nhật lại gridview
                selectedRow.Cells["SoThe"].Value = theDuocChon.SoThe;

                // cập nhật lại thông tin donhang
                string maThe = theDuocChon.MaThe;
                if (donhang.UpdateMaTheDonHang(maDonHang, maThe) <= 0)
                {
                    General.ShowError("Đổi thẻ không thành công", this);
                }
                else
                {
                    // cập nhật lại thẻ hiện tại
                    theRung.UpdateStateTheRung(0, matheHienTai);

                    // cập nhật lại trạng thái thẻ rung
                    theRung.UpdateStateTheRung(1, maThe);
                }
            }
        }
    }
}
