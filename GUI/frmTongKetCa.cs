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

        private void frmTongKetCa_Load(object sender, EventArgs e)
        {
            maCa = Program.shift.Rows[0]["MaCaLam"].ToString();
            int tienDauCa = int.Parse(Program.shift.Rows[0]["TienDauCa"].ToString());

            lblMaCaLam.Text = maCa;
            lblTienDauCa.Text = General.FormatMoney(tienDauCa);

            DataTable donhang = new BUS_DonHang().SelectOrderOfShift(maCa);

            int soHoaDon = donhang.Rows.Count;
            int soDonChuaThanhToan = donhang.AsEnumerable()
                .Count(row => string.IsNullOrEmpty(row.Field<string>("MaCaThanhToan")));
            int soDonDaThanhToan = soHoaDon - soDonChuaThanhToan;

            int tienChuyenKhoan = donhang.AsEnumerable()
                .Where(row => row.Field<byte?>("LoaiThanhToan") == 1)
                .Sum(row => row.Field<int?>("TongTien") ?? 0);

            int tienMat = donhang.AsEnumerable()
                .Where(row => row.Field<byte?>("LoaiThanhToan") == 0)
                .Sum(row => row.Field<int?>("TongTien") ?? 0);

            int doanhThuNet = donhang.AsEnumerable()
                .Sum(row => row.Field<int>("TongTien"));
            int tongGiamGia = donhang.AsEnumerable()
                .Sum(row =>
                {
                    int tongTien = row.Field<int>("TongTien");
                    byte giamGia = row.Field<byte>("GiamGia");
                    return tongTien * giamGia / 100;
                });
            int tongDoanhThu = doanhThuNet - tongGiamGia;


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

        private void btnChotCa_Click(object sender, EventArgs e)
        {
            // Xác nhận có chốt ca không
            DialogResult confirm = Guna.UI2.WinForms.MessageDialog.Show(this, "Bạn có chắc chắn muốn chốt ca?", "Xác nhận", Guna.UI2.WinForms.MessageDialogButtons.YesNo);
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

            int tienThucTe = General.FormatMoneyToInt(txtTienThucTe.Text);
            string ghiChu = txtGhiChu.Text.Trim();

            int affectedRow = new BUS_CaLamViec().ChotCaLamViec(maCa, tienThucTe, ghiChu);

            if (affectedRow > 0)
            {
                Guna.UI2.WinForms.MessageDialog.Show(this, "Chốt ca thành công!", "Thông báo", Guna.UI2.WinForms.MessageDialogButtons.OK);

                ShiftClosed?.Invoke(this, EventArgs.Empty); // gọi event thông báo đã chốt ca

                this.Close();

                Program.shift.Clear(); // clear shift luôn
            }

            else
            {
                Guna.UI2.WinForms.MessageDialog.Show(this, "Có lỗi xảy ra khi chốt ca.", "Lỗi", Guna.UI2.WinForms.MessageDialogButtons.OK);
            }
        }


    }
}
