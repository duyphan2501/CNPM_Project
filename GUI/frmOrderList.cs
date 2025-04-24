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
            string maCaLam = Program.shift.Rows[0]["MaCaLam"].ToString();
            LoadOrderList(donhang.SelectOrderForCashier(maCaLam));
            gridOrderDetail.Columns["MaSP"].ReadOnly = true;
            gridOrderDetail.Columns["TenSp"].ReadOnly = true;
            gridOrderDetail.Columns["DonGia"].ReadOnly = true;
            pnlOrderDetail.Visible = false;
            EnableEditing(false);
        }

        private void EnableEditing(bool enable)
        {
            numGiamGia.Enabled = enable;
            txtGhiChu.Enabled = enable;
            gridOrderDetail.Columns["SoLuong"].ReadOnly = !enable;
            btnChinhSua.Text = enable ? "Huỷ" : "Chỉnh sửa";
        }

        private void LoadOrderList(DataTable orderList)
        {
            gridOrderList.Rows.Clear();
            BUS_CaLamViec caLamViec = new BUS_CaLamViec();
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
                gridOrderList.ResumeLayout(); // Kích hoạt lại UI
            }
        }

        private string ConvertLoaiThanhToan(int loai)
        {
            return loai == 0 ? "Tiền mặt" :
                   loai == 1 ? "Chuyển khoản" :
                   "Chưa Thanh Toán";
        }

        private string ConvertTrangThai(int trangThai)
        {
            return trangThai switch
            {
                0 => "Đang chế biến",
                1 => "Sẵn sàng",
                2 => "Hoàn thành",
            };
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            pnlOrderDetail.Visible = false;
            EnableEditing(false);
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (gridOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng.");
                return;
            }
            selectedRow = gridOrderList.SelectedRows[0];
            maDonHang = gridOrderList.SelectedRows[0].Cells[0].Value.ToString();
            LoadOrderDetail();
        }

        private void LoadOrderDetail()
        {
            DataTable ctList = ctDonHang.SelectChiTietByMaDon(maDonHang); // Gọi từ BUS

            gridOrderDetail.Rows.Clear();
            int tongTien = 0;
            foreach (DataRow row in ctList.Rows)
            {
                string maSP = row["MaSp"].ToString();
                string tenSP = row["TenSp"].ToString();
                string donGia = General.FormatMoney((int)row["DonGia"]);
                string soLuong = row["SoLuong"].ToString();
                Image img = Properties.Resources.recyclebin;
                gridOrderDetail.Rows.Add(img, maSP, tenSP, donGia, soLuong);
                tongTien += (int)row["DonGia"] * (int)row["SoLuong"];
            }
            lblTongTien.Text = General.FormatMoney(tongTien);
            txtGhiChu.Text = donhang.LayGhiChu(maDonHang);
            pnlOrderDetail.Visible = true;
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            isEditing = !isEditing;
            EnableEditing(isEditing);
            if (!isEditing)
            {
                LoadOrderDetail();
            }
        }

        private void gridOrderDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu chỉnh ở cột "SoLuong"
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                // Bạn có thể xử lý cập nhật lại thành tiền, hoặc validate số lượng
                var cell = gridOrderDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (int.TryParse(cell.Value?.ToString(), out int soLuong))
                {
                    if (soLuong < 1)
                    {
                        MessageBox.Show("Số lượng phải lớn hơn 0.");
                        cell.Value = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số nguyên hợp lệ.");
                    cell.Value = 1;
                }
            }
            CapNhatTongTienVaGiamGia();
        }

        private void gridOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isEditing) return;

            // Nếu click vào cột hình ảnh (giả sử cột 0)
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xoá sản phẩm này khỏi đơn?",
                                              "Xác nhận xoá",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    gridOrderDetail.Rows.RemoveAt(e.RowIndex);
                    CapNhatTongTienVaGiamGia();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int giamGia = (int)numGiamGia.Value;
            string ghiChu = txtGhiChu.Text.Trim();
            // xoá chi tiết đơn hàng cũ 
            ctDonHang.DeleteAllCTDonHang(maDonHang);

            // cập nhật chi tiết đơn hàng mới;
            foreach (DataGridViewRow row in gridOrderDetail.Rows)
            {
                if (row.IsNewRow) continue; // bỏ dòng mới trống

                string maSP = row.Cells["MaSP"].Value?.ToString();
                int donGia = General.FormatMoneyToInt(row.Cells["DonGia"].Value.ToString());
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);

                ctDonHang = new BUS_ChiTietDonHang(maDonHang, maSP, donGia, soLuong);
                int added = ctDonHang.InsertOrderDetail();

                if (added == 0)
                {
                    MessageBox.Show($"Lỗi khi thêm sản phẩm {maSP} vào đơn hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            int tongTien = General.FormatMoneyToInt(lblTongTien.Text);
            donhang.UpdateDonHang(maDonHang, giamGia, tongTien, ghiChu);

            MessageBox.Show("Lưu đơn hàng thành công!");
            LoadOrderDetail();
            UpdateSelectedRow();
        }

        private void UpdateSelectedRow()
        {
            // Cập nhật lại từng cột theo index hoặc tên
            selectedRow.Cells["GiamGia"].Value = numGiamGia.Value;
            selectedRow.Cells["TongTien"].Value = General.FormatMoneyToInt(lblTongTien.Text);
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTongTienVaGiamGia();
        }


        private void CapNhatTongTienVaGiamGia()
        {
            tongTienGoc = 0;

            foreach (DataGridViewRow row in gridOrderDetail.Rows)
            {
                if (row.IsNewRow) continue;

                int donGia = General.FormatMoneyToInt(row.Cells["DonGia"].Value.ToString());
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                tongTienGoc += donGia * soLuong;
            }

            int percent = (int)numGiamGia.Value;
            int tienGiam = (int)(tongTienGoc * percent / 100);
            tienGiam = tienGiam / 1000 * 1000;

            int tongTienSauGiam = tongTienGoc - tienGiam;

            lblTongTien.Text = General.FormatMoney(tongTienSauGiam);
        }

    }
}
