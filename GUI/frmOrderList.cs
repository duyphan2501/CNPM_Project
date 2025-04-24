using BUS;
using DAL;
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
        private BUS_DonHang donhang;
        private BUS_ChiTietDonHang ctDonHang;
        private BUS_TaiKhoan taikhoan;
        bool isEditing = false;
        int tongTienGoc = 0;
        string maDonHang = "";
        DataGridViewRow selectedRow;
        public frmOrderList()
        {
            InitializeComponent();
            donhang = new BUS_DonHang();
            ctDonHang = new BUS_ChiTietDonHang();
            taikhoan = new BUS_TaiKhoan();
        }

        private void frmOrderList_Load(object sender, EventArgs e)
        {
            // Load danh sách đơn hàng
            string maCaLam = Program.shift.Rows[0]["MaCaLam"].ToString();
            LoadOrderList(donhang.SelectOrderForCashier(maCaLam));

            // không cho chỉnh sửa 
            gridOrderDetail.Columns["MaSP"].ReadOnly = true;
            gridOrderDetail.Columns["TenSp"].ReadOnly = true;
            gridOrderDetail.Columns["DonGia"].ReadOnly = true;

            // Ẩn panel chi tiết đơn hàng
            pnlOrderDetail.Visible = false;
            EnableEditing(false);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            // ẩn chi tiết đơn hàng
            pnlOrderDetail.Visible = false;
        }

        private void LoadOrderList(DataTable orderList)
        {
            gridOrderList.Rows.Clear();
            BUS_CaLamViec caLamViec = new BUS_CaLamViec();

            // đổ dữ liệu vào gridOrderlist 
            foreach (DataRow row in orderList.Rows)
            {
                string maDon = row["MaDonHang"].ToString();
                string NVLap = caLamViec.GetUserNameOfShift(row["MaCaLap"].ToString());
                string NVThanhToan = caLamViec.GetUserNameOfShift(row["MaCaThanhToan"].ToString());
                string giamGia = row["GiamGia"].ToString();
                string tongTien = General.FormatMoney((int)row["TongTien"]);
                string thanhToanStr = ConvertLoaiThanhToan(Convert.ToInt32(row["LoaiThanhToan"]));
                string trangThaiStr = ConvertTrangThai(Convert.ToInt32(row["TrangThai"]));
                string ngayLap = Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy HH:mm:ss");

                gridOrderList.Rows.Add(maDon, NVLap, NVThanhToan, giamGia, tongTien, thanhToanStr, trangThaiStr, ngayLap);
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
            selectedRow = gridOrderList.SelectedRows[0];
            maDonHang = selectedRow.Cells[0].Value.ToString();
            LoadOrderDetail();
        }

        private void LoadOrderDetail()
        {
            // Lấy thông tin chi tiết đơn hàng
            DataTable ctList = ctDonHang.SelectChiTietByMaDon(maDonHang);
            gridOrderDetail.Rows.Clear();

            // Tính số tiền góc để tính toán lại tổng tiền khi có thay đổi về số lượng sản phẩm hoặc giảm giá
            tongTienGoc = 0;
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
            txtGhiChu.Text = donhang.LayGhiChu(maDonHang);
            pnlOrderDetail.Visible = true;
            CapNhatTongTienVaGiamGia(); // Hiển thị tổng tiền
        }

        private void CapNhatTongTienVaGiamGia()
        {
            // tính tiền góc
            tongTienGoc = 0;
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
            // xoá tất cả chi tiết đơn hàng hiện tại
            ctDonHang.DeleteAllCTDonHang(maDonHang);

            // thêm chi tiết đơn hàng trong gridview
            foreach (DataGridViewRow row in gridOrderDetail.Rows)
            {
                if (row.IsNewRow) continue;

                // lấy thông tin để thêm ctđh
                string maSP = row.Cells["MaSP"].Value?.ToString();
                int donGia = General.FormatMoneyToInt(row.Cells["DonGia"].Value.ToString());
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                // thêm chi tiết đơn hàng
                ctDonHang = new BUS_ChiTietDonHang(maDonHang, maSP, donGia, soLuong);
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
            donhang.UpdateDonHang(maDonHang, giamGia, tongTien, ghiChu);

            // cập nhật lại cả 2 gridview 
            MessageBox.Show("Lưu đơn hàng thành công!");
            LoadOrderDetail();
            UpdateSelectedRow();
        }

        private void UpdateSelectedRow()
        {
            // cập nhật phần liên quan đơn hàng
            selectedRow.Cells["GiamGia"].Value = numGiamGia.Value;
            selectedRow.Cells["TongTien"].Value = lblTongTien.Text;
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
                1 => "Sẵn sàng",
                2 => "Hoàn thành",
                _ => "Không xác định"
            };

    }
}
