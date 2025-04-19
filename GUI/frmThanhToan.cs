using GUI.components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace GUI
{
    public partial class frmThanhToan : Form
    {
        private List<InvoiceItem> invoiceItemList;
        private string maDonhang;
        private string maThe;
        private string ghiChu;

        public event EventHandler ThanhToanThanhCong;

        public frmThanhToan()
        {
            InitializeComponent();
        }

        public frmThanhToan(string tongtien, string madon, string mathe, List<InvoiceItem> itemList, string ghichu)
        {
            InitializeComponent();
            lblTongTien.Text = tongtien;
            lblKhachCanTra.Text = tongtien;
            invoiceItemList = itemList;
            maDonhang = madon;
            maThe = mathe;
            ghiChu = ghichu;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            int tienKhachTra = General.FormatMoneyToInt(lblKhachCanTra.Text);
            CreateSmartCashSuggestions(tienKhachTra);
            LoadLoaiThanhToan();
        }

        private void LoadLoaiThanhToan()
        {
            var dsLoaiThanhToan = new Dictionary<int, string>()
            {
                { 0, "Tiền mặt" },
                { 1, "Chuyển khoản" }
            };

            cboLoaiThanhToan.DataSource = new BindingSource(dsLoaiThanhToan, null);
            cboLoaiThanhToan.DisplayMember = "Value";
            cboLoaiThanhToan.ValueMember = "Key";
        }


        private void CreateSmartCashSuggestions(int soTienCanThanhToan)
        {
            pnlTienMat.Controls.Clear();

            List<int> suggestions = new List<int>();

            // 1. Gợi ý đúng số tiền
            suggestions.Add(soTienCanThanhToan);

            // 2. Làm tròn lên các bước nhỏ hơn
            int roundUpTo5000 = ((soTienCanThanhToan + 4999) / 5000) * 5000;
            if (!suggestions.Contains(roundUpTo5000)) suggestions.Add(roundUpTo5000);

            int roundUpTo10000 = ((soTienCanThanhToan + 9999) / 10000) * 10000;
            if (!suggestions.Contains(roundUpTo10000)) suggestions.Add(roundUpTo10000);

            // 3. Thêm mệnh giá lớn hơn thông dụng
            int[] commonCash = { 100000, 200000, 500000 };
            foreach (var money in commonCash)
            {
                if (money > soTienCanThanhToan)
                    suggestions.Add(money);
            }

            // Tạo nút cho từng giá trị
            foreach (int value in suggestions)
            {
                Guna.UI2.WinForms.Guna2Button btn = new Guna.UI2.WinForms.Guna2Button();
                // giao diện
                btn.Text = General.FormatMoney(value);
                btn.Tag = value;
                btn.Width = 100;
                btn.Height = 40;
                btn.Margin = new Padding(5);
                btn.FillColor = Color.FromArgb(33, 150, 243); // Xanh dương (Material Blue)
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
                btn.BorderRadius = 5;
                // thêm sự kiện click
                btn.Click += CashButton_Click;
                // thêm vào pnl
                pnlTienMat.Controls.Add(btn);
            }
        }

        private void CashButton_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = sender as Guna.UI2.WinForms.Guna2Button;
            int tienMat = (int)btn.Tag;

            txtKhachDua.Text = tienMat.ToString("N0"); // format lại
        }

        private void cboLoaiThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiThanhToan.SelectedValue != null)
            {
                int loai;
                if (int.TryParse(cboLoaiThanhToan.SelectedValue.ToString(), out loai))
                {
                    // 0: tiền mặt mới enable pnl
                    pnlTienMat.Enabled = (loai == 0);
                    txtKhachDua.Enabled = (loai == 0);

                    //  reset lại các trường tiền mặt
                    txtKhachDua.Text = "";  // Xóa nội dung txtKhachDua
                    lblTienThua.Text = "0đ";  // Cập nhật lại tiền thừa
                }
            }
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            // Lấy tổng tiền gốc từ label
            int tongTienGoc = General.FormatMoneyToInt(lblTongTien.Text);

            // Lấy phần trăm giảm giá từ NumericUpDown
            int percent = (int)numGiamGia.Value;

            int tienGiam = (int)(tongTienGoc * percent / 100);
            // Làm tròn xuống bậc 1.000
            tienGiam = tienGiam / 1000 * 1000;

            // Tính tổng tiền sau khi giảm
            int tongTienSauGiam = tongTienGoc - tienGiam;

            // Hiển thị số tiền sau khi giảm
            lblKhachCanTra.Text = General.FormatMoney(tongTienSauGiam); // format "100,000"

            // Nếu chọn chuyển khoản thì không thay đổi gì thêm
            if (cboLoaiThanhToan.SelectedValue != null && (int)cboLoaiThanhToan.SelectedValue == 1)
            {
                // Nếu đang chọn chuyển khoản, không cập nhật lại tiền khách đưa và tiền thừa
                txtKhachDua.Clear(); // Xóa nội dung trường nhập tiền khách đưa
                lblTienThua.Text = "0đ"; // Không hiển thị tiền thừa
            }
            else
            {
                // Nếu đang chọn tiền mặt, tính tiền thừa
                if (txtKhachDua.Text != "")
                {
                    // Parse tiền khách đưa
                    int tienKhachDua = General.FormatMoneyToInt(txtKhachDua.Text);
                    // Hiển thị tiền thừa
                    lblTienThua.Text = General.FormatMoney(tienKhachDua - tongTienSauGiam);
                }
            }
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (txtKhachDua.Text != "" && txtKhachDua.Text != ",")
            {
                // cập nhật lại tiền thừa
                int tienKhachDua = General.FormatMoneyToInt(txtKhachDua.Text);
                int tienCanTra = General.FormatMoneyToInt(lblKhachCanTra.Text);
                lblTienThua.Text = General.FormatMoney(tienKhachDua - tienCanTra);
            }
        }

        private void txtKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép: số, dấu phẩy, phím backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // chặn ký tự không hợp lệ
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (cboLoaiThanhToan.SelectedIndex != 1)
            {
                if (txtKhachDua.Text == "")
                {
                    MessageBox.Show("Hãy nhập tiền khách đưa!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int tienKhachDua = General.FormatMoneyToInt(txtKhachDua.Text); // Tiền khách đưa
                int tienCanTra = General.FormatMoneyToInt(lblKhachCanTra.Text);
                // 2. Tính tổng tiền sau khi giảm

                // 3. Kiểm tra xem tiền khách đưa có đủ không
                if (tienKhachDua < tienCanTra)
                {
                    MessageBox.Show("Tiền khách đưa không đủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string tenDangNhap = Program.account.Rows[0]["TenDangNhap"].ToString();
            string maCaLam = Program.shift.Rows[0]["MaCaLam"].ToString();
            int giamGia = (int)numGiamGia.Value;
            int loaiThanhToan = cboLoaiThanhToan.SelectedIndex;

            // Tạo đối tượng đơn hàng
            BUS_DonHang donHang = new BUS_DonHang(maDonhang, tenDangNhap, maCaLam, 0, maThe, ghiChu);
            if (!donHang.isExistedOrder(maDonhang))
            {
                donHang.InsertNewOrder();
                BUS_TheRung therung = new BUS_TheRung();
                therung.UpdateStateTheRung(1, maThe);
            }
            donHang = new BUS_DonHang(maDonhang, tenDangNhap, maCaLam, giamGia, loaiThanhToan);
            int affectedRows = donHang.ThanhToanDonHang();
            if (affectedRows != 0)
            {
                // Thêm chi tiết đơn hàng
                foreach (var item in invoiceItemList)
                {
                    // Tạo chi tiết đơn hàng
                    BUS_ChiTietDonHang chiTietDonHang = new BUS_ChiTietDonHang(maDonhang, item.MaSanPham, item.DonGia, item.SoLuong);
                    // Thêm chi tiết đơn hàng vào cơ sở dữ liệu
                    int isDetailAdded = chiTietDonHang.InsertOrderDetail();
                    if (isDetailAdded == 0)
                    {
                        MessageBox.Show("Lỗi khi thêm chi tiết đơn hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Thông báo thành công
                MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xử lý các bước tiếp theo
                ThanhToanThanhCong?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm đơn hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
