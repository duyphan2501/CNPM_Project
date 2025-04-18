using BUS;
using cnpm;
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
        public frmOrderList()
        {
            InitializeComponent();
            donhang = new BUS_DonHang();
            ctDonHang = new BUS_ChiTietDonHang();
            taikhoan = new BUS_TaiKhoan();
        }

        private void frmOrderList_Load(object sender, EventArgs e)
        {
            LoadOrderList();
            pnlOrderDetail.Visible = false;
        }

        private void LoadOrderList()
        {
            string maCaLam = Program.shift.Rows[0]["MaCaLam"].ToString();
            string tenNhanVien = Program.account.Rows[0]["HoTen"].ToString();

            DataTable orderList = donhang.SelectOrderForCashier(maCaLam);

            gridOrderList.Rows.Clear(); // nếu không dùng DataBinding

            foreach (DataRow row in orderList.Rows)
            {
                string maDon = row["MaDonHang"].ToString();
                string NVLap = tenNhanVien;
                string maCaLap = row["MaCaLam"].ToString();
                string maCaThanhToan = row["MaCaThanhToan"].ToString();

                string NVThanhToan = "";
                if (maCaLap.Equals(MaCaThanhToan))
                {
                    NVThanhToan = NVLap;
                }
                else
                {
                    NVThanhToan = taikhoan.GetUserNameByShiftID(maCaThanhToan);
                }
                string thanhToanStr = ConvertLoaiThanhToan(Convert.ToInt32(row["LoaiThanhToan"]));
                string trangThaiStr = ConvertTrangThai(Convert.ToInt32(row["TrangThai"]));
                string ngayLap = Convert.ToDateTime(row["NgayLap"]).ToString("dd/MM/yyyy HH:mm");

                gridOrderList.Rows.Add(maDon, maCaLap, NVLap, maCaThanhToan, NVThanhToan, thanhToanStr, trangThaiStr, ngayLap);
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
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (gridOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng.");
                return;
            }

            string maDonHang = gridOrderList.SelectedRows[0].Cells[0].Value.ToString(); // Cột đầu tiên là MaDonHang
            DataTable ctList = ctDonHang.SelectChiTietByMaDon(maDonHang); // Gọi từ BUS

            gridOrderDetail.Rows.Clear();

            foreach (DataRow row in ctList.Rows)
            {
                string tenSP = row["TenSp"].ToString();
                string donGia = General.FormatMoney((int)row["DonGia"]);
                string soLuong = row["SoLuong"].ToString();
                Image img = Properties.Resources.recyclebin;
                gridOrderDetail.Rows.Add(img, tenSP, donGia, soLuong);
            }

            pnlOrderDetail.Visible = true;
        }

        bool isEditing = false;

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            isEditing = !isEditing;
            gridOrderDetail.Columns["SoLuong"].ReadOnly = false;
        }

        private void gridOrderDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu chỉnh ở cột "SoLuong"
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
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
                }
            }
        }


    }
}
