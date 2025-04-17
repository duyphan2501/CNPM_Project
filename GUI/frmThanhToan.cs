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
    public partial class frmThanhToan : Form
    {
        public frmThanhToan()
        {
            InitializeComponent();
        }

        public frmThanhToan(string tongTien)
        {
            InitializeComponent();
            lblTongTien.Text = tongTien;
            lblKhachCanTra.Text = tongTien;
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
                    if (loai == 0)
                    {
                        // Tiền mặt: reset lại các trường tiền mặt
                        txtKhachDua.Text = lblKhachCanTra.Text.Replace("đ", "");
                        lblTienThua.Text = "0đ";
                    }
                    else
                    {
                        // Chuyển khoản: không cần nhập tiền khách đưa, thiết lập lại lblTienThua
                        txtKhachDua.Clear();  // Xóa nội dung txtKhachDua
                        lblTienThua.Text = "0đ";  // Cập nhật lại tiền thừa
                    }
                }
            }
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            // Lấy tổng tiền gốc từ label
            int tongTienGoc = General.FormatMoneyToInt(lblTongTien.Text);

            // Lấy phần trăm giảm giá từ NumericUpDown
            int percent = (int)numGiamGia.Value;

            // Tính số tiền giảm và làm tròn xuống
            int tienGiam = (int)Math.Floor((double)tongTienGoc * percent / 100);

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
                int tienKhachDua = General.FormatMoneyToInt(txtKhachDua.Text); // Parse tiền khách đưa
                lblTienThua.Text = General.FormatMoney(tienKhachDua - tongTienSauGiam); // Hiển thị tiền thừa
            }
        }


        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            int tienKhachDua = General.FormatMoneyToInt(txtKhachDua.Text);
            int tienCanTra = General.FormatMoneyToInt(lblKhachCanTra.Text);
            lblTienThua.Text = General.FormatMoney(tienKhachDua - tienCanTra);
        }

    }
}
