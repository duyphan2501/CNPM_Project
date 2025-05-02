using BUS;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTongKetCa : Form
    {
        
        string maCa;
        int tienCuoiCa = 0; // lưu tiền cuối ca để xử lý dễ hơn
        public event EventHandler ShiftClosed;
        public frmTongKetCa()
        {
            InitializeComponent();
        }

        public frmTongKetCa(string maCaLam, bool isCashier)
        {
            InitializeComponent();
            maCa = maCaLam;
            // Đăng nhập từ admin
            if (!isCashier)
            {
                // tắt các control
                btnChotCa.Visible = false;
                txtGhiChu.Enabled = false;
                txtTienThucTe.Enabled = false;

                // gán thông tin ca làm
                DataTable informationShift = new BUS_CaLamViec().GetInformationShift(maCa);
                txtTienThucTe.Text = informationShift.Rows[0]["TienCuoiCa"].ToString();
                txtGhiChu.Text = informationShift.Rows[0]["GhiChu"].ToString();
            }
            else // từ thu ngân
            {
                maCa = Program.shift.Rows[0]["MaCaLam"].ToString();
            }
        }

        private void frmTongKetCa_Load(object sender, EventArgs e)
        {
            int tienDauCa = new BUS_CaLamViec().GetTienDauCa(maCa);
            lblMaCaLam.Text = maCa;
            lblTienDauCa.Text = General.FormatMoney(tienDauCa);
            
            // Lấy số hoá đơn đã xử lí trong ca
            DataTable donhang = new BUS_DonHang().SelectOrderOfShift(maCa);

            // đếm hàng để lấy số hđ
            int soHoaDon = donhang.Rows.Count;

            // MaCaThanhToan là null -> chưua thanh toán
            int soDonChuaThanhToan = donhang.AsEnumerable()
                .Count(row => string.IsNullOrEmpty(row.Field<string>("MaCaThanhToan")));
            int soDonDaThanhToan = soHoaDon - soDonChuaThanhToan;

            // loaiThanhToan = 1 -> chuyển khoản
            int tienChuyenKhoan = donhang.AsEnumerable()
                .Where(row => row.Field<byte?>("LoaiThanhToan") == 1)
                .Sum(row => row.Field<int?>("TongTien") ?? 0);

            // loaiThanhToan = 0 -> tiền mặt
            int tienMat = donhang.AsEnumerable()
                .Where(row => row.Field<byte?>("LoaiThanhToan") == 0)
                .Sum(row => row.Field<int?>("TongTien") ?? 0);

            // tongtien đã là tiền sau giảm giá
            int tongGiamGia = donhang.AsEnumerable()
            .Sum(row =>
            {
                int tongTien = row.Field<int>("TongTien");
                byte giamGia = row.Field<byte>("GiamGia");
                if (giamGia == 0) return 0;

                // Tính tiền gốc rồi suy ra số tiền giảm
                double tongTienTruocGiam = tongTien / (1 - giamGia / 100.0);
                return (int)Math.Round(tongTienTruocGiam - tongTien);
            });

            int doanhThuNet = donhang.AsEnumerable()
                .Sum(row => row.Field<int>("TongTien"));

            int tongDoanhThu = doanhThuNet + tongGiamGia;

            // Gán vào label
            lblSoHoaDon.Text = soHoaDon.ToString();
            lblDaThanhToan.Text = soDonDaThanhToan.ToString();
            lblChuaThanhToan.Text = soDonChuaThanhToan.ToString();

            lblTienMat.Text = General.FormatMoney(tienMat);
            lblChuyenKhoan.Text = General.FormatMoney(tienChuyenKhoan);

            lblTongDoanhThu.Text = General.FormatMoney(tongDoanhThu);
            lblTongGiamGia.Text = General.FormatMoney(tongGiamGia);
            lblDoanhThuNet.Text = General.FormatMoney(doanhThuNet);

            // Tính tiền trong ca (không tính tiền đầu ca)
            lblTienTrongCa.Text = General.FormatMoney(tienMat);

            // Tính tiền cuối ca (có cộng tiền đầu ca)
            tienCuoiCa = tienMat + tienDauCa;
            lblTienCuoiCa.Text = General.FormatMoney(tienCuoiCa);
        }

        private void txtTienThucTe_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtTienThucTe.Text.Replace(",", ""), out int tienThucTe))
            {
                int chenhlech = tienThucTe - tienCuoiCa;
                lblChenhLech.Text = General.FormatMoney(chenhlech);
            }
            else
            {
                lblChenhLech.Text = "0";
            }
        }

        private void txtTienDauCa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }

            // Kiểm tra giá trị sau khi người dùng nhập một ký tự mới
            string currentText = txtTienThucTe.Text + e.KeyChar;
            if (long.TryParse(currentText, out long result))
            {
                if (result > 100000000) // Giới hạn giá trị 
                {
                    e.Handled = true; // Không cho phép nhập khi vượt quá giới hạn
                    General.ShowError("Số tiền vượt quá giới hạn. Vui lòng nhập lại!", this);
                }
            }
        }

        private void btnChotCa_Click(object sender, EventArgs e)
        {
            // Xác nhận có chốt ca không
            DialogResult confirm = General.ShowConfirm("Bạn có chắc chắn muốn chốt ca?",this);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            int chenhlech = General.FormatMoneyToInt(lblChenhLech.Text);

            // Nếu có chênh lệch thì cảnh báo và bắt nhập ghi chú
            if (chenhlech != 0)
            {
                Guna.UI2.WinForms.MessageDialog.Show(this, $"Chênh lệch số tiền: {General.FormatMoney(chenhlech)}", "Cảnh báo", Guna.UI2.WinForms.MessageDialogButtons.OK);

                if (string.IsNullOrEmpty(txtGhiChu.Text))
                {
                    Guna.UI2.WinForms.MessageDialog.Show(this, "Vui lòng nhập ghi chú lý do chênh lệch!", "Thông báo", Guna.UI2.WinForms.MessageDialogButtons.OK);
                    txtGhiChu.Focus();
                    return;
                }
            }

            // Kiểm tra xem người dùng đã nhập tiền thực tế chưa
            if (string.IsNullOrEmpty(txtTienThucTe.Text))
            {
                Guna.UI2.WinForms.MessageDialog.Show(this, "Vui lòng nhập số tiền thực tế!", "Thông báo", Guna.UI2.WinForms.MessageDialogButtons.OK);
                txtTienThucTe.Focus();
                return;
            }

            // Kiểm tra tính hợp lệ của số tiền thực tế (có thể sử dụng FormatMoneyToInt nếu cần)
            int tienThucTe = General.FormatMoneyToInt(txtTienThucTe.Text);

            // Nếu số tiền thực tế không hợp lệ
            if (tienThucTe < 0)
            {
                Guna.UI2.WinForms.MessageDialog.Show(this, "Số tiền thực tế không hợp lệ!", "Thông báo", Guna.UI2.WinForms.MessageDialogButtons.OK);
                txtTienThucTe.Focus();
                return;
            }

            string ghiChu = txtGhiChu.Text.Trim();

            // Gọi hàm chốt ca
            int affectedRow = new BUS_CaLamViec().ChotCaLamViec(maCa, tienThucTe, ghiChu);

            if (affectedRow > 0)
            {
                Guna.UI2.WinForms.MessageDialog.Show(this, "Chốt ca thành công!", "Thông báo", Guna.UI2.WinForms.MessageDialogButtons.OK);
                Program.shift.Clear(); // Xóa thông tin ca làm việc

                // Gọi event thông báo đã chốt ca
                ShiftClosed?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
            else
            {
                Guna.UI2.WinForms.MessageDialog.Show(this, "Có lỗi xảy ra khi chốt ca.", "Lỗi", Guna.UI2.WinForms.MessageDialogButtons.OK);
            }
        }
    }
}
